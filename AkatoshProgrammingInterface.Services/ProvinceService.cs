using AkatoshProgrammingInterface.Data;
using AkatoshProgrammingInterface.Data.IdentityData;
using AkatoshProgrammingInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkatoshProgrammingInterface.Services
{
    public class ProvinceService
    {
        public ProvinceService() { }

        public bool CreateProvince(ProvinceCreate model)
        {
            var entity =
                new Province()
                {
                    Name = model.Name,
                    CapitalCity = model.CapitalCity,
                    Government = model.Government,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Provinces.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProvinceListItem> GetProvinces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Provinces
                    .Select(
                        e =>
                        new ProvinceListItem()
                        {
                            ProvinceId = e.ProvinceId,
                            Name = e.Name,
                            Description = e.Description
                        });
                return query.ToArray();
            }
        }

        public bool DeleteProvince(int provinceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Provinces
                    .Single(e=> e.ProvinceId == provinceID);

                ctx.Provinces.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
