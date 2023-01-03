using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void CategoryDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void CategoryUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public void ContactInsert(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public Contact GetContactById(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> GetContactListAll()
        {
            return _contactDal.GetListAll();
        }
    }
}
