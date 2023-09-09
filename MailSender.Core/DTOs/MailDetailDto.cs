using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.DTOs
{
    public class MailDetailDto 
    {
        public int Id { get; set; }
        public DateTime SendedDate { get; set; }
        public string MailContent { get; set; }

        //Navigation Prop
        //Many to Many Relation
        //Repository katmanı altındaki Configuration dosyasının altında bu configurasyonlarımı Fluent Api aracılığı ile yapacağım  
        public int SendedMailId { get; set; }
    }
}
