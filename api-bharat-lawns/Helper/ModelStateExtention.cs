using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api_bharat_lawns.Helper
{
    public static class ModelStateExtensions
    {
        public static IDictionary ToSerializedDictionary(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
          k => k.Key,
          v => v.Value.Errors.Select(x => x.ErrorMessage).ToArray()
);
        }
    }
}

