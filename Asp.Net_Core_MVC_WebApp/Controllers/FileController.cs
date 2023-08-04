using _Services.Service;
using Asp.Net_Core_MVC_WebApp.Extensions;
using Asp.Net_Core_MVC_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_MVC_WebApp.Controllers
{
    public class FileController : Controller
    {

        private readonly CsvService csvService;

        public FileController()
        {
            csvService = new CsvService();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(FileModel model)
        {
            if (model.CsvFile != null && model.CsvFile.Length > 0)
            {
                // Check if the uploaded file is a valid CSV
                bool isValidCsv = csvService.IsCsvFileValid(model.CsvFile);

                if (!isValidCsv)
                {
                    // Handle the case when the file is not a valid CSV
                    ModelState.AddModelError("CsvFile", "The uploaded file is not in a valid CSV format.");
                    return View();
                }

                using (var reader = new StreamReader(model.CsvFile.OpenReadStream()))
                {
                    string content = reader.ReadToEnd();
                    model.CsvData = content.Split(',').Select(int.Parse).ToList();
                }

                int file = model.CsvData.File();
                model.FileValue = file;
            }

            return View(model);
        }
    }
}
