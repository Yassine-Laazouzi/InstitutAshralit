using Institut_Ashralite_Adm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institut_Ashralite_Adm.ViewModel
{
    public class MatiereViewModel
    {
        public MATIERE MATIERE = new MATIERE();
        public List<INDIVIDU> INDIVIDU { get; set; }


    }
}