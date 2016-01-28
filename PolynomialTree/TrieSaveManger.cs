using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Data;
using System.Diagnostics;
using CMath.PolynomialEquation;
using CMath.Trie;
using CMath.Utils;
using ClosedXML;
using ClosedXML.Excel;
using ClosedXML.Utils;

namespace CMath.Trie
{
    #region TypeDefinitions
    using Node = TreeNode<KeyValuePair<int, Complex>>;
    using Trie = Trie<KeyValuePair<int, Complex>>;
    using paraStore = Dictionary<List<Complex>, Complex>;
    #endregion
    public class TrieSaveMangaer
    {
        #region XML
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
        #region Excel
        public void saveExcel(PolynomialTrie toBeSaved,string fileName)
        {
            DataTable sub, defint;
            paraDT(toBeSaved, out sub, out defint);
            using (XLWorkbook saver = new XLWorkbook(XLEventTracking.Disabled))
            {
                saver.Worksheets.Add(OneOperationDT(toBeSaved));
                saver.Worksheets.Add(sub);
                saver.Worksheets.Add(defint);
                saver.Worksheets.Add(TwoPolynomialsDT(toBeSaved));
                saver.SaveAs(fileName);
            }
        }
        #endregion
        #region XMLdfs
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
                        currentNode._special.Add(edgeChar, new Trie(dfs(edge)));
                    }
                    foreach (var edge in currentXNode.Elements("listComplex"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        currentNode._special.Add(edgeChar, ComplexUtils.complexListParse(edge.Elements("root")));
                    }
                    foreach (var edge in currentXNode.Elements("params"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        var operations = new paraStore(new ListComparer<Complex>());
                        foreach (var op in edge.Elements("operation"))
                        {
                            operations.Add(ComplexUtils.complexListParse(op.Elements("para")), ComplexUtils.ParseComplex(op.Element("Result").Value));
                        }
                        currentNode._special.Add(edgeChar, operations);
                    }
                    foreach (var edge in currentXNode.Elements("Result"))
                    {
                        char edgeChar = edge.Element("Edge").Value[0];
                        var resultPoly = new Polynomial(edge.Element("poly").Value);
                        currentNode._special.Add(edgeChar, resultPoly);
                    }
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
                        string Name = Constants.operationsName[special.Key];
                        XElement newChild = new XElement(Name);
                        if (Name == "listComplex")
                        {
                            foreach (var solution in (special.Value as List<Complex>))
                            {
                                newChild.Add(new XElement("root",ComplexUtils.ComplexToString(solution)));
                            }
                        }
                        else if (Name == "Result")
                        {
                            newChild.Add(new XElement("poly",special.Value.ToString()));
                        }
                        else if (Name == "params")
                        {
                            foreach (var operation in (special.Value as paraStore))
                            {
                                XElement op = new XElement("operation");
                                foreach (var para in operation.Key)
                                {
                                    op.Add(new XElement("para", para.ToString()));
                                }
                                op.Add(new XElement("Result", operation.Value.ToString()));
                                newChild.Add(op);
                            }
                        }
                        else if (Name == "Tree")
                        {
                            newChild = dfs((special.Value as Trie).root);
                        }
                        newChild.Name = Name;
                        newChild.Add(new XElement("Edge", special.Key.ToString()));
                        Xcurrent.Add(newChild);
                    }
                }
            }
            return Xroot;
        }
        #endregion
        #region ExcelUtils
        DataTable OneOperationDT(PolynomialTrie trie)
        {
            DataTable result = new DataTable("Operations on one polynomial");
            foreach (var title in Constants.OnePolynomialColumnsName)
            {
                result.Columns.Add(title.Value, typeof(string));
            }
            Polynomial SoFar = new Polynomial();
            Stack<Tuple<Node, Term, bool>> dfsStack = new Stack<Tuple<Node, Term, bool>>();
            dfsStack.Push(new Tuple<Node,Term,bool>(trie.main.root,new Term(0,0),false));
            while (dfsStack.Count != 0)
            {
                if (dfsStack.Peek().Item3)
                {
                    dfsStack.Pop();
                    if(SoFar.Count != 0)
                        SoFar.Remove(SoFar.Back.Degree);
                    continue;
                }
                Node current = dfsStack.Peek().Item1;
                Term edge = dfsStack.Peek().Item2;
                if(edge.Coefficient != 0)
                    SoFar.Add(edge);
                dfsStack.Pop();
                dfsStack.Push(new Tuple<Node, Term, bool>(current,edge, true));
                foreach (var child in current._children)
                {
                    dfsStack.Push(new Tuple<Node, Term, bool>(child.Value,new Term(child.Key), false));
                }
                if (current.isEnd)
                {
                    result.Rows.Add(result.NewRow());
                    int index = result.Rows.Count - 1;
                    result.Rows[index]["Polynomial"] = SoFar.ToString();
                    bool foundOperation = false;
                    foreach (var special in current._special)
                    {
                        if (Constants.operationsName[special.Key] == "Result")
                        {
                            foundOperation = true;
                            result.Rows[index][Constants.OnePolynomialColumnsName[special.Key]] = (special.Value as Polynomial).ToString();
                        }
                        else if (Constants.operationsName[special.Key] == "listComplex")
                        {
                            foundOperation = true;
                            result.Rows[index][Constants.OnePolynomialColumnsName[special.Key]] = ComplexUtils.ComplexListToString(special.Value as List<Complex>);
                        }
                    }
                    if (!foundOperation)
                    {
                        result.Rows.RemoveAt(result.Rows.Count - 1);
                    }
                }
            }
            return result;
        }
        void paraDT(PolynomialTrie trie,out DataTable substitutaions,out DataTable definiteIntegral)
        {
            substitutaions = new DataTable("subtitutions in polynomial");
            definiteIntegral = new DataTable("Definite integral on polynomial");
            foreach (var title in Constants.SubstitutionColumnsName)
            {
                substitutaions.Columns.Add(title, typeof(string));
            }
            foreach (var title in Constants.DefiniteIntColumnsName)
            {
                definiteIntegral.Columns.Add(title, typeof(string));
            }
            Polynomial SoFar = new Polynomial();
            Stack<Tuple<Node, Term, bool>> dfsStack = new Stack<Tuple<Node, Term, bool>>();
            dfsStack.Push(new Tuple<Node,Term,bool>(trie.main.root,new Term(0,0),false));
            while (dfsStack.Count != 0)
            {
                if (dfsStack.Peek().Item3)
                {
                    dfsStack.Pop();
                    if(SoFar.Count != 0)
                        SoFar.Remove(SoFar.Back.Degree);
                    continue;
                }
                Node current = dfsStack.Peek().Item1;
                Term edge = dfsStack.Peek().Item2;
                if(edge.Coefficient != 0)
                    SoFar.Add(edge);
                dfsStack.Pop();
                dfsStack.Push(new Tuple<Node, Term, bool>(current,edge, true));
                foreach (var child in current._children)
                {
                    dfsStack.Push(new Tuple<Node, Term, bool>(child.Value,new Term(child.Key), false));
                }
                if (current.isEnd)
                {
                    substitutaions.Rows.Add(substitutaions.NewRow());
                    definiteIntegral.Rows.Add(definiteIntegral.NewRow());
                    int indexSub = substitutaions.Rows.Count - 1;
                    int indexDefint = definiteIntegral.Rows.Count - 1;
                    substitutaions.Rows[indexSub]["Polynomial"] = SoFar.ToString();
                    definiteIntegral.Rows[indexDefint]["Polynomial"] = SoFar.ToString();
                    bool foundSubstitution = false;
                    bool foundDefint = false;
                    foreach (var special in current._special)
                    {
                        if (special.Key == 's')
                        {
                            foundSubstitution = true;
                            foreach(var substitutaion in special.Value as paraStore)
                            {
                                substitutaions.Rows[indexSub]["X"] = ComplexUtils.ComplexToString(substitutaion.Key[0]);
                                substitutaions.Rows[indexSub]["Result"] = ComplexUtils.ComplexToString(substitutaion.Value);

                            }
                        }
                        else if (special.Key == 'd')
                        {
                            foundDefint = true;
                            foreach (var defint in special.Value as paraStore)
                            {
                                definiteIntegral.Rows[indexSub]["A"] = ComplexUtils.ComplexToString(defint.Key[0]);
                                definiteIntegral.Rows[indexSub]["B"] = ComplexUtils.ComplexToString(defint.Key[1]);
                                definiteIntegral.Rows[indexSub]["Result"] = ComplexUtils.ComplexToString(defint.Value);

                            }
                        }
                    }
                    if (!foundSubstitution)
                    {
                        substitutaions.Rows.RemoveAt(substitutaions.Rows.Count - 1);
                    }
                    if (!foundDefint)
                    {
                        definiteIntegral.Rows.RemoveAt(definiteIntegral.Rows.Count - 1);
                    }
                }
            }
        }
        DataTable TwoPolynomialsDT(PolynomialTrie trie)
        {
            DataTable result = new DataTable("Operations on two polynomials");
            foreach (var title in Constants.TwoPolynomialsColumnsName)
            {
                result.Columns.Add(title.Value, typeof(string));
            }
            Polynomial SoFar = new Polynomial();
            Stack<Tuple<Node, Term, bool>> dfsStack = new Stack<Tuple<Node, Term, bool>>();
            dfsStack.Push(new Tuple<Node, Term, bool>(trie.main.root, new Term(0, 0), false));
            while (dfsStack.Count != 0)
            {
                if (dfsStack.Peek().Item3)
                {
                    dfsStack.Pop();
                    if (SoFar.Count != 0)
                        SoFar.Remove(SoFar.Back.Degree);
                    continue;
                }
                Node current = dfsStack.Peek().Item1;
                Term edge = dfsStack.Peek().Item2;
                if (edge.Coefficient != 0)
                    SoFar.Add(edge);
                dfsStack.Pop();
                dfsStack.Push(new Tuple<Node, Term, bool>(current, edge, true));
                foreach (var child in current._children)
                {
                    dfsStack.Push(new Tuple<Node, Term, bool>(child.Value, new Term(child.Key), false));
                }
                if (current.isEnd)
                {
                    foreach (var special in current._special)
                    {
                        if (Constants.operationsName[special.Key] == "Tree")
                        {
                            SecondTreeExtraction(special.Value as Trie, SoFar, ref result);
                        }
                    }
                }
            }
            return result;
        }
        void SecondTreeExtraction(Trie trie, Polynomial firstPolynomial, ref DataTable result)
        {
            Polynomial SoFar = new Polynomial();
            Stack<Tuple<Node, Term, bool>> dfsStack = new Stack<Tuple<Node, Term, bool>>();
            dfsStack.Push(new Tuple<Node, Term, bool>(trie.root, new Term(0, 0), false));
            while (dfsStack.Count != 0)
            {
                if (dfsStack.Peek().Item3)
                {
                    dfsStack.Pop();
                    if (SoFar.Count != 0)
                        SoFar.Remove(SoFar.Back.Degree);
                    continue;
                }
                Node current = dfsStack.Peek().Item1;
                Term edge = dfsStack.Peek().Item2;
                if (edge.Coefficient != 0)
                    SoFar.Add(edge);
                dfsStack.Pop();
                dfsStack.Push(new Tuple<Node, Term, bool>(current, edge, true));
                foreach (var child in current._children)
                {
                    dfsStack.Push(new Tuple<Node, Term, bool>(child.Value, new Term(child.Key), false));
                }
                if (current.isEnd)
                {
                    result.Rows.Add(result.NewRow());
                    int index = result.Rows.Count - 1;
                    result.Rows[index]["Polynomial1"] = firstPolynomial.ToString();
                    result.Rows[index]["Polynomial2"] = SoFar.ToString();
                    bool foundOperation = false;
                    foreach (var special in current._special)
                    {
                        if (Constants.operationsName[special.Key] == "Result")
                        {
                            foundOperation = true;
                            result.Rows[index][Constants.TwoPolynomialsColumnsName[special.Key]] = (special.Value as Polynomial).ToString();
                        }
                    }
                    if (!foundOperation)
                    {
                        result.Rows.RemoveAt(result.Rows.Count - 1);
                    }
                }
            }
        }
        #endregion
    }
}
