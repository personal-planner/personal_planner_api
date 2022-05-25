namespace DAL
{
    public interface IUserQuery
    {
        public UserModel GetByName(string Name);
    }
}
