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

    #region utils
    class ListComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> obj)
        {
            int hashcode = 0;
            foreach (T t in obj)
            {
                hashcode ^= t.GetHashCode();
            }
            return hashcode;
        }
    }
    #endregion
    public class TreeNode<T>
    {
        #region Properties
        public Dictionary<T, TreeNode<T>> _children;
        public Dictionary<Char, Object> _special;
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
        public void insert(Polynomial equation, char operation, List<Complex> X, Complex result)
        {
            try
            {
                var lastFirst = main.insert(equation._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, new Dictionary<List<Complex>, Complex>(new ListComparer<Complex>()));
                }
                var toInsertIn = lastFirst._special[operation] as Dictionary<List<Complex>, Complex>;
                toInsertIn.Add(X, result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void insert(Polynomial equation,Char operation, Object toBeStored)
        {
            try
            {
                var lastFirst = main.insert(equation._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, toBeStored);
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
                var secondTrie = lastFirst._special[operation] as Trie;
                var lastSecond = secondTrie.insert(second._data.ToList());
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
        Object search(Polynomial equation, Char operation)
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
        Complex search(Polynomial equation, Char operation, List<Complex> X)
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
            var specialDict = last._special[operation] as Dictionary<List<Complex>, Complex>;
            if (!specialDict.ContainsKey(X))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            return specialDict[X];
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
            if (!(lastFirst._special[operation] as Trie).try_get_node(second._data.ToList(), out lastSecond))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastSecond._special.ContainsKey('='))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            return (lastSecond._special['='] as Polynomial);
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
        public bool try_search(Polynomial equation,char operation, out Object result)
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
        public bool try_search(Polynomial equation, Char Operation, List<Complex> X, out Complex result)
        {
            try
            {
                result = search(equation, Operation, X);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
        #endregion
        #region remove&clear
        public bool try_remove(Polynomial first)
        {
            return main.try_remove(first._data.ToList());
        }
        public bool try_remove(Polynomial first, char operation)
        {
            try
            {
                remove(first, operation);
                return true;
            }
            catch
            {
                return false;
            }
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
            var secondTrie = lastFirst._special[operation] as Trie;
            if (!secondTrie.try_remove(second._data.ToList()))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            if ((lastFirst._special[operation] as Trie).isEmpty())
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
        Node dfs(XElement Xroot)
        {
            Node root = new Node();
            Stack<List<Object>> dfsStack = new Stack<List<Object>>();
            dfsStack.Push(new List<Object>());
            dfsStack.Peek().Add(root);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(Xroot);
            while (dfsStack.Count != 0)
            {
                var temporaryList = dfsStack.Pop();
                Node currentNode = temporaryList[0] as Node;
                Node parentNode = temporaryList[1] as Node;
                XElement currentXNode = temporaryList[3] as XElement;
                currentNode.isEnd = currentXNode.Element("isEnd").Value == "True";
                if (parentNode != null)
                {
                    KeyValuePair<int, Complex> Edge = (KeyValuePair<int, Complex>)temporaryList[2];
                    parentNode._children.Add(Edge, currentNode);
                }
                foreach (var edge in currentXNode.Elements("Node"))
                {
                    int degree = int.Parse(edge.Element("Edge").Element("Degree").Value);
                    double real = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Real").Value);
                    double imaginary = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Imaginary").Value);
                    Node newNode = new Node();
                    dfsStack.Push(new List<Object>());
                    dfsStack.Peek().Add(newNode);
                    dfsStack.Peek().Add(currentNode);
                    dfsStack.Peek().Add(new KeyValuePair<int, Complex>(degree, new Complex(real, imaginary)));
                    dfsStack.Peek().Add(edge);
                }
                if (currentNode.isEnd)
                {
                    foreach (var edge in currentXNode.Elements("Tree"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        currentNode._special.Add(edgeChar, new Trie(dfsSecond(edge)));
                    }
                    foreach (var edge in currentXNode.Elements("SolutionSet"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        List<Complex> solutions = new List<Complex>();
                        foreach (var solution in edge.Elements("Solution"))
                        {
                            solutions.Add(new Complex(double.Parse(solution.Element("Real").Value),
                                double.Parse(solution.Element("Imaginary").Value)));
                        }
                        currentNode._special.Add(edgeChar, solutions);
                    }
                    foreach (var edge in currentXNode.Elements("substitutions"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        var substitutions = new Dictionary<List<Complex>, Complex>(new ListComparer<Complex>());
                        foreach (var substitution in edge.Elements("substitution"))
                        {
                            string[] tempX = substitution.Element("X").Value.Split('(', ',', ')');
                            string[] tempR = substitution.Element("Result").Value.Split('(', ',', ')');
                            List<Complex> key = new List<Complex>();
                            key.Add(new Complex(double.Parse(tempX[1]), double.Parse(tempX[2])));
                            substitutions.Add(key,
                                 new Complex(double.Parse(tempR[1]), double.Parse(tempR[2])));
                        }
                        currentNode._special.Add(edgeChar, substitutions);
                    }
                    foreach (var edge in currentXNode.Elements("definiteInts"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        var substitutions = new Dictionary<List<Complex>, Complex>(new ListComparer<Complex>());
                        foreach (var substitution in edge.Elements("definiteInt"))
                        {
                            string[] tempA = substitution.Element("A").Value.Split('(', ',', ')');
                            string[] tempB = substitution.Element("B").Value.Split('(', ',', ')');
                            string[] tempR = substitution.Element("Result").Value.Split('(', ',', ')');
                            List<Complex> key = new List<Complex>();
                            key.Add(new Complex(double.Parse(tempA[1]), double.Parse(tempA[2])));
                            key.Add(new Complex(double.Parse(tempB[1]), double.Parse(tempB[2])));
                            substitutions.Add(key,
                                 new Complex(double.Parse(tempR[1]), double.Parse(tempR[2])));
                        }
                        currentNode._special.Add(edgeChar, substitutions);
                    }
                    foreach (var edge in currentXNode.Elements("derivative"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        var derivative = new Polynomial(edge.Element("Result").Value);
                        currentNode._special.Add(edgeChar, derivative);
                    }
                }
            }
            return root;
        }
        Node dfsSecond(XElement Xroot)
        {
            Node root = new Node();
            Stack<List<Object>> dfsStack = new Stack<List<Object>>();
            dfsStack.Push(new List<Object>());
            dfsStack.Peek().Add(root);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(Xroot);
            while (dfsStack.Count != 0)
            {
                var temporaryList = dfsStack.Pop();
                Node currentNode = temporaryList[0] as Node;
                Node parentNode = temporaryList[1] as Node;
                XElement currentXNode = temporaryList[3] as XElement;
                currentNode.isEnd = currentXNode.Element("isEnd").Value == "True";
                if (parentNode != null)
                {
                    KeyValuePair<int, Complex> Edge = (KeyValuePair<int, Complex>)temporaryList[2];
                    parentNode._children.Add(Edge, currentNode);
                }
                foreach (var edge in currentXNode.Elements("Node"))
                {
                    int degree = int.Parse(edge.Element("Edge").Element("Degree").Value);
                    double real = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Real").Value);
                    double imaginary = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Imaginary").Value);
                    Node newNode = new Node();
                    dfsStack.Push(new List<Object>());
                    dfsStack.Peek().Add(newNode);
                    dfsStack.Peek().Add(currentNode);
                    dfsStack.Peek().Add(new KeyValuePair<int, Complex>(degree, new Complex(real, imaginary)));
                    dfsStack.Peek().Add(edge);
                }
                if (currentNode.isEnd)
                {
                    currentNode._special.Add('=', new Polynomial(currentXNode.Element("Result").Value));
                }
            }
            return root;
        }
        XElement dfs(Node root)
        {
            XElement Xroot = new XElement("Node");
            Stack<List<Object>> dfsStack = new Stack<List<Object>>();
            dfsStack.Push(new List<Object>());
            dfsStack.Peek().Add(Xroot);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(root);
            while (dfsStack.Count != 0)
            {
                var temporaryList = dfsStack.Pop();
                XElement Xcurrent = temporaryList[0] as XElement;
                XElement Xparent = temporaryList[1] as XElement;
                Node currentNode = temporaryList[2] as Node;
                Xcurrent.Add(new XElement("isEnd", currentNode.isEnd.ToString()));
                if (Xparent != null)
                {
                    Xparent.Add(Xcurrent);
                }
                foreach (var edge in currentNode._children)
                {
                    var newChild = new XElement("Node");
                    newChild.Add(new XElement("Edge",
                        new XElement("Degree", edge.Key.Key.ToString()),
                        new XElement("Coefficient",
                            new XElement("Real", edge.Key.Value.Real),
                            new XElement("Imaginary", edge.Key.Value.Imaginary))));
                    dfsStack.Push(new List<Object>());
                    dfsStack.Peek().Add(newChild);
                    dfsStack.Peek().Add(Xcurrent);
                    dfsStack.Peek().Add(edge.Value);
                }
                if (currentNode.isEnd)
                {
                    foreach (var special in currentNode._special)
                    {
                        XElement newChild;
                        if (special.Key == '=')
                        {
                            newChild = new XElement("SolutionSet");
                            foreach (var solution in (special.Value as List<Complex>))
                            {
                                newChild.Add(new XElement("Solution",
                                    new XElement("Real", solution.Real),
                                    new XElement("Imaginary", solution.Imaginary)));
                            }
                        }
                        else if (special.Key == 's')
                        {
                            newChild = new XElement("substitutions");
                            foreach (var substitution in (special.Value as Dictionary<List<Complex>,Complex>))
                            {
                                newChild.Add(new XElement("substitution",
                                    new XElement("X", substitution.Key[0].ToString()),
                                    new XElement("Result", substitution.Value.ToString())));
                            }
                        }
                        else if (special.Key == 'd')
                        {
                            newChild = new XElement("definiteInts");
                            foreach (var substitution in (special.Value as Dictionary<List<Complex>, Complex>))
                            {
                                newChild.Add(new XElement("definiteInt",
                                    new XElement("A", substitution.Key[0].ToString()),
                                    new XElement("B", substitution.Key[1].ToString()),
                                    new XElement("Result", substitution.Value.ToString())));
                            }
                        }
                        else if (special.Key == '^')
                        {
                            newChild = new XElement("derivative");
                            newChild.Add(new XElement("Result", special.Value.ToString()));
                        }
                        else
                        {
                            newChild = dfsSecond((special.Value as Trie).root);
                            newChild.Name = "Tree";
                        }
                        newChild.Add(new XElement("Edge", special.Key.ToString()));
                        Xcurrent.Add(newChild);
                    }
                }
            }
            return Xroot;
        }
        XElement dfsSecond(Node root)
        {
            XElement Xroot = new XElement("Node");
            Stack<List<Object>> dfsStack = new Stack<List<Object>>();
            dfsStack.Push(new List<Object>());
            dfsStack.Peek().Add(Xroot);
            dfsStack.Peek().Add(null);
            dfsStack.Peek().Add(root);
            while (dfsStack.Count != 0)
            {
                var temporaryList = dfsStack.Pop();
                XElement Xcurrent = temporaryList[0] as XElement;
                XElement Xparent = temporaryList[1] as XElement;
                Node currentNode = temporaryList[2] as Node;
                Xcurrent.Add(new XElement("isEnd", currentNode.isEnd.ToString()));
                if (Xparent != null)
                {
                    Xparent.Add(Xcurrent);
                }
                foreach (var edge in currentNode._children)
                {
                    var newChild = new XElement("Node");
                    newChild.Add(new XElement("Edge",
                        new XElement("Degree", edge.Key.Key.ToString()),
                        new XElement("Coefficient",
                            new XElement("Real", edge.Key.Value.Real),
                            new XElement("Imaginary", edge.Key.Value.Imaginary))));
                    dfsStack.Push(new List<Object>());
                    dfsStack.Peek().Add(newChild);
                    dfsStack.Peek().Add(Xcurrent);
                    dfsStack.Peek().Add(edge.Value);
                }
                if (currentNode.isEnd)
                {
                    Xcurrent.Add(new XElement("Result", currentNode._special['='].ToString()));
                }
            }
            return Xroot;
        }
        #endregion
    }
}
