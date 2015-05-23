using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrabalhoWeb2.Models;

namespace WS.Model
{
    public class DataAccessController : DbContext
    {
        public DataAccessController()
            : base("aulaweb2")
        {
            Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["aulaweb2"].ToString();
            
            Database.SetInitializer<DataAccessController>(new CreateDatabaseIfNotExists<DataAccessController>());

            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Participantes> Participantes { get; set; }
    }
}