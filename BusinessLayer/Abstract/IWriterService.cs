using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterListAll();
        void WriterInsert(Writer contact);
        void WriterDelete(Writer contact);
        void WriterUpdate(Writer contact);
        Writer GetWriterById(int id);
    }
}
