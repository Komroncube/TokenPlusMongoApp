namespace TokenPlusMongo.Services.UserServices
{
    public interface IUserService
    {
        ValueTask<IEnumerable<User>> GetAllUserAsync();
        ValueTask<User> CreateUser(UserDto userDto);
    }
}
