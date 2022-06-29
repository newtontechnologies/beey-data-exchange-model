using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
#if BeeyServer
using System.ComponentModel.DataAnnotations;
#endif
using System.Linq;

namespace Beey.DataExchangeModel
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? Updated { get; set; }
    }
}
