# Treasure Hunt Maze Solver using BFS and DFS Algorithm
> *Source Code* ini dibuat oleh kami, Kelompok MencariMaknaSpek, untuk memenuhi Tugas Besar 2 Strategi Algoritma yaitu mengaplikasikan
> Algoritma BFS dan DFS dalam Menyelesaikan Persoalan *Maze Treasure Hunt*

## Daftar Isi
- [Author](#author)
- [Deskripsi Singkat](#deskripsi-singkat)
- [Sistematika File](#sistematika-file)
- [Requirements](#requirements)
- [Cara Mengkompilasi dan Menjalankan Program](#cara-mengkompilasi-dan-menjalankan-program)
- [Cara Mengoperasikan Program](#cara-mengoprasikan-program)

## Author
| NIM      | Nama                       | Github Profile                                            |
| -------- | ---------------------------|-----------------------------------------------------------|
| 13521062 | Go Dillon Audris           | [GoDillonAudris512](https://github.com/GoDillonAudris512) |
| 13521108 | Michael Leon Putra Widhi   | [mikeleo03](https://github.com/mikeleo03)                 |
| 13521145 | Kenneth Dave Bahana        | [kenndave](https://github.com/kenndave)                   |

## Deskripsi Singkat
Pada Tugas Besar kali ini, dibuat sebuah *desktop application* yang dapat mengimplementasikan dua buah Algoritma traversal dalam graf tanpa informasi (*blind search graph traversal*), yaitu Algoritma *Breadth First Search* (BFS) dan *Depth First Search* (DFS) dalam bahasa pemorgraman C#. Adapun graf yang dimaksud pada persoalan ini adalah sebuah *Maze Treasure Hunt* untuk mencari semua harta karun yang terdapat dalam peta hingga terbentuk sebuah rute penyelesaian, baik secara DFS maupun DFS.

Secara singkat, Algoritma *Breadth First Search* (BFS) mengutamakan pencarian secara melebar daripada pencarian secara mendalam, sehingga implementasi dari langkah-langkah berikut adalah skema pencarian melebar yang diimplementasikan dalam program. Solusi pemecahan ini dibangun menggunakan konsep graf dinamis sehingga perlu dilakukan penyimpanan rute untuk mempermudah melakukan perunutan langkah pencarian selanjutnya.

Adapun algoritma *Depth First Search* (DFS) mengutamakan pencarian secara mendalam pada simpul yang sedang dikunjungi, sehingga implementasi dari langkah-langkah pemecahan masalah berupa pencarian mendalam. Solusi pemecahan ini dibangun menggunakan konsep graf dinamis sehingga akan disimpan suatu rute solusi untuk menyimpan urutan simpul yang telah dikunjungi oleh algoritma DFS. 

Arsip - arsip pembentukkan awal yang disediakan Windows Form Application dalam pembentukan proyek ini berupa tiga arsip utama yang menjadi pengatur GUI yang ingin dibuat. Arsip yang dapat memodifikasi tampilan GUI merupakan [Nama Arsip].design, penyimpanan data komponen - komponen yang telah dibentuk pada [Nama Arsip].designer, dan inisialisasi tampilan utama beserta fungsionalitas komponen - komponen yang mungkin dibentuk pada [Nama Arsip].cs. Hasil implementasi utama dari algoritma BFS dan DFS dapat secara langsung digunakan pada arsip GUI ini dengan membentuk objek pemanggilan tipe data dari algoritma yang telah dibuat, yaitu dalam bentuk kelas.

## Sistematika File
```bash
.
C:.
├─── bin
├─── doc
├─── src
│   ├─── Algorithm
│   │   ├─── BFSSolver.cs
│   │   └─── DFSolver.cs
│   ├─── Application
│   ├─── Container
│   │   ├─── Coordinate.cs
│   │   ├─── MatrixNode.cs
│   │   ├─── Node.cs
│   │   └─── Route.cs
│   ├─── IO
│   │   └─── Parser.cs
│   ├─── Properties
│   ├─── Program.cs
│   ├─── TreasureHunt.csproj
│   ├─── TreasureHunt.csproj.user
│   └─── TreasureHunt.sln
└─── test
```

## Requirements
- .NET *framework* minimal 5.0 atau yang lebih baru
- Visual Studio 2022
- Windows Forms (Terunduh bersamaan dengan Visual Studio)

## Cara Mengkompilasi dan Menjalankan Program
1. Lakukan *clone repository* melalui terminal dengan *command* berikut
    ``` bash
    $ git clone https://github.com/mikeleo03/Tubes2_MencariMaknaSpek.git
    ```
2. Buka solution dari repositori ini (`TreasureHunt.sln`) pada Visual Studio.
3. Lakukan kompilasi dengan menekan tombol `start` berwarna hijau pada Visual Studio.
4. Jika kompilasi berhasil, maka akan muncul file bernama `TreasureHunt.exe` pada *folder* `bin` yang
   sejajar dengan *folder* `src` dan akan muncul tampilan dari *desktop application* pada layar.

Selain cara tersebut, program dapat pula dijalankan dengan menggunakan *executable file* yang telah teredia pada *folder* `bin` dengan cara masuk ke dalam direktori kode, lalu jalankan *command* berikut pada terminal
``` bash
$ bin/TreasureHunt
```

## Cara Mengoprasikan Program
1. Pada bagian awal akan muncul tampilan muka dari *desktop application* yang telah dibangun
2. Pengguna dapat memasukkan *file maze* yang ingin dianalisis dengan menekan tombol `Browse` pada bagian kiri atas. Selanjutnya pengguna akan diarahkan pada laman pemilihan dokumen. Pilih *file*
   yang ingin diproses lalu tekan tombol `open`.

   Jika *file* Anda valid, maka aplikasi akan menunjukkan peta hasil pembacaan dari *file* yang telah digenerasi oleh aplikasi. Jika tidak, maka aplikasi akan mengabarkan *error* yang mengatakan *file* tidak valid sehingga Anda harus memberikan masukan ulang.
3. Setelah hasil generasi petak dimunculkan, pengguna diarahkan untuk memilih algoritma yang akan digunakan. Pilihan algoritma terdiri atas algoritma BFS dan DFS. Pemrosesan tidak akan dilanjutkan sebelum pengguna memilih satu jenis algoritma yang diinginkan.
4. Selanjutnya, pengguna akan diminta untuk memilih apakah ingin mengimplementasikan TSP pada proses pencarian. Jika iya, maka pengguna harus memberikan *checklist* pada kolom TSP yang tersedia. Secara *default* proses pencarian tidak mengimplementasikan TSP.
5. Setelah seluruh prosedur diatas dilakukan, pengguna dapat melihat hasil penyelesaian dari algoritma dan skema yang dipilih dengan menekan tombol `Solve` pada bagian tengah bawah. Informasi terkait proses pencarian meliputi rute, jumlah langkah, jumlah simpul yang dikunjungi, dan waktu eksekusi akan muncul sesaat setelah tombol tersebut ditekan.
6. Sebagai pelengkap, pengguna juga dapat melihat hasil akhir dan proses pencarian menggunakan algoritma yang dipilih hingga ditemukan solusi rute yang memenuhi kondisi dengan menekan tombol `Visualize`. Pengguna juga dapat mengatur interval *delay* dari penampilan proses pencarian dengan menggerakkan *scroll bar* yang berada pada bagian kanan atas sesuai kebutuhan.