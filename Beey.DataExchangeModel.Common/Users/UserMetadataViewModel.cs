using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users;
public class UserMetadataViewModel : EntityBase
{
    public int UserId { get; set; }
    public string Key { get; set; }
    public string? Value { get; set; }
}
