﻿using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{    
    public class ProjectToDeleteInElastic : EntityBase
    {
        public int ProjectId { get; set; }
    }
}
