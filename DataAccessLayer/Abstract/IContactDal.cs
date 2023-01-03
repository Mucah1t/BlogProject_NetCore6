using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal:IGenericDal<Contact> //It will be inheritad from Generic repository to access all methods
    {
    }
}
