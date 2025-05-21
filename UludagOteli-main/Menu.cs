using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UludagOteli
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        

        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            MusteriGiris gecis = new MusteriGiris();
            gecis.Show();
            
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            Odalar gecis = new Odalar();
            gecis.Show();
            
        }

        private void btnMusteriCıkıs_Click(object sender, EventArgs e)
        {
            MusteriCikis gecis = new MusteriCikis();
            gecis.Show();
           
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Çıkış Onayı",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
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
