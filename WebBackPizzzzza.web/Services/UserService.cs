using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using WebBackPizzzzza.web.ViewModels;

namespace WebBackPizzzzza.web.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserByEmail(string email);
        Task<bool> RegisterUser(UserViewModel viewModel);
        Task UpdateUser(UserViewModel viewModel);
    }

    public class UserService : IUserService
    {
        private ConcurrentBag<UserViewModel> _users = new ConcurrentBag<UserViewModel>();

        public Task<UserViewModel> GetUserByEmail(string email)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
        }

        public Task<bool> RegisterUser(UserViewModel viewModel)
        {
            _users.Add(viewModel);
            return Task.FromResult(true);
        }

        public Task UpdateUser(UserViewModel viewModel)
        {
            var user = _users.FirstOrDefault(u => u.Email.Equals(viewModel.Email));

            if (user == null)
                _users.Add(viewModel);
            else
                _users = new ConcurrentBag<UserViewModel>(_users.Except(new[] {viewModel})) {viewModel};

            return Task.CompletedTask;
        }
    }
}