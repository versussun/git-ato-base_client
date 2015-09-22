using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;

namespace ATOClient.repositories
{
    public interface IRepositori<T>
    {
        T Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        List<T> GetAll();

    }
}
