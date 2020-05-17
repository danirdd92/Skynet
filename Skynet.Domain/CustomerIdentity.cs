using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Domain
{
    public class CustomerIdentity
    {
        public int CustomerId { get; set; }
        public string UserGuid { get; set; }
  

        public virtual Customer Customer { get; set; }
    }
}
