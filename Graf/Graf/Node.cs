using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    internal class Node
    {
        public int index;
        public List<Node> neighbours;

        public Node (int index)
        {
            this.index = index;
            neighbours = new List<Node> ();
        }

        public void AddNeighbour(Node neighbour)
        {
            if (neighbours.Contains(neighbour))
            {
                Console.WriteLine("this neighbour is already present");
            }
            else
            {
                neighbours.Add(neighbour);
            }
        }

        public void AddNeighbours(List<Node> newNeighbours)
        {
            foreach (Node neighbour in newNeighbours)
            {
                AddNeighbour(neighbour);
            }
            //neighbours.AddRange(newNeighbours);
        }

        public void PrintNeighbours()
        {
            Console.Write("neighbours of node " + index + ": ");
            foreach (Node neighbour in neighbours)
            {
                Console.Write(neighbour.index + " ");
            }
            Console.WriteLine();
        }

        public Node FindNeighbour(int NextIndex)
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.index == NextIndex)
                {
                    return neighbour;
                }
            }
            Console.WriteLine("Invalid neighbour, staying in the same node.");
            return this;
        }
    }
}
