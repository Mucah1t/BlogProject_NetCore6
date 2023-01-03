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
    public class WriterManager:IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriterById(int id)
        {
          return  _writerDal.GetById(id);
        }

        public List<Writer> GetWriterListAll()
        {
            return _writerDal.GetListAll();
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterInsert(Writer writer)
        {
           _writerDal.Insert(writer);  
        }

        public void WriterUpdate(Writer writer)
        {
           _writerDal.Update(writer);
        }
    }
}