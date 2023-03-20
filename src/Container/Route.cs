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

        // public section
        // constructor
        public Route() {
            this.routes = new List<Coordinate>();
            this.visitedTreasure = new List<Coordinate>();
            this.numsTreasure = 0;
            this.length = 0;
        }

        // getter
        public int getNumsTreasure() {
            return this.numsTreasure;
        }

        public int getRouteLength() {
            return this.length;
        }

        public int getRoutesTopX() {
            return this.routes[this.length - 1].getX();
        }

        public int getRoutesTopY() {
            return this.routes[this.length - 1].getY();
        }

        public Coordinate getRoutesTop() {
            return this.routes[this.length - 1];
        }

        // methods
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
        }

        public void printPath() {
            for (int i = 0; i < getRouteLength(); i++) {
                Console.WriteLine($"pathhh: \t({routes[i].getX()}, {routes[i].getY()}) -");
            }
        }
    }
}