using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Numerics;
using CMath.PolynomialEquation;
using CMath.Utils;

namespace CMath.Trie
{
    #region TypeDefinitions
    using Node = TreeNode<KeyValuePair<int, Complex>>;
    using Trie = Trie<KeyValuePair<int, Complex>>;
    using paraStore = Dictionary<List<Complex>, Complex>;
    #endregion
    public class PolynomialTrie : IDisposable
    {
        #region Constructor&Properties
        public Trie main;
        public void Dispose()
        {
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
        #region insert&search
        public void insert(Polynomial equation, char operation, List<Complex> X, Complex result)
        {
            try
            {
                var lastFirst = main.insert(equation._data.ToList());
                if (!lastFirst._special.ContainsKey(operation))
                {
                    lastFirst._special.Add(operation, new paraStore(new ListComparer<Complex>()));
                }
                var toInsertIn = lastFirst._special[operation] as paraStore;
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
                if (!lastFirst._special.ContainsKey(','))
                {
                    lastFirst._special.Add(',', new Trie());
                }
                var secondTrie = lastFirst._special[','] as Trie;
                var lastSecond = secondTrie.insert(second._data.ToList());
                if (lastSecond._special.ContainsKey(operation))
                {
                    throw new ArgumentException("Operation is already stored");
                }
                lastSecond._special.Add(operation, result);
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
            var specialDict = last._special[operation] as paraStore;
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
            if (!lastFirst._special.ContainsKey(','))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            Node lastSecond;
            if (!(lastFirst._special[','] as Trie).try_get_node(second._data.ToList(), out lastSecond))
            {
                throw new KeyNotFoundException("There is no such polynomial in the trie;");
            }
            if (!lastSecond._special.ContainsKey(operation))
            {
                throw new KeyNotFoundException("There is no such operation in the trie;");
            }
            return (lastSecond._special[operation] as Polynomial);
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
    }
}
