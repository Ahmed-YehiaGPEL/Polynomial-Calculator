using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalculatorUI
{
     static class Program
    {
         static public CMath.Trie.PolynomialTrie _historyTrie;
         static public CMath.Trie.TrieSaveMangaer _saveMan = new CMath.Trie.TrieSaveMangaer();
         static public string filePath = Application.StartupPath + "\\appdata.xml.plcl";
         static public List<string> _logItems = new List<string>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         [STAThread]
         static void Main(string[] args)
         {
             if (args.Length == 1)
             {
                 if (File.Exists(args[0]))
                 {
                     filePath = args[0];
                 }
                 else if (File.Exists(args[0] + ".plcl"))
                 {
                     filePath = args[0] + ".plcl";
                 }
                 else if (File.Exists(args[0] + ".xwrt"))
                 {
                     filePath = args[0] + ".xwrt";
                 }
             }
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new SplashScreen());
         }
    }
}
