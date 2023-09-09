using AutoMapper;
using MailSender.Core.DTOs;
using MailSender.Core.Model;
using MailSender.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace MailSender.Controllers
{
   
    public class MailAdressesController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IService<EmailAdress> _service;

        public MailAdressesController(IMapper mapper, IService<EmailAdress> serviceMail)
        {
            _mapper = mapper;

            _service = serviceMail;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> EMailAdressList()
        {
            var MailAdress = await _service.GetAllAsync();
            var mailAdressDto = _mapper.Map<List<EMailAdressDto>>(MailAdress.ToList());
           // return Ok( CustomResponseDto<List<EMailAdressDto>>.Success(200, mailAdressDto));
            //
            // Bu şekilde tek tek çağırıp kodu kirletmektense , CustomBaseController adında bir controller daha oluşturduk 

            return CreateActionResult(CustomResponseDto<List<EMailAdressDto>>.Success(200, mailAdressDto));
        }

        
      

        [HttpPost("[action]")]
        public async Task<IActionResult> AddEMailAdress(EMailAdressDto eMailAdressDto)
        {
            var emailAdress = await _service.AddAsync(_mapper.Map<EmailAdress>(eMailAdressDto));  // AddAsync bir product nesnesi aldığı için içinde map lama yaptık 
            var eMailAdressDtos = _mapper.Map<EMailAdressDto>(emailAdress);


            return CreateActionResult(CustomResponseDto<EMailAdressDto>.Success(201, eMailAdressDtos));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMailAdress (EMailAdressDto eMailAdressDto)
        {
            await _service.UpdateAsync(_mapper.Map<EmailAdress>(eMailAdressDto));  



            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("[action] / Id ")]
        public async Task<IActionResult> RemoveMailAdress(int id)
        {
            var eMailAdress = await _service.Where(x=> x.Id ==id).FirstAsync();

            await _service.RemoveAsync(eMailAdress);

           

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }




    }
}
