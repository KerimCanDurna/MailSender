using AutoMapper;
using MailSender.Core.DTOs;
using MailSender.Core.Model;
using MailSender.Core.Repositories;
using MailSender.Core.Services;
using MailSender.Core.UnitOFWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Service.Services
{
    public class SendedMailService : service<SendedMail>, ISendedMailService
    {
        private readonly ISendedMailRepository _repository;
        private readonly IMapper _mapper;

        public SendedMailService(IGenericRepository<SendedMail> repository, ISendedMailRepository sendedMailRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = sendedMailRepository;
        }

        public async Task<CustomResponseDto<List<SendedMailWithEmailsDto>>> GetSendedMailWithEmailAdress()
        {
            var sendedMail = await _repository.GetSendedMailWithEmailAdress();
            var sendedMailDto = _mapper.Map<List<SendedMailWithEmailsDto>>(sendedMail);

            return CustomResponseDto<List<SendedMailWithEmailsDto>>.Success(200,sendedMailDto);
        }
    }
}
