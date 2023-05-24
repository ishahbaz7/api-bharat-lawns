using System;
using System.Collections;

namespace api_bharat_lawns.Response
{
    public class ResponseErrors
    {
        public ResponseErrors()
        {

        }
        public ResponseErrors(IDictionary errors)
        {
            this.Errors = errors;
        }
        public IDictionary Errors { get; set; }

    }
}

