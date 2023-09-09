using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Model
{
    public class SendedMail : BaseEntity
    {
        public DateTime SendedDate { get; set; }
        public string MailSubject { get; set; }
             
        public string MailContent { get; set; }

        // Many to Many Relation
        // Repository katmanı altındaki Configuration dosyasının altında bu configurasyonlarımı Fluent Api aracılığı ile yapacağım  


       

        //Navigation Prop.
        public ICollection<EmailAdress> emailAdresses { get; set; }

        
    }
}
