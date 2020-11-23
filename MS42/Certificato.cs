﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS42
{
    class Certificato
    {
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
                if (Emissione==null)
                {
                    throw new Exception("Non sono accettati campi nulli");
                }
                if(Emissione>DateTime.Now)
                {
                    throw new Exception("Data non valida");
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
                    throw new Exception("Data non valida");
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
        public Gruppo_sportivo Gruppo_sportivo { get; set; }
        public Discipline Disciplina { get; set; }
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
                if(value!="Dilettanti" && value != "Junior" && value != "Senior")
                _Livello_Agonistico = value;
            }
        }
        private int _Idoneità;
        public int Idoneità
        {
            get { return _Idoneità; }
            set
            {
                if (value>=1 && value<=100)
                {
                    throw new Exception("Range massimo superato");
                }
                _Idoneità = value;
            }
        }
            
        


        public Certificato(string codice, string medico, string nome,string cognome,DateTime nascita, string residenza, Gruppo_sportivo Gruppo,Discipline disciplina, string agonismo,int lvl, DateTime emissione = default )
        {

        }
    }
}
