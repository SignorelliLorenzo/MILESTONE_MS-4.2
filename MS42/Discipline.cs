using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS42
{
    class Discipline : IDisposable
    {
        private List<string> elenomi = new List<string>();
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Fornire un nome");
                }
                if (elenomi.Contains(value))
                {
                    throw new Exception("Disciplina già creata");
                }
                _Nome = value;
            }

        }
        private int _LvlMinDilettanti;
        public int LvlMinDilettanti { get { return _LvlMinDilettanti; } 
            set
            {
                if(value<0 || value>100)
                {
                    throw new Exception("Inserire un valore valido per i dilettanti");
                }
                if(value>this._LvlMinJunior)
                {
                    throw new Exception("Valore troppo alto intervallo non valido");
                }
                _LvlMinDilettanti = value;
            }
        }
        private int _LvlMinJunior;
        public int LvlMinJunior
        {
            get { return _LvlMinJunior; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Inserire un valore valido per la categoria Junior");
                }
                if (value > this._LvlMinSenior || value > this._LvlMinDilettanti)
                {
                    throw new Exception("Valore troppo alto intervallo non valido");
                }
                _LvlMinJunior = value;
            }
        }
        private int _LvlMinSenior;
        public int LvlMinSenior
        {
            get { return _LvlMinSenior; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Inserire un valore valido per la categoria Senior");
                }
                if (value < this._LvlMinJunior)
                {
                    throw new Exception("Valore troppo alto intervallo non valido");
                }
                _LvlMinSenior = value;
            }
        }
        public void Dispose()
        {
            elenomi.Remove(Nome);
        }
        public Discipline(int dilettanti, int junior, int senior, string nome)
        {
            if(!(dilettanti<junior && junior<senior) || (dilettanti < 0 || senior > 100) )
            {
                throw new Exception("Fornire intervalli validi");
            }
           
            this.Nome = nome;
            this._LvlMinDilettanti = dilettanti;
            this._LvlMinJunior = junior;
            this._LvlMinSenior = senior;
        }
    }
}
