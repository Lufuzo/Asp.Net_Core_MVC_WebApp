using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities
{
    public class File
    {
        public IFormFile? CsvFile { get; set; }
        public List<int>? CsvData { get; set; }
        public int FileValue { get; set; }
    }
}
