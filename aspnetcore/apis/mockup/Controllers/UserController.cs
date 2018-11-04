using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("list")]
    //https://localhost:44396/api/user/list
    public IActionResult list()
    {
        try
        {
            return Ok(listUser());

        }
        catch (Exception error)
        {
            return BadRequest("Error: " + error);
        }
    }

    [HttpGet("list/{id}")]
    //https://localhost:44396/api/user/list/1
    public IActionResult listById(int id)
    {
        try
        {
            var users = listUser();
            return Ok(users.FirstOrDefault(p => p.id == id));

        }
        catch (Exception error)
        {
            return BadRequest("Error: " + error);
        }
    }

    [HttpPost("save")]
    //https://localhost:44396/api/user/save
    public IActionResult save([FromBody]User user)
    {
        try
        {
            addUser(user);
            return Ok(user);

        }
        catch (Exception error)
        {
            return BadRequest("Error: " + error);
        }
    }

    [HttpDelete("delete")]
    //https://localhost:44396/api/user/delete
    public IActionResult delete([FromBody]User user)
    {
        try
        {
            var users = listUser();

            users.RemoveAll(p => p.id == user.id);
            return Ok(user);

        }
        catch (Exception error)
        {
            return BadRequest("Error: " + error);
        }
    }

    [HttpPut("update")]
    //https://localhost:44396/api/user/update
    public IActionResult update([FromBody] User newUser)
    {
        try
        {
            var users = listUser();
            var user = users.FirstOrDefault(p => p.id == newUser.id);
            updateUser(user, newUser);

            if (user != null)
            {
                return Ok(newUser);
            } else
            {
                var messages = updateUser(user, newUser);
                return BadRequest("Error: " + messages);
            }

        }
        catch (Exception error)
        {
            return BadRequest("Error: " + error);
        }
    }

    private List<User> setUser()
    {
        List<User> users = new List<User>();
        users.Add(new User { id = 1, name = "Sabrina", username = "sabrina", password = "sabrina123", cpf = 00000000000, accountId = 1 });
        users.Add(new User { id = 2, name = "Alexander", username = "alexander", password = "alexander123", cpf = 1111111111, accountId = 2 });

        return users;
    }

    private List<User> listUser()
    {
        return setUser();
    }

    private User addUser(User user)
    {
        var users = listUser();
        users.Add(user);
        return user;
    }

    private Object updateUser(User user, User newUser)
    {
        if (user != null)
        {
            user.name = newUser.name;
            user.username = newUser.username;
            user.password = newUser.password;
            user.cpf = newUser.cpf;
            user.accountId = newUser.accountId;

            return newUser;
        } else {
            var messages = new { error = "Error: user not founded !" };

            return messages;
        }
    }
}