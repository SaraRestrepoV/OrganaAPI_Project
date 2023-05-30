using Organa.DAL;
using Organa.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Organa
{
    public class Seeder
    {
        private readonly DataBaseContext _context;
        public Seeder(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //Esta línea me ayuda a crear mi BD de forma automática
            await PopulateDishesAsync();
           // await PopulateIngredientsAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateDishesAsync()
        {
            if (!_context.Dishes.Any())
            {
                _context.Dishes.Add(new Dish
                {
                    CreatedDate = DateTime.Now,
                    Name = "Bandeja paisa",
                    Category = 1,
                    Image = "https://cdn.colombia.com/gastronomia/2011/08/02/bandeja-paisa-1616.gif",
                    Description = "La bandeja paisa es uno de los platos más representativos de Colombia " +
                    "y la insignia de la gastronomía antioqueña, y es propio de esta región, Antioquia.",
                    Value = 25000,
                    Ingredients = new List<Ingredient>()

                    {
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Tallos de cebolla larga"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Tomates maduros"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Sobre de caldo con costilla maggie desmenuzado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Libra de carne molida magra"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Libra de arroz blanco cocinado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Libra de tocino crocante cortado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Chorizos tipo coctel"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Huevos fritos"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Aguacate partido en 4 porciones"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Arepas pequeñas redondas"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Tajadas de plátano maduro fritas "
                        }

                    }
                }) ; 
            }
        }
    }
}
