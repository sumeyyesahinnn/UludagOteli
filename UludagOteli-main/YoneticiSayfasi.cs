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
    public partial class YoneticiSayfasi : Form
    {
        private readonly DashboardBLL _dashboardBLL;

        public YoneticiSayfasi()
        {
            InitializeComponent();
            _dashboardBLL = new DashboardBLL();
        }

        private void btnPersonelIslemleri_Click(object sender, EventArgs e)
        {
            Personelİslemleri gecis = new Personelİslemleri();
            gecis.Show();
            
        }

        private void btnOdaİslemleri_Click(object sender, EventArgs e)
        {
            OdaIslemleri gecis = new OdaIslemleri();
            gecis.Show();
            
        }

        private void btnMusteriİslemleri_Click(object sender, EventArgs e)
        {
            MusteriIslemleriForm gecis = new MusteriIslemleriForm();
            gecis.Show();
            
        }

        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            MusteriGiris gecis = new MusteriGiris();
            gecis.Show();
            
        }

        private void btnMusteriCikis_Click(object sender, EventArgs e)
        {
            MusteriCikis gecis = new MusteriCikis();
            gecis.Show();
            
        }

        private void YoneticiSayfasi_Load(object sender, EventArgs e)
        {
            DoluOdaSayisiniGetir();
            ToplamGeliriGetir();
            AktifRezervasyonSayisiniGetir();
            SuAndaOteldeKalanSayisi();
            ListeleRezervasyonlar();
        }
        private void DoluOdaSayisiniGetir()
        {
            int doluOdaSayisi = _dashboardBLL.DoluOdaSayisi();
            lblDoluOdaSayisi.Text = $"Dolu Oda: {doluOdaSayisi}";
        }

        private void ToplamGeliriGetir()
        {
            decimal toplamGelir = _dashboardBLL.ToplamGelir();
            lblToplamGelir.Text = $"Toplam Gelir: {toplamGelir:C}";
        }

        private void AktifRezervasyonSayisiniGetir()
        {
            int aktifRezervasyon = _dashboardBLL.AktifRezervasyonSayisi();
            lblAktifRezervasyon.Text = $"Rezervasyon: {aktifRezervasyon}";
        }

        private void SuAndaOteldeKalanSayisi()
        {
            int suAndaOtelde = _dashboardBLL.SuAndaOteldeKalanSayisi();
            lblSuAndaOteldeKalan.Text = $"Su Anda Otelde: {suAndaOtelde}";
        }

        private void ListeleRezervasyonlar()
        {
            DataTable rezervasyonlar = _dashboardBLL.TumRezervasyonlariGetir();
            dgvBilgiler.DataSource = rezervasyonlar;

            dgvBilgiler.Columns["RezervasyonID"].Visible = false;
            dgvBilgiler.Columns["MusteriAdi"].HeaderText = "Müşteri Adı";
            dgvBilgiler.Columns["MusteriSoyAdi"].HeaderText = "Müşteri Soyadı";
            dgvBilgiler.Columns["TC_Numarasi"].HeaderText = "TC Numarası";
            dgvBilgiler.Columns["GirisTarihi"].HeaderText = "Giriş Tarihi";
            dgvBilgiler.Columns["CikisTarihi"].HeaderText = "Çıkış Tarihi";
            dgvBilgiler.Columns["OdaNumarasi"].HeaderText = "Oda Numarası";
            dgvBilgiler.Columns["Durum"].HeaderText = "Durum";
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text.Trim();
            dgvBilgiler.DataSource = _dashboardBLL.HizliArama(aramaMetni);
        }

        
        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text.Trim();

            if (!string.IsNullOrEmpty(aramaMetni))
            {
                try
                {
                    DataTable aramaSonuclari = _dashboardBLL.HizliArama(aramaMetni);
                    dgvBilgiler.DataSource = aramaSonuclari;

                    if (aramaSonuclari.Rows.Count == 0)
                    {
                        MessageBox.Show("Aradığınız kriterlere uygun bir sonuç bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arama işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen arama yapmak için bir metin girin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisForm gecis = new GirisForm();
            gecis.Show();

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (!(form is GirisForm) && form != gecis)
                {
                    form.Close();
                }
            }
        }
    }
}
