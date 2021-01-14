using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json;
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
        [Key]
        public int Id { get; set; }

        [JsonIgnoreWebDeserialize]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset? Created { get; set; }

        [JsonIgnoreWebDeserialize]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? Updated { get; set; }
    }
}
