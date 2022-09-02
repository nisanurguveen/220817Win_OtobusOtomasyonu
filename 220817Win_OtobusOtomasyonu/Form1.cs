using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _220817Win_OtobusOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOtobüs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOtobüs.Text)
            {
                case "Metro Turizm": KoltukDoldur(8, false); break;
                case "Kamil Koç": KoltukDoldur(8, false); break;
                case "Pamukkale Turizm": KoltukDoldur(10, false); break;
                case "Varan Turizm": KoltukDoldur(8, true); break;
                case "Ulusoy Turizm": KoltukDoldur(8, false); break;
                case "Nilüfer Turizm": KoltukDoldur(10, false); break;
                case "İstanbul Kalesi": KoltukDoldur(8, false); break;
                default:
                    break;


            }
        }
        void KoltukDoldur(int sira, bool arkaBesliMi)
        {
        yavaslat:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;
                    if (btn.Text == "Kaydet")
                    {
                        continue;
                    }
                    else
                    {
                        this.Controls.Remove(ctrl);
                        goto yavaslat;
                    }
                }
            }
            int koltukNo = 1;

            for (int i = 0; i < sira; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == sira / 2 && j > 2)
                    {
                        continue;
                    }
                    else
                    {
                        if (j == 2)
                            continue;
                    }
                    if (arkaBesliMi == true)
                    {
                        if (i != sira - 1 && j == 2)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (j == 2)
                            continue;
                    }
                    if (j == 2)
                        continue;
                    Button koltuk = new Button();
                    koltuk.Height = koltuk.Width = 40;
                    koltuk.Top = 30 + (i * 45);
                    koltuk.Left = 5 + (j * 45);
                    koltuk.Text = koltukNo.ToString();
                    koltuk.ContextMenuStrip = contextMenuStrip1;
                    koltuk.MouseDown += Koltuk_MouseDown;
                    koltukNo++;
                    this.Controls.Add(koltuk);
                }
            }
        }
        Button tiklanan;
        private void Koltuk_MouseDown(object sender, MouseEventArgs e)
        {
            tiklanan = sender as Button;

        }
        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbOtobüs.SelectedIndex == -1 || cmbNerden.SelectedIndex == -1 || cmbNereye.SelectedIndex == -1)
            {
                MessageBox.Show("lÜTFEN ÖNCE GEREKLİ ALANLARI DOLDURUNUZ.");
                return;
            }
            KayitFormu kf = new KayitFormu();
            DialogResult sonuc = kf.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Format("{0} {1}", kf.txtIsim.Text, kf.txtSoyisim.Text); lvi.SubItems.Add(kf.mskTel.Text);
                if (kf.rdbBay.Checked)
                {
                    lvi.SubItems.Add("BAY");
                    tiklanan.BackColor = Color.Blue;

                }
                if (kf.rdbBayan.Checked)
                {
                    lvi.SubItems.Add("BAYAN");
                    tiklanan.BackColor = Color.Pink;
                }
                lvi.SubItems.Add(cmbNerden.Text);
                lvi.SubItems.Add(cmbNereye.Text);
                lvi.SubItems.Add(tiklanan.Text);
                lvi.SubItems.Add(dtpTarih.Text);
                lvi.SubItems.Add(nudFiyat.Value.ToString());
                listView1.Items.Add(lvi);

            }


        }
    }
}
