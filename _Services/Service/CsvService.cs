using _Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.Service
{
    public class CsvService : ICsvService
    {
        public bool IsCsvFileValid(IFormFile file)
        {
            // Check if the file is not null and has content
            if (file == null || file.Length == 0)
                return false;

            // Check the file extension 
            var allowedExtensions = new[] { ".csv"};
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
                return false;

            

            return true;
        }

        public IFormFile GenerateInvalidCsvFile()
        {
            // Create a dummy CSV content
            string csvContent = "Invalid,CSV,Content";

            // Convert the content to a stream
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(csvContent));

            // Create a dummy IFormFile with an incorrect content type and filename
            IFormFile file = new FormFile(stream, 0, csvContent.Length, "invalid.csv", "invalid.csv");

            return file;
        }
    }
}
