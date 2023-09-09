using MailSender.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        // Her action dan sonra retun ok gibi bildirgeçleri dönmemek için , CustomResponseDto altındaki belirli bir metodu dönmek için kullanıyoruz
        public IActionResult CreateActionResult <T>(CustomResponseDto<T> response)
        {

            if (response.StatusCode == 204)
                return new ObjectResult(null)
                { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
