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
    public partial class Personelİslemleri : Form
    {
        private readonly PersonelBLL _personelBLL;
        public Personelİslemleri()
        {
            InitializeComponent();
            _personelBLL = new PersonelBLL();
        }

        private void Personelİslemleri_Load(object sender, EventArgs e)
        {
            ListelePersoneller();
        }

        private void ListelePersoneller()
        {
            try
            {
                DataTable personel = _personelBLL.TumPersonelleriGetir();
                dgvPersoneller.DataSource = personel;


                dgvPersoneller.Columns["PersonelID"].Visible = false;
                dgvPersoneller.Columns["AdSoyad"].HeaderText = "Ad Soyad";
                dgvPersoneller.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                dgvPersoneller.Columns["Sifre"].HeaderText = "Şifre";
                dgvPersoneller.Columns["Telefon"].HeaderText = "Telefon";
                dgvPersoneller.Columns["TC_Numarası"].HeaderText = "TC_Numarası";
                dgvPersoneller.Columns["Gorev"].HeaderText = "Görev";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text.Trim();
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string telefon = txtNumarası.Text.Trim();
            string tC_Numarası = txtTCNumarası.Text.Trim();
            string gorev = txtGorev.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(tC_Numarası) || string.IsNullOrEmpty(gorev) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            bool result = _personelBLL.PersonelEkle(adSoyad, kullaniciAdi, sifre, telefon, tC_Numarası , gorev);
            if (result)
            {
                MessageBox.Show("Personel başarıyla eklendi.");
                ListelePersoneller();
            }
            else
            {
                MessageBox.Show("Personel eklenirken bir hata oluştu.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı kontrol et
                if (dgvPersoneller.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bir personel seçiniz.");
                    return;
                }

                // Seçilen personelin ID'sini al
                int personelID = Convert.ToInt32(dgvPersoneller.SelectedRows[0].Cells["PersonelID"].Value);

                // Formdaki bilgileri al
                string adSoyad = txtAdSoyad.Text.Trim();
                string kullaniciAdi = txtKullaniciAdi.Text.Trim();
                string telefon = txtNumarası.Text.Trim();
                string tC_Numarası = txtTCNumarası.Text.Trim();
                string gorev = txtGorev.Text.Trim();
                string sifre = txtSifre.Text.Trim();

                // Eksik bilgi kontrolü
                if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(tC_Numarası) || string.IsNullOrEmpty(gorev) || string.IsNullOrEmpty(sifre))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                // Güncelleme işlemini çağır
                bool result = _personelBLL.PersonelGuncelle(personelID, adSoyad, kullaniciAdi, sifre, telefon, tC_Numarası, gorev);

                // İşlem sonucunu kontrol et
                if (result)
                {
                    MessageBox.Show("Personel başarıyla güncellendi.");
                    ListelePersoneller(); // Listeyi güncelle
                }
                else
                {
                    MessageBox.Show("Personel güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvPersoneller.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir personel seçiniz.");
                return;
            }

            int personelID = Convert.ToInt32(dgvPersoneller.SelectedRows[0].Cells["PersonelID"].Value);

            bool result = _personelBLL.PersonelSil(personelID);
            if (result)
            {
                MessageBox.Show("Personel başarıyla silindi.");
                ListelePersoneller(); // Listeyi güncelle
            }
            else
            {
                MessageBox.Show("Personel silinirken bir hata oluştu.");
            }
        }
    }
}
