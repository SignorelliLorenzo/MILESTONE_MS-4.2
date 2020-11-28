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

        private void button1_Click(object sender, EventArgs e)
        {
            TAB.TabPages.Add(tab_elementi);
            TAB.SelectedIndex = 2;
            backtab = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TAB.TabPages.Remove(tab_elementi);
            Gruppi.Add(new Gruppo_sportivo("PaleEolice S.p.a.", "Via Romagnolo della montanara", "Albreto d'aragona" ,"1111111111","albero@gmail.com"));
            Gruppi.Add(new Gruppo_sportivo("Robabella S.p.a.", "Via Albero della collina", "Foremia Francesco", "2222222222", "pesche@gmail.com"));
            Gruppi.Add(new Gruppo_sportivo("Pescebello S.p.a.", "Via Persona sconosciuta", "Yiu Del mare", "3333333333", "comodino@gmail.com"));
            GruppoSportivo.DataSource = Gruppi;
            modgruppo.DataSource = Gruppi;
            modgruppo.SelectedIndex = -1;
            GruppoSportivo.SelectedIndex = -1;
            EleDiscipline.Add(new Discipline( 12, 13, 14, "Pallavolo"));
            EleDiscipline.Add(new Discipline(1, 13, 24, "Calcio"));
            EleDiscipline.Add(new Discipline(6, 76, 100, "Basket"));
            Disciplina.DataSource = EleDiscipline;
            moddisciplina.DataSource = EleDiscipline;
            Disciplina.SelectedIndex = -1;
            moddisciplina.SelectedIndex = -1;
            Certificati.Add(new Certificato("IBMC456BASDJKLL","Rossi Mario","Alberto","Signorelli",DateTime.Parse("12/12/2003"),"Italia Roma",Gruppi[0],EleDiscipline[0],"Dilettante",12, DateTime.Parse("12/9/2020")));
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
                        GridVisualizza.DataSource= Certificati;
                        TAB.TabPages.Remove(tab_elementi);
                        break;
                    }
                case 2:
                    {
                        GridDisciplina.DataSource = EleDiscipline;
                        GridGruppo.DataSource = Gruppi;
                        break;
                    }
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            int k = Certificati.IndexOf(Certificati.Where(s => s.Idcertificato == modid.Text).FirstOrDefault());
            try
            {
                Certificati[k].Medico = modmedico.Text;
                Certificati[k].Emissione = modemissione.Value;
                Certificati[k].Nome = modnome.Text;
                Certificati[k].Cognome = modcognome.Text;
                Certificati[k].Nascita = modnascita.Value;
                Certificati[k].Residenza = modres.Text;
                Certificati[k].Gruppo_sportivo = modgruppo.SelectedItem as Gruppo_sportivo;
                Certificati[k].CambiaDisciplina(moddisciplina.SelectedItem as Discipline, (int)modlvl.Value, modagonismo.SelectedItem.ToString());
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
                GridDisciplina.DataSource = EleDiscipline;
                Disciplina.Items.Add(bozza);
                TAB.SelectedIndex = backtab;
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
                GridGruppo.DataSource = Gruppi;
                GruppoSportivo.Items.Add(bozza);
                TAB.SelectedIndex = backtab;
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

        private void GridDisciplina_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            modis.Enabled = true;
            eliminadis.Enabled = true;
            var code = GridDisciplina.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void modis_Click(object sender, EventArgs e)
        {

        }

        private void GridGruppo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Certificati.RemoveAll(s => s.Idcertificato ==GridVisualizza.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void GridDisciplina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridVisualizza_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            modid.Text = GridVisualizza.SelectedRows[0].Cells[0].Value.ToString();
            var k = Certificati.Where(s => s.Idcertificato== modid.Text).FirstOrDefault();
            if(k==null)
            {
                MessageBox.Show("Errore nel caricamento dei dati codice non trovato");
            }
            
            modmedico.Text = k.Medico;
            modnome.Text = k.Nome;
            modcognome.Text = k.Cognome;
            modres.Text = k.Residenza;
            modnascita.Value = k.Nascita;
            modgruppo.SelectedItem = k.Gruppo_sportivo;
            moddisciplina.SelectedItem = k.Disciplina;
            modagonismo.SelectedItem = k.Livello_Agonistico;
            modlvl.Value = k.Idoneità;
        }

        private void modnascita_ValueChanged(object sender, EventArgs e)
        {

        }

        private void modagonismo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
