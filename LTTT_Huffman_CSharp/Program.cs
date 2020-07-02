using System;
using System.Collections.Generic;
using System.Linq;

namespace LTTT_Huffman_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "ten em la lo van son nguoi thi thap be nho con nhung co tai bo em la lo van sai";
            
            var tree = new Tree();

            tree.GetInitialListNodes(message);
            
            tree.GetInfo();
            
            tree.CreateTree();
            
            var finalNode = tree.Nodes.FirstOrDefault();

            if (finalNode != null)
            {
                finalNode.SetCode();
                
                finalNode.GetCodeWords();
            }
        }
    }
}