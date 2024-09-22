using System.Collections;
using System.Collections.Generic;

namespace Huffman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msg = "internet";
            huffman huff = new huffman(msg);

            foreach (char k in huff.codes.Keys)
            {
                Console.Write(k + " ");
                Console.WriteLine(huff.codes[k]);
            }
        }
    }
    public class HeapNode
    {
        public char data;
        public int freq;
        public HeapNode left;
        public HeapNode right;
        public HeapNode(char data,int freq)
        {
            this.data = data;
            this.freq = freq;
            this.right = left = null;
        }
    }

    public class huffman
    {
        private char internal_char = (char)0;
        public Hashtable codes = new Hashtable();
        PriorityQueue<HeapNode, int> minHeap = new PriorityQueue<HeapNode, int>();
        public huffman(string message)
        {
            // Get the chars frequences
            Hashtable freqhash =new Hashtable();
            for (int i = 0; i < message.Length; i++)
            {
                if (freqhash[message[i]] == null)
                    freqhash[message[i]] = 1;
                else
                    freqhash[message[i]] = (int)freqhash[message[i]] + 1;
            }
            // Convert Hashtable to Queue[minHeap]
            foreach(char k in freqhash.Keys)
            {
                HeapNode newNode=new HeapNode(k,(int)freqhash[k]);
                minHeap.Enqueue(newNode,(int)freqhash[k]);
            }
            // we will use the priority queue to build the huffman map ..
            // because we can move nodes with it's child nodes
            // this is the ultimate reson why we using Prioriy queue
            HeapNode top, left, right;
            int newfreq;
            while(minHeap.Count != 1)
            {
                left = minHeap.Dequeue();
                right = minHeap.Dequeue();
                newfreq = left.freq + right.freq;
                top = new HeapNode(internal_char, newfreq);
                top.right = right;
                top.left = left;
                minHeap.Enqueue(top, newfreq);
            }
            this.generateCodes(minHeap.Peek(), "");

        }

        private void generateCodes(HeapNode node, string str)
        {
            if (node == null)
            {
                return;
            }
            if (node.data != internal_char)
            {
                codes[node.data] = str;
            }

            generateCodes(node.left, str + "0");
            generateCodes(node.right, str + "1");


        }
    }
}
