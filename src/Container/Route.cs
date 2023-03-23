using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    class Route {
        // private section
        private List<Coordinate> routes;
        private List<Coordinate> visitedTreasure;
        private int numsTreasure;
        private int length;
        private Coordinate currentCoordinate;
        private MatrixNode matrixVisit;

        // public section
        // constructor
        public Route() {
            this.numsTreasure = 0;
            this.length = 0;
            this.routes = new List<Coordinate>();
            this.visitedTreasure = new List<Coordinate>();
            this.currentCoordinate = new Coordinate();
            this.matrixVisit = new MatrixNode();
        }

        public Route(MatrixNode maze) {
            this.numsTreasure = 0;
            this.length = 0;
            this.routes = new List<Coordinate>();
            this.visitedTreasure = new List<Coordinate>();
            this.currentCoordinate = maze.getStart();
            this.matrixVisit = maze;
        }

        // getter
        public int getNumsTreasure() {
            return this.numsTreasure;
        }

        public Coordinate getCurrentCoordinate() {
            return this.currentCoordinate;
        }
        
        public int getRouteLength() {
            return this.length;
        }

        public List<Coordinate> getRoutes() {
            return this.routes;
        }

        public Coordinate getRoutesTop() {
            return this.routes[this.length - 1];
        }

        public int getRoutesTopX() {
            return this.routes[this.length - 1].getX();
        }

        public int getRoutesTopY() {
            return this.routes[this.length - 1].getY();
        }

        public int getNumsCoordinateVisited(Coordinate coord) {
            return this.matrixVisit.getVisitedTime(coord);
        }

        public void addNumsTreasure(Coordinate treasurePoint) {
            this.numsTreasure++;
            this.visitedTreasure.Add(treasurePoint);
        }

        public bool isTreasureVisited(Coordinate treasurePoint) {
            for (int i = 0; i < this.visitedTreasure.Count; i++) {
                if (this.visitedTreasure[i].getX() == treasurePoint.getX() && this.visitedTreasure[i].getY() == treasurePoint.getY()) {
                    return true;
                }
            }
            return false;
        }

        public void addElement(Coordinate coord) {
            this.routes.Add(coord);
            this.currentCoordinate = coord;
            this.matrixVisit.visitCoordinate(coord);
            this.length++;
        }

        public void copyRoute(Route oldRoutes) {
            this.length = oldRoutes.getRouteLength();
            this.numsTreasure = oldRoutes.getNumsTreasure();
            this.routes = new List<Coordinate>();
            for (int i = 0; i < getRouteLength(); i++) {
                this.routes.Add(oldRoutes.routes[i]);
            }
            this.visitedTreasure = new List<Coordinate>();
            for (int i = 0; i < oldRoutes.visitedTreasure.Count; i++) {
                this.visitedTreasure.Add(oldRoutes.visitedTreasure[i]);
            }
            this.currentCoordinate = oldRoutes.getCurrentCoordinate();
            this.matrixVisit = oldRoutes.matrixVisit;
        }

        public List<String> getSequenceOfDirection() {
            List<String> sequence = new List<String>();
            for (int i = 0; i < getRouteLength() - 1; i++) {
                if (this.routes[i+1].getX() > this.routes[i].getX()) {
                    sequence.Add("D");
                } else if (this.routes[i+1].getX() < this.routes[i].getX()) {
                    sequence.Add("U");
                } else if (this.routes[i+1].getY() > this.routes[i].getY()) {
                    sequence.Add("R");
                } else {
                    sequence.Add("L");
                }
            }
            return sequence;
        }
    }
}