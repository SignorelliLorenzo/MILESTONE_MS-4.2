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
        private List<string> listnome = new List<string>();
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire il nome del gruppo sportivo");
                }
                if(listnome.Contains(value))
                {
                    throw new Exception("Gruppo sportivo Già inserito");
                }
               _Nome = value;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
                }
                if(value.Length>15)
                {
                    throw new Exception("Numero non valido");
                }

                _Telefono = value;
            }

        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Inserire la sede del gruppo sportivo");
                }
                if(!Regex.IsMatch(value, @"^([a - zA - Z0 - 9_\-\.] +)@([a - zA - Z0 - 9_\-\.] +)\.([a - zA - Z]{ 2,5})$"))
                {
                    throw new Exception("Email non valida");
                }
                _Email = value;
            }

        }
        public Gruppo_sportivo (string nome, string sede,string capo, string cell, string email)
        {
            this.Nome = nome;
            this.Sede = sede;
            this.Presidete = capo;
            this.Telefono = cell;
            this.Email = email;
            listnome.Add(nome);
        }
        public void Dispose()
        {
            listnome.Remove(this.Nome);
        }

    }
}
