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
    public partial class GirisForm : Form
    {
        private GirisBLL girisBLL = new GirisBLL();
        public GirisForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (girisBLL.ValidateYonetici(kullaniciAdi, sifre))
            {
                MessageBox.Show("Yönetici girişi başarılı!");
                YoneticiSayfasi yoneticiSayfasi = new YoneticiSayfasi();
                yoneticiSayfasi.Show();
                this.Hide();
            }
            else if (girisBLL.ValidatePersonel(kullaniciAdi, sifre))
            {
                MessageBox.Show("Personel girişi başarılı!");
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
            }

        }
    }
}
