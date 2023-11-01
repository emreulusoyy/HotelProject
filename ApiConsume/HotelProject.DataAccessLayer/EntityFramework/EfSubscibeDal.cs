using HotelProject.DataAccessLayer.Abstruct;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfSubscibeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EfSubscibeDal(Context context) : base(context)
        {
        }
    }
}
