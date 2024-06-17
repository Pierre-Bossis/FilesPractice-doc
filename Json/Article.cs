using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    internal class Article
    {
        public string Nom {  get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public Article(string nom,string description, decimal prix)
        {
            Nom = nom;
            Description = description;
            Prix = prix;
        }
    }
}
