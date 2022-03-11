using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TestWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public TestController(IWebHostEnvironment env) 
        {
            _env = env;
        }

        public IActionResult Index()
        {
            RunExecutable("test2");

            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;

            return Content(contentRootPath + "\n" + webRootPath);
        }

        private void RunExecutable(string parameter) 
        {
            try
            {
                string contentRootpath = _env.ContentRootPath;
                string webrootPath = _env.WebRootPath;
                var fileName = contentRootpath + webrootPath + @"\content\WebAPIConsole.exe";

                Process p = new Process();
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = fileName;
                p.StartInfo.Arguments = parameter;
                p.StartInfo.WorkingDirectory = contentRootpath + webrootPath + @"\content\";

                p.Start();
                p.WaitForExit();

            }
            catch (Exception)
            {

                throw;
            }
        
        
        }
    }
}
