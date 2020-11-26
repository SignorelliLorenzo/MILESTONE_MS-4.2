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
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
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
                if (Emissione == null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (Emissione > DateTime.Now)
                {
                    throw new Exception("Data di emissione non valida");
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
                if (Emissione == null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (Emissione > DateTime.Now)
                {
                    throw new Exception("Data di nascita non valida");
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
                if (value == null)
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
                if (value == null)
                {
                    throw new Exception("Non sono accettati campi nulli");
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if (value != "Dilettanti" && value != "Junior" && value != "Senior")
                    _Livello_Agonistico = value;
            }
        }
        private int _Idoneità;
        public int Idoneità
        {
            get { return _Idoneità; }
            set
            {
                if (value >= 1 && value <= 100)
                {
                    throw new Exception("Range massimo superato");
                }
                string k = this._Livello_Agonistico;
                switch (k)
                {
                    case "Dilettanti":
                        {
                            if (value<_Disciplina.LvlMinDilettanti)
                            {
                                throw new Exception("Livello non sufficente per dilettanti");
                            }
                            
                            break;
                        }
                    case "Junior":
                        {
                            if (value < _Disciplina.LvlMinJunior)
                            {
                                throw new Exception("Livello non sufficente per Junior");
                            }
                            
                            break;
                        }
                    case "Senior":
                        {
                            if (value < _Disciplina.LvlMinSenior)
                            {
                                throw new Exception("Non sono accettati campi Senior");
                            }
                            break;
                        }

                }
                _Idoneità = value;
            }
        }




        public Certificato(string codice, string medico, string nome, string cognome, DateTime nascita, string residenza, Gruppo_sportivo Gruppo, Discipline disciplina, string agonismo, int lvl, DateTime emissione = default)
        {
            if (string.IsNullOrEmpty(codice))
            {
                throw new Exception("L'id non può essere nullo");
            }
            if (listaid.Contains(codice))
            {
                throw new Exception("Id già presente");
            }
            if (emissione == default(DateTime))
            {
                emissione = DateTime.Now;
            }
            this.Idcertificato = codice;
            this.Medico = medico;
            this.Nome = nome;
            this.Cognome = cognome;
            this.Nascita = nascita;
            this.Residenza = residenza;
            this.Gruppo_sportivo = Gruppo;
            this.Disciplina = disciplina;
            this.Livello_Agonistico = agonismo;
            this.Idoneità = lvl;
            this.Emissione = emissione;
            listaid.Add(codice);

        }
        public void Dispose()
        {
            listaid.Remove(this.Idcertificato);
        }
    }
}
