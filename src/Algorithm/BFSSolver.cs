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
        public BFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.queueRoute = new Queue<Route>();
        }

        public BFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.queueRoute = new Queue<Route>();
        }

        // expand coordinate with bfs rules
        public List<Coordinate> expandWithBFS() {
            List<Coordinate> neighborNode = new List<Coordinate>();
            List<int> visitList = new List<int>();
            int count = 0;
            
            // Validate expand paths
            if (this.maze.isCoordinatePassable(this.currentLoc.moveUp())) {  // UP
                Coordinate temp1 = this.currentLoc.moveUp();
                neighborNode.Add(temp1);
                visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveUp()));
                count++;
            }
            if (this.maze.isCoordinatePassable(this.currentLoc.moveRight())) {  // RIGHT
                Coordinate temp2 = this.currentLoc.moveRight();
                neighborNode.Add(temp2);
                visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveRight()));
                count++;
            }
            if (this.maze.isCoordinatePassable(this.currentLoc.moveDown())) {  // DOWN
                Coordinate temp3 = this.currentLoc.moveDown();
                neighborNode.Add(temp3);
                visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveDown()));
                count++;
            }
            if (this.maze.isCoordinatePassable(this.currentLoc.moveLeft())) {  // LEFT
                Coordinate temp4 = this.currentLoc.moveLeft();
                neighborNode.Add(temp4);
                visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveLeft()));
                count++;
            }

            // If tovisit more than 1, then filters by order less-visited
            if (count > 1) {
                int min = visitList[0];
                int totals = 0;
                // iterate over
                for (int i = 1; i < count; i++) {
                    int temp = visitList[i];
                    if (min > temp) {
                        min = temp;
                        totals = 0;
                    } else if (min == temp) {
                        totals++;
                    }
                }

                if (totals < count) {
                    for (int i = neighborNode.Count() - 1; i >= 0; i--) {
                        if (visitList[i] > min) {
                            neighborNode.RemoveAt(i);
                        }
                    }
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
            this.maze.visitCoordinate(this.currentLoc);
            this.queueRoute.Enqueue(initial_route);
            
            // while not node
            while (!isSearchDone()) {
                initial_route = this.queueRoute.Dequeue();
                this.currentLoc = initial_route.getRoutesTop();
                foreach (Coordinate coords in expandWithBFS()) {
                    Route tempRoute = new Route();
                    tempRoute.copyRoute(initial_route);
                    this.currentLoc = coords;
                    if (this.maze.isTreasure(this.currentLoc) && !tempRoute.isTreasureVisited(this.currentLoc)) {
                        tempRoute.addNumsTreasure(this.currentLoc);
                    }

                    this.maze.visitCoordinate(this.currentLoc);
                    tempRoute.addElement(this.currentLoc);
                    this.queueRoute.Enqueue(tempRoute);
                }
            }
        }
    }
}