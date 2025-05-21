using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UludagOteli.BLL;

namespace UludagOteli
{
    public partial class Odalar : Form
    {
        private readonly OdaDurumuBLL _odaDurumuBLL;

        public Odalar()
        {
            InitializeComponent();
            _odaDurumuBLL = new OdaDurumuBLL();
        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            try
            {
                // Tüm odaları getir
                DataTable odalar = _odaDurumuBLL.TumOdalarGetir();

                // FlowLayoutPanel'in genel görünümü
                flowLayoutPanelOdalar.BackColor = ColorTranslator.FromHtml("#E8F5E9"); // Açık yeşil arka plan
                flowLayoutPanelOdalar.Padding = new Padding(10); // İçerik aralığı
                flowLayoutPanelOdalar.AutoScroll = true;

                // Her oda için bir kart oluştur
                foreach (DataRow row in odalar.Rows)
                {
                    // Oda bilgilerini al
                    string odaNumarasi = row["OdaNumarasi"].ToString();
                    string odaTipi = row["OdaTipi"].ToString();
                    string odaDurumu = row["OdaDurumu"].ToString();

                    // Kart rengi belirleme (duruma göre)
                    Color kartRengi;
                    if (odaDurumu == "Boş")
                        kartRengi = Color.LightGreen;
                    else if (odaDurumu == "Dolu")
                        kartRengi = Color.IndianRed;
                    else if (odaDurumu == "Rezervasyon")
                        kartRengi = Color.Yellow;
                    else
                        kartRengi = Color.White;

                    // Kartı oluştur
                    Panel odaKart = new Panel
                    {
                        Size = new Size(130, 100), // Kart boyutu
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = kartRengi,
                        Margin = new Padding(10) // Kartlar arasında boşluk
                    };

                    // Oda numarası etiketi
                    Label lblOdaNumarasi = new Label
                    {
                        Text = "Oda No: " + odaNumarasi,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 10),
                        ForeColor = ColorTranslator.FromHtml("#1B4332") // Koyu yeşil yazı
                    };

                    // Oda tipi etiketi
                    Label lblOdaTipi = new Label
                    {
                        Text = "Tip: " + odaTipi,
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(10, 40),
                        ForeColor = ColorTranslator.FromHtml("#424242") // Koyu gri yazı
                    };

                    // Oda durumu etiketi
                    Label lblOdaDurumu = new Label
                    {
                        Text = "Durum: " + odaDurumu,
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(10, 70),
                        ForeColor = ColorTranslator.FromHtml("#424242") // Koyu gri yazı
                    };

                    // Etiketleri karta ekle
                    odaKart.Controls.Add(lblOdaNumarasi);
                    odaKart.Controls.Add(lblOdaTipi);
                    odaKart.Controls.Add(lblOdaDurumu);

                    // Kartı FlowLayoutPanel'e ekle
                    flowLayoutPanelOdalar.Controls.Add(odaKart);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            flowLayoutPanelOdalar.Controls.Clear(); // Mevcut kartları temizle
            Odalar_Load(sender, e); // Yeniden yükle
        }

        private void btnRezervasyonaGit_Click(object sender, EventArgs e)
        {
            MusteriGiris musteriGiris = new MusteriGiris();
            musteriGiris.Show();
            this.Hide();
        }

       
    }
}
