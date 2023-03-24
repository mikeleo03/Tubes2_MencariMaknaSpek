namespace TreasureHunt.Container {
    // Kelas Node
    class Node {
        // Atribut kelas
        private char type;         // Karakter tipe node
        private Coordinate loc;    // Lokasi koordinat 
        private int visitedTime;   // Jumlah dikunjungi

        // Metode kelas
        // 1. Konstruktor objek node (default)
        public Node() {
            this.type = ' ';
            this.loc = new Coordinate();
            this.visitedTime = 0;
        }

        // 2. Konstruktor objek node
        public Node(char type, int x, int y, int visitedTime) {
            this.type = type;
            this.loc = new Coordinate(x, y);
            this.visitedTime = visitedTime;
        }

        // 3. Getter atribut type
        public char getType() {
            return this.type;
        }

        // 4. Getter atribut visitedTime
        public int getVisitedTime() {
            return this.visitedTime;
        }

        // 5. Melakukan pengaturan ulang terhadap nilai atribut visitedTime
        public void reset() {
            this.visitedTime = 0;
        }

        // 6. Melakukan penambahan nilai visitedTime sebanyak 1
        public void visit() {
            this.visitedTime++;
        }
    }
}