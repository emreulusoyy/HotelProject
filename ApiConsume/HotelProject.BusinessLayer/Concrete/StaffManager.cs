using HotelProject.BusinessLayer.Abstruct;
using HotelProject.DataAccessLayer.Abstruct;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStraffDal _staffDal;

        public StaffManager(IStraffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TDelete(Staff t)
        {
           _staffDal.Delete(t);
        }

        public Staff TGetByID(int id)
        {
            return _staffDal.GetById(id);
        }

        public List<Staff> TGetList()
        {
           return _staffDal.GetList();
        }

        public void TInsert(Staff t)
        {
            _staffDal.Insert(t);
        }

        public void TUpdate(Staff t)
        {
            _staffDal.Uptade(t);
        }
    }
}
