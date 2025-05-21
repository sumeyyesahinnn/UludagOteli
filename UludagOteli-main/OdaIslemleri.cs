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
    public partial class OdaIslemleri : Form
    {
        private readonly OdaBLL _odaBLL;
        public OdaIslemleri()
        {
            InitializeComponent();
            _odaBLL = new OdaBLL();
        }

        private void OdaIslemleri_Load(object sender, EventArgs e)
        {
            ListeleOdalar();
        }

        private void ListeleOdalar()
        {
            try
            {
                DataTable odalar = _odaBLL.TumOdalar();
                dgvOdalar.DataSource = odalar;

               
                dgvOdalar.Columns["OdaID"].Visible = false; 
                dgvOdalar.Columns["OdaNumarasi"].HeaderText = "Oda Numarası";
                dgvOdalar.Columns["OdaTipi"].HeaderText = "Oda Tipi";
                dgvOdalar.Columns["OdaDurumu"].HeaderText = "Oda Durumu";
                dgvOdalar.Columns["OdaUcreti"].HeaderText = "Oda Ücreti (₺)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string odaNumarasi = txtOdaNumarasi.Text.Trim();
            string odaTipi = cmbOdaTipi.Text.Trim();
            string odaDurumu = cmbOdaDurumu.Text.Trim();
            decimal odaUcreti = nudFiyat.Value;

            if (string.IsNullOrEmpty(odaNumarasi) || string.IsNullOrEmpty(odaTipi) || string.IsNullOrEmpty(odaDurumu) || odaUcreti <= 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli bir fiyat girin.");
                return;
            }

            bool result = _odaBLL.OdaEkle(odaNumarasi, odaTipi, odaDurumu, odaUcreti);
            if (result)
            {
                MessageBox.Show("Oda başarıyla eklendi.");
                ListeleOdalar();
            }
            else
            {
                MessageBox.Show("Oda eklenirken bir hata oluştu.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvOdalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir oda seçiniz.");
                return;
            }

            int odaID = Convert.ToInt32(dgvOdalar.SelectedRows[0].Cells["OdaID"].Value);
            string odaNumarasi = txtOdaNumarasi.Text.Trim();
            string odaTipi = cmbOdaTipi.Text.Trim();
            string odaDurumu = cmbOdaDurumu.Text.Trim();
            decimal odaUcreti = nudFiyat.Value;

            if (string.IsNullOrEmpty(odaNumarasi) || string.IsNullOrEmpty(odaTipi) || string.IsNullOrEmpty(odaDurumu) || odaUcreti <= 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli bir fiyat girin.");
                return;
            }

            bool result = _odaBLL.OdaGuncelle(odaID, odaNumarasi, odaTipi, odaDurumu, odaUcreti);
            if (result)
            {
                MessageBox.Show("Oda başarıyla güncellendi.");
                ListeleOdalar();
            }
            else
            {
                MessageBox.Show("Oda güncellenirken bir hata oluştu.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvOdalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir oda seçiniz.");
                return;
            }

            // DataGridView'den seçili odanın ID'sini al
            int odaID = Convert.ToInt32(dgvOdalar.SelectedRows[0].Cells["OdaID"].Value);

            // Oda silme işlemini gerçekleştir
            bool result = _odaBLL.OdaSil(odaID);

            if (result)
            {
                MessageBox.Show("Oda başarıyla silindi.");
                ListeleOdalar(); // Listeyi güncelle
            }
            else
            {
                MessageBox.Show("Oda silinirken bir hata oluştu.");
            }
        }
    }
}
