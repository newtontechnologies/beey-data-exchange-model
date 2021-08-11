using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Workspaces
{
    public class Workspace : EntityBase
    {
        public int? OwnerId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
