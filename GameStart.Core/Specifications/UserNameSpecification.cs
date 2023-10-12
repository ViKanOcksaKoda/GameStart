using Ardalis.Specification;
using GameStart.Core.Entities;

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
