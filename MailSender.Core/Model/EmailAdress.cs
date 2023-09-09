using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Model
{
    public class EmailAdress : BaseEntity
    {
        public string Name { get; set; }
        public string EMailAdres { get; set; }

        // Many to Many Relation
        // Fakat ben genede Repository katmanı altındaki Configuration dosyasının altında bu configurasyonlarımı Fluent Api aracılığı i,le yapacağım  
       

        //Navigation Prop.
        public ICollection<SendedMail> sendedMails { get; set; }




    }
}
