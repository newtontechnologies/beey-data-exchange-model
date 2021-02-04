﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Auth
{
    /// <summary>
    /// UserRole is saved as string to DB.
    /// </summary>
    public enum UserRole : int
    {
        None,
        Promo,
        /// <summary>
        /// Cannot buy credit.
        /// </summary>
        EnterpriseUser,
        User,
        Admin,
        Developer,
    }
}
