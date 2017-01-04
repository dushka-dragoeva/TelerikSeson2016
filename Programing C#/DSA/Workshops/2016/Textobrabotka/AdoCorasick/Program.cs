using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoCorasick
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(-1);
            string[] patterns = {
                "bca","caa","cb","a","",""
            };

            for (int i = 0; i < patterns.Length; i++)
            {
                Node.Add()
            }
        }


    }

    public class Node
    {
        private Node[] children;

        private Node faillink;

        private const int MaxChildren = 26;

        private int indexOfPattern;

        public int IndexOfPattern { get; private set; }

        public Node()
        {
            this.children = new Node[MaxChildren];
            this.IndexOfPattern = -1;
        }

        public static void Add( Node node, string str, int index)
        {
            foreach (var c in str)
            {
                if (node.children[c - 'a'] == null)
                {
                    node.children[c - 'a'] = new Node();
                }
            }
        }

        public static void Precompute(Node root)
        {
            var que = new Queue<Node>();
            que.Enqueue(root);

            while (que.Count > 0)
            {
                Node node = que.Dequeue();
                for (int i = 0; i < MaxChildren; i++)
                {
                    if (node.children[i] == null)
                    {
                        continue;
                    }

                    var fl = node.faillink;
                    while (fl != null)
                    {
                        
                    }

                }
            }
        }


    }
}
