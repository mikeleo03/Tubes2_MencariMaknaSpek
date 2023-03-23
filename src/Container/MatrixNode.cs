using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.IO;

namespace TreasureHunt.Container {
    class MatrixNode {
        // attribute
        private Node[,] map;
        private Coordinate start;
        private int row;
        private int col;
        private int numOfTreasure;

        // constructor
        public MatrixNode() {
            this.map = new Node[0, 0];
            this.start = new Coordinate();
            this.row = -1;
            this.col = -1;
            this.numOfTreasure = 0;
        }

        // getter
        public int getRow() {
            return this.row;
        }

        public int getCol() {
            return this.col;
        }
        
        public Coordinate getStart() {
            return this.start;
        }

        public int getTreasure() {
            return this.numOfTreasure;
        }

        public int getVisitedTime(Coordinate test) {
            return this.map[test.getX(), test.getY()].getVisitedTime();
        }

        // setter
        public void clearVisits() {
            for (int i = 0; i < this.row; i++) {
                for (int j = 0; j < this.col; j++) {
                    this.map[i, j].reset();
                }
            }
        }

        // fill the matrix
        public void fillMatrix(string fileName) {
            Parser parser = new Parser(fileName);
            this.map = parser.parseAndFill();
            this.start = parser.getStart();
            this.row = parser.getRow();
            this.col = parser.getCol();
            this.numOfTreasure = parser.getTreasure();
        }

        // check the condition of node locations
        public bool isCoordinateValid(Coordinate test) {
            return test.getX() >= 0 && test.getX() < this.row && test.getY() >= 0 && test.getY() < this.col;
        }

        public bool isCoordinatePassable(Coordinate test) {
            return this.map[test.getX(), test.getY()].getType() != 'X';
        }

        public bool isTreasure(Coordinate test) {
            return this.map[test.getX(), test.getY()].getType() == 'T';
        }

        public bool isVisited(Coordinate test) {
            return this.map[test.getX(), test.getY()].getVisitedTime() > 0;
        }

        // visit the node
        public void visitCoordinate(Coordinate test) {
            this.map[test.getX(), test.getY()].visit();
        }

        // change maze to list of string
        public string[] convertToStringArray(){
            string[] lines = new string[0];
            string line;

            for (int i = 0; i < this.row; i++) {
                line = "";
                for (int j = 0; j < this.col-1; j++) {
                    line += this.map[i, j].getType() + " ";
                }
                line += this.map[i, this.col - 1].getType();
                lines = lines.Append(line).ToArray();
            }
            return lines;
        }
    }
}