using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DAL
{
    public interface IDBManager
    {
       public MongoClient getDatabase(); 
    }
}
