using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploads.Controllers
{
    [ApiController]
    [Route("api/files")]

    public class FilesController : ControllerBase
    {
        [Authorize]
        [HttpPost("upload")]
        public IActionResult UploadTicket(string description, List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files were provided for upload.");
            }
            foreach (var file in files)
            {
                if (file.Length > 0)
                {


                    var filePath = Path.Combine("C://FilesTest", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            return Ok("Files uploaded successfully.");

        }
    }

}
