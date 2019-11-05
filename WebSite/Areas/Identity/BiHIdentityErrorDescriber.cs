using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Identity
{
    public class BiHIdentityErrorDescriber : IdentityErrorDescriber
    {
        public BiHIdentityErrorDescriber() { }

        public override IdentityError ConcurrencyFailure()
        {
            return base.ConcurrencyFailure();
        }
        public override IdentityError DefaultError()
        {
            return base.DefaultError();
        }
        public override IdentityError InvalidToken()
        {
            return base.InvalidToken();
        }

    }
}
