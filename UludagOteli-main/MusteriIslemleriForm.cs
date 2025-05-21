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
    public partial class MusteriIslemleriForm : Form
    {
        private readonly MusteriBLL _musteriBLL;
        private readonly OdaBLL _odaBLL;

        public MusteriIslemleriForm()
        {
            InitializeComponent();
            _musteriBLL = new MusteriBLL();
            _odaBLL = new OdaBLL();
        }

        private void MusteriIslemleriForm_Load(object sender, EventArgs e)
        {
            ListeleRezervasyonlar();
            BosOdalarYukle();
        }

        private void ListeleRezervasyonlar()
        {
            try
            {
                DataTable musteriler = _musteriBLL.RezervasyonVeMusteriDetaylariGetir();
                dgvMusteriler.DataSource = musteriler;

                dgvMusteriler.Columns["MusteriID"].Visible = false;
                dgvMusteriler.Columns["Ad"].HeaderText = "Ad";
                dgvMusteriler.Columns["Soyad"].HeaderText = "Soyad";
                dgvMusteriler.Columns["Telefon"].HeaderText = "Telefon";
                dgvMusteriler.Columns["TC_Numarasi"].HeaderText = "TC Numarası";
                dgvMusteriler.Columns["OdaNumarasi"].HeaderText = "Oda Numarası";
                dgvMusteriler.Columns["GirisTarihi"].HeaderText = "Giriş Tarihi";
                dgvMusteriler.Columns["CikisTarihi"].HeaderText = "Çıkış Tarihi";
                dgvMusteriler.Columns["ToplamTutar"].HeaderText = "Toplam Tutar (₺)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void BosOdalarYukle()
        {
            try
            {
                DataTable bosOdalar = _odaBLL.BosOdalar();
                cmbOdalar.DataSource = bosOdalar;
                cmbOdalar.DisplayMember = "OdaNumarasi";
                cmbOdalar.ValueMember = "OdaID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

       

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string tC_Numarasi = txtTC_Numarası.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            int odaID = Convert.ToInt32(cmbOdalar.SelectedValue);
            DateTime girisTarihi = dtpGirisTarihi.Value;
            DateTime cikisTarihi = dtpCikisTarihi.Value;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(tC_Numarasi) || string.IsNullOrEmpty(telefon) || odaID == 0 || girisTarihi >= cikisTarihi)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve tarih aralığını kontrol edin.");
                return;
            }

            bool result = _musteriBLL.MusteriGuncelle(musteriID, ad, soyad, telefon, tC_Numarasi, odaID, girisTarihi, cikisTarihi);
            if (result)
            {
                MessageBox.Show("Müşteri başarıyla güncellendi.");
                ListeleRezervasyonlar();
            }
            else
            {
                MessageBox.Show("Müşteri güncellenirken bir hata oluştu.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
                return;
            }

            int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);

            DialogResult dialogResult = MessageBox.Show("Bu müşteriyi silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = _musteriBLL.MusteriSil(musteriID);
                if (result)
                {
                    MessageBox.Show("Müşteri başarıyla silindi.");
                    ListeleRezervasyonlar();
                    BosOdalarYukle();
                }
                else
                {
                    MessageBox.Show("Müşteri silinirken bir hata oluştu.");
                }
            }
        }

        private void cmbOdalar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
