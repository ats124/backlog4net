using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    class InternalFactoryJsonImpl : InternalFactory
    {
        public async Task<ResponseList<User>> CreateUserListAsync(HttpResponseMessage res) => CreateObjectList<User, UserJsonImpl>(await res.Content.ReadAsStringAsync());

        private ResponseList<T1> CreateObjectList<T1, T2>(string content) where T2 : T1
            => new ResponseListImpl<T1>(JsonConvert.DeserializeObject<T2[]>(content).Cast<T1>());

        private T1 CreateObject<T1, T2>(string content) where T2 : T1
            => JsonConvert.DeserializeObject<T2>(content);
    }
}
