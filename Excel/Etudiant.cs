using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    internal class Etudiant
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Classe { get; set; }

        public Etudiant(string nom, string prenom, DateTime dateNaissance, string classe)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Classe = classe;
        }
        public int GetAge()
        {
            DateTime ActualDate = DateTime.Now;

            int age = ActualDate.Year - DateNaissance.Year;

            if (ActualDate.Month < DateNaissance.Month)
                age--;

            return age;
        }
    }
}
