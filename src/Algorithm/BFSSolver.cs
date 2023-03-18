using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Container;

namespace TreasureHunt.Algorithm {
    class BFSSolver {
        private MatrixNode maze;
        private Coordinate currentLoc;
        private Queue<Coordinate[]> queueCoordinate;
        private int treasureCollected;

        // constructor
        BFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.queueCoordinate = new Queue<Coordinate[]>();
            this.treasureCollected = 0;
        }

        BFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.queueCoordinate = new Queue<Coordinate[]>();
            this.treasureCollected = 0;
        }

        public void solve() {
            Coordinate[] route = new Coordinate[0];
            route.Append(this.currentLoc);
            this.queueCoordinate.Enqueue(route);
            while (this.treasureCollected != this.maze.getTreasure()) {
                route = this.queueCoordinate.Dequeue();
                foreach (Coordinate coords in this.maze.expandWithBFS(this.currentLoc)) {
                    this.currentLoc = coords;
                    if (this.maze.isTreasure(this.currentLoc) && !this.maze.isVisited(this.currentLoc)) {
                        this.treasureCollected++;
                    }
                    // insert back to queue
                    this.maze.visitCoordinate(this.currentLoc);
                    route.Append(this.currentLoc);
                    this.queueCoordinate.Enqueue(route);
                }
            }
        }
    }
}
