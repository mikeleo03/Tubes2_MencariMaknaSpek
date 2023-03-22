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
        private Queue<Route> queueRouteTSP;
        private Route finalRoute;
        private Route finalRouteTSP;
        private List<Route> sequenceOfRoute;

        // constructor
        public BFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.queueRoute = new Queue<Route>();
            this.queueRouteTSP = new Queue<Route>();
            this.finalRoute = new Route();
            this.finalRouteTSP = new Route();
            this.sequenceOfRoute = new List<Route>();
        }

        public BFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.queueRoute = new Queue<Route>();
            this.queueRouteTSP = new Queue<Route>();
            this.finalRoute = new Route();
            this.finalRouteTSP = new Route();
            this.sequenceOfRoute = new List<Route>();
        }

        public List<Route> getSequence() {
            return this.sequenceOfRoute;
        }

        public Route getFinalRoute() {
            return this.finalRoute;
        }

        // expand coordinate with bfs rules
        public List<Coordinate> expandWithBFS(int flag) {
            List<Coordinate> neighborNode = new List<Coordinate>();
            List<int> visitList = new List<int>();
            int count = 0;
            
            // Validate expand paths
            if (flag == 1) {
                if (this.maze.isCoordinateValid(this.currentLoc.moveUp())) {  // UP
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveUp())) {
                        Coordinate temp1 = this.currentLoc.moveUp();
                        neighborNode.Add(temp1);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveUp()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveLeft())) {  // LEFT
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveLeft())) {
                        Coordinate temp4 = this.currentLoc.moveLeft();
                        neighborNode.Add(temp4);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveLeft()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveDown())) {  // DOWN
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveDown())) {
                        Coordinate temp3 = this.currentLoc.moveDown();
                        neighborNode.Add(temp3);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveDown()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveRight())) {  // RIGHT
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveRight())) {
                        Coordinate temp2 = this.currentLoc.moveRight();
                        neighborNode.Add(temp2);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveRight()));
                        count++;
                    }
                }
            } else {
                if (this.maze.isCoordinateValid(this.currentLoc.moveRight())) {  // RIGHT
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveRight())) {
                        Coordinate temp2 = this.currentLoc.moveRight();
                        neighborNode.Add(temp2);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveRight()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveDown())) {  // DOWN
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveDown())) {
                        Coordinate temp3 = this.currentLoc.moveDown();
                        neighborNode.Add(temp3);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveDown()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveLeft())) {  // LEFT
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveLeft())) {
                        Coordinate temp4 = this.currentLoc.moveLeft();
                        neighborNode.Add(temp4);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveLeft()));
                        count++;
                    }
                }
                if (this.maze.isCoordinateValid(this.currentLoc.moveUp())) {  // UP
                    if (this.maze.isCoordinatePassable(this.currentLoc.moveUp())) {
                        Coordinate temp1 = this.currentLoc.moveUp();
                        neighborNode.Add(temp1);
                        visitList.Add(this.maze.getVisitedTime(this.currentLoc.moveUp()));
                        count++;
                    }
                }
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
                    this.finalRoute.copyRoute(routes);
                    break;
                }
            }
            return temp;
        }

        public bool isSearchTSPDone() {
            bool temp = false;
            foreach (Route routes in this.queueRouteTSP) {
                if (routes.getCurrentCoordinate().getX() == this.maze.getStart().getX() && routes.getCurrentCoordinate().getY() == this.maze.getStart().getY()) {
                    temp = true;
                    this.finalRouteTSP.copyRoute(routes);
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
            this.sequenceOfRoute.Add(initial_route);
            
            // while not node
            while (!isSearchDone()) {
                initial_route = this.queueRoute.Dequeue();
                this.currentLoc = initial_route.getRoutesTop();
                foreach (Coordinate coords in expandWithBFS(1)) {
                    Route tempRoute = new Route();
                    tempRoute.copyRoute(initial_route);
                    this.currentLoc = coords;
                    if (this.maze.isTreasure(this.currentLoc) && !tempRoute.isTreasureVisited(this.currentLoc)) {
                        tempRoute.addNumsTreasure(this.currentLoc);
                    }

                    this.maze.visitCoordinate(this.currentLoc);
                    tempRoute.addElement(this.currentLoc);
                    this.queueRoute.Enqueue(tempRoute);
                    this.sequenceOfRoute.Add(tempRoute);
                }
            }
        }

        public void solveAndTSP() {
            solve();
            this.maze.clearVisits();
            Route initial_route = new Route();
            initial_route.copyRoute(this.finalRoute);
            this.maze.visitCoordinate(this.currentLoc);
            this.queueRouteTSP.Enqueue(initial_route);
            this.sequenceOfRoute.Add(initial_route);

            while(!isSearchTSPDone()) {
                initial_route = this.queueRouteTSP.Dequeue();
                this.currentLoc = initial_route.getRoutesTop();
                foreach (Coordinate coords in expandWithBFS(2)) {
                    Route tempRoute = new Route();
                    tempRoute.copyRoute(initial_route);
                    this.currentLoc = coords;
                    
                    this.maze.visitCoordinate(this.currentLoc);
                    tempRoute.addElement(this.currentLoc);
                    this.queueRouteTSP.Enqueue(tempRoute);
                    this.sequenceOfRoute.Add(tempRoute);
                }
            }
        }
    }
}