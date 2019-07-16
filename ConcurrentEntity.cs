using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beey.DataExchangeModel
{
    public class ConcurrentEntity : EntityBase
    {
        [ConcurrencyCheck]
        public long AccessToken { get; set; }
    }
}
