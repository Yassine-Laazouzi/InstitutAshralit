//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Institut_Ashralite_Adm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class COURS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURS()
        {
            this.PRESENCE = new HashSet<PRESENCE>();
        }
    
        public int ID { get; set; }
        public int ID_MATIERE { get; set; }
        public int ID_ENCADREUR { get; set; }
        public string LIBELLE { get; set; }
        public System.DateTime DATE_COURS { get; set; }
        public Nullable<int> HEURE_DEBUT { get; set; }
        public Nullable<int> HEURE_FIN { get; set; }
        public string COMMENTAIRE { get; set; }
        public bool ACTIF { get; set; }
        public System.DateTime DATE_ACTIF { get; set; }
        public string UTILISATEUR_CREATION { get; set; }
        public string UTILISATEUR_MODIFICATION { get; set; }
        public System.DateTime DATE_CREATION { get; set; }
        public System.DateTime DATE_MODIFICATION { get; set; }
    
        public virtual INDIVIDU INDIVIDU { get; set; }
        public virtual MATIERE MATIERE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENCE> PRESENCE { get; set; }
    }
}
