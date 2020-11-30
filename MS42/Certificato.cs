using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS42
{
    class Certificato : IDisposable
    {
        private static List<string> listaid = new List<string>();
        
        public string Idcertificato { get; }
        private string _Medico;
        public string Medico
        {
            get { return _Medico; }
            //set
            //{
            //    if (String.IsNullOrEmpty(value))
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    if (value.Trim().Count(f => f == ' ') == 0)
            //    {
            //        throw new Exception("Inserire sia nome che cognome");
            //    }
            //    _Medico = value;
            //}
        }
        private DateTime _Emissione;
        public DateTime Emissione
        {
            get { return _Emissione; }
            //set
            //{
            //    if (value == null)
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    if (value > DateTime.Now)
            //    {
            //        throw new Exception("Data di emissione non valida");
            //    }
            //    _Emissione = value;
            //}
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            //set
            //{
            //    if (String.IsNullOrEmpty(value))
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    _Nome = value;
            //}
        }
        private string _Cognome;
        public string Cognome
        {
            get { return _Cognome; }
            //set
            //{
            //    if (String.IsNullOrEmpty(value))
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    _Cognome = value;
            //}
        }
        private DateTime _Nascita;
        public DateTime Nascita
        {
            get { return _Nascita; }
            //set
            //{
            //    if (value == null)
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    if (value >= DateTime.Now)
            //    {
            //        throw new Exception("Data di nascita non valida");
            //    }
            //    _Nascita = value;
            //}
        }
        private string _Residenza;
        public string Residenza
        {
            get { return _Residenza; }
            //set
            //{
            //    if (String.IsNullOrEmpty(value))
            //    {
            //        throw new Exception("Non sono accettati campi nulli");
            //    }
            //    _Residenza = value;
            //}
        }
        private Gruppo_sportivo _Gruppo_sportivo;
        public Gruppo_sportivo Gruppo_sportivo
        {
            get { return _Gruppo_sportivo; }
            

        }
        private Discipline _Disciplina;
        public Discipline Disciplina
        {
            get { return _Disciplina; }
            

        }
        private string _Livello_Agonistico;
        public string Livello_Agonistico
        {
            get { return _Livello_Agonistico; }
            
        }
        private int _Idoneità;
        public int Idoneità
        {
            get { return _Idoneità; }
            

        }


        public void ModifyParameters( string medico, string nome, string cognome, DateTime nascita, string residenza, Gruppo_sportivo Gruppo, Discipline disciplina, string agonismo, int lvl, DateTime emissione = default)
        {


            if ( string.IsNullOrEmpty(agonismo) || disciplina == null || string.IsNullOrEmpty(medico) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cognome) || nascita == null || string.IsNullOrEmpty(residenza) || Gruppo == null || disciplina == null || string.IsNullOrEmpty(agonismo))
            {
                throw new Exception("Non sono accettati campi nulli");
            }
            
            if (emissione == default(DateTime))
            {
                emissione = DateTime.Now;
            }

            if (!(lvl >= 1 && lvl <= 100))
            {
                throw new Exception("Range massimo superato");
            }
            if (agonismo != "Dilettante" && agonismo != "Junior" && agonismo != "Senior")
            {
                throw new Exception("Classe non valida");
            }
            string k = agonismo;
            switch (k)
            {
                case "Dilettante":
                    {
                        if (lvl < disciplina.LvlMinDilettanti)
                        {
                            throw new Exception("Livello non sufficente per dilettanti");
                        }

                        break;
                    }
                case "Junior":
                    {
                        if (lvl < disciplina.LvlMinJunior)
                        {
                            throw new Exception("Livello non sufficente per Junior");
                        }

                        break;
                    }
                case "Senior":
                    {
                        if (lvl < disciplina.LvlMinSenior)
                        {
                            throw new Exception("Non sono accettati campi Senior");
                        }
                        break;

                    }
                default:
                    {
                        throw new Exception("Classe non valida");
                    }

            }
            if (medico.Trim().Count(f => f == ' ') == 0)
            {
                throw new Exception("Inserire sia nome che cognome");
            }
            if (emissione >= DateTime.Now)
            {
                throw new Exception("Data di emissione non valida");
            }
            if (nascita > DateTime.Now)
            {
                throw new Exception("Data di nascita non valida");
            }
            _Emissione = emissione;

            _Medico = medico;

            this._Nome = nome;
            this._Cognome = cognome;
            this._Nascita = nascita;
            this._Residenza = residenza;
            this._Gruppo_sportivo = Gruppo;
            this._Disciplina = disciplina;
            this._Livello_Agonistico = agonismo;
            this._Idoneità = lvl;
        }

        public Certificato(string codice, string medico, string nome, string cognome, DateTime nascita, string residenza, Gruppo_sportivo Gruppo, Discipline disciplina, string agonismo, int lvl, DateTime emissione = default)
        {
            if (string.IsNullOrEmpty(codice) || string.IsNullOrEmpty(agonismo) || disciplina == null || string.IsNullOrEmpty(medico)|| string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cognome) || nascita==null || string.IsNullOrEmpty(residenza) || Gruppo==null || disciplina==null || string.IsNullOrEmpty(agonismo))
            {
                throw new Exception("Non sono accettati campi nulli");
            }
            if (listaid.Contains(codice))
            {
                throw new Exception("Id già presente");
            }
            if (emissione == default(DateTime))
            {
                emissione = DateTime.Now;
            }

            if (!(lvl >= 1 && lvl <= 100))
            {
                throw new Exception("Range massimo superato");
            }
            if (agonismo != "Dilettante" && agonismo != "Junior" && agonismo != "Senior")
            {
                throw new Exception("Classe non valida");
            }
            string k = agonismo;
            switch (k)
            {
                case "Dilettante":
                    {
                        if (lvl < disciplina.LvlMinDilettanti)
                        {
                            throw new Exception("Livello non sufficente per dilettanti");
                        }

                        break;
                    }
                case "Junior":
                    {
                        if (lvl < disciplina.LvlMinJunior)
                        {
                            throw new Exception("Livello non sufficente per Junior");
                        }

                        break;
                    }
                case "Senior":
                    {
                        if (lvl < disciplina.LvlMinSenior)
                        {
                            throw new Exception("Non sono accettati campi Senior");
                        }
                        break;

                    }
                default:
                    {
                        throw new Exception("Classe non valida");
                    }

            }
            if (medico.Trim().Count(f => f == ' ') == 0)
            {
                throw new Exception("Inserire sia nome che cognome");
            }
            if (Emissione > DateTime.Now)
            {
                throw new Exception("Data di emissione non valida");
            }
            _Emissione = emissione;
        
            _Medico = medico;
            this.Idcertificato = codice;
            this._Nome = nome;
            this._Cognome = cognome;
            this._Nascita = nascita;
            this._Residenza = residenza;
            this._Gruppo_sportivo = Gruppo;
            this._Disciplina = disciplina;
            this._Livello_Agonistico = agonismo;
            this._Idoneità = lvl;
            listaid.Add(codice);

        }
     
        public void Dispose()
        {
            listaid.Remove(this.Idcertificato);
        }
    }
}
