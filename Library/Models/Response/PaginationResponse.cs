using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Response
{
    public class PaginationResponse<T>
    {
        public int TotalPages { get; set; }

        public int PageIndex { get; set; }

        public int TotalItens { get; set; }

        public List<T> ItemsList { get; set; }
    }
}
