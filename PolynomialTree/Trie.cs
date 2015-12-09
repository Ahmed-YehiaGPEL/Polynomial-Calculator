using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMath.PolynomialEquation;


namespace CMath.Trie
{
    public class TreeNode<T>
    {
       T _value;
       List<int> _childernIndices;
       List<WeakReference<Polynomial>> _children;
       WeakReference<Trie<T>> _addition, _subtraction, _multiplication;
       bool isEnd;
    }
    public class Trie<T>
    {
        TreeNode<T> root;
        
    }
}
