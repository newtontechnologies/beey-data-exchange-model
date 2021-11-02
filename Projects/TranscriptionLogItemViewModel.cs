using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public class TranscriptionLogItemViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal TranscribedMinutes { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
