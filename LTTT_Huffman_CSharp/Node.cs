using System;

namespace LTTT_Huffman_CSharp
{
    public class Node
    {
        public string Symbol { get; set; }
        public int Frequency { get; set; }
        public string Code { get; set; } = "";
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }


        public Node(string symbol)
        {
            Symbol = symbol;
            Frequency = 1;
        }

        public Node(Node node1, Node node2)
        {
            if (node1.Frequency >= node2.Frequency)
            {
                this.Right = node1;
                this.Left = node2;
                this.Symbol = node1.Symbol + node2.Symbol;
            }
            else
            {
                this.Right = node2;
                this.Left = node1;
                this.Symbol = node2.Symbol + node1.Symbol;
            }

            node1.Parent = node2.Parent = this;
            this.Frequency = node1.Frequency + node2.Frequency;
        }

        public void SetCode(string code = "")
        {
            if (this.Left == null && this.Right == null)
            {
                this.Code = code;
                return;
            }

            this.Left?.SetCode(code + "0");
            this.Right?.SetCode(code + "1");
        }

        public void GetCodeWords()
        {
            if (this.Left == null && this.Right == null)
            {
                Console.WriteLine("Symbol : {0} -  Code : {1}", this.Symbol, this.Code);
                return;
            }

            this.Left?.GetCodeWords();
            this.Right?.GetCodeWords();
        }
    }
}