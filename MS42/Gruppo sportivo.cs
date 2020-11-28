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
        public void ModifyParametersForUniqueness(string Nome, string Cell, string Email)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Cell) || string.IsNullOrEmpty(Nome))
            {
                throw new Exception("Inserire la sede del gruppo sportivo");
            }
            if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Email non valida");
            }
            Cell = Cell.Trim();

            if (Cell.Length != 10)
            {
                throw new Exception("Numero non valido");
            }
            if (!Int64.TryParse(Cell, out Int64 item))
            {
                throw new Exception("Il Numero di telefono deve essere appunto un numero");
            }
            if (listnome.Contains(Nome))
            {
                throw new Exception("Gruppo sportivo già inserito");
            }
            if (listcell.Contains(Cell))
            {
                throw new Exception("Numero di telefono già inserito");
            }
            if (listemail.Contains(Email))
            {
                throw new Exception("Email già inserito");
            }
            listnome.Remove(_Nome);
            listnome.Add(Nome);
            _Nome = Nome;
            listemail.Remove(_Email);
            listnome.Add(Email);
            _Email = Email;
            listemail.Remove(_Telefono);
            listnome.Add(Cell);
            _Telefono = Cell;
            
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            //set
            //{
            //    //if(string.IsNullOrEmpty(value))
            //    //{
            //    //    throw new Exception("Inserire il nome del gruppo sportivo");
            //    //}
            //    //if(_Nome==value)
            //    //{
            //    //    return;
            //    //}
            //    //if(listnome.Contains(value))
            //    //{
            //    //    throw new Exception("Gruppo sportivo Già inserito");
            //    //}
            //    //listnome.Remove(_Nome);
            //    //_Nome = value;       /////// PROBLEMA MODIFICA 
            //    //listnome.Add(_Nome);
            //}

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");

                }
                if(value.Trim().Count(f=> f==' ')==0)
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
                //value = value.Trim();
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new Exception("Inserire la sede del gruppo sportivo");
                //}
                //if(value.Length>15)
                //{
                //    throw new Exception("Numero non valido");
                //}
                //if(!Int64.TryParse(value,out Int64 item))
                //{
                //    throw new Exception("Il Numero di telefono deve essere appunto un numero");
                //}
                //_Telefono = value;
            }

        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            //set
            //{
            //    if (string.IsNullOrEmpty(value))
            //    {
            //        throw new Exception("Inserire la sede del gruppo sportivo");
            //    }
            //    if(!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            //    {
            //        throw new Exception("Email non valida");
            //    }
            //    _Email = value;
            //}

        }
        public override string ToString()
        {
            return _Nome;
        }
        public Gruppo_sportivo (string nome, string sede,string capo, string cell, string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cell) || string.IsNullOrEmpty(nome))
            {
                throw new Exception("Inserire la sede del gruppo sportivo");
            }
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Email non valida");
            }
            cell = cell.Trim();
            
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
        public void Dispose()
        {
            listnome.Remove(this.Nome);
        }

    }
}
