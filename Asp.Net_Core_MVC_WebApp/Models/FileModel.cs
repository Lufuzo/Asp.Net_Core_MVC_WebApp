namespace Asp.Net_Core_MVC_WebApp.Models
{
    public class FileModel
    {

        public IFormFile? CsvFile { get; set; }
        public List<int>? CsvData { get; set; }
        public int FileValue { get; set; }
    }
}
