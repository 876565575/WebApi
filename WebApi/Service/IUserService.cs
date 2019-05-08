using WebApi.entity;

namespace WebApi.Service
{
    public interface IUserService
    {
        User UserLogin(User user);
    }
}