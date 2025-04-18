using Microsoft.EntityFrameworkCore;

namespace LogistikApp.Models
{
    public class RecipientInfo
    {
        
        public string R_Name { get; set; }
        public string R_Tlp { get; set; }
        public string R_Address { get; set; }
        public string R_PostCode { get; set; }
    }
}
