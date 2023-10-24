using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IUser_Service
    {
        Task<User_ResultSet> AddUser(string name, string surname, string email, string phone, string password, string role);
        
        Task<User_ResultSet> GetUserById(long user_id);

        Task<User_ResultSet> UpdateUser(long user_id, string name, string surname, string email, string phone, string password, string role);
        
        Task<bool> DeleteUserById(long user_id);

        Task<List<User_ResultSet>> GetAllUsers();
    }
}
