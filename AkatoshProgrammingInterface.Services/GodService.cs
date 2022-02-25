using AkatoshProgrammingInterface.Models.GodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkatoshProgrammingInterface.Data.GodData;
using AkatoshProgrammingInterface.Data.IdentityData;

namespace AkatoshProgrammingInterface.Services
{
    public class GodService
    {
        public GodService() { }

        public bool CreateGod(GodCreate model)
        {
            var entity =
                new God()
                {
                    GodName = model.GodName,
                    GodDesc = model.GodDesc
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GodList> GetGods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Gods
                    .Select(
                        e =>
                        new GodList()
                        {
                            GodID = e.GodID,
                            GodName = e.GodName
                        });
                return query.ToArray();
            }
        }

        public GodDetail GetGodByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gods
                    .Single(e => e.GodID == id);
                return
                    new GodDetail()
                    {
                        GodID = entity.GodID,
                        GodName= entity.GodName,
                        GodDesc= entity.GodDesc
                    };
            }
        }

        public bool UpdateGod(GodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .Gods
                    .Single(e=> e.GodID == model.GodID);
                entity.GodName = model.GodName;
                entity.GodDesc = model.GodDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGod(int godID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                God entity =
                    ctx
                    .Gods
                    .Single(e=> e.GodID == godID);

                ctx.Gods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
