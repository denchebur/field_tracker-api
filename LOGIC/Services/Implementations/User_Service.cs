using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementations
{
    public class User_Service : IUser_Service
    {
        private ICrud _crud = new Crud();

        public async Task<User_ResultSet> AddUser(string name, string surname, string email, string phone, string password, string role)
        {
            try
            {
                User user = new User
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    Role = role
                    /*new Roles[] { (Roles)Enum.Parse(typeof(Roles), role) }*/
                };

                user = await _crud.Create<User>(user);

                User_ResultSet userAdded = new User_ResultSet
                {
                    user_id = user.UserId,
                    name = user.Name,
                    surname = user.Surname,
                    email = user.Email,
                    phone = user.Phone,
                    password = user.Password,
                    role = user.Role
                };

                return userAdded;
            }
            catch (Exception)
            {
                throw new Exception("We failed to register your information. Please try again.");
            }
        }

        public async Task<bool> DeleteUserById(long user_id)
        {
            try
            {
                bool isUserDeleted = await _crud.Delete<User>(user_id);

                return isUserDeleted;
            }
            catch (Exception)
            {
                throw new Exception("We failed find the user you are looking for.");
            }
        }

        public async Task<List<User_ResultSet>> GetAllUsers()
        {
            try
            {
                List<User> users = await _crud.ReadAll<User>();

                List<User_ResultSet> result = new List<User_ResultSet>();
                users.ForEach(p =>
                {
                    result.Add(new User_ResultSet
                    {
                        user_id = p.UserId,
                        name = p.Name,
                        surname = p.Surname,
                        email = p.Email,
                        phone = p.Phone,
                        password = p.Password,
                        role = p.Role
                    });
                });

                return result;
            }
            catch (Exception)
            {
                throw new Exception("We failed fetch all the required pets statuses from the database.");
            }
        }

        public async Task<User_ResultSet> GetUserById(long user_id)
        {
            try
            {
                User user = await _crud.Read<User>(user_id);

                User_ResultSet userReturned = new User_ResultSet
                {
                    user_id = user.UserId,
                    name = user.Name,
                    surname = user.Surname,
                    email = user.Email,
                    phone = user.Phone,
                    password = user.Password,
                    role = user.Role
                };

                return userReturned;
            }
            catch (Exception)
            {
                throw new Exception("We failed to find the user you are looking for.");
            }
        }

        public async Task<User_ResultSet> UpdateUser(long user_id, string name, string surname, string email, string phone, string password, string role)
        {
            try
            {
                User userToUpdate = new User
                {
                    UserId = user_id,
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    Role = role
                    /*new Roles[] { (Roles)Enum.Parse(typeof(Roles), role) }*/
                };

                userToUpdate = await _crud.Update<User>(userToUpdate, user_id);

                User_ResultSet userUpdated = new User_ResultSet
                {
                    user_id = userToUpdate.UserId,
                    name = userToUpdate.Name,
                    surname = userToUpdate.Surname,
                    email = userToUpdate.Email,
                    phone = userToUpdate.Phone,
                    password = userToUpdate.Password,
                    role = userToUpdate.Role
                };

                return userUpdated;
            }
            catch (Exception)
            {
                throw new Exception("We failed to update the supplied user.");
            }
        }
    }
}
