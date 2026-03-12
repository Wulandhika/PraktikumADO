using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        // Method Koneksi Database
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-07AAA94J\\SQLEXPRESS;Initial Catalog=DBAkademikADO;Integrated Security=True"
            );
        }

        // ===== TOMBOL CONNECT =====
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                MessageBox.Show("Koneksi berhasil dibuka!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ===== TOMBOL HITUNG MAHASISWA =====
        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = "Jumlah Mahasiswa: " + jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== TOMBOL HITUNG MATA KULIAH =====
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = "Jumlah Mata Kuliah: " + jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== TOMBOL UPDATE ALAMAT =====
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== LATIHAN 1: HITUNG DOSEN =====
        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Dosen";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = "Jumlah Dosen: " + jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== LATIHAN 2: UPDATE SKS =====
        private void btnUpdateMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== LATIHAN 3: INSERT PRODI (VERSI OTOMATIS) =====
        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                // Generate kode prodi baru otomatis
                string kodeBaru = GenerateKodeProdi();

                string query = "INSERT INTO ProgramStudi (KodeProdi, NamaProdi) VALUES ('" + kodeBaru + "', 'Manajemen Informatika')";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();

                MessageBox.Show("Berhasil menambahkan data dengan KodeProdi: " + kodeBaru +
                                "\nJumlah baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ===== METHOD KHUSUS: GENERATE KODE PRODI BARU =====
        private string GenerateKodeProdi()
        {
            string kodeBaru = "MI01";

            try
            {
                // Cek kode terakhir di database yang berawalan 'MI'
                string query = "SELECT TOP 1 KodeProdi FROM ProgramStudi WHERE KodeProdi LIKE 'MI%' ORDER BY KodeProdi DESC";
                cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string kodeTerakhir = result.ToString();

                    // Ambil angka dari kode (misal MI01 -> 1, MI02 -> 2)
                    if (kodeTerakhir.Length >= 4)
                    {
                        string angkaStr = kodeTerakhir.Substring(2); // Ambil setelah 'MI'
                        int angka = int.Parse(angkaStr);

                        // Tambah 1
                        angka++;

                        // Format jadi MI01, MI02, MI03, MI04, dst
                        kodeBaru = "MI" + angka.ToString("00");
                    }
                }
            }
            catch
            {
                // Kalau error, pakai default MI01
                kodeBaru = "MI01";
            }

            return kodeBaru;
        }
    }
}// ============================================
 // COMMIT 3: Menambahkan tombol Connect
 // ============================================

//123


// ============================================
// COMMIT 4: Menambahkan tombol Hitung Mahasiswa
// ============================================

// ============================================
// COMMIT 5: Menambahkan tombol Hitung Mata Kuliah
// ============================================

// ============================================
// COMMIT 6: Menambahkan tombol Update Alamat
// ============================================

// ============================================
// COMMIT 7: Menambahkan tombol Hitung Dosen (Latihan 1)
// ============================================

// ============================================
// COMMIT 8: Menambahkan tombol Update SKS (Latihan 2)
// ============================================

// ============================================
// COMMIT 9: Menambahkan tombol Insert Prodi (Latihan 3)
// ============================================

// ============================================
// COMMIT 10: Memperbaiki komentar dan dokumentasi
// ============================================

// ============================================
// COMMIT 11: Menambahkan try-catch di semua method
// - Error handling untuk koneksi database
// - Menampilkan pesan error jika gagal
// ============================================

// ============================================
// COMMIT 12: Memperbaiki penamaan method
// - Konsistensi penamaan button click
// - Mengikuti naming convention C#
// ============================================

// ============================================
// COMMIT 13: Menambahkan komentar di btnConnect
// - Menjelaskan parameter sender dan e
// - Menjelaskan fungsi tombol Connect
// ============================================

// ============================================
// COMMIT 14: Menambahkan komentar di btnHitungMhs
// - Menjelaskan cara kerja ExecuteScalar()
// - Menjelaskan konversi hasil ke int
// ============================================

// ============================================
// COMMIT 15: Menambahkan komentar di btnHitungMK
// - Menjelaskan query COUNT(*)
// - Menjelaskan penanganan hasil query
// ============================================

// ============================================
// COMMIT 16: Menambahkan komentar di btnUpdate
// - Menjelaskan perbedaan ExecuteNonQuery
// - Menjelaskan return value jumlah baris
// ============================================

// ============================================
// COMMIT 17: Menambahkan komentar di btnHitungDosen
// - Dokumentasi Latihan 1
// - Menjelaskan tujuan praktikum
// ============================================

// ============================================
// COMMIT 18: Menambahkan komentar di btnUpdateMK
// - Dokumentasi Latihan 2
// - Menjelaskan query UPDATE SKS
// ============================================

// ============================================
// COMMIT 19: Menambahkan komentar di btnInsertProdi
// - Dokumentasi Latihan 3
// - Menjelaskan query INSERT INTO
// ============================================

// ============================================
// COMMIT 20: Membersihkan kode
// - Menghapus spasi tidak perlu
// - Merapikan format kode
// ============================================


// ============================================
// COMMIT 3: Menambahkan method Koneksi()
// - Setup connection string ke database
// - Menggunakan SQL Server Authentication
// ============================================

// ============================================
// COMMIT 4: Menambahkan tombol Connect
// - Fungsi: Menguji koneksi ke database
// - Menampilkan pesan sukses/gagal
// ============================================

// ============================================
// COMMIT 5: Menambahkan tombol Hitung Mahasiswa
// - Menggunakan ExecuteScalar() untuk COUNT
// - Menampilkan jumlah di txtHasil
// ============================================

// ============================================
// COMMIT 6: Menambahkan tombol Hitung Mata Kuliah
// - Query SELECT COUNT(*) FROM MataKuliah
// - Menampilkan hasil di textbox
// ============================================

// ============================================
// COMMIT 7: Menambahkan tombol Update Alamat
// - Menggunakan ExecuteNonQuery() untuk UPDATE
// - Menampilkan jumlah baris terpengaruh
// ============================================