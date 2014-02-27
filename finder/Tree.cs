using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finder
{
    class Tree
    {
        private char id;
        public void setID(char _id) { id = _id; }
        public char getID() { return id;}

        public Tree left;
        public Tree right;
        public Tree() { right = left = null; }
        public Tree(char _id) { id = _id; left = right = null; }


    }
}
