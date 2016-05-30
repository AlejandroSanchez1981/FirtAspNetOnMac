using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace firstaspnet.ViewModels.Manage
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
    }
}
