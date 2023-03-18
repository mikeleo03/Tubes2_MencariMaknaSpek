using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TreasureHunt.Container;

namespace TreasureHunt.IO {
    class Parser {
        // attributes
        public Node[,] map;
        private string fileName; // nama file
        private int row; // jumlah baris
        private int col; // jumlah kolom
        private int i;
        private int j;
        private int startPoint; // titik mulai
        private Coordinate startLoc; // lokasi titik mulai
        private int treasure; // jumlah treassure

        // constructors
        public Parser() {
            this.fileName = string.Empty;
            this.row = 0;
            this.col = 0;
            this.i = 0;
            this.j = 0;
            this.startPoint = 0;
            this.startLoc = new Coordinate();
            this.treasure = 0;
        } 

        public Parser(string fileName) {
            this.fileName = fileName;
            this.row = 1;
            this.col = 1;
            this.i = 0;
            this.j = 0;
            this.startPoint = 0;
            this.startLoc = new Coordinate();
            this.treasure = 0;
        }

        // getter 
        public int getRow() {
            return this.row;
        }

        public int getCol() {
            return this.col;
        }

        public int getTreasure() {
            return this.treasure;
        }

        public Coordinate getStart() {
            return this.startLoc;
        }

        // check validity of file
        public void checkColumnInRow(int col) {
            if (col != this.col) {
                throw new Exception("Number of column is not same");
            }
        }

        public void checkCharacterValidity(string s) {
            if (!(s == "K" || s == "X" || s == "R" || s == "T")) {
                throw new Exception("Character in file cannot be defined");
            }
        }

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

        // parse and fill matrix according to txt file
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
                    this.map[i, j] = new Node(character[0], this.i, this.j, 0);
                    this.j++;
                }
                this.i++;
            }

            return this.map;
        }
    }
}