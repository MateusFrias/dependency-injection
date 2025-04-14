//each class now has its own interface
//each class creates its own instances of dependent classes, still using the "new" statement
//lesser coupled, centralizes the initialization of the services in the constructor
//but still coupled, still using "new" statement
public class UserInterface
{
    private string _userName;
    private string _password;

    private IBusiness _business;

    public UserInterface()
    {
        _business = new Business();
    }
    private void GetData()
    {
        Console.Write("Enter user name:");
        _userName = Console.ReadLine();

        Console.Write("Enter password:");
        _password = Console.ReadLine();
    }

    public void Signup()
    {
        GetData();

        //var biz = new Business();
        _business.SignUp(_userName, _password);
    }
}

public interface IBusiness
{
    void SignUp(string userName, string password);
}
public class Business : IBusiness
{
    private IDataAccess _dataAccess;

    public Business()
    {
        _dataAccess = new DataAccessMySQL();
    }
    public void SignUp(string userName, string password)
    {
        //var da = new DataAccessMySQL();
        _dataAccess.SignUp(userName, password);
    }
}

public interface IDataAccess
{
    void SignUp(string userName, string password);
}
public class DataAccessSqlServer : IDataAccess
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into Sql Server   
    }
}

public class DataAccessMySQL : IDataAccess
{
    public void SignUp(string userName, string password)
    {
        // use EF to write data into My SQL  
    }
}