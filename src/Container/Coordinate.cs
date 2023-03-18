using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    class Coordinate {
        // attributes
        private int x;
        private int y;

        // constructors 
        public Coordinate() {
            this.x = 0;
            this.y = 0;
        }

        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }

        // getter
        public int getX() { 
            return this.x; 
        }
        
        public int getY() {
            return this.y;
        }

        // method to move point
        public Coordinate moveUp() {
            return new Coordinate(this.x, this.y-1);
        }

        public Coordinate moveDown() {
            return new Coordinate(this.x, this.y+1);
        }

        public Coordinate moveLeft() {
            return new Coordinate(this.x-1, this.y);
        }

        public Coordinate moveRight() {
            return new Coordinate(this.x+1, this.y);
        }
    }
}
