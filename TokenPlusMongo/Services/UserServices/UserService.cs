
namespace TokenPlusMongo.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly TokenComboDb _dbContext;

        public UserService(TokenComboDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<User> CreateUser(UserDto userDto)
        {
            if (_dbContext.Users.Any(x => x.UserName == userDto.UserName))
            {
                throw new Exception("username already exists");
            }
            var user = new User();
            user.UserName = userDto.UserName;
            user.PasswordHash = PasswordHasher.GetHash(userDto.Password);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async ValueTask<IEnumerable<User>> GetAllUserAsync()
        {
            IEnumerable<User> users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}
