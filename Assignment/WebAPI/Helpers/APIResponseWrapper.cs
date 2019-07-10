using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public class APIResponseWrapper<T>
    {
        public T Data { get; set; }
        public IEnumerable<object> Errors { get; set; }
    }
}
