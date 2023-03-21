using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Container;

namespace TreasureHunt.Algorithm {
    class DFSSolver {
        // attributes
        private MatrixNode maze;
        private Coordinate currentLoc;
        private Coordinate[] route;
        private int treasureCollected;

        // constructors
        public DFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.route = new Coordinate[0];
            this.treasureCollected = 0;
        }

        // getter
        public Coordinate[] getRoute() {
            return this.route;
        }

        // fill the matrix needed for dfs
        public void fillMaze(String fileName) {
            this.maze.fillMatrix(fileName);
            this.currentLoc = this.maze.getStart();
        }

        // expand current location to the next location 
        // because the node can be visited again, there is no backtracking can be done with dfs
        public bool[] checkNeighbourNode() {
            bool[] neighbourNode = {false, false, false, false};

            if (this.maze.isCoordinateValid(this.currentLoc.moveUp())) {
                neighbourNode[0] = this.maze.isCoordinatePassable(this.currentLoc.moveUp());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveLeft())) {
                neighbourNode[1] = this.maze.isCoordinatePassable(this.currentLoc.moveLeft());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveDown())) {
                neighbourNode[2] = this.maze.isCoordinatePassable(this.currentLoc.moveDown());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveRight())) {
                neighbourNode[3] = this.maze.isCoordinatePassable(this.currentLoc.moveRight());
            }

            return neighbourNode;
        }

        public int[] checkNeighbourNodeVisits(bool[] visitable) {
            int[] visitList = {-1, -1, -1, -1};

            visitList[0] = visitable[0] ? this.maze.getVisitedTime(this.currentLoc.moveUp()) : -1;
            visitList[1] = visitable[1] ? this.maze.getVisitedTime(this.currentLoc.moveLeft()) : -1;
            visitList[2] = visitable[2] ? this.maze.getVisitedTime(this.currentLoc.moveDown()) : -1;
            visitList[3] = visitable[3] ? this.maze.getVisitedTime(this.currentLoc.moveRight()) : -1;

            return visitList;
        }

        public Coordinate expandWithDFS() {
            Coordinate[] neighbour = { this.currentLoc.moveUp(), this.currentLoc.moveLeft(), this.currentLoc.moveDown(), this.currentLoc.moveRight() };

            bool[] visitable = checkNeighbourNode();
            int[] visitList = checkNeighbourNodeVisits(visitable);
            
            int idx = 0;
            for(int i = 1; i < 4; i++) {
                if (visitList[idx] == -1) {
                    idx = i;
                }
                else {
                    idx = visitList[i] < visitList[idx] && visitList[i] != -1 ? i : idx;
                }
            }

            return neighbour[idx];
        }

        // process the current location visited
        public void visitCurrentLocation() {
            if (this.maze.isTreasure(this.currentLoc) && !this.maze.isVisited(this.currentLoc)) {
                this.treasureCollected++;
            }
            this.maze.visitCoordinate(this.currentLoc);
        }

        public void solve() {
            visitCurrentLocation();
            while (this.treasureCollected != this.maze.getTreasure()) {
                this.route = this.route.Append(this.currentLoc).ToArray();
                this.currentLoc = expandWithDFS();
                visitCurrentLocation();
            }
            this.route = this.route.Append(this.currentLoc).ToArray();
        }

        // transform the route found to sequence of direction
        public String[] getSequenceOfDirection() {
            String[] sequence = new String[0];
            for (int i = 0; i < this.route.Length-1; i++) {
                if (this.route[i+1].getX() > this.route[i].getX()) {
                    sequence = sequence.Append("D").ToArray();
                }
                else if (this.route[i+1].getX() < this.route[i].getX()) {
                    sequence = sequence.Append("U").ToArray();
                }
                else if (this.route[i+1].getY() > this.route[i].getY()) {
                    sequence = sequence.Append("R").ToArray();
                }
                else {
                    sequence = sequence.Append("L").ToArray();
                }
            }
            return sequence;
        }
    }
}