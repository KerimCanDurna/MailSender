using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.DTOs
{
    public class EMailAdressDto : BaseDto
    {
        public string Name { get; set; }
        public string EMailAdres { get; set; }
    }
}
