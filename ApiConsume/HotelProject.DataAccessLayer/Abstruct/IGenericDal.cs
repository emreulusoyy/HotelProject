
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstruct
{
    public interface IGenericDal<T> where T : class 
    {
        void Insert(T t);
        void Delete(T t);
        void Uptade(T t);
        List<T> GetList();
        T GetById(int id);
    }
   
}
