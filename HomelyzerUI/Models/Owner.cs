using HomelyzerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.Models
{
    public sealed class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string PhoneContact { get; set; }
        public string EmailContact { get; set; }
        public List<AdvertDTO> Adverts { get; set; }
    }
}
