using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CMath.PolynomialEquation;
using System.Numerics;


namespace CMath.Trie
{
    #region TypeDefinitions
    using Node = TreeNode<KeyValuePair<int, Complex>>;
    using Trie = Trie<KeyValuePair<int, Complex>>;
    #endregion

    public class TreeNode<T>
    {
        #region Properties
        public Dictionary<T, TreeNode<T>> _children;
        public Dictionary<Char, dynamic> _special;
        public bool isEnd;
        #endregion
        #region constructor
        public TreeNode()
        {
            isEnd = false;
            _children = new Dictionary<T, TreeNode<T>>();
            _special = new Dictionary<Char, dynamic>();
        }
        #endregion
        #region functions
        public void insert(T value, TreeNode<T> child)
        {
            _children.Add(value, child);
        }
        TreeNode<T> get_child(T value)
        {
            if (_children.ContainsKey(value))
            {
                return _children[value];
            }
            else
            {
                throw new KeyNotFoundException("There is no such child");
            }
        }
        public bool try_get_child(T value, out TreeNode<T> result)
        {
            try
            {
                result = get_child(value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        #endregion
    }
    public class Trie<T> : IDisposable
    {
        #region Constructor&Properties
        public TreeNode<T> root;
        public Trie()
        {
            root = new TreeNode<T>();
        }
        public void Dispose()
        {
            GC.Collect();
        }
        public Trie(TreeNode<T> _root)
        {
            root = _root;
        }
        public bool isEmpty()
        {
            return root._children.Count == 0;
        }
        #endregion
        #region insert&search
        public TreeNode<T> insert(List<T> value)
        {
            if (value.Count == 0)
                throw new ArgumentOutOfRangeException("List cannot be empty;");

            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T> next;
                if (!current.try_get_child(value[i], out next))
                {
                    next = new TreeNode<T>();
                    current.insert(value[i], next);
                }
                current = next;
            }
            current.isEnd = true;
            return current;
        }
        TreeNode<T> get_node(List<T> value)
        {
            if (value.Count == 0)
                throw new ArgumentOutOfRangeException("List cannot be empty;");

            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T> next;
                if (!current.try_get_child(value[i], out next))
                {
                    throw new KeyNotFoundException("There is no such list in the trie;");
                }
                current = next;
            }
            if (!current.isEnd)
            {
                throw new KeyNotFoundException("There is no such list in the trie;");
            }
            return current;
        }
        public bool try_get_node(List<T> value, out TreeNode<T> result)
        {
            try
            {
                result = get_node(value);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        #endregion
        #region remove&clear
        void remove(List<T> value)
        {
            if (value.Count == 0)
                throw new ArgumentOutOfRangeException("List cannot be empty;");

            var dfs = new Stack<TreeNode<T>>();
            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T> next;
                if (!current.try_get_child(value[i], out next))
                {
                    throw new KeyNotFoundException("There is no such list in the trie;");
                }
                current = next;
                dfs.Push(current);
            }
            if (!current.isEnd)
            {
                throw new KeyNotFoundException("There is no such list in the trie;");
            }
            current.isEnd = false;
            current._special.Clear();
            int last = value.Count;
            while (dfs.Count != 0)
            {
                current = dfs.Pop();
                if (last < value.Count)
                {
                    current._children.Remove(value[last]);
                }
                if (last == 0)
                {
                    break;
                }
                if (current._children.Count == 0 && current._special.Count == 0)
                {
                    current = null;
                    last--;
                }
                else
                {
                    break;
                }
            }
        }
        public bool try_remove(List<T> value)
        {
            try
            {
                remove(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void clear()
        {
            var bfs = new Queue<TreeNode<T>>();
            bfs.Enqueue(root);
            TreeNode<T> current;
            while (bfs.Count != 0)
            {
                current = bfs.Dequeue();
                foreach (var item in current._children)
                {
                    bfs.Enqueue(item.Value);
                }
                current = null;
            }
            root = new TreeNode<T>();
        }
        #endregion
    }
    public class PolynomialTrie : IDisposable
    {
        #region Constructor&Properties
        Trie main;
        public void Dispose()
        {
            main.clear();
            main.Dispose();
            GC.Collect();
        }
        public PolynomialTrie()
        {
            main = new Trie();
        }
        public PolynomialTrie(string FileName)
        {
            XDocument xDoc = XDocument.Load(FileName);
            main = new Trie(dfs((XElement)xDoc.FirstNode));
        }
        #endregion
        #region insert&search&save
        public void save(string FileName)
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xDoc.Add(dfs(main.root));
            xDoc.Save(FileName);
        }
        public void insert(Polynomial equation,Char operation, dynamic storage)
        {
            try
            {
                var lastFirst = main.insert(equation._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, storage);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void insert(Polynomial first, Char operation, Polynomial second, Polynomial result)
        {
            try
            {
                var lastFirst = main.insert(first._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, new Trie());
                }
                var lastSecond = lastFirst._special[operation].insert(second._data.ToList());
                if (lastSecond._special.ContainsKey('='))
                {
                    throw new ArgumentException("Operation is already stored");
                }
                lastSecond._special.Add('=', result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        dynamic search(Polynomial equation, Char operation)
        {
            Node last;
            if (!main.try_get_node(equation._data.ToList(), out last))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!last._special.ContainsKey(operation))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            return last._special[operation];
        }
        Polynomial search(Polynomial first, char operation, Polynomial second)
        {
            Node lastFirst;
            if (!main.try_get_node(first._data.ToList(), out lastFirst))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastFirst._special.ContainsKey(operation))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            Node lastSecond;
            if (!lastFirst._special[operation].try_get_node(second._data.ToList(), out lastSecond))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastSecond._special.ContainsKey('='))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            return lastSecond._special['='];
        }
        public bool try_search(Polynomial first, char operation, Polynomial second, out Polynomial result)
        {
            try
            {
                result = search(first, operation, second);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public bool try_search(Polynomial equation,char operation, out object result)
        {
            try
            {
                result = search(equation, operation);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        #endregion
        #region remove&clear
        public bool try_remove(Polynomial first)
        {
            return main.try_remove(first._data.ToList());
        }
        void remove(Polynomial first, Char operation)
        {
            Node lastFirst;
            if (main.try_get_node(first._data.ToList(), out lastFirst))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            lastFirst._special.Remove(operation);
            if (lastFirst._special.Count == 0)
            {
                try_remove(first);
            }
        }
        void remove(Polynomial first, Char operation, Polynomial second)
        {
            Node lastFirst;
            if (main.try_get_node(first._data.ToList(), out lastFirst))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            if (!lastFirst._special.ContainsKey(operation))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            if (!lastFirst._special[operation].try_remove(second._data.ToList()))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            if (lastFirst._special[operation].isEmpty())
            {
                lastFirst._special.Remove(operation);
                if (lastFirst._special.Count == 0)
                {
                    try_remove(first);
                }
            }
        }
        public bool try_remove(Polynomial first, Char operation, Polynomial second)
        {
            try
            {
                remove(first, operation, second);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region dfs
        Node dfs(XElement current)
        {
            Node result = new Node();
            result.isEnd = current.Element("isEnd").Value == "True";
            foreach (var edge in current.Elements("Node"))
            {
                int degree = int.Parse(edge.Element("Edge").Element("Degree").Value);
                double real = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Real").Value);
                double imaginary = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Imaginary").Value);
                result._children.Add(new KeyValuePair<int, Complex>(degree, new Complex(real, imaginary)), dfs(edge));
            }
            if (result.isEnd)
            {
                foreach (var edge in current.Elements("Tree"))
                {
                    char Edge = edge.Element("Edge").Value[0];
                    result._special.Add(Edge, new Trie(dfsSecond(edge)));
                }
                foreach (var edge in current.Elements("SolutionSet"))
                {
                    char Edge = edge.Element("Edge").Value[0];
                    List<Complex> solutions = new List<Complex>();
                    foreach (var solution in edge.Elements("Solution"))
                    {
                        solutions.Add(new Complex(double.Parse(solution.Element("Real").Value),
                            double.Parse(solution.Element("Imaginary").Value)));
                    }
                    result._special.Add(Edge, solutions);
                }
                foreach (var edge in current.Elements("Derivatives"))
                {
                    char Edge = edge.Element("Edge").Value[0];
                    SortedList<int, Polynomial> derivatives = new SortedList<int,Polynomial>();
                    foreach (var detivative in edge.Elements("Derivative"))
                    {
                        derivatives.Add(int.Parse(detivative.Element("level").Value),
                            new Polynomial(detivative.Element("result").Value));
                    }
                    result._special.Add(Edge, derivatives);
                }
            }
            return result;
        }
        Node dfsSecond(XElement current)
        {
            Node result = new Node();
            result.isEnd = current.Element("isEnd").Value == "True";
            foreach (var edge in current.Elements("Node"))
            {
                int degree = int.Parse(edge.Element("Edge").Element("Degree").Value);
                double real = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Real").Value);
                double imaginary = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Imaginary").Value);
                result._children.Add(new KeyValuePair<int, Complex>(degree, new Complex(real, imaginary)), dfsSecond(edge));
            }
            if (result.isEnd)
            {
                result._special.Add('=', new Polynomial(current.Element("Result").Value));
            }
            return result;
        }
        XElement dfs(Node node)
        {
            XElement result = new XElement("Node");
            result.Add(new XElement("isEnd", node.isEnd.ToString()));
            foreach (var edge in node._children)
            {
                var newChild = dfs(edge.Value);
                newChild.Add(new XElement("Edge",
                    new XElement("Degree", edge.Key.Key.ToString()),
                    new XElement("Coefficient",
                        new XElement("Real", edge.Key.Value.Real),
                        new XElement("Imaginary", edge.Key.Value.Imaginary))));
                result.Add(newChild);
            }
            if (node.isEnd)
            {
                foreach (var special in node._special)
                {
                    XElement newChild;
                    if (special.Key == '=')
                    {
                        newChild = new XElement("SolutionSet");
                        foreach (var solution in special.Value)
                        {
                            newChild.Add(new XElement("Solution",
                                new XElement("Real", solution.Real),
                                new XElement("Imaginary", solution.Imaginary)));
                        }
                    }
                    else if (special.Key == '^')
                    {
                        newChild = new XElement("Derivatives");
                        foreach(var detivative in special.Value)
                        {
                            newChild.Add(new XElement("Derivative",
                                new XElement("level", detivative.Key.ToString()),
                                new XElement("result", detivative.Value.ToString())));
                        }
                    }
                    else
                    {
                        newChild = dfsSecond(special.Value.root);
                        newChild.Name = "Tree";
                    }
                    newChild.Add(new XElement("Edge", special.Key.ToString()));
                    result.Add(newChild);
                }
            }
            return result;
        }
        XElement dfsSecond(Node node)
        {
            XElement result = new XElement("Node");
            result.Add(new XElement("isEnd", node.isEnd.ToString()));
            foreach (var edge in node._children)
            {
                var newChild = dfsSecond(edge.Value);
                newChild.Add(new XElement("Edge",
                    new XElement("Degree", edge.Key.Key.ToString()),
                    new XElement("Coefficient",
                        new XElement("Real", edge.Key.Value.Real),
                        new XElement("Imaginary", edge.Key.Value.Imaginary))));
                result.Add(newChild);
            }
            if (node.isEnd) result.Add(new XElement("Result", node._special['='].ToString()));
            return result;
        }
        #endregion
    }
}
