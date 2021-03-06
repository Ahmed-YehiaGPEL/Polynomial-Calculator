﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMath.Trie
{
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
    }
}
