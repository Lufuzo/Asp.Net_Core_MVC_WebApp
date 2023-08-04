using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.IService
{
    public interface ICsvService
    {
        public bool IsCsvFileValid(IFormFile file);
        public IFormFile GenerateInvalidCsvFile();
    }
}
