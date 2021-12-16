using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC_1.Models.AccountViewModels
{
    public class ServiceEngineerViewModel
    {
        public List<ApplicationUser> ServiceEngineers { get; set; }
        public ServiceEngineerRegistrationViewModel Registration { get; set; }
    }
}
