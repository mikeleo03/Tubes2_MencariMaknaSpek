using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Container;
using System.Timers;
using System.Diagnostics;

namespace TreasureHunt.Algorithm {
    // Kelas DFSSolver
    class DFSSolver {
        // Atribut kelas
        private MatrixNode maze;        // Matriks pencarian harta karun
        private Coordinate currentLoc;  // Posisi saat ini
        private Coordinate[] route;     // Rute pencarian
        private int treasureCollected;  // Jumlah harta karun yang diperoleh

        // Meode kelas
        // 1. Konstruktor objek DFSSolver
        public DFSSolver() {
            this.maze = new MatrixNode();
            this.currentLoc = new Coordinate();
            this.route = new Coordinate[0];
            this.treasureCollected = 0;
        }

        // 2. Getter atribur route
        public Coordinate[] getRoute() {
            return this.route;
        }

        // 3. Melakukan parsing file untuk atribut MatrixNode
        public void fillMaze(String fileName) {
            this.maze.fillMatrix(fileName);
            this.currentLoc = this.maze.getStart();
        }

        // 4. mengembalikan list of boolean yang menunjukkan apakah tetangga simpul aktif
        // dapat dikunjungi atau tidak. Urutan simpul mengikuti prioritas ULDR
        public bool[] checkNeighbourNode() {
            bool[] neighbourNode = { false, false, false, false };

            if (this.maze.isCoordinateValid(this.currentLoc.moveUp())) {
                neighbourNode[0] = this.maze.isCoordinatePassable(this.currentLoc.moveUp());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveLeft())) {
                neighbourNode[1] = this.maze.isCoordinatePassable(this.currentLoc.moveLeft());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveDown())) {
                neighbourNode[2] = this.maze.isCoordinatePassable(this.currentLoc.moveDown());
            }
            if (this.maze.isCoordinateValid(this.currentLoc.moveRight())) {
                neighbourNode[3] = this.maze.isCoordinatePassable(this.currentLoc.moveRight());
            }

            return neighbourNode;
        }

        // 5. Mengembalikan list of int yang menunjukkan jumlah kunjungan tetangga simpul
        // aktif. Jika tetangga tidak dapat dikunjungi, maka jumlah kunjungan = -1. 
        // Urutan mengikuti prioritas ULDR
        public int[] checkNeighbourNodeVisits(bool[] visitable) {
            int[] visitList = { -1, -1, -1, -1 };

            visitList[0] = visitable[0] ? this.maze.getVisitedTime(this.currentLoc.moveUp()) : -1;
            visitList[1] = visitable[1] ? this.maze.getVisitedTime(this.currentLoc.moveLeft()) : -1;
            visitList[2] = visitable[2] ? this.maze.getVisitedTime(this.currentLoc.moveDown()) : -1;
            visitList[3] = visitable[3] ? this.maze.getVisitedTime(this.currentLoc.moveRight()) : -1;

            return visitList;
        }

        // 6. Mengembalikan koordinat simpul yang akan dikunjungi selanjutnya oleh 
        // algoritma DFS
        public Coordinate expandWithDFS() {
            Coordinate[] neighbour = { this.currentLoc.moveUp(), this.currentLoc.moveLeft(), this.currentLoc.moveDown(), this.currentLoc.moveRight() };

            bool[] visitable = checkNeighbourNode();
            int[] visitList = checkNeighbourNodeVisits(visitable);

            int idx = 0;
            for (int i = 1; i < 4; i++) {
                if (visitList[idx] == -1) {
                    idx = i;
                } else {
                    idx = visitList[i] < visitList[idx] && visitList[i] != -1 ? i : idx;
                }
            }

            return neighbour[idx];
        }

        // 7. melakukan prosedur mengunjungi simpul aktif. Jika flag tidak sama dengan 0
        // maka jumlah harta karun yang didapat tidak akan naik meskipun simpul aktif
        // adalah sebuah harta karun
        public void visitCurrentLocation(int flag) {
            if (flag == 0) {
                if (this.maze.isTreasure(this.currentLoc) && !this.maze.isVisited(this.currentLoc)) {
                    this.treasureCollected++;
                }
            }
            this.maze.visitCoordinate(this.currentLoc);
        }

        // 8. Melakukan algoritma DFS untuk mencari seluruh harta karun
        public void solve() {
            visitCurrentLocation(0);
            while (this.treasureCollected != this.maze.getTreasure()) {
                this.route = this.route.Append(this.currentLoc).ToArray();
                this.currentLoc = expandWithDFS();
                visitCurrentLocation(0);
            }
            this.route = this.route.Append(this.currentLoc).ToArray();
        }

        // 9. Melakukan algoritma DFS untuk mencari seluruh harta karun dan kembali ke
        // Krusty Krab
        public void solveAndTSP() {
            solve();
            this.maze.clearVisits();
            visitCurrentLocation(1);
            while (!(this.currentLoc.getX() == this.maze.getStart().getX() && this.currentLoc.getY() == this.maze.getStart().getY())) {
                this.currentLoc = expandWithDFS();
                visitCurrentLocation(1);
                this.route = this.route.Append(this.currentLoc).ToArray();
            }
        }

        // 10. mengubah rute solusi pencarian menjadi urutan-urutan arah untuk melakukan
        // rute solusi
        public String[] getSequenceOfDirection() {
            String[] sequence = new String[0];
            for (int i = 0; i < this.route.Length-1; i++) {
                if (this.route[i+1].getX() > this.route[i].getX()) {
                    sequence = sequence.Append("D").ToArray();
                } else if (this.route[i+1].getX() < this.route[i].getX()) {
                    sequence = sequence.Append("U").ToArray();
                } else if (this.route[i+1].getY() > this.route[i].getY()) {
                    sequence = sequence.Append("R").ToArray();
                } else {
                    sequence = sequence.Append("L").ToArray();
                }
            }
            
            return sequence;
        }
    }
}