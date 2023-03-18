using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    class Route {
        // private section
        private Coordinate[] routes;
        private int numsTreasure;
        private int length;

        // public section
        // constructor
        public Route() {
            this.numsTreasure = 0;
            this.length = 0;
            this.routes = new Coordinate[this.length];
        }

        // getter
        public int getNumsTreasure() {
            return this.numsTreasure;
        }
        
        public void addNumsTreasure() {
            this.numsTreasure++;
        }

        public int getRouteLength() {
            return this.length;
        }

        public Coordinate getRoutesElement(int idx) {
            return this.routes[idx];
        }

        public void addElement(Coordinate coord) {
            this.routes.Append(coord);
            this.length++;
        }

        public void copyRoute(Route oldRoutes) {
            this.length = oldRoutes.getRouteLength();
            this.numsTreasure = oldRoutes.getNumsTreasure();
            this.routes = new Coordinate[this.length];
            for (int i = 0; i < getRouteLength(); i++) {
                this.routes[i] = oldRoutes.getRoutesElement(i);
            }
        }
    }
}