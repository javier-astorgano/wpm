using Microsoft.EntityFrameworkCore;
using wpm.Domain;

namespace wpm.Dal
{
    public class WpmDbContext(DbContextOptions<WpmDbContext> options) :DbContext(options)
    {
        public DbSet<Species> Species { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Owner>().HasData(
    new Owner() { Id = 1, Name = "Javier" },
    new Owner() { Id = 2, Name = "Alona" },
    new Owner() { Id = 3, Name = "Monica" },
    new Owner() { Id = 4, Name = "Alessando" },
    new Owner() { Id = 5, Name = "Silvia" },
    new Owner() { Id = 6, Name = "Dino" },
    new Owner() { Id = 7, Name = "Asier" },
    new Owner() { Id = 8, Name = "Vicina" }

    );
            modelBuilder.Entity<Species>().HasData(
    new Species() { Id=1, Name="Dog" },
    new Species() { Id=2, Name="Cat"},
    new Species() { Id=3, Name="Rabbit"}

    );
            modelBuilder.Entity<Breed>().HasData(
    new Breed() { Id = 1, Name = "Siberiano", IdealMaxWeight = 5, SpeciesId = 2 },
    new Breed() { Id = 2, Name = "Border Collie", IdealMaxWeight = 5, SpeciesId = 1 },
    new Breed() { Id = 3, Name = "Pastor Tedesco", IdealMaxWeight = 5, SpeciesId = 1 },
    new Breed() { Id = 4, Name = "American", IdealMaxWeight = 5, SpeciesId = 1 },
    new Breed() { Id = 5, Name = "Non si sa", IdealMaxWeight = 5, SpeciesId = 1 },
    new Breed() { Id = 6, Name = "Maremano", IdealMaxWeight = 5, SpeciesId = 1 }

    );            
            modelBuilder.Entity<Pet>().HasData(
                new Pet() { Id = 1, Name = "Bucks", Age = 8, BreedId = 1 },
                new Pet() { Id = 2, Name = "Shiro", Age = 10, BreedId = 2 },
                new Pet() { Id = 3, Name = "Peggy", Age = 5, BreedId = 3 },
                new Pet() { Id = 4, Name = "Pablo", Age = 1, BreedId = 5 },
                new Pet() { Id = 5, Name = "Monela", Age = 2, BreedId = 6 },
                new Pet() { Id = 6, Name = "Tommy", Age = 6, BreedId = 4 },
                new Pet() { Id = 7, Name = "Gaia", Age = 11, BreedId = 2 }
                );
            modelBuilder.Entity("OwnerPet").HasData(
               [
                new { PetsId =1, OwnersId =1},
                new { PetsId =1, OwnersId =2},
                new { PetsId =2, OwnersId =1},
                new { PetsId =3, OwnersId =3},
                new { PetsId =3, OwnersId =4},
                new { PetsId =4, OwnersId =5},
                new { PetsId =5, OwnersId =6},
                new { PetsId =6, OwnersId =8},
                new { PetsId =7, OwnersId =7}
                ]
                );
        }
    }
}
