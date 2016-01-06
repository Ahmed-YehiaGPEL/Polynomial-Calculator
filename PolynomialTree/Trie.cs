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
    public class PolynomialTrie : IDisposable
    {
        #region Constructor&Properties
        public Trie main;
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
        public PolynomialTrie(Trie _main)
        {
            main = _main;
        }
        #endregion
        #region insert&search&save
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
    }
}
