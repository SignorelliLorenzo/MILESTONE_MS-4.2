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
            GruppoSportivo.Items.AddRange(Gruppi.ToArray());
            modgruppo.Items.AddRange(Gruppi.ToArray());
            modgruppo.SelectedIndex = -1;
            GruppoSportivo.SelectedIndex = -1;
            EleDiscipline.Add(new Discipline( 12, 13, 14, "Pallavolo"));
            EleDiscipline.Add(new Discipline(1, 13, 24, "Calcio"));
            EleDiscipline.Add(new Discipline(6, 76, 100, "Basket"));
            Disciplina.Items.AddRange(EleDiscipline.ToArray());
            moddisciplina.Items.AddRange(EleDiscipline.ToArray());
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
                        var visualizza = Certificati.OrderBy(s => s.Idcertificato);
                        GridVisualizza.DataSource= visualizza.ToList();
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
                Certificati[k].ModifyParameters(modmedico.Text, modnome.Text, modcognome.Text, modnascita.Value, modres.Text, modgruppo.SelectedItem as Gruppo_sportivo, moddisciplina.SelectedItem as Discipline, modagonismo.SelectedItem.ToString(),(int)modlvl.Value,modemissione.Value );
             
                refresh();
                MessageBox.Show("MODIFICA ESEGUITA CON SUCCESSO");
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                    return;
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
                    return;
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
                var visualizza = EleDiscipline.OrderBy(s => s.Nome);
                GridDisciplina.DataSource = visualizza.ToList();
                Disciplina.Items.Add(bozza);
                moddisciplina.Items.Add(bozza);
                TAB.SelectedIndex = backtab;
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                    return;
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
                var visualizza = Gruppi.OrderBy(s => s.Nome);
                GridGruppo.DataSource = visualizza.ToList();
                GruppoSportivo.Items.Add(bozza);
                modgruppo.Items.Add(bozza);
                TAB.SelectedIndex = backtab;
            }
            catch (Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                    return;
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
            try
            { 

                int x = EleDiscipline.IndexOf(EleDiscipline.Where(s => s.Nome==GridDisciplina.Rows[0].Cells[0].Value.ToString()).FirstOrDefault());
                if(x==-1)
                {
                    MessageBox.Show("ERRORE LA DISCIPLINA NON SEMBRA ESISTERE");
                    return;

                }
                EleDiscipline[x].ModifyParameters(nomedis.Text, (int)mindil.Value, (int)minjun.Value, (int)minsen.Value);
            }
            catch(Exception ex)
            {
                if (ex.Source != "MS42")
                {
                    MessageBox.Show("ERRORE GENERICO RICONTROLLARE I DATI!");
                    return;
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void GridGruppo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x=Certificati.RemoveAll(s => s.Idcertificato ==GridVisualizza.SelectedRows[0].Cells[0].Value.ToString());
            if(x==0)
            {
                MessageBox.Show("Codice non trovato");
                return;
            }
            MessageBox.Show("Certificato eliminato con successo");
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void refresh()
        {
            modnome.Clear();
            modmedico.Clear();
            modnome.Clear();
            modcognome.Clear();
            modres.Clear();
            modnascita.Value = DateTime.Now;
            modgruppo.SelectedItem = -1;
            moddisciplina.SelectedItem = -1;
            modagonismo.SelectedItem = -1;
            modlvl.Value = 1;
            btnmod.Enabled = false;
            modmedico.Enabled = false;
            modnome.Enabled = false;
            modcognome.Enabled = false;
            modres.Enabled = false;
            modnascita.Enabled = false;
            modgruppo.Enabled = false;
            moddisciplina.Enabled = false;
            modagonismo.Enabled = false;
            modlvl.Enabled = false;
            adddismod.Enabled = false;
            addmodgr.Enabled = false;
            modemissione.Enabled = false;
            GridVisualizza.DataSource = Certificati;
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
            modemissione.Value = k.Emissione;
            modlvl.Value = k.Idoneità;
            btnmod.Enabled = true;
            modmedico.Enabled = true;
            modnome.Enabled = true;
            modcognome.Enabled = true;
            modres.Enabled = true;
            modnascita.Enabled = true;
            modgruppo.Enabled = true;
            moddisciplina.Enabled = true;
            modagonismo.Enabled = true;
            modlvl.Enabled = true;
            adddismod.Enabled = true;
            addmodgr.Enabled = true;
            modemissione.Enabled = true;
        }

        private void modnascita_ValueChanged(object sender, EventArgs e)
        {

        }

        private void modagonismo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void eliminadis_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show("ATTENZIONE!", "Cancellando la disciplina verranno eliminati tutti i cerificati con questa disciplina si vuole continuare?", MessageBoxButtons.YesNo);
            switch(result)
            {
                case DialogResult.Yes:
                {

                        var x = EleDiscipline.Where(s => s.Nome == GridDisciplina.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
                        if (x == null)
                        {
                            MessageBox.Show("Disciplina non trovato");
                            return;
                        }
                        Certificati.ForEach(item =>
                        {
                            if(item.Disciplina==x)
                            {
                                item.Dispose();
                            }
                        });
                        int eliminati=Certificati.RemoveAll(s=> s.Disciplina==x);
                        int index=EleDiscipline.IndexOf(x);
                        EleDiscipline[index].Dispose();
                        EleDiscipline.Remove(x);
                        MessageBox.Show("Disciplina eliminata con successo, sono stati eliminati "+eliminati+" certificati che contenevano questa disciplina");
                        break;
                }
                case DialogResult.No:
                {
                        return;
                }
            }
           
        }

        private void eliminabtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ATTENZIONE!", "Cancellando il gruppo sportivo verranno eliminati tutti i cerificati con questo guppo si vuole continuare?", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    {

                        var x = Gruppi.Where(s => s.Nome == GridDisciplina.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
                        if (x == null)
                        {
                            MessageBox.Show("Gruppo non trovato");
                            return;
                        }
                        Certificati.ForEach(item =>
                        {
                            if (item.Gruppo_sportivo == x)
                            {
                                item.Dispose();
                            }
                        });
                        int eliminati = Certificati.RemoveAll(s => s.Gruppo_sportivo == x);
                        int index = Gruppi.IndexOf(x);
                        Gruppi[index].Dispose();
                        Gruppi.Remove(x);
                        MessageBox.Show("Gruppo sportivo eliminata con successo, sono stati eliminati " + eliminati + " certificati che contenevano questa disciplina");
                        break;
                    }
                case DialogResult.No:
                    {
                        return;
                    }
            }
        }
    }
}
