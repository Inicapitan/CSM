using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CsmContext context)
        {
            context.Database.EnsureCreated();

            if (context.Client.Any()
                || context.Stock.Any()
                || context.Schedule.Any()
                || context.Service.Any())
            {
                return;
            }

            var clients = new Client[]
            {
               new Client{Name="Marc",Surname="Iniesta",NIF="45235689E",Mail="marc@iniesta.com",Gender="Male",Phone=789456123},
               new Client{Name="Cris",Surname="<3",NIF="45235689E",Mail="cris@galveh.com",Gender="Fenale",Phone=789456123},
               new Client{Name="Pol",Surname="Iniesta",NIF="45235689E",Mail="Pol@iniesta.com",Gender="Male",Phone=789456123}
            };
            foreach(var c in clients)
            {
                context.Client.Add(c);
            }
            context.SaveChanges();

            var stocks = new Stock[]
            {
                new Stock{Brand="Pan",Model="Bimbo", Category="Pan", Description="Esto es la descr. de un pan bimbo"},
                new Stock{Brand="Pan",Model="De Molde", Category="Pan", Description="Esto es la descr. de un pan de molde"},
                new Stock{Brand="Yamaha",Model="MT-07", Category="Motocicleta", Description="Esto es la descr. de una moto"}
            };
            foreach(var st in stocks)
            {
                context.Stock.Add(st);
            }
            context.SaveChanges();

            var schdules = new Schedule[]
            {
                new Schedule{ClientID=0,ServiceID=0, Date=DateTime.Parse("2019-05-07"),Payed=true},
                new Schedule{ClientID=0,ServiceID=2, Date=DateTime.Parse("2019-05-08"),Payed=false},
                new Schedule{ClientID=1,ServiceID=3, Date=DateTime.Parse("2019-05-09"),Payed=true},
            };
            foreach(var sc in schdules)
            {
                context.Schedule.Add(sc);
            }
            context.SaveChanges();

            var services = new Service[]
            {
                new Service{Name="Cambio aseite", Time=30, Description="Esto es la descr. de un cambio di aseite", Price=15},
                new Service{Name="Cambio flitro", Time=15, Description="Esto es la descr. de un cambio di filtro", Price=30},
                new Service{Name="Taller", Time=60, Description="Esto es la descr. di un taller intero ehh", Price=60},
            };
            foreach (var ser in services)
            {
                context.Service.Add(ser);
            }
            context.SaveChanges();
        }
    }
}
