using System;
using System.Collections.Generic;
using System.Linq;

namespace LTTT_Huffman_CSharp
{
    public class Tree
    {
        public Tree()
        {
            Nodes = new List<Node>();
        }

        public List<Node> Nodes { get; set; }

        public void GetInfo()
        {
            foreach (var node in Nodes)
                Console.WriteLine("Symbol : {0} - Frequency : {1}", node.Symbol, node.Frequency);
        }


        public void GetInitialListNodes(string message)
        {
            var listNodes = new List<Node>();

            foreach (var c in message.ToCharArray())
            {
                var symbol = c.ToString();
                var node = listNodes.FirstOrDefault(n => n.Symbol == symbol);
                if (node == null)
                {
                    listNodes.Add(new Node(symbol));
                }
                else
                {
                    node.Frequency += 1;
                }
            }

            Nodes = listNodes.OrderBy(n => n.Frequency).ToList();
        }

        public void CreateTree()
        {
            while (Nodes.Count > 1)
            {
                var node1 = Nodes[0];
                Nodes.RemoveAt(0);

                var node2 = Nodes[0];
                Nodes.RemoveAt(0);

                Nodes.Add(new Node(node1, node2));

                Nodes = Nodes.OrderBy(n => n.Frequency).ToList();
            }
        }
    }
}