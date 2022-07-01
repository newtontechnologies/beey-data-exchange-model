using Beey.DataExchangeModel.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users;

public class UserTranscriptionLimit : EntityBase
{
    public int UserId { get; set; }
    public QueueType? QueueType { get; set; }
    public int Limit { get; set; }
}
