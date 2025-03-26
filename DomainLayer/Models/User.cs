using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string userAddress { get; set; }
        public string email { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime updateDateTime { get; set; }
        public string phoneNumber { get; set; }


    }
}
