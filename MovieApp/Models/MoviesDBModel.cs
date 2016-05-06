namespace MovieApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoviesDBModel : DbContext
    {
       

        public MoviesDBModel()
            : base("name=MoviesDBEntities")
        {
        }
            
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
