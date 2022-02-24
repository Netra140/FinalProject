using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkatoshProgrammingInterface.Data.RaceData;
using AkatoshProgrammingInterface.Data.IdentityData;
using AkatoshProgrammingInterface.Models.RaceModels;

namespace AkatoshProgrammingInterface.Services {
    public class RaceService
    {
        private readonly Guid _userId;
        private Guid userId;

        public RaceService(Guid userId)
        {
            this.userId = userId;
        }

        public bool CreateRace(RaceCreate model)
        {
            Race entity = new Race() {Playable = model.Playable, Name = model.Name, ProvinceID = model.ProvinceID, PantheonID = model.PantheonID, RaceType = model.RaceType};
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Race.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RaceList> GetRaces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Race
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                            new RaceList { 
                            RaceId = e.RaceID,
                            Name = e.Name,
                            CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        public RaceDetail GetRaceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Race
                    .Single(e => e.RaceID == id && e.OwnerID == _userId);
                return
                    new RaceDetail
                    {
                        RaceID = entity.RaceID,
                        Playable = entity.Playable,
                        Name = entity.Name,
                        ProvinceID = entity.ProvinceID,
                        PantheonID = entity.PantheonID,
                        RaceType = entity.RaceType,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateRace(RaceEdit model) {
            using(var ctx = new ApplicationDbContext()) {
                var entity =
                    ctx
                    .Race
                    .Single(e => e.RaceID == model.RaceID && e.OwnerID == _userId);

                entity.Playable = model.Playable;
                entity.Name = model.Name;
                entity.ProvinceID = model.ProvinceID;
                entity.PantheonID = model.PantheonID;
                entity.RaceType = model.RaceType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRace(int raceid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Race
                    .Single(e => e.RaceID == raceid && e.OwnerID == _userId);

                ctx.Race.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
