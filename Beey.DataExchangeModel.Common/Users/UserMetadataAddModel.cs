﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Common.Users;

public record UserMetadataAddModel(string Key, string? Value = null);
