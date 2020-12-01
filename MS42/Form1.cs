using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            //Gruppi.Add(new Gruppo_sportivo("PaleEolice S.p.a.", "Via Romagnolo della montanara", "Albreto d'aragona" ,"1111111111","albero@gmail.com"));
            //Gruppi.Add(new Gruppo_sportivo("Robabella S.p.a.", "Via Albero della collina", "Foremia Francesco", "2222222222", "pesche@gmail.com"));
            //Gruppi.Add(new Gruppo_sportivo("Pescebello S.p.a.", "Via Persona sconosciuta", "Yiu Del mare", "3333333333", "comodino@gmail.com"));
            //GruppoSportivo.Items.AddRange(Gruppi.ToArray());
            //EleDiscipline.Add(new Discipline( 12, 13, 14, "Pallavolo"));
            //EleDiscipline.Add(new Discipline(1, 13, 24, "Calcio"));
            //EleDiscipline.Add(new Discipline(6, 76, 100, "Basket"));
            //Certificati.Add(new Certificato("IENDHADTOAD12DIA","Rossi Mario","Alberto","Signorelli",DateTime.Parse("12/12/2003"),"Italia Roma",Gruppi[0],EleDiscipline[0],"Dilettante",12, DateTime.Parse("12/9/2020")));
            //Certificati.Add(new Certificato("12NDHADAHDKL2DIA", "Alberto Vitaglione", "Giovanni", "Da ventura", DateTime.Parse("05/12/1999"), "Italia Milano", Gruppi[2], EleDiscipline[1], "Senior", 100, DateTime.Parse("30/9/2020")));
            //Certificati.Add(new Certificato("12NDHADJHFJH1DIB", "Publio Virgilio", "Dante", "Alighieri", DateTime.Parse("05/07/1998"), "Italia Firenze", Gruppi[0], EleDiscipline[1], "Junior", 100, DateTime.Parse("30/9/2012")));
            StreamReader miofile = new StreamReader("GruppiSportivi.csv");
            while (!miofile.EndOfStream)
            {
                var row = miofile.ReadLine().Split(';');
                Gruppi.Add(new Gruppo_sportivo(row[0], row[1], row[2],  row[3],row[4]));
            }
            miofile.Close();
            miofile = new StreamReader("Discipline.csv");
            while (!miofile.EndOfStream)
            {
                var row = miofile.ReadLine().Split(';');
                EleDiscipline.Add(new Discipline( int.Parse(row[1]), int.Parse(row[2]),int.Parse( row[3]),row[0]));
            }
            miofile.Close();
            miofile = new StreamReader("Certificati.csv");
            while (!miofile.EndOfStream)
            {
                var row=miofile.ReadLine().Split(';');
                Certificati.Add(new Certificato(row[0], row[1], row[3], row[4], DateTime.Parse(row[5]), row[6], Gruppi.Where(s=>s.Nome == row[7]).FirstOrDefault(), EleDiscipline.Where(s => s.Nome == row[8]).FirstOrDefault(), row[9], int.Parse(row[10]), DateTime.Parse(row[2])));
            }
            miofile.Close();
            modgruppo.Items.AddRange(Gruppi.ToArray());
            modgruppo.SelectedIndex = -1;
            Searchgruppi.Items.AddRange(Gruppi.ToArray());
            Searchgruppi.SelectedIndex = -1;
            GruppoSportivo.SelectedIndex = -1;
            Disciplina.Items.AddRange(EleDiscipline.ToArray());
            moddisciplina.Items.AddRange(EleDiscipline.ToArray());
            searchsidisciplina.Items.AddRange(EleDiscipline.ToArray());
            searchsidisciplina.SelectedIndex = -1;
            Disciplina.SelectedIndex = -1;
            moddisciplina.SelectedIndex = -1;
            emissione.Value = DateTime.Now;
            NascitaAtleta.Value = DateTime.Now;
            modemissione.Value = DateTime.Now;
            modnascita.Value = DateTime.Now;

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
                        if(backtab==2)
                        {
                            backtab = 0;
                        }
                        break;
                    }
                case 1:
                    {
                        if (backtab != 2)
                        {
                            refreshgeneral();
                        }
                        else 
                        {
                            backtab = 1;
                        }
                        TAB.TabPages.Remove(tab_elementi);
                        break;
                    }
                case 2:
                    {
                        GridDisciplina.DataSource = EleDiscipline;
                        GridGruppo.DataSource = Gruppi;
                        backtab = 2;
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
             
                refreshgeneral();
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
                MessageBox.Show("CERTIFICATO INSERITO");
                refreshins();
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
                refreshdisciplina();
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
                refreshgruppo();
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
           
            var x = EleDiscipline.Where(s => s.Nome == GridDisciplina.Rows[e.RowIndex].Cells[0].Value.ToString()).FirstOrDefault();
            if(x==null)
            {
                MessageBox.Show("ERRORE LA DISCIPLINA NON SEMBRA ESISTERE");
                return;
            }    
            nomedis.Text=x.Nome;
            mindil.Value = x.LvlMinDilettanti;
            minjun.Value = x.LvlMinJunior;
            minsen.Value = x.LvlMinSenior;
        }

        private void modis_Click(object sender, EventArgs e)
        {
            try
            { 

                int x = EleDiscipline.IndexOf(EleDiscipline.Where(s => s.Nome==GridDisciplina.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault());
                if(x==-1)
                {
                    MessageBox.Show("ERRORE LA DISCIPLINA NON SEMBRA ESISTERE");
                    return;

                }
                var eliminato = EleDiscipline[x] ;
                EleDiscipline[x].ModifyParameters(nomedis.Text, (int)mindil.Value, (int)minjun.Value, (int)minsen.Value);
                moddisciplina.Items.Remove(eliminato);
                moddisciplina.Items.Add(EleDiscipline[x]);
                Disciplina.Items.Remove(eliminato);
                Disciplina.Items.Add(EleDiscipline[x]);
                searchsidisciplina.Items.Remove(eliminato);
                searchsidisciplina.Items.Add(EleDiscipline[x]);
                refreshdisciplina();
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
            btnmodgruppo.Enabled = true;
            eliminagruppo.Enabled = true;

            var x = Gruppi.Where(s => s.Nome == GridGruppo.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
            if (x == null)
            {
                MessageBox.Show("ERRORE LA DISCIPLINA NON SEMBRA ESISTERE");
                return;
            }
            RSGr.Text = x.Nome;
            Sede.Text = x.Sede;
            nominativo.Text = x.Presidete;
            cell.Text = x.Telefono;
            email.Text = x.Email;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var eliminare= Certificati.Where(s => s.Idcertificato == GridVisualizza.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
            if (eliminare == null)
            {
                MessageBox.Show("Codice non trovato");
                return;
            }
            Certificati.ForEach(item =>
            {
                if (item.Idcertificato == eliminare.Idcertificato)
                {
                    item.Dispose();
                }
            });
            Certificati.Remove(eliminare);
            MessageBox.Show("Certificato eliminato con successo");
            refreshgeneral();
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //refresh
        private void refreshgeneral()
        {
            modnome.Clear();
            modmedico.Clear();
            modnome.Clear();
            modcognome.Clear();
            modres.Clear();
            modid.Clear();
            modnascita.Value = DateTime.Now;
            modgruppo.SelectedIndex = -1;
            moddisciplina.SelectedIndex = -1;
            modagonismo.SelectedIndex = -1;
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
            button4.Enabled = false;
            modemissione.Value = DateTime.Now;
            UpdateGeneralGrid();
        }
        private void refreshdisciplina()
        {
            var visualizza = EleDiscipline.OrderBy(s => s.Nome);
            GridDisciplina.DataSource = visualizza.ToList();
            eliminadis.Enabled = false;
            modis.Enabled = false;
            nomedis.Clear();
            mindil.Value=0;
            minjun.Value = 0;
            minsen.Value = 0;

        }
        private void refreshgruppo()
        {
            var visualizza = Gruppi.OrderBy(s => s.Nome);
            GridGruppo.DataSource = visualizza.ToList();
            eliminagruppo.Enabled = false;
            btnmodgruppo.Enabled = false;
            RSGr.Clear();
            Sede.Clear();
            nominativo.Clear();
            cell.Clear();
            email.Clear();
        }
        private void refreshins()
        {
            id.Clear();
            medico.Clear();
            emissione.Value = DateTime.Now;
            NomeAtleta.Clear();
            CognomeAtleta.Clear();
            NascitaAtleta.Value = DateTime.Now;
            ResidenzaAtleta.Clear();
            GruppoSportivo.SelectedIndex = -1;
            Agonismo.SelectedIndex = -1;
            Disciplina.SelectedIndex = -1;
            LVL.Value = 1;
        }

        private void UpdateGeneralGrid()
        {
            var visualizza = Certificati;
            if (searchsidisciplina.SelectedIndex!=-1)
            {
                 visualizza = visualizza.Where(s => s.Disciplina.Nome == searchsidisciplina.Text).ToList();
            }
            if(Searchgruppi.SelectedIndex != -1)
            {
                visualizza = visualizza.Where(s => s.Gruppo_sportivo.Nome == Searchgruppi.Text).ToList();
            }
            if(Migliore.Checked)
            {
                visualizza = visualizza.Where(s => {
                string k = s.Livello_Agonistico;
                    switch (k)
                    {
                        case "Dilettante":
                            {
                                if (s.Idoneità > s.Disciplina.LvlMinJunior)
                                {
                                    return true;
                                }
                                return false;
                            }
                        case "Junior":
                            {
                                if (s.Idoneità > s.Disciplina.LvlMinSenior)
                                {
                                    return true;
                                }

                                return false;
                            }
                        default:
                            {
                                return false;
                            }
                    }
                }).ToList();
            }
            GridVisualizza.DataSource = visualizza.OrderBy(s => s.Disciplina.Nome).ToList(); 
        }
        //----------------------------------------
        private void GridVisualizza_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            modid.Text = GridVisualizza.SelectedRows[0].Cells[0].Value.ToString();
            var k = Certificati.Where(s => s.Idcertificato== modid.Text).FirstOrDefault();
            if(k==null)
            {
                MessageBox.Show("Errore nel caricamento dei dati codice non trovato");
                return;
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
            button4.Enabled = true;
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
            var result=MessageBox.Show("Cancellando la disciplina verranno eliminati tutti i cerificati con questa disciplina si vuole continuare?", "ATTENZIONE!", MessageBoxButtons.YesNo);
            switch(result)
            {
                case DialogResult.Yes:
                {

                        Discipline x = EleDiscipline.Where(s => s.Nome == GridDisciplina.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
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
                        Disciplina.Items.Remove(EleDiscipline[index]);
                        moddisciplina.Items.Remove(EleDiscipline[index]);
                        EleDiscipline[index].Dispose();
                        EleDiscipline.Remove(x);
                        refreshdisciplina();

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
            var result = MessageBox.Show("Cancellando la disciplina verranno eliminati tutti i cerificati con questa disciplina si vuole continuare?", "ATTENZIONE!", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    {

                        var x = Gruppi.Where(s => s.Nome == GridGruppo.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
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
                        GruppoSportivo.Items.Remove(Gruppi[index]);
                        modgruppo.Items.Remove(Gruppi[index]);
                        Gruppi[index].Dispose();
                        Gruppi.Remove(x);
                        MessageBox.Show("Gruppo sportivo eliminata con successo, sono stati eliminati " + eliminati + " certificati che contenevano questa disciplina");
                        refreshgruppo();
                        break;
                    }
                case DialogResult.No:
                    {
                        return;
                    }
            }
        }

        private void btnmodgruppo_Click(object sender, EventArgs e)
        {
            try
            {

                int x = Gruppi.IndexOf(Gruppi.Where(s => s.Nome == GridGruppo.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault());
                if (x == -1)
                {
                    MessageBox.Show("ERRORE IL GRUPPO NON SEMBRA ESISTERE");
                    return;

                }
                var eliminato = Gruppi[x];
                Gruppi[x].ModifyParameters(RSGr.Text,cell.Text.Replace(" ",""),email.Text,Sede.Text,nominativo.Text);
                modgruppo.Items.Remove(eliminato);
                modgruppo.Items.Add(EleDiscipline[x]);
                GruppoSportivo.Items.Remove(eliminato);
                GruppoSportivo.Items.Add(EleDiscipline[x]);
                Searchgruppi.Items.Remove(eliminato);
                Searchgruppi.Items.Add(EleDiscipline[x]);
                refreshgruppo();
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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void resetdis_Click(object sender, EventArgs e)
        {
            searchsidisciplina.SelectedIndex = -1;
            refreshgeneral();
        }

        private void resetgruppo_Click(object sender, EventArgs e)
        {
            Searchgruppi.SelectedIndex = -1;
            refreshgeneral();
        }

        private void searchsidisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshgeneral();
        }

        private void Searchgruppi_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshgeneral();
        }

        private void Migliore_CheckedChanged(object sender, EventArgs e)
        {
            refreshgeneral();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Path = "Certificati.csv";
            StreamWriter miofile = new StreamWriter(Path);
            string row = default;
            foreach (var item in Certificati)
            {
                row = item.Idcertificato + ";" + item.Medico + ";" + item.Emissione.ToString() + ";" + item.Nome + ";" + item.Cognome + ";" + item.Nascita.ToString() + ";" + item.Residenza + ";" + item.Gruppo_sportivo.ToString() + ";" + item.Disciplina.ToString() + ";" + item.Livello_Agonistico + ";" + item.Idoneità.ToString();
                miofile.WriteLine(row);
            }
            miofile.Close();
            Path = "Discipline.csv";
            miofile =new StreamWriter(Path);
            foreach (var item in EleDiscipline)
            {
                row = item.Nome + ";" + item.LvlMinDilettanti.ToString() + ";" + item.LvlMinJunior.ToString() + ";" + item.LvlMinSenior.ToString();
                miofile.WriteLine(row);
            }
            miofile.Close();
            Path = "GruppiSportivi.csv";
            miofile = new StreamWriter(Path);
            foreach (var item in Gruppi)
            {
                row = item.Nome + ";" + item.Sede.ToString() + ";" + item.Presidete.ToString() + ";" + item.Telefono + ";" +item.Email;
                miofile.WriteLine(row);
            }
            miofile.Close();
        }
    }
}
