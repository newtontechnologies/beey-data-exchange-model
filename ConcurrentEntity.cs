using System;
using System.Collections.Generic;
#if BeeyServer
using System.ComponentModel.DataAnnotations;
#endif
using System.Text;

namespace Beey.DataExchangeModel
{
    public class ConcurrentEntity : EntityBase
    {
        [ConcurrencyCheck]
        public long AccessToken { get; set; }
    }
}
