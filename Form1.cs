using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        //Dosya menüsü
        //YENİ
        //DOSYA AÇ
        //DOSYA KAYDET
        //ÇIKIŞ

        

        void Yeni()
        {
            Kontrol();
            richTextBox1.Text = "";
            //richTextBox1.Visible = true;
        }
        void dosyaAc()
        {
            Kontrol();
            DialogResult dr;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Zengin Format(*.rtf)|*.rtf";
            dr=openFileDialog1.ShowDialog();
            if(dr==DialogResult.OK)
            {
                //dosyayı yükleyelim
                //System.IO.Path
                //MessageBox.Show(openFileDialog1.FileName);
                richTextBox1.Text = "";
                richTextBox1.LoadFile(openFileDialog1.FileName);
                richTextBox1.Modified = false;
            }

        }
        bool dosyaKayitliMi = false;
         
        void dosyaKaydet()
        {
            DialogResult dr;
            if(dosyaKayitliMi==false)
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Zengin Format(*.rtf)|*.rtf";
                dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                    richTextBox1.Modified = false;
                    this.Text = baslik;
                    dosyaKayitliMi = true;

                }
            }
            else
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                richTextBox1.Modified = false;
                this.Text = baslik;
            }

        }

        void Kontrol()
        {
            DialogResult dr;
            if (richTextBox1.Modified == true) //richtextbox değişmiş ise true olur
            {
                dr = MessageBox.Show("Kaydetmek istiyor musunuz?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes) //dosyayı kaydedip çıkacak!!!
                {
                    dosyaKaydet();
                }
            }
        }
        //Düzen menüsü
        //KES 
        //KOPYALA 
        //YAPIŞTIR
        //BİÇİMLE

        void kes()
        {
            richTextBox1.Cut();
        }
        void yapistir()
        { 
            richTextBox1.Paste();
        }
        void kopyala()
        {
            richTextBox1.Copy();
        }
        void bicimle()
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;
        }
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yeni();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Yeni();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = baslik;
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosyaAc();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            dosyaAc();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosyaKaydet();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            dosyaKaydet();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kontrol();
        }
        string baslik = DateTime.Now.ToLongTimeString();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Modified == true)
                this.Text = baslik + "*";
            else
                this.Text = baslik;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kes();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            kes();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kopyala();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            kopyala();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapistir();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            yapistir();
        }

        private void biçimleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bicimle();

        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if(e.Button==MouseButtons.Right)
            {
                contextMenuStrip1.Show(richTextBox1,new Point(e.X,e.Y));
            }
        }

        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kes();
        }

        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kopyala();
        }

        private void yapıştırToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yapistir();
        }

        private void biçimleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bicimle();
        }
    }


}
