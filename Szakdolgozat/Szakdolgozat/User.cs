using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat
{
    class User
    {
        int felhasznaloid;
        string name;
        string jelszo;


        public string Name { get => name; set => name = value; }
        public string Jelszo { get => jelszo; set => jelszo = value; }
        public int Felhasznaloid { get => felhasznaloid; set => felhasznaloid = value; }

        public User()
        {

        }
    }
}
