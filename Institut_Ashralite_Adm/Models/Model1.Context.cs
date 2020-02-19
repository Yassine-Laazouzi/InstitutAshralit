﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Institut_Ashralite_ADMEntities : DbContext
    {
        public Institut_Ashralite_ADMEntities()
            : base("name=Institut_Ashralite_ADMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COURS> COURS { get; set; }
        public virtual DbSet<INDIVIDU> INDIVIDU { get; set; }
        public virtual DbSet<INSCRIPTION> INSCRIPTION { get; set; }
        public virtual DbSet<MATIERE> MATIERE { get; set; }
        public virtual DbSet<PRESENCE> PRESENCE { get; set; }
        public virtual DbSet<REF_CIVILITE> REF_CIVILITE { get; set; }
        public virtual DbSet<REF_METIER> REF_METIER { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    
        public virtual int I_Ligne_Table_Presence(Nullable<int> i_id_cours, Nullable<int> i_id_eleve)
        {
            var i_id_coursParameter = i_id_cours.HasValue ?
                new ObjectParameter("I_id_cours", i_id_cours) :
                new ObjectParameter("I_id_cours", typeof(int));
    
            var i_id_eleveParameter = i_id_eleve.HasValue ?
                new ObjectParameter("I_id_eleve", i_id_eleve) :
                new ObjectParameter("I_id_eleve", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("I_Ligne_Table_Presence", i_id_coursParameter, i_id_eleveParameter);
        }
    
        public virtual int MAJ_Presence(Nullable<int> i_id_cours, Nullable<int> i_id_eleve)
        {
            var i_id_coursParameter = i_id_cours.HasValue ?
                new ObjectParameter("I_id_cours", i_id_cours) :
                new ObjectParameter("I_id_cours", typeof(int));
    
            var i_id_eleveParameter = i_id_eleve.HasValue ?
                new ObjectParameter("I_id_eleve", i_id_eleve) :
                new ObjectParameter("I_id_eleve", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MAJ_Presence", i_id_coursParameter, i_id_eleveParameter);
        }
    
        public virtual int I_Ajout_Matiere(Nullable<int> i_id_prof)
        {
            var i_id_profParameter = i_id_prof.HasValue ?
                new ObjectParameter("I_id_prof", i_id_prof) :
                new ObjectParameter("I_id_prof", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("I_Ajout_Matiere", i_id_profParameter);
        }
    
        public virtual int D_supprimer_eleve_dun_cours(Nullable<int> id_Matiere, Nullable<int> id_Eleve)
        {
            var id_MatiereParameter = id_Matiere.HasValue ?
                new ObjectParameter("id_Matiere", id_Matiere) :
                new ObjectParameter("id_Matiere", typeof(int));
    
            var id_EleveParameter = id_Eleve.HasValue ?
                new ObjectParameter("id_Eleve", id_Eleve) :
                new ObjectParameter("id_Eleve", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("D_supprimer_eleve_dun_cours", id_MatiereParameter, id_EleveParameter);
        }
    
        public virtual int D_supprimer_Matiere_avec_eleve(Nullable<int> id_Matiere)
        {
            var id_MatiereParameter = id_Matiere.HasValue ?
                new ObjectParameter("id_Matiere", id_Matiere) :
                new ObjectParameter("id_Matiere", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("D_supprimer_Matiere_avec_eleve", id_MatiereParameter);
        }
    }
}