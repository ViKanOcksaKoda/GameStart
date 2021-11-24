using Ardalis.Specification;
using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Specifications
{
    public class UserNameSpecification : Specification<User>
    {
        public UserNameSpecification(string userName)
        {
            Query.Where(name => userName == name.UserName);
        }
    }
}
