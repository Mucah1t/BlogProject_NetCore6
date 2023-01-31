﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Delete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
