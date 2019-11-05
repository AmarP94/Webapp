using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSite.db.EntityModels;

namespace WebSite.db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<KalendarskaObavijest> KalendarskaObavijests { get; set; }
        public DbSet<Konkurs> Konkursi { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Anketa> Ankete { get; set; }
        public DbSet<OdgovoriAnkete> OdgovoriAnkete { get; set; }
        public DbSet<Kanton> Kantoni { get; set; }
        public DbSet<KategorijeLinkova> KategorijeLinkova { get; set; }
        public DbSet<NajaveMediji> NajaveMediji { get; set; }
        public DbSet<Linkovi> Linkovi { get; set; }
        public DbSet<TipKonkursa> TipKonkursa { get; set; }
        public DbSet<UstanoveKantoni> Ustanove { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
