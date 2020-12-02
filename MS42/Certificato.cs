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
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (value.Trim().Count(f => f == ' ') == 0)
                {
                    throw new Exception("Inserire sia nome che cognome");
                }
                _Medico = value;
            }
        }
        private DateTime _Emissione;
        public DateTime Emissione
        {
            get { return _Emissione; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (value.Date > DateTime.Now.Date)
                {
                    throw new Exception("Data di emissione non valida");
                }
                if (value.Date < this.Nascita.Date)
                {
                    throw new Exception("Il certificato non può essere fatto prima della nascita dell'esaminato");
                }
                _Emissione = value;
            }
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                _Nome = value;
            }
        }
        private string _Cognome;
        public string Cognome
        {
            get { return _Cognome; }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                _Cognome = value;
            }
        }
        private DateTime _Nascita;
        public DateTime Nascita
        {
            get { return _Nascita; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (value.Date >= DateTime.Now.Date)
                {
                    throw new Exception("Data di nascita non valida");
                }
                if (this.Emissione.Date < value.Date)
                {
                    throw new Exception("Il certificato non può essere fatto prima della nascita dell'esaminato");
                }
                _Nascita = value;
            }
        }
        private string _Residenza;
        public string Residenza
        {
            get { return _Residenza; }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                _Residenza = value;
            }
        }
        private Gruppo_sportivo _Gruppo_sportivo;
        public Gruppo_sportivo Gruppo_sportivo
        {
            get { return _Gruppo_sportivo; }
            set
            {
                if (value==null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                _Gruppo_sportivo = value;
            }

        }
        private Discipline _Disciplina;
        public Discipline Disciplina
        {
            get { return _Disciplina; }

            set
            {
                if (value==null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
               string k = this.Livello_Agonistico;
                switch (k)
                {
                    case "Dilettante":
                        {
                            if (this.Idoneità < value.LvlMinDilettanti)
                            {
                                throw new Exception("Livello non sufficente per dilettanti");
                            }

                            break;
                        }
                    case "Junior":
                        {
                            if (this.Idoneità < value.LvlMinJunior)
                            {
                                throw new Exception("Livello non sufficente per Junior");
                            }

                            break;
                        }
                    case "Senior":
                        {
                            if (this.Idoneità < value.LvlMinSenior)
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
                _Disciplina = value;
            }
        }
        private string _Livello_Agonistico;
        public string Livello_Agonistico
        {
            get { return _Livello_Agonistico; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                
                string k = value;
                switch (k)
                {
                    case "Dilettante":
                        {
                            if (this.Idoneità < this._Disciplina.LvlMinDilettanti)
                            {
                                throw new Exception("Livello non sufficente per dilettanti");
                            }

                            break;
                        }
                    case "Junior":
                        {
                            if (this.Idoneità < this._Disciplina.LvlMinJunior)
                            {
                                throw new Exception("Livello non sufficente per Junior");
                            }

                            break;
                        }
                    case "Senior":
                        {
                            if (this.Idoneità < this._Disciplina.LvlMinSenior)
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
                _Livello_Agonistico = value;
            }
        }
        private int _Idoneità;
        public int Idoneità
        {
            get { return _Idoneità; }
            set
            {
                string k = this._Livello_Agonistico;
                switch (k)
                {
                    case "Dilettante":
                        {
                            if (value < this._Disciplina.LvlMinDilettanti)
                            {
                                throw new Exception("Livello non sufficente per dilettanti");
                            }

                            break;
                        }
                    case "Junior":
                        {
                            if (value < this._Disciplina.LvlMinJunior)
                            {
                                throw new Exception("Livello non sufficente per Junior");
                            }

                            break;
                        }
                    case "Senior":
                        {
                            if (value < this._Disciplina.LvlMinSenior)
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
                _Idoneità = value;
            }
                

        }


        public void ModifyParameters( string medico, string nome, string cognome, DateTime nascita, string residenza, Gruppo_sportivo Gruppo, Discipline disciplina, string agonismo, int lvl, DateTime emissione = default)
        {
            
            medico = medico.Trim();
            nome = nome.Trim();
            cognome = cognome.Trim();
            residenza = residenza.Trim();
            agonismo = agonismo.Trim();

            if ( string.IsNullOrEmpty(agonismo) || disciplina == null || string.IsNullOrEmpty(medico) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cognome) || nascita == null || string.IsNullOrEmpty(residenza) || Gruppo == null )
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
                            throw new Exception("Livello non sufficente per Senior");
                        }
                        break;

                    }
                default:
                    {
                        throw new Exception("Livello agonistico non valido");
                    }

            }
            if (medico.Trim().Count(f => f == ' ') == 0)
            {
                throw new Exception("Inserire sia nome che cognome");
            }
            if (emissione.Date > DateTime.Now.Date)
            {
                throw new Exception("Data di emissione non valida");
            }
            if (nascita.Date >= DateTime.Now.Date)
            {
                throw new Exception("Data di nascita non valida");
            }
            if (emissione < nascita)
            {
                throw new Exception("Il certificato non può essere fatto prima della nascita dell'esaminato");
            }
            this._Emissione = emissione;

            this._Medico = medico;

            this._Nome = nome;
            this._Cognome = cognome;
            this._Nascita = nascita.Date;
            this._Residenza = residenza;
            this._Gruppo_sportivo = Gruppo;
            this._Disciplina = disciplina;
            this._Livello_Agonistico = agonismo;
            this._Idoneità = lvl;
        }

        public Certificato(string codice, string medico, string nome, string cognome, DateTime nascita, string residenza, Gruppo_sportivo Gruppo, Discipline disciplina, string agonismo, int lvl, DateTime emissione = default)
        {
            codice = codice.Trim();
            medico = medico.Trim();
            nome = nome.Trim();
            cognome = cognome.Trim();
            residenza = residenza.Trim();
            agonismo = agonismo.Trim();
            if (string.IsNullOrEmpty(codice) || string.IsNullOrEmpty(agonismo) || disciplina == null )
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
                        throw new Exception("Livello agonistico non valido");
                    }

            }
            if(emissione.Date<nascita.Date)
            {
                throw new Exception("Il certificato non può essere fatto prima della nascita dell'esaminato");
            }
            if (emissione.Date > DateTime.Now.Date)
            {
                throw new Exception("Data di emissione non valida");
            }
            if (nascita.Date >= DateTime.Now.Date)
            {
                throw new Exception("Data di nascita non valida");
            }
            this._Emissione = emissione;
            this._Nascita = nascita.Date;
            this.Medico = medico;
            this.Idcertificato = codice;
            this.Nome = nome;
            this.Cognome = cognome;
            
            this.Residenza = residenza;
            this.Gruppo_sportivo = Gruppo;
            this._Disciplina = disciplina;
            this._Livello_Agonistico = agonismo;
            this._Idoneità = lvl;
            listaid.Add(codice);

        }
        //DISPOSE
        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {

                listaid.Remove(Idcertificato);
                _disposed = true;
            }

        }
        ~Certificato()
        {
            Dispose(false);
        }
        //----------------
    }
}
