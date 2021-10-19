using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users
{
    public class CreditChangeHistoryEntry : EntityBase
    {
        public int TeamId { get; set; }
        public int Credit { get; set; }
        public int InitiatorId { get; set; }
        public int? OrderInfoId { get; set; }

    }
}
