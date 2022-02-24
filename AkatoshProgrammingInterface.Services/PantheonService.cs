using AkatoshProgrammingInterface.Data.IdentityData;
using AkatoshProgrammingInterface.Data.PantheonData;
using AkatoshProgrammingInterface.Models.PantheonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Services
{
    public class PantheonService
    {
        public PantheonService() { }

        public bool CreatePantheon(PantheonCreate model)
        {
            var entity =
                new Pantheon()
                {
                    PantheonName = model.PantheonName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pantheons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PantheonList> GetPantheons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Pantheons
                    .Select(
                        e =>
                        new PantheonList()
                        {
                            PantheonID = e.PantheonID,
                            PantheonName = e.PantheonName
                        });
                return query.ToArray();
            }
        }

        public PantheonDetail GetPantheonByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .Pantheons
                    .Single(e=> e.PantheonID == id);
                return
                    new PantheonDetail()
                    {
                        PantheonID = entity.PantheonID,
                        PantheonName = entity.PantheonName
                    };
            }
        }

        public bool UpdatePantheon(PantheonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Pantheons
                    .Single(e=> e.PantheonID == model.PantheonID);
                entity.PantheonName = model.PantheonName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePantheon(int pantheonID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Pantheons
                    .Single(e => e.PantheonID == pantheonID);

                ctx.Pantheons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
