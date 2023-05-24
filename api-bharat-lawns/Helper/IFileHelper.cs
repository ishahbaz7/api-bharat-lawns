
namespace lib_barcode.api.Helper
{
    public interface IFileHelper<TModel>
    {

        Task<dynamic> GetExcelDataAsync(IFormFile excellFile);

        Task<string> SaveFileAsync(IFormFile file, string path);
    }
}

