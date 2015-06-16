using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Util.Store;

namespace SumUpYourMail.Controllers
{
    public class SumUpYourMailDataStore : IDataStore
    {
        public System.Threading.Tasks.Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task StoreAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}