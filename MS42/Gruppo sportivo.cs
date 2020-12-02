using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MS42
{
    class Gruppo_sportivo:IDisposable
    {
        private static List<string> listnome = new List<string>();
        private static List<string> listcell = new List<string>();
        private static List<string> listemail = new List<string>();
        public void ModifyParameters(string Nome, string Cell, string Email, string sede, string capo)
        {
            Cell = Cell.Trim();
            Email = Email.Trim();
            Nome = Nome.Trim();
            capo = capo.Trim();
            sede = sede.Trim();
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Cell) || string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(sede) || string.IsNullOrEmpty(capo))
            {
                throw new Exception("NON SONO ACCETTATI CAMPI NULLI");
            }
            if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Email non valida");
            }
            if (capo.Count(f => f == ' ') == 0)
            {
                throw new Exception("Inserire sia nome che cognome");
            }
            if (Cell.Length != 10)
            {
                throw new Exception("Numero non valido");
            }
            if (!Int64.TryParse(Cell, out Int64 item))
            {
                throw new Exception("Il Numero di telefono deve essere appunto un numero");
            }
            if (Nome != _Nome)
            {
                if (listnome.Contains(Nome))
                {
                    throw new Exception("Gruppo sportivo già inserito");
                }
                

            }

            if(Cell!=_Telefono)
            {
                if (listcell.Contains(Cell))
                {
                    throw new Exception("Numero di telefono già inserito");
                }
                
            }
            
            if (Email != _Email)
            {
                if (listemail.Contains(Email))
                {
                    throw new Exception("Email già inserito");
                }
                
                
            }
            listnome.Remove(_Nome);
            listnome.Add(Nome);
            _Nome = Nome;
            listemail.Remove(_Email);
            listemail.Add(Email);
            _Email = Email;
            listcell.Remove(_Telefono);
            listcell.Add(Cell);
            _Telefono = Cell;
            this._Sede = sede;
            this._Presidete = capo;


        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set
            {
                value=value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire il nome del gruppo sportivo");
                }
                if (value != _Nome)
                {
                    if (listnome.Contains(value))
                    {
                        throw new Exception("Gruppo sportivo già inserito");
                    }
                    listnome.Remove(_Nome);
                    _Nome = value;
                    listnome.Add(_Nome);

                }
                
            }

        }
        private string _Sede;
        public string Sede
        {
            get { return _Sede; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
                }

                _Sede = value;
            }

        }
        private string _Presidete;
        public string Presidete
        {
            get { return _Presidete; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire il nominativo");

                }
                if (value.Count(f => f == ' ') == 0)
                {
                    throw new Exception("Inserire sia nome che cognome");
                }
                _Presidete = value;
            }

        }
        private string _Telefono;
        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
                }
                if (value.Length > 15)
                {
                    throw new Exception("Numero non valido");
                }
                if (!Int64.TryParse(value, out Int64 item))
                {
                    throw new Exception("Il Numero di telefono deve essere appunto un numero");
                }
                if (value != _Telefono)
                {
                    if (listcell.Contains(value))
                    {
                        throw new Exception("Numero di telefono già inserito");
                    }
                    listcell.Remove(_Telefono);
                    listcell.Add(value);
                    _Telefono = value;
                }
                
            }

        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
                }
                if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new Exception("Email non valida");
                }
                if (value != _Email)
                {
                    if (listcell.Contains(value))
                    {
                        throw new Exception("Email già inserita");
                    }
                    listcell.Remove(_Email);
                    listcell.Add(value);
                    _Telefono = value;
                }
                _Email = value;
            }

        }
        public override string ToString()
        {
            return _Nome;
        }
        public Gruppo_sportivo (string nome, string sede,string capo, string cell, string email)
        {

            cell = cell.Trim();
            email = email.Trim();
            nome = nome.Trim();
            capo = capo.Trim();
            sede = sede.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cell) || string.IsNullOrEmpty(nome))
            {
                throw new Exception("NON SONO ACCETTATI CAMPI NULLI");
            }
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Email non valida");
            }
            cell = cell.Replace(" ",""); ;
            
            if (cell.Length != 10)
            {
                throw new Exception("Numero non valido");
            }
            if (!Int64.TryParse(cell, out Int64 item))
            {
                throw new Exception("Il Numero di telefono deve essere appunto un numero");
            }
            if (listnome.Contains(nome))
            {
                throw new Exception("Gruppo sportivo già inserito");
            }
            if (listcell.Contains(cell))
            {
                throw new Exception("Numero di telefono già inserito");
            }
            if (listemail.Contains(email))
            {
                throw new Exception("Email già inserito");
            }

            _Nome = nome; 
            _Telefono = cell;
            _Email = email;
            
            
            this.Sede = sede;
            this.Presidete = capo;
            listemail.Add(_Email);
            listcell.Add(_Telefono);
            listnome.Add(nome);
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

                listemail.Remove(this.Email);
                listnome.Remove(this.Nome);
                listcell.Remove(this.Telefono);
                _disposed = true;
            }

        }
        ~Gruppo_sportivo()
        {
            Dispose(false);
        }
        //-------------

    }
}
