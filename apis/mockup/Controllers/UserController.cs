using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("users")]
    //https://localhost:44396/api/user/users
    public List<User> GetAllUsers()
    {
        var users = listUsers();
        return users;
    }

    [HttpGet("{id}")]
    //https://localhost:44396/api/user/1
    public User GetUserById(int id)
    {
        var users = listUsers();
        return users.FirstOrDefault(p => p.id == id);
    }

    [HttpPost("register")]
    //https://localhost:44396/api/user/register
    public List<User> RegisterUser([FromBody]User user)
    {
        return addUser(user);
    }

    [HttpDelete("delete/{id}")]
    //https://localhost:44396/api/user/delete/1
    public List<User> deleteUser(int id)
    {
        var users = listUsers();
        var user = users.FirstOrDefault(p => p.id == id);

        users.RemoveAll(p => p.id == id);

        return users;
    }

    [HttpPut("update/{id}")]
    //https://localhost:44396/api/user/update/1
    public List<User> updateUser([FromBody] User newUser)
    {
        var users = listUsers();
        var user = users.FirstOrDefault(p => p.id == newUser.id);
        UpdateUser(user, newUser);
        return users;
    }

    private List<User> getData()
    {
        List<User> users = new List<User>();
        users.Add(new User { id = 1, name = "Sabrina", username = "sabrina", password = "sabrina123", cpf = 00000000000, accountId = 1 });
        users.Add(new User { id = 2, name = "Alexander", username = "alexander", password = "alexander123", cpf = 1111111111, accountId = 2 });

        return users;
    }

    private List<User> listUsers()
    {
        var users = getData();
        return users;
    }

    private List<User> addUser(User user)
    {
        var users = listUsers();
        users.Add(user);
        return users;
    }

    private User UpdateUser(User user, User newUser)
    {
        user.name = newUser.name;
        user.username = newUser.username;
        user.password = newUser.password;
        user.cpf = newUser.cpf;
        user.accountId = newUser.accountId;
        
        return user;
    }
}