using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.DTOs
{
    public class SendedMailDto : BaseDto
    {
        public string MailSubject { get; set; }
 


        public int MailDetailId { get; set; }

    }
}
