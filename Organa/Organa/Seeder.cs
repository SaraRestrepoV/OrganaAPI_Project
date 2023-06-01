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
            await PopulateChefsAsync();
            await PopulateCustomersAsync();
            await PopulateDistributorsAsync();
            await PopulateMenusAsync();

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
                    Category = 1 /*0= Entrada, 1= Plato fuerte, 2= Postre*/,
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
                            Name = "1 cucharada y media de aceite"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "2 tallos de cebolla larga finamente picada"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "2 tomates maduros sin piel y finamente picados"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 sobre de caldo con costilla maggie desmenuzado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "3 tazas de agua"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1/2 libra de fríjoles bola roja remojados desde la noche anterior"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1/4 libra de carne molida magra"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1/2 libra de arroz blanco cocinado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1/4 de libra de tocino crocante cortado en 4 porciones"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "4 chorizos tipo coctel previamente cocinados y dorados"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "4 huevos fritos"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 aguacate partido en 4 porciones "
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "4 arepas pequeñas redondas"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "4 tajadas de plátano maduro fritas"
                        }

                    }
                });
                
                _context.Dishes.Add(new Dish
                {
                    CreatedDate = DateTime.Now,
                    Name = "Ajiaco Santafereño",
                    Category = 1 /*0= Entrada, 1= Plato fuerte, 2= Postre*/,
                    Image = "https://www.recetasnestle.com.co/sites/default/files/srh_recipes/f78cf6630b31638994b09b3b470b085c.jpg",
                    Description = "El Ajiaco santafereño en una receta tradicional de la zona centro de colombia.",
                    Value = 20000,
                    Ingredients = new List<Ingredient>()

                    {
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "300 g de pechuga"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "900 ml de agua"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "300 g de papa criolla pelada y cortada en cubos"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "300 g de papa pastusa pelada y cortada en rodajas"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "300 g de papa sabanera pelada y cortada en rodajas"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 mazorca tierna cortada  en rodajas de 3 cm"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 tallo de cebolla larga"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "5 g de ajo"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 ramillete de guascas"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 ramillete de cilantro"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "250 g de crema de leche"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "100 g de alcaparras"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 aguacate mediano cortado en cubos"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Sal al gusto"
                        }

                    }
                });

                _context.Dishes.Add(new Dish
                {
                    CreatedDate = DateTime.Now,
                    Name = "Postre napoleon",
                    Category = 2 /*0= Entrada, 1= Plato fuerte, 2= Postre*/,
                    Image = "https://cdn.colombia.com/gastronomia/2019/05/08/napoleon-1658.gif",
                    Description = " El postre napoleon es un postre hecho de hojaldre con capas de crema pastelera. " +
                    "Su forma moderna estuvo influenciada por las mejoras realizadas por Marie-Antoine Carême.",
                    Value = 15000,
                    Ingredients = new List<Ingredient>()

                    {
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "400 gramos de crema de leche"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "4 tazas de leche entera"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "400 gramos de leche condensada"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 paquete de galletas Ducales"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "125 gramos de maicena"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 sobre de milo"
                        }

                    }
                });

                _context.Dishes.Add(new Dish
                {
                    CreatedDate = DateTime.Now,
                    Name = "Croquetas de cangrejo",
                    Category = 0 /*0= Entrada, 1= Plato fuerte, 2= Postre*/,
                    Image = "https://www.laylita.com/recetas/wp-content/uploads/2023/03/Receta-de-las-croquetas-de-cangrejo.jpg",
                    Description = "Estas deliciosas croquetas se preparan con cangrejo (regular, jaiba, o surimi)," +
                    " queso crema, ralladura de pan, zanahoria, huevo, cilantro, y más.",
                    Value = 15000,
                    Ingredients = new List<Ingredient>()

                    {
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "300 gramos de carne/pulpa de cangrejo/jaiba"

                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 zanahoria pequeña"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "2 tazas y media de agua"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "3 tazas y media de queso crema"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 taza y media de pan rallado"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Media taza de harina de trigo"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "2 huevos"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "2 tazas de aceite"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "1 ramita de cilantro"
                        },
                        new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            CreatedDate = DateTime.Now,
                            Name = "Sal y pimienta al gusto"
                        }

                    }
                });
                
            }
        }

        private async Task PopulateMenusAsync()
        {
            if (!_context.Menus.Any())
            {
                _context.Menus.Add(new Menu
                {
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    Name = "Menú prueba",
                    Description = "Primer menú creado para el restaurante ORGANA",
                    Dishes = new List<Dish>()
                    {
                        new Dish{
                                 CreatedDate = DateTime.Now,
                                Name = "Plato prueba",
                                Category = 0 /*0= Entrada, 1= Plato fuerte, 2= Postre*/,
                                Image = "https://www.ORGANA/Platos/prueba.png",
                                Description = "Un plato creado para el menú de prueba.",
                                Value = 100000,
                                Ingredients = new List<Ingredient>()
                                    {
                                        new Ingredient
                                        {
                                            Id = Guid.NewGuid(),
                                            CreatedDate = DateTime.Now,
                                            Name = "Agua de uwu"
                                        }
                                    }
                                }
                    }
                });
            }
        }

        private async Task PopulateDistributorsAsync()
        {
            if (!_context.Distributors.Any())
            {
                _context.Distributors.Add(new DeliveryPerson
                {
                    CreatedDate = DateTime.Now,
                    deliveryPersonId = "1003456671",
                    firstName = "Susana",
                    lastName = "Horia",
                    email = "Susanahoria021@gmail.com",
                    phone = "3035567534"

                });

                _context.Distributors.Add(new DeliveryPerson
                {
                    CreatedDate = DateTime.Now,
                    deliveryPersonId = "1001234567",
                    firstName = "Antonio",
                    lastName = "Martinez",
                    email = "AntonnieMartinez04@gmail.com",
                    phone = "3267890567"

                });
            }
        }

        private async Task PopulateCustomersAsync()
        {
            if (!_context.Customers.Any())
            {
                _context.Customers.Add(new Customer
                {
                    CreatedDate = DateTime.Now,
                    customerId = "75690876",
                    firstName = "Cristina",
                    lastName = "Amalgama",
                    email = "CrisAmalga02@gmail.com",
                    phone = "3012485633",
                    address = "Calle 34 A # 10-25"

                });

                _context.Customers.Add(new Customer
                {
                    CreatedDate = DateTime.Now,
                    customerId = "1000234654",
                    firstName = "Santiago",
                    lastName = "Villamizar",
                    email = "SantVilla98@gmail.com",
                    phone = "3564568790",
                    address = "Calle 76 B # 08-10"

                });
            }
        }

        private async Task PopulateChefsAsync()
        {
            if(!_context.Chefs.Any())
            {
                _context.Chefs.Add(new Chef
                {
                    CreatedDate = DateTime.Now,
                    idChef = "1001278905",
                    firstNameChef = "Paquito",
                    lastNameChef = "Almarado",
                    emailChef = "PacoAL007@gmail.com",
                    phoneChef = "3108890768"

                });
            }
        }
    }
}
