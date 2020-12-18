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
    public class AvatarController : ControllerBase
    {
        private readonly AttachmentPathProvider _attachmentPathProvider;
        private readonly MainContext _context;
        private readonly AvatarService _avatarService;
        public AvatarController(MainContext context, AttachmentPathProvider attachmentPathProvider, AvatarService avatarService)
        {
            _context = context;
            _attachmentPathProvider = attachmentPathProvider;
            _avatarService = avatarService;
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

            Avatar file = new Avatar { Path = "Files/" + fileName + ext,  Name = uploadedFile.FileName };

            await _avatarService.AddAvatar(file);

            return Ok(file);
        }
    }
}
