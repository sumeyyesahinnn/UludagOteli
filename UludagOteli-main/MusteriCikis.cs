using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UludagOteli.BLL;

namespace UludagOteli
{
    public partial class MusteriCikis : Form
    {
        private readonly MusteriCikisBLL _musteriCikisBLL;
        public MusteriCikis()
        {
            InitializeComponent();
            _musteriCikisBLL = new MusteriCikisBLL();
        }

        private void MusteriCikis_Load(object sender, EventArgs e)
        {
            try
            {
                // Tüm müşterileri yükle ve DataGridView'e aktar
                DataTable musteriler = _musteriCikisBLL.TumMusterileriGetir();
                dgvMusteriler.DataSource = musteriler;

                // DataGridView sütun başlıklarını düzenle
                dgvMusteriler.Columns["MusteriID"].Visible = false;
                dgvMusteriler.Columns["OdaID"].Visible = false;
                dgvMusteriler.Columns["Ad"].HeaderText = "Ad";
                dgvMusteriler.Columns["Soyad"].HeaderText = "Soyad";
                dgvMusteriler.Columns["GirisTarihi"].HeaderText = "Giriş Tarihi";
                dgvMusteriler.Columns["CikisTarihi"].HeaderText = "Çıkış Tarihi";
                dgvMusteriler.Columns["ToplamTutar"].HeaderText = "Toplam Tutar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                string arama = txtArama.Text.Trim();
                if (string.IsNullOrEmpty(arama))
                {
                    MessageBox.Show("Lütfen bir arama kriteri giriniz.");
                    return;
                }

                // Müşteri arama işlemi
                DataTable sonuc = _musteriCikisBLL.MusteriAra(arama);
                dgvMusteriler.DataSource = sonuc;

                if (sonuc.Rows.Count == 0)
                {
                    MessageBox.Show("Arama kriterine uygun müşteri bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnHesapKapat_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvMusteriler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bir müşteri seçiniz.");
                    return;
                }

                // Seçili müşterinin bilgilerini al
                string adSoyad = $"{dgvMusteriler.SelectedRows[0].Cells["Ad"].Value} {dgvMusteriler.SelectedRows[0].Cells["Soyad"].Value}";
                int musteriID = _musteriCikisBLL.MusteriIDGetir(adSoyad);
                int odaID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["OdaID"].Value);

                if (musteriID == 0)
                {
                    MessageBox.Show("Müşteri bulunamadı.");
                    return;
                }

                // Hesap kapatma işlemi
                bool result = _musteriCikisBLL.HesapKapat(musteriID, odaID);

                if (result)
                {
                    MessageBox.Show("Hesap başarıyla kapatıldı.");
                    MusteriCikis_Load(sender, e); // Listeyi güncelle
                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnGeriGit_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
