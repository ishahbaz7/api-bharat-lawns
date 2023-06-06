using System;
namespace api_bharat_lawns.Response
{
    public class ResponseData<T>
    {
        public ResponseData(List<T> data, Pager pager)
        {
            this.Data = data;
            this.Pager = pager;
        }

      
        public List<T>? Data { get; set; }

        public Pager? Pager { get; set; }

    }
}

