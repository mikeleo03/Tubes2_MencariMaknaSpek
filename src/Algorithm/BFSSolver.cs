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
        private Queue<Route> queueRoute;

        // constructor
        BFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.queueRoute = new Queue<Route>();
        }

        BFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.queueRoute = new Queue<Route>();
        }

        // expand coordinate with bfs rules
        public Coordinate[] expandWithBFS() {
            Coordinate[] neighborNode = new Coordinate[0];
            int[] visitList = new int[0];
            int count = 0;
            
            // Validate expand paths
            if (this.maze.isCoordinateValid(this.currentLoc.moveUp()) && this.maze.isCoordinatePassable(this.currentLoc.moveUp())) {  // UP
                Coordinate temp1 = this.currentLoc.moveUp();
                neighborNode.Append(temp1);
                visitList.Append(this.maze.getVisitedTime(this.currentLoc.moveUp()));
                count++;
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveRight()) && this.maze.isCoordinatePassable(this.currentLoc.moveRight())) {  // RIGHT
                Coordinate temp2 = this.currentLoc.moveRight();
                neighborNode.Append(temp2);
                visitList.Append(this.maze.getVisitedTime(this.currentLoc.moveRight()));
                count++;
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveDown()) && this.maze.isCoordinatePassable(this.currentLoc.moveDown())) {  // DOWN
                Coordinate temp3 = this.currentLoc.moveDown();
                neighborNode.Append(temp3);
                visitList.Append(this.maze.getVisitedTime(this.currentLoc.moveDown()));
                count++;
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveLeft()) && this.maze.isCoordinatePassable(this.currentLoc.moveLeft())) {  // LEFT
                Coordinate temp4 = this.currentLoc.moveLeft();
                neighborNode.Append(temp4);
                visitList.Append(this.maze.getVisitedTime(this.currentLoc.moveLeft()));
                count++;
            }

            // If tovisit more than 1, then filters by order less-visited
            if (count > 1) {
                int max = visitList[0];
                int totals = 0;
                // iterate over
                for (int i = 1; i < count; i++) {
                    int temp = visitList[i];
                    if (max < temp) {
                        max = temp;
                        totals = 0;
                    } else if (max == temp) {
                        totals++;
                    }
                }

                if (totals < count) {
                    neighborNode = neighborNode.Where(nodes => this.maze.getVisitedTime(nodes) < max).ToArray();
                }
            }
            
            return neighborNode;
        }

        public bool isSearchDone() {
            bool temp = false;
            foreach (Route routes in this.queueRoute) {
                if (routes.getNumsTreasure() == this.maze.getTreasure()) {
                    temp = true;
                    break;
                }
            }
            return temp;
        }

        public void solve() {
            Route initial_route = new Route();
            initial_route.addElement(this.currentLoc);
            this.queueRoute.Enqueue(initial_route);
            
            // while not node
            while (!isSearchDone()) {
                initial_route = this.queueRoute.Dequeue();
                foreach (Coordinate coords in expandWithBFS()) {
                    Route tempRoute = new Route();
                    tempRoute.copyRoute(initial_route);
                    this.currentLoc = coords;
                    if (this.maze.isTreasure(this.currentLoc)) {
                        tempRoute.addNumsTreasure();
                    }

                    this.maze.visitCoordinate(this.currentLoc);
                    tempRoute.addElement(this.currentLoc);
                    this.queueRoute.Enqueue(tempRoute);
                }
            }
        }
    }
}
