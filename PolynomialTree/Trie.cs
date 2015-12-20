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
    using FirstLevelNode = TreeNode<KeyValuePair<int, Complex>, Trie<KeyValuePair<int, Complex>, Polynomial>>;
    using SecondLevelNode = TreeNode<KeyValuePair<int, Complex>, Polynomial>;
    using FirstLevelTrie = Trie<KeyValuePair<int, Complex>, Trie<KeyValuePair<int, Complex>, Polynomial>>;
    using SecondLevelTrie = Trie<KeyValuePair<int, Complex>, Polynomial>;
    #endregion

    public class TreeNode<T, TSpecial>
    {
       #region Properties
       public Dictionary<T, TreeNode<T, TSpecial>> _children;
       public Dictionary<Char, TSpecial> _special;
       public bool isEnd;
       #endregion
       #region constructor
       public TreeNode()
       {
           isEnd = false;
           _children = new Dictionary<T, TreeNode<T, TSpecial>>();
           _special = new Dictionary<Char, TSpecial>();
       }
       #endregion
       #region functions
       public void insert(T value, TreeNode<T, TSpecial> child)
       {
           _children.Add(value,child);
       }
       TreeNode<T, TSpecial> get_child(T value)
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
       public bool try_get_child(T value, out TreeNode<T, TSpecial> result)
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
    public class Trie<T, TSpecial> : IDisposable
    {
        #region Constructor&Properties
        public TreeNode<T, TSpecial> root;
        public Trie()
        {
            root = new TreeNode<T, TSpecial>();
        }
        public void Dispose()
        {
            GC.Collect();
        }
        public Trie(TreeNode<T, TSpecial> _root)
        {
            root = _root;
        }
        public bool isEmpty()
        {
            return root._children.Count == 0;
        }
        #endregion
        #region insert&search
        public TreeNode<T, TSpecial> insert(List<T> value)
        {
            if(value.Count == 0)
                throw new ArgumentOutOfRangeException("List cannot be empty;");

            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T, TSpecial> next;
                if (!current.try_get_child(value[i],out next))
                {
                    next = new TreeNode<T, TSpecial>();
                    current.insert(value[i], next);
                }
                current = next;
            }
            current.isEnd = true;
            return current;
        }
        TreeNode<T, TSpecial> get_node(List<T> value)
        {
            if(value.Count == 0)
                throw new ArgumentOutOfRangeException("List cannot be empty;");

            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T, TSpecial> next;
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
        public bool try_get_node(List<T> value, out TreeNode<T, TSpecial> result)
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

            var dfs = new Stack<TreeNode<T, TSpecial>>();
            var current = root;
            for (int i = 0; i < value.Count; i++)
            {
                TreeNode<T, TSpecial> next;
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
            var bfs = new Queue<TreeNode<T, TSpecial>>();
            bfs.Enqueue(root);
            TreeNode<T, TSpecial> current;
            while (bfs.Count != 0)
            {
                current = bfs.Dequeue();
                foreach (var item in current._children)
                {
                    bfs.Enqueue(item.Value);
                }
                current = null;
            }
            root = new TreeNode<T, TSpecial>();
        }
        #endregion
    }
    public class PolynomialTrie : IDisposable
    {
        #region Constructor&Properties
        FirstLevelTrie main;
        public void Dispose()
        {
            main.clear();
            main.Dispose();
            GC.Collect();
        }
        public PolynomialTrie()
        {
            main = new FirstLevelTrie();
        }
        public PolynomialTrie(string FileName)
        {
                XDocument xDoc = XDocument.Load(FileName);
                main = new FirstLevelTrie(dfs((XElement)xDoc.FirstNode));

        }
        #endregion
        #region insert&search&save
        public void save(string FileName)
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xDoc.Add(dfs(main.root));
            xDoc.Save(FileName);
        }
        public void insert(Polynomial first, Char operation, Polynomial second, Polynomial result)
        {
            try
            {
                var lastFirst = main.insert(first._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, new SecondLevelTrie());
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
        Polynomial search(Polynomial first, char operation, Polynomial second)
        {
            FirstLevelNode lastFirst;
            if (!main.try_get_node(first._data.ToList(),out lastFirst))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastFirst._special.ContainsKey(operation))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            SecondLevelNode lastSecond;
            if (!lastFirst._special[operation].try_get_node(second._data.ToList(), out lastSecond))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastSecond._special.ContainsKey('='))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
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
        #endregion
        #region remove&clear
        void remove(Polynomial first, Char operation, Polynomial second)
        {
            FirstLevelNode lastFirst;
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
                try
                {
                    main.try_remove(first._data.ToList());
                }
                catch
                {
                    throw new Exception("Unknown error happened;");
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
        FirstLevelNode dfs(XElement current)
        {
            FirstLevelNode result = new FirstLevelNode();
            result.isEnd = current.Element("isEnd").Value == "True";
            foreach (var edge in current.Elements("Node"))
            {
                int degree = int.Parse(edge.Element("Edge").Element("Degree").Value);
                double real = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Real").Value);
                double imaginary = double.Parse(edge.Element("Edge").Element("Coefficient").Element("Imaginary").Value);
                result._children.Add(new KeyValuePair<int,Complex>(degree,new Complex(real,imaginary)),dfs(edge));
            }
            if (result.isEnd)
            {
                foreach (var edge in current.Elements("Tree"))
                {
                    char Edge = edge.Element("Edge").Value[0];
                    SecondLevelTrie special = new SecondLevelTrie(dfsSecond(edge));
                    result._special.Add(Edge, special);
                }
            }
            return result;
        }
        SecondLevelNode dfsSecond(XElement current)
        {
            SecondLevelNode result = new SecondLevelNode();
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
        XElement dfs(FirstLevelNode node)
        {
            XElement result = new XElement("Node");
            result.Add(new XElement("isEnd", node.isEnd.ToString()));
            foreach (var edge in node._children)
            {
                var newChild = dfs(edge.Value);
                newChild.Add(new XElement("Edge",
                    new XElement("Degree",edge.Key.Key.ToString()),
                    new XElement("Coefficient",
                        new XElement("Real",edge.Key.Value.Real),
                        new XElement("Imaginary", edge.Key.Value.Imaginary))));
                result.Add(newChild);
            }
            if(node.isEnd){
                foreach (var special in node._special)
                {
                    XElement newChild = dfsSecond(special.Value.root);
                    newChild.Name = "Tree";
                    newChild.Add(new XElement("Edge",special.Key.ToString()));
                    result.Add(newChild);
                }
            }
            return result;
        }
        XElement dfsSecond(SecondLevelNode node)
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
