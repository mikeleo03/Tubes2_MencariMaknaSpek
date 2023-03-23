using System;
using TreasureHunt.Container;

namespace TreasureHunt.IO {
    // Kelas Parser
    class Parser {
        // Atribut kelas
        public Node[,] map;             // Matriks node penyimpan peta
        private string fileName;        // Nama file
        private int row;                // Jumlah baris
        private int col;                // Jumlah kolom
        private int i;                  // Iterator baris
        private int j;                  // Iterator kolom
        private int startPoint;         // Titik mulai
        private Coordinate startLoc;    // Lokasi titik mulai
        private int treasure;           // Jumlah harta karun

        // Metode kelas
        // 1. Konstruktor objek parser (default)
        public Parser() {
            this.map = new Node[0,0];
            this.fileName = string.Empty;
            this.row = 0;
            this.col = 0;
            this.i = 0;
            this.j = 0;
            this.startPoint = 0;
            this.startLoc = new Coordinate();
            this.treasure = 0;
        } 

        // 2. Konstruktor objek parser
        public Parser(string fileName) {
            this.map = new Node[0,0];
            this.fileName = fileName;
            this.row = 1;
            this.col = 1;
            this.i = 0;
            this.j = 0;
            this.startPoint = 0;
            this.startLoc = new Coordinate();
            this.treasure = 0;
        }

        // 3. Getter atribut row
        public int getRow() {
            return this.row;
        }

        // 4. Getter atribut col
        public int getCol() {
            return this.col;
        }

        // 5. Getter atribut treasure
        public int getTreasure() {
            return this.treasure;
        }

        // 6. Getter atribut startLoc
        public Coordinate getStart() {
            return this.startLoc;
        }

        // 7. Melemparkan exception jika col tidak sama dengan kolom mula-mula peta
        public void checkColumnInRow(int col) {
            if (col != this.col) {
                throw new Exception("Number of column is not same");
            }
        }

        // 8. Melemparkan exception jika s tidak sesuai dengan simbol T, R, X, atau K
        public void checkCharacterValidity(string s) {
            if (!(s == "K" || s == "X" || s == "R" || s == "T")) {
                throw new Exception("Character in file cannot be defined");
            }
        }

        // 9. Mengubah atribut objek Parser tergantung pada c, jika terdapat 2 simbol K
        // yang muncul, maka akan melemparkan exception
        public void processCharacter(char c) {
            if (c == 'T') {
                this.treasure++;
            } else if (c == 'K') {
                this.startPoint++;
                if (this.startPoint == 1) {
                    this.startLoc = new Coordinate(this.i, this.j);
                }
                if (this.startPoint > 1) {
                    throw new Exception("There is too many start point");
                }
            }
        }

        // 10. Mengembalikan matriks simpul hasil parsing
        public Node[,] parseAndFill() {
            string[] lines = System.IO.File.ReadAllLines(this.fileName);
            if (lines.Length == 0) {
                throw new Exception("File empty");
            }

            this.row = lines.Length;
            this.col = lines[0].Split(' ').Length;
            this.map = new Node[this.row, this.col];

            foreach (string line in lines) {
                this.j = 0;
                string[] temp = line.Split(' ');
                checkColumnInRow(temp.Length);
                foreach (string character in temp) {
                    checkCharacterValidity(character);
                    processCharacter(character[0]);
                    if (character[0] != 'X') {
                        this.map[i, j] = new Node(character[0], this.i, this.j, 0);
                    } else {
                        this.map[i, j] = new Node(character[0], this.i, this.j, -1);
                    }
                    this.j++;
                }
                this.i++;
            }

            return this.map;
        }
    }
}