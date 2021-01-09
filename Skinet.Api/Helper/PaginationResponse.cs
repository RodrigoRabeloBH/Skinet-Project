using System;
using System.Collections.Generic;
using System.Linq;
using Skinet.Model;

namespace Skinet.Api.Helper
{
    public class PaginationResponse<T> where T : class
    {
        public int Total { get; set; }
        public double TotalPage { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PaginationResponse(IEnumerable<T> data, int i, int l)
        {
            Total = data.Count();
            TotalPage = Math.Ceiling((double)data.Count() / l);
            Data = data.Skip((i - 1) * l).Take(l);
        }
    }
}