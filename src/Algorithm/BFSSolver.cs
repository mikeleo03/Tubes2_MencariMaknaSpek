using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Container;

namespace TreasureHunt.Algorithm {
    // Kelas BFSSolver
    class BFSSolver {
        // Atribut kelas
        private MatrixNode maze;                // Matriks pencarian harta karun
        private Coordinate currentLoc;          // Posisi saat ini
        private Queue<Route> queueRoute;        // Antrian rute biasa
        private Queue<Route> queueRouteTSP;     // Antrian rute dengan TSP
        private Route finalRoute;               // Rute akhir pecarian
        private Route finalRouteTSP;            // Rute akhir pencarian dengan TSP
        private List<Route> sequenceOfRoute;    // Senarai penampung urutan rute

        // Metode kelas
        // 1. Konstruktor objek BFSSolver (default)
        public BFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.queueRoute = new Queue<Route>();
            this.queueRouteTSP = new Queue<Route>();
            this.finalRoute = new Route();
            this.finalRouteTSP = new Route();
            this.sequenceOfRoute = new List<Route>();
        }

        // 2. Konstruktor objek BFSSolver
        public BFSSolver(MatrixNode maze) {
            this.maze = maze;
            this.currentLoc = maze.getStart();
            this.queueRoute = new Queue<Route>();
            this.queueRouteTSP = new Queue<Route>();
            this.finalRoute = new Route();
            this.finalRouteTSP = new Route();
            this.sequenceOfRoute = new List<Route>();
        }

        // 3. Getter atribut sequenceOfRoute
        public List<Route> getSequence() {
            return this.sequenceOfRoute;
        }

        // 4. Getter atribut finalRoute
        public Route getFinalRoute() {
            return this.finalRoute;
        }
        
        // 5. Getter atribut finalRouteTSP
        public Route getFinalRouteTSP() { 
            return this.finalRouteTSP; 
        }

        // 6. melakukan pencarian simpul jelajah dengan algoritma BFS
        // menggunakan skema penentuan simpul jelajah yang dibahas pada bagian
        // langkah-langkah.
        public List<Coordinate> expandWithBFS(int flag) {
            List<Coordinate> neighborNode = new List<Coordinate>();
            List<int> visitList = new List<int>();
            int count = 0;

            // Validasi arah ekspan
            if (flag == 1) {
                // BFS biasa - Prioritas : ULDR
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
                // BFS dengan TSP - Prioritas : RDLU
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

            // Seleksi jika terdapat node dengan jumlah yang dikunjungi lebih dari nilai minimum
            if (count > 1) {
                int min = visitList[0];
                int totals = 0;
                // Melakukan iterasi sepanjang senarai ekspan
                for (int i = 1; i < count; i++) {
                    int temp = visitList[i];
                    if (min > temp) {
                        min = temp;
                        totals = 0;
                    } else if (min == temp) {
                        totals++;
                    }
                }

                // Jika terdapat yang lebih, eliminasi
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

        // 7. melakukan analisis apakah proses pencarian telah selesai dilakukan
        // dalam hal ini, terdapat rute yang memiliki jumlah harta karun sama dengan
        // jumlah harta karun dalam peta
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

        // 8. melakukan analisis apakah proses pencarian TSP telah selesai dilakukan
        // dalam hal ini, terdapat posisi koordinat akhir rute sudah tiba pada titik
        // awal pencarian dimulai
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

        // 9. Menyelesaikan dengan algoritma BFS
        public void solve() {
            Route initial_route = new Route();
            initial_route.addElement(this.currentLoc);
            this.maze.visitCoordinate(this.currentLoc);
            this.queueRoute.Enqueue(initial_route);
            this.sequenceOfRoute.Add(initial_route);

            // selama pencarian belum selesai dilakukan
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

        // 10. Menyelesaikan dengan algoritma BFS lengkap dengan skema TSP
        public void solveAndTSP() {
            solve();
            this.maze.clearVisits();
            Route initial_route = new Route();
            initial_route.copyRoute(this.finalRoute);
            this.maze.visitCoordinate(this.currentLoc);
            this.queueRouteTSP.Enqueue(initial_route);
            this.sequenceOfRoute.Add(initial_route);

            while (!isSearchTSPDone()) {
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