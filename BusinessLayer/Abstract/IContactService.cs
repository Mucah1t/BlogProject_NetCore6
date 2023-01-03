using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactListAll();
        void ContactInsert(Contact contact);
        void CategoryDelete(Contact contact);
        void CategoryUpdate(Contact contact);
        Contact GetContactById(int id);
    }
}
