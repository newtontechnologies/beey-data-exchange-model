﻿using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Projects
{
    public partial class ProjectAccessViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string CustomPath { get; set; }

    }
}
