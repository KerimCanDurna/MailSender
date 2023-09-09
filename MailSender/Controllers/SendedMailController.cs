using AutoMapper;
using MailSender.Core.DTOs;
using MailSender.Core.Model;
using MailSender.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MailSender.Controllers
{
  
    public class SendedMailController : CustomBaseController
    {

        private readonly ISendedMailService _service;
        private readonly IMapper _mapper;

        public SendedMailController(ISendedMailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SendedMailList()
        {
            var sendedMail = await _service.GetAllAsync();
            var sendedMailDtos = _mapper.Map<List<SendedMailDto>>(sendedMail.ToList());
           

            return CreateActionResult(CustomResponseDto<List<SendedMailDto>>.Success(200,sendedMailDtos));
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> SendenMailWithEmails()
        {
            return CreateActionResult(await _service.GetSendedMailWithEmailAdress());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddEMailAdress(SendedMailDto sendedMailDto)
        {
            var sendedMail = await _service.AddAsync(_mapper.Map<SendedMail>(sendedMailDto));  // AddAsync bir product nesnesi aldığı için içinde map lama yaptık 
            var sendedMailDtos = _mapper.Map<SendedMailDto>(sendedMailDto);


            return CreateActionResult(CustomResponseDto<SendedMailDto>.Success(201,sendedMailDtos));
        }
    }
}
