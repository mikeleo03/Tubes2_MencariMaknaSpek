using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container {
    // Kelas Coordinate
    class Coordinate {
        // Atribut kelas
        private int x;  // Nilai absis
        private int y;  // Nilai ordinat

        // Metode kelas
        // 1. Konstruktor objek coordinate (default)
        public Coordinate() {
            this.x = 0;
            this.y = 0;
        }

        // 2. Konstruktor objek coordinate
        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }

        // 3. Getter atribut x
        public int getX() { 
            return this.x; 
        }
        
        // 4. Getter atribut y
        public int getY() {
            return this.y;
        }

        // 5. Memindah posisi dari koordinat ke atas dengan membuat objek baru
        public Coordinate moveUp() {
            return new Coordinate(this.x-1, this.y);
        }

        // 6. Memindah posisi dari koordinat ke bawah dengan membuat objek baru
        public Coordinate moveDown() {
            return new Coordinate(this.x+1, this.y);
        }

        // 7. Memindah posisi dari koordinat ke kiri dengan membuat objek baru
        public Coordinate moveLeft() {
            return new Coordinate(this.x, this.y-1);
        }

        // 8. Memindah posisi dari koordinat ke kanan dengan membuat objek baru
        public Coordinate moveRight() {
            return new Coordinate(this.x, this.y+1);
        }
    }
}
