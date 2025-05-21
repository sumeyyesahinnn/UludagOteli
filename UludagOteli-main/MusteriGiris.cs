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
using UludagOteli.DAL;

namespace UludagOteli
{
    public partial class MusteriGiris : Form
    {
        private readonly RezervasyonBLL _rezervasyonBLL;
        private readonly OdaDurumuBLL _odaDurumuBLL;

        public MusteriGiris()
        {
            InitializeComponent();
            _rezervasyonBLL = new RezervasyonBLL();
            _odaDurumuBLL = new OdaDurumuBLL();
        }

        private void MusteriGiris_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDurum.Items.Add("Rezervasyon");
                cmbDurum.Items.Add("Giriş");
                cmbDurum.SelectedIndex = 0;


                DataTable odaTipleri = _rezervasyonBLL.OdaTipleriniGetir();
                cmbOdaTipi.Items.Clear();

                foreach (DataRow row in odaTipleri.Rows)
                {
                    cmbOdaTipi.Items.Add(row["OdaTipi"].ToString());
                }

                if (cmbOdaTipi.Items.Count > 0)
                {
                    cmbOdaTipi.SelectedIndex = 0; // İlk oda tipini seç
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void cmbOdaTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Seçilen oda tipini al
                string odaTipi = cmbOdaTipi.SelectedItem.ToString();

                // Bu oda tipine ait boş odaları getir
                DataTable odaBilgileri = _rezervasyonBLL.BosOdaBilgileriGetir(odaTipi);

                // Oda numaralarını ComboBox'a yükle
                cmbOdaNumarasi.Items.Clear();
                foreach (DataRow row in odaBilgileri.Rows)
                {
                    cmbOdaNumarasi.Items.Add(row["OdaNumarasi"].ToString());
                }

                if (cmbOdaNumarasi.Items.Count > 0)
                {
                    cmbOdaNumarasi.SelectedIndex = 0; // İlk oda numarasını seç
                }
                else
                {
                    MessageBox.Show("Seçilen oda tipinde boş oda bulunamadı.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
               

                // Giriş ve çıkış tarihlerini al
                DateTime girisTarihi = dtpGirisTarihi.Value.Date;
                DateTime cikisTarihi = dtpCikisTarihi.Value.Date;

                
                if (girisTarihi >= cikisTarihi)
                {
                    MessageBox.Show("Giriş tarihi çıkış tarihinden önce olmalıdır!");
                    return;
                }

                if (cmbOdaNumarasi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir oda seçiniz!");
                    return;
                }

                string odaNumarasi = cmbOdaNumarasi.SelectedItem.ToString();
                int odaID = _rezervasyonBLL.OdaIDGetir(odaNumarasi);

                if (odaID == 0)
                {
                    MessageBox.Show("Seçilen oda bulunamadı.");
                    return;
                }



                // Toplam tutarı hesapla
                decimal toplamTutar = _rezervasyonBLL.ToplamTutarHesapla(girisTarihi, cikisTarihi, odaID);

                // Tutarı TextBox'a yaz
                txtToplamTutar.Text = toplamTutar.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
               
                string ad = txtAd.Text.Trim();
                string soyad = txtSoyad.Text.Trim();
                string TC_Numarasi = txtKimlik.Text.Trim();
                string telefon = txtTelefon.Text.Trim();
                string durum = cmbDurum.SelectedItem.ToString();

                if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) ||  string.IsNullOrEmpty(durum))
                {
                    MessageBox.Show("Lütfen müşteri adını ve soyadını giriniz.");
                    return;
                }

                if (cmbOdaNumarasi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir oda seçiniz!");
                    return;
                }

                string odaNumarasi = cmbOdaNumarasi.SelectedItem.ToString();
                int odaID = _rezervasyonBLL.OdaIDGetir(odaNumarasi);
                
                if (odaID == 0)
                {
                    MessageBox.Show("Seçilen oda bulunamadı.");
                    return;
                }

                DateTime girisTarihi = dtpGirisTarihi.Value.Date;
                DateTime cikisTarihi = dtpCikisTarihi.Value.Date;

                if (girisTarihi >= cikisTarihi)
                {
                    MessageBox.Show("Giriş tarihi çıkış tarihinden önce olmalıdır!");
                    return;
                }

                // Toplam tutarı al
                if (string.IsNullOrEmpty(txtToplamTutar.Text))
                {
                    MessageBox.Show("Lütfen toplam tutarı hesaplayınız!");
                    return;
                }

                decimal toplamTutar = decimal.Parse(txtToplamTutar.Text, System.Globalization.NumberStyles.Currency);

                // Müşteri Kaydet
                int musteriID = _rezervasyonBLL.MusteriEkle(ad, soyad, telefon, TC_Numarasi, odaID);

                if (musteriID == 0)
                {
                    MessageBox.Show("Müşteri kaydedilemedi!");
                    return;
                }

               

                // Rezervasyon Kaydetme
                bool result = _rezervasyonBLL.RezervasyonKaydet(musteriID, odaID, girisTarihi, cikisTarihi, toplamTutar, durum);

                if (result)
                {
                    string yeniDurum = durum == "Rezervasyon" ? "Rezervasyon" : "Dolu";
                    bool odaDurumuSonuc = _odaDurumuBLL.OdaDurumunuGuncelle(odaID, yeniDurum);

                    if (odaDurumuSonuc)
                    {
                        MessageBox.Show($"Müşteri ve {durum} başarıyla kaydedildi. Oda durumu güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show($"{durum} başarıyla kaydedildi ancak oda durumu güncellenemedi.");
                    }
                }
                else
                {
                    MessageBox.Show("Rezervasyon kaydedilemedi!");
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

            // Mevcut formu kapat
            this.Close();
        }
    }
}
