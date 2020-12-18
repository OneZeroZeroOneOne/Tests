using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly AttachmentPathProvider _attachmentPathProvider;
        private readonly MainContext _context;
        private readonly ResumeService _resumeService;

        public ResumeController(MainContext context, AttachmentPathProvider attachmentPathProvider, ResumeService resumeService)
        {
            _context = context;
            _attachmentPathProvider = attachmentPathProvider;
            _resumeService = resumeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            var ext = Path.GetExtension(uploadedFile.FileName);
            var fileName = DateTime.UtcNow.ToFileTimeUtc();

            string path = Path.Combine(Path.Combine(_attachmentPathProvider.GetPath(), "Files"), fileName + ext);
            await using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            var file = new Resume { Path = "Files/" + fileName + ext, Name = uploadedFile.FileName };

            await _resumeService.AddResume(file);

            return Ok(file);
        }
    }
}
