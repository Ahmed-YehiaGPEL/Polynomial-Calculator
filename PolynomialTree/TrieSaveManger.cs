using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Diagnostics;
using CMath.PolynomialEquation;
using CMath.Trie;

namespace CMath.Trie
{
    #region TypeDefinitions
    using Node = TreeNode<KeyValuePair<int, Complex>>;
    using Trie = Trie<KeyValuePair<int, Complex>>;
    #endregion
    #region utils
    public class ListComparer<T> : IEqualityComparer<List<T>>
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
    public class TrieSaveMangaer
    {
        #region functions
        public void save(PolynomialTrie toBeSaved, string FileName)
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xDoc.Add(dfs(toBeSaved.main.root));
            xDoc.Save(FileName);
        }
        public void saveCompressed(PolynomialTrie toBeSaved, string FileName)
        {
            if (!File.Exists("xwrt32.exe")) throw new FileNotFoundException("Compressor was not found");
            string temp = FileName + ".tmp";
            save(toBeSaved, temp);
            Process compressor = new Process();
            compressor.StartInfo.FileName = "xwrt32.exe";
            compressor.StartInfo.Arguments = " -l3 +d -o " + temp;
            compressor.StartInfo.CreateNoWindow = true;
            compressor.Start();
            compressor.WaitForExit();
            File.Delete(temp);
            temp += ".xwrt";
            File.Copy(temp, FileName, true);
            File.Delete(temp);
        }
        public bool trySave(PolynomialTrie toBeSaved, string FileName)
        {
            if (FileName.Substring(FileName.Length - 5) != ".plcl")
            {
                FileName += ".plcl";
            }
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            try
            {
                saveCompressed(toBeSaved, FileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PolynomialTrie load(string FileName)
        {
            XDocument xDoc = XDocument.Load(FileName);
            return new PolynomialTrie(new Trie(dfs((XElement)xDoc.FirstNode)));
        }
        public PolynomialTrie tryLoad(string FileName)
        {
            if (IsFileLocked(new FileInfo(FileName)))
            {
                return new PolynomialTrie();
            }
            if (!correctFileHeader(FileName))
            {
                return new PolynomialTrie();
            }
            Process compressor = new Process();
            compressor.StartInfo.CreateNoWindow = true;
            compressor.StartInfo.FileName = "xwrt32.exe";
            compressor.StartInfo.Arguments = " -o " + FileName;
            compressor.Start();
            compressor.WaitForExit();
            string tmp = FileName + ".xml";
            if (FileName.Contains('.') && FileName.LastIndexOf('.') != 0)
                tmp = FileName.Substring(0, FileName.LastIndexOf('.'));
            PolynomialTrie result = load(tmp);
            File.Delete(tmp);
            return result;
        }
        bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
        bool correctFileHeader(string FileName)
        {
            var fileReader = File.OpenRead(FileName);
            byte[] header = new byte[10];
            if (!fileReader.CanRead) return false;
            fileReader.Read(header, 0, 5);
            fileReader.Close();
            if (header[0] != 'X' || header[1] != 'W' || header[2] != 'R' || header[3] != 'C' || header[4] != 190) return false;
            return true;
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
                            foreach (var substitution in (special.Value as Dictionary<List<Complex>, Complex>))
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
