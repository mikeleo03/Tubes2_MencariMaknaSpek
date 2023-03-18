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

        public DFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.route = new Coordinate[0];
            this.treasureCollected = 0;
        }

        // expand current location to the next location 
        // because the node can be visited again, there is no backtracking can be done with dfs
        public bool[] checkNeighbourNode() {
            bool[] neighbourNode = {true, true, true, true};

            neighbourNode[0] = this.maze.isCoordinateValid(this.currentLoc.moveUp()) && this.maze.isCoordinatePassable(this.currentLoc.moveUp()) ? true : false;
            neighbourNode[1] = this.maze.isCoordinateValid(this.currentLoc.moveRight()) && this.maze.isCoordinatePassable(this.currentLoc.moveRight()) ? true : false;
            neighbourNode[2] = this.maze.isCoordinateValid(this.currentLoc.moveDown()) && this.maze.isCoordinatePassable(this.currentLoc.moveDown()) ? true : false;
            neighbourNode[3] = this.maze.isCoordinateValid(this.currentLoc.moveLeft()) && this.maze.isCoordinatePassable(this.currentLoc.moveLeft()) ? true : false;

            return neighbourNode;
        }

        public int[] checkNeighbourNodeVisits(bool[] visitable) {
            int[] visitList = {-1, -1, -1, -1};

            visitList[0] = visitable[0] ? this.maze.getVisitedTime(this.currentLoc.moveUp()) : -1;
            visitList[1] = visitable[1] ? this.maze.getVisitedTime(this.currentLoc.moveRight()) : -1;
            visitList[2] = visitable[2] ? this.maze.getVisitedTime(this.currentLoc.moveDown()) : -1;
            visitList[3] = visitable[3] ? this.maze.getVisitedTime(this.currentLoc.moveLeft()) : -1;

            return visitList;
        }

        public Coordinate expandWithDFS() {
            Coordinate[] neighbour = { this.currentLoc.moveUp(), this.currentLoc.moveRight(), this.currentLoc.moveDown(), this.currentLoc.moveLeft() };

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
            while (this.treasureCollected != this.maze.getTreasure()) {
                this.route.Append(this.currentLoc).ToArray();
                this.currentLoc = expandWithDFS();
                visitCurrentLocation();
            }
        }
    }
}