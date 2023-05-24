using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using api_bharat_lawns.Helper;
using lib_barcode.api.Helper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_bharat_lawns.Response
{
    public class Pager
    {
        public int? Count { get; set; }

        private int _page;
        public int Page
        {
            get { return _page; }
            set
            {
                if (value <= 1)
                {
                    _page = 1;
                }
                else
                {
                    _page = value;
                }

            }
        }

        public int PerPage { get; set; } = 10;

        public string? Query { get; set; }


        //Direction [asc, desc]
        private string _sort = "CreatedAt";
        public string? Sort
        {
            get { return _sort; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _sort = "CreatedAt";
                }
                else
                {
                    _sort = value;
                }

            }
        }

        private string _sortDir = "desc";
        public string? SortDir
        {
            get { return _sortDir; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _sortDir = "desc";
                }
                else
                {
                    _sortDir = value;
                }

            }
        }
        public List<Filter>? Filters { get; set; }
    }


    public class Pager<T> : Pager
    {
        public IQueryable<T> Paginate(IQueryable<T> queraybleObj)
        {
            if (this.Filters != null)
                foreach (var filter in this.Filters)
                {
                    queraybleObj = queraybleObj.WhereContains(filter.Field, filter.Query);
                }
            queraybleObj = queraybleObj.OrderBy($"{this.Sort} {SortDir}");
            var skip = (this.Page - 1) * this.PerPage;
            this.Count = queraybleObj.Count();
            return queraybleObj.Skip(skip).Take(this.PerPage);
        }

    }

    public class Filter
    {
        public string? Field { get; set; }
        public string? Query { get; set; }
    }
}

