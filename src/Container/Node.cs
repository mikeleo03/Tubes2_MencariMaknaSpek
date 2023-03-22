using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    class Node {
        // attributes
        private char type;
        private Coordinate loc;
        private int visitedTime;

        // constructors
        public Node() {
            this.type = ' ';
            this.loc = new Coordinate();
            this.visitedTime = 0;
        }

        public Node(char type, int x, int y, int visitedTime) {
            this.type = type;
            this.loc = new Coordinate(x, y);
            this.visitedTime = visitedTime;
        }

        // getter
        public char getType() {
            return this.type;
        }

        public int getVisitedTime() {
            return this.visitedTime;
        }

        // setter
        public void reset()
        {
            this.visitedTime = 0;
        }

        // method to visit node
        public void visit() {
            this.visitedTime++;
        }
    }
}
