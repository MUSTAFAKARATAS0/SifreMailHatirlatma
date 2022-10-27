using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormOturumAçmaIslemleriSifreMailHatirlatma.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormOturumAçmaIslemleriSifreMailHatirlatma
{
    public partial class Form1 : Form
    {
        WindowsFormOturumAçmaIslemleriSifreMailHatirlatmaEntitiesConnectionDb db =
            new WindowsFormOturumAçmaIslemleriSifreMailHatirlatmaEntitiesConnectionDb(); 
        public Form1()
        {
            InitializeComponent();
        }
        public static int Id;
        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            var Durum = db.PersonelGirisTablosu.FirstOrDefault(x => x.Username==textBox3.Text && x.Password==textBox2.Text);
            if (Durum != null)
            {
                Id = Durum.ıd;
                GirisBasarili gb = new GirisBasarili();
                gb.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalıdır","Durum",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifreTazele st = new SifreTazele();
            st.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox2.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
