using CleanArchitecture.ApplicationCore.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId => throw new NotImplementedException();

        public string UserEmail => throw new NotImplementedException();

        public string UserRoles => throw new NotImplementedException();

        public string Origin => throw new NotImplementedException();

        public string Referer => throw new NotImplementedException();

    }
}
