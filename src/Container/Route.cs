using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    // Kelas Route
    class Route {
        // Atribut kelas
        private List<Coordinate> routes;            // Rute senarai koordinat
        private List<Coordinate> visitedTreasure;   // Senarai penampung koordinat treasure
        private int numsTreasure;                   // Jumlah treasure
        private int length;                         // Panjang rute
        private Coordinate currentCoordinate;       // Koordinat rute saat ini

        // Metode kelas
        // 1. Konstruktor objek route (default)
        public Route() {
            this.numsTreasure = 0;
            this.length = 0;
            this.routes = new List<Coordinate>();
            this.visitedTreasure = new List<Coordinate>();
            this.currentCoordinate = new Coordinate();
        }

        // 2. Getter atribut numsTreasure
        public int getNumsTreasure() {
            return this.numsTreasure;
        }

        // 3. Getter atribut currentCoordinate
        public Coordinate getCurrentCoordinate() {
            return this.currentCoordinate;
        }

        // 4. Getter atribut length
        public int getRouteLength() {
            return this.length;
        }

        // 5. Getter atribut routes
        public List<Coordinate> getRoutes() {
            return this.routes;
        }

        // 6. Getter nilai elemen terakhir dari routes
        public Coordinate getRoutesTop() {
            return this.routes[this.length - 1];
        }

        // 7. Getter nilai absis elemen terakhir dari routes
        public int getRoutesTopX() {
            return this.routes[this.length - 1].getX();
        }

        // 8. Getter nilai ordinat elemen terakhir dari routes
        public int getRoutesTopY() {
            return this.routes[this.length - 1].getY();
        }
        
        // 9. Menambahkan jumlah treasure yang telah dikunjungi
        // menambahkan koordinat lokasi treasure yang telah dikunjungi
        public void addNumsTreasure(Coordinate treasurePoint) {
            this.numsTreasure++;
            this.visitedTreasure.Add(treasurePoint);
        }

        // 10. melakukan traversal terhadap isi senarai hingga ditemukan 
        // Coordinate di dalam list atau tidak ditemukan
        public bool isTreasureVisited(Coordinate treasurePoint) {
            for (int i = 0; i < this.visitedTreasure.Count; i++) {
                if (this.visitedTreasure[i].getX() == treasurePoint.getX() && this.visitedTreasure[i].getY() == treasurePoint.getY()) {
                    return true;
                }
            }
            return false;
        }

        // 11. Menambahkan Coordinate pada List of Coordinate visitedTreasure
        public void addElement(Coordinate coord) {
            this.routes.Add(coord);
            this.currentCoordinate = coord;
            this.length++;
        }

        // 12. Menyalin seluruh atribut rute dari route1 ke route2
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
        }

        // 13. Mengembalikan sekuens karakter arah dari setiap langkah dari awal 
        // pencarian hingga tiba di tujuan
        public List<String> getSequenceOfDirection() {
            List<String> sequence = new List<String>();
            for (int i = 0; i < getRouteLength() - 1; i++) {
                if (this.routes[i + 1].getX() > this.routes[i].getX()) {
                    sequence.Add("D");
                } else if (this.routes[i + 1].getX() < this.routes[i].getX()) {
                    sequence.Add("U");
                } else if (this.routes[i + 1].getY() > this.routes[i].getY()) {
                    sequence.Add("R");
                } else {
                    sequence.Add("L");
                }
            }
            return sequence;
        }
    }
}