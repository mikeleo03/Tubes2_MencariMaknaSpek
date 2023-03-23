using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.IO;

namespace TreasureHunt.Container {
    // Kelas MatrixNode
    class MatrixNode {
        // Atribut kelas
        private Node[,] map;        // Peta yang berisi kumpulan node
        private Coordinate start;   // Koordinat mulai jelajah
        private int row;            // Bnyak baris
        private int col;            // Banyak kolom
        private int numOfTreasure;  // Jumlah treasure

        // Metode kelas
        // 1. Konstruktor objek matrixnode (default)
        public MatrixNode() {
            this.map = new Node[0, 0];
            this.start = new Coordinate();
            this.row = -1;
            this.col = -1;
            this.numOfTreasure = 0;
        }

        // 2. Getter atribut row
        public int getRow() {
            return this.row;
        }

        // 3. Getter atribut col
        public int getCol() {
            return this.col;
        }
        
        // 4. Getter atribut start
        public Coordinate getStart() {
            return this.start;
        }

        // 5. Getter atribut numOfTreasure
        public int getTreasure() {
            return this.numOfTreasure;
        }

        // 6. Mengembalikan jumlah kunjungan pada simpul dengan koordinat test
        public int getVisitedTime(Coordinate test) {
            return this.map[test.getX(), test.getY()].getVisitedTime();
        }

        // 7. Mengubah jumlah kunjungan semua simpul pada peta menjadi 0
        public void clearVisits() {
            for (int i = 0; i < this.row; i++) {
                for (int j = 0; j < this.col; j++) {
                    this.map[i, j].reset();
                }
            }
        }

        // 8. Menginisiasi seluruh atribut objek MatrixNode sesuai hasil parsing file
        public void fillMatrix(string fileName) {
            Parser parser = new Parser(fileName);
            this.map = parser.parseAndFill();
            this.start = parser.getStart();
            this.row = parser.getRow();
            this.col = parser.getCol();
            this.numOfTreasure = parser.getTreasure();
        }

        // 9. mengembalikan true jika test valid sebagai koordinat pada matriks
        // false jika tidak
        public bool isCoordinateValid(Coordinate test) {
            return test.getX() >= 0 && test.getX() < this.row && test.getY() >= 0 && test.getY() < this.col;
        }

        // 10. Mengembalikan true jika simpul dengan koordinat test tidak memiliki 
        // simbol berupa simbol X, false jika tidak
        public bool isCoordinatePassable(Coordinate test) {
            return this.map[test.getX(), test.getY()].getType() != 'X';
        }

        // 11. mengembalikan true jika simpul dengan koordinat test memiliki simbol
        // berupa simbol T, false jika tidak
        public bool isTreasure(Coordinate test) {
            return this.map[test.getX(), test.getY()].getType() == 'T';
        }

        // 12. mengembalikan true jika simpul dengan koordinat test sudah pernah
        // dikunjungi setidaknya satu kali, false jika tidak
        public bool isVisited(Coordinate test) {
            return this.map[test.getX(), test.getY()].getVisitedTime() > 0;
        }

        // 13. Menaikkan jumlah kunjungan pada simpul dengan koordinat test sebesar 1
        public void visitCoordinate(Coordinate test) {
            this.map[test.getX(), test.getY()].visit();
        }

        // 14. Mengubah setiap baris pada simpul menjadi suatu string berisi simbol simpul
        public string[] convertToStringArray() {
            string[] lines = new string[0];
            string line;

            for (int i = 0; i < this.row; i++) {
                line = "";
                for (int j = 0; j < this.col-1; j++) {
                    line += this.map[i, j].getType() + " ";
                }
                line += this.map[i, this.col - 1].getType();
                lines = lines.Append(line).ToArray();
            }
            
            return lines;
        }
    }
}