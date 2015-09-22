using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATOClient.repositories;
using System.Data.Entity;
using ATOClient.model;

namespace ATOClient.repositories
{
    static class SingletonContext
    {
        static public ModelEntities context= new ModelEntities();
    }
}
