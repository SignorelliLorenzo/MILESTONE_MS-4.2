using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int backtab = default;
        private List<Certificato> Certificati=new List<Certificato>();
        private List<Discipline> EleDiscipline = new List<Discipline>();
        private List<Gruppo_sportivo> Gruppi = new List<Gruppo_sportivo>();
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TAB.TabPages.Add(tab_elementi);
            TAB.SelectedIndex = 2;
            backtab = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TAB.TabPages.Remove(tab_elementi);
        }

        private void tab_elementi_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

   

        private void btndisciplina_Click(object sender, EventArgs e)
        {
            TAB.TabPages.Add(tab_elementi);
            TAB.SelectedIndex = 2;
            backtab = 0;
        }

        private void TAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = TAB.SelectedIndex;
            switch(k)
            {
                case 0:
                    {
                        TAB.TabPages.Remove(tab_elementi);
                        break;
                    }
                case 1:
                    {
                        TAB.TabPages.Remove(tab_elementi);
                        break;
                    }
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {

        }

        private void addmodgr_Click(object sender, EventArgs e)
        {
            TAB.TabPages.Add(tab_elementi);
            TAB.SelectedIndex = 2;
            backtab = 1;
        }

        private void adddismod_Click(object sender, EventArgs e)
        {
            TAB.TabPages.Add(tab_elementi);
            TAB.SelectedIndex = 2;
            backtab = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnins_Click(object sender, EventArgs e)
        {
            try
            {
                Certificato bozza = new Certificato(id.Text, medico.Text, NomeAtleta.Text, CognomeAtleta.Text, NascitaAtleta.Value, ResidenzaAtleta.Text, GruppoSportivo.SelectedItem as Gruppo_sportivo, Disciplina.SelectedItem as Discipline, Agonismo.Text, (int)LVL.Value, emissione.Value);
                Certificati.Add(bozza);
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNINSERISCIDIS_Click(object sender, EventArgs e)
        {
            try
            {
                Discipline bozza = new Discipline((int)mindil.Value, (int)minjun.Value, (int)minsen.Value,nomedis.Text);
                EleDiscipline.Add(bozza);
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void insgruppo_Click_1(object sender, EventArgs e)
        {
            try
            {
                Gruppo_sportivo bozza = new Gruppo_sportivo(RSGr.Text , Sede.Text , nominativo.Text , cell.Text , email.Text);
                Gruppi.Add(bozza);
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                }
                MessageBox.Show(ex.Message);
            }
        }
    }
}
