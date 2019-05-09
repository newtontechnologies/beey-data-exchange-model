using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Auth
{
    public enum UserRole : int
    {
        None,
        Promo,
        User,
        Admin,
        Developer,
    }
}
