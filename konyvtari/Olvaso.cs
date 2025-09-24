using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtari
{
    class Olvaso
    {
        string nev;
        int kor;
        string ertesites;
        string tagsag;

        public Olvaso(string nev, int kor, string ertesites, string tagsag)
        {
            this.nev = nev;
            this.kor = kor;
            this.ertesites = ertesites;
            this.tagsag = tagsag;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Kor { get => kor; set => kor = value; }
        public string Ertesites { get => ertesites; set => ertesites = value; }
        public string Tagsag { get => tagsag; set => tagsag = value; }

        public override string? ToString()
        {
            return $"{nev}, {kor}, {ertesites}, {tagsag}";
        }
    }
}
