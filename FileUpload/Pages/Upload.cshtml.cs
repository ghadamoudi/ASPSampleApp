using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace FileUpload.Pages
{
    public class UploadModel : PageModel
    { 
        private IWebHostEnvironment ihostEnvironment;

        public string FileName { get; set; }
        
        public UploadModel(IWebHostEnvironment ihostEnvironment)
        {
            this.ihostEnvironment = ihostEnvironment;
        }
        public void OnGet()
        {
        }
        public void OnPost(IFormFile afile)
        {
            var path = Path.Combine(ihostEnvironment.WebRootPath, "Files", afile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            afile.CopyToAsync(stream);
            FileName = afile.FileName;
        }   
    }
}