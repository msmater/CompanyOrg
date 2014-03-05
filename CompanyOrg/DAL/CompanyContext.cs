using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyOrg.Models;

namespace CompanyOrg.Models
{

    public class CompanyContext : DbContext
    {
        //        public CompanyContext() : base("CompanyOrg") {} // OLD way

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Komputer> Komputery { get; set; }
        public DbSet<Lokalizacja> Lokalizacje { get; set; }
        public DbSet<JednostkaOrg> JednostkiOrg { set; get; }

      

        public CompanyContext()
            : base("CompanyOrg") 
        {
            //Database.SetInitializer<CompanyContext>(null);// mialo dzialac i nei dziaal
            //Database.SetInitializer<CompanyContext>(new DropCreateDatabaseIfModelChanges<CompanyContext>());                    
            //(new DropCreateDatabaseAlways<CompanyContext>());
        }

        /***
         * //Tamplate ze strony
         * //http://stackoverflow.com/questions/20349796/asp-net-mvc4-ef5-invalid-column-error?answertab=active#tab-top
          protected override void OnModelCreating(DbModelBuilder modelBuilder) 
         {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>().HasRequired(x => x.Song).WithMany(y => y.Comments).WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>().HasRequired(x => x.User).WithMany(y => y.Comments).WillCascadeOnDelete(false);
         }
         */

        //wylacza tworzenie tabel o nazwie w liczbie mnogiej
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            /**
             modelBuilder.Entity OrganizationStructure>()
            .HasMany(o => o.ChildrenItems)
            .WithOptional()
            .HasForeignKey(c => c.ParentID);
             */
            /**
             jednostka_org 1 - uzytkownik many
            komputer many - lokalizacja 1

            uzytkownik 1 - komputer many
            uzytkownik many - lokalizacja 1
             */
            modelBuilder.Entity<JednostkaOrg>()
            .HasMany(o => o.Uzytkownicy)
            .WithOptional()
            .HasForeignKey(c => c.jednostka_organizacyjnaID_JO);//ewentualnie id

            modelBuilder.Entity<Lokalizacja>()
                .HasMany(o => o.Uzytkownicy)
                .WithOptional()
                .HasForeignKey(c => c.lokalizacjaId);//ewentualnie id

            modelBuilder.Entity<Uzytkownik>()
                .HasMany(o => o.Komputery)
                .WithOptional()
                .HasForeignKey(c => c.wlascicielId);
        }
    }
}