using WebApi.entity;

namespace WebApi.Service
{
    public class UserService : IUserService
    {
        public User UserLogin(User user)
        {
            return string.Equals(user.Name, "小王") ? user : null;
        }
    }
}