using AssignmentDatabase.Context;
using AssignmentDatabase.Models;
using AssignmentDatabase.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Services
{
    public class UserService
    {
        private static DataContext _context = new DataContext();



        public static async Task SaveToDatabaseAsync(UserModel user)
        {
            var _userEntity = new UserEntity
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,

            };

            var _departmentEntity = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentName == user.DepartmentName && x.StreetName == user.StreetName && x.PostalCode == user.PostalCode && x.City == user.City);
            if (_departmentEntity != null)
            {
                _userEntity.DepartmentId = _departmentEntity.Id; // Should be _DepartmentEntity.id
            }
            else
            {
                _userEntity.Departments = new DepartmentEntity
                {
                    DepartmentName = user.DepartmentName,
                    StreetName = user.StreetName,
                    PostalCode = user.PostalCode,
                    City = user.City
                };
            }


            var _ticketEntity = await _context.Tickets.FirstOrDefaultAsync(x => x.Description == user.Description && x.TicketText == user.TicketText && x.Status == user.Status && x.CreationTime == user.CreationTime);
            if (_ticketEntity != null)
            {
                _userEntity.TicketId = _ticketEntity.Id;
            }
            else
            {
                _userEntity.Tickets = new TicketEntity
                {
                    Description = user.Description,
                    CreationTime = user.CreationTime,
                    TicketText = user.TicketText,
                    Status = user.Status,
                };
            }


            var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.Comment == user.Comment);
            if (_commentEntity != null)
            {
                _userEntity.CommentId = _commentEntity.Id;
            }
            else
            {
                _userEntity.Comments = new CommentEntity
                {
                    Comment = user.Comment
                };
            }

            _context.Add(_userEntity);
            await _context.SaveChangesAsync();

        }

        public static async Task<IEnumerable<UserModel>> GetAllTicketsAsync()
        {
            var _users = new List<UserModel>();


            foreach (var _item in await _context.Users.Include(x => x.Departments).Include(x => x.Tickets).Include(x => x.Comments).ToListAsync())
                _users.Add(new UserModel
                {

                    Id = _item.Id,
                    FirstName = _item.FirstName,
                    LastName = _item.LastName,
                    Email = _item.Email,
                    PhoneNumber = _item.PhoneNumber,
                    DepartmentName = _item.Departments.DepartmentName,
                    StreetName = _item.Departments.StreetName,
                    PostalCode = _item.Departments.PostalCode,
                    City = _item.Departments.PostalCode,
                    Description = _item.Tickets.Description,
                    Status = _item.Tickets.Status,
                    TicketText = _item.Tickets.TicketText,
                    CreationTime = (DateTime)_item.Tickets.CreationTime,
                    Comment = _item.Comments.Comment


                });

            return _users;
        }

        public static async Task<UserModel> GetSpecificTicketAsync(string email)
        {
            var _user = await _context.Users.Include(x => x.Departments).Include(x => x.Tickets).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);

            if (_user != null)
            {
                return new UserModel
                {
                    Id = _user.Id,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Email = _user.Email,
                    PhoneNumber = _user.PhoneNumber,
                    DepartmentName = _user.Departments.DepartmentName,
                    StreetName = _user.Departments.StreetName,
                    PostalCode = _user.Departments.PostalCode,
                    City = _user.Departments.PostalCode,
                    Description = _user.Tickets.Description,
                    Status = _user.Tickets.Status,
                    TicketText = _user.Tickets.TicketText,
                    CreationTime = (DateTime)_user.Tickets.CreationTime,
                    Comment = _user.Comments.Comment
                };
            }
            else
            {
                return null!;
            }
        }

        public static async Task UpdateStatusAsync(UserModel user)
        {
            var _user = await _context.Users.Include(x => x.Departments).Include(x => x.Tickets).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == user.Id);

            if (_user != null)
            {
                if (!string.IsNullOrEmpty(_user.Tickets.Status))
                {
                    _user.Tickets.Status = user.Status; // Derives from TicketEntity

                    user.ModifiedDate = (DateTime)_user.Tickets.ModifiedDate; // Derives from Usermodel, bad naming on my part.

                    await _context.SaveChangesAsync();
                }

            }

        }

   

         public static async Task AddCommentAsync(UserModel user)
        
         {
                var _user = await _context.Users.Include(x => x.Departments).Include(x => x.Tickets).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == user.Id);

                if (_user != null)
                {
                    if (!string.IsNullOrEmpty(_user.Comments.Comment))
                    {
                        user.ModifiedDate = (DateTime)_user.Tickets.ModifiedDate;
                        _user.Comments.Comment = user.Comment;
                        await _context.SaveChangesAsync();
                         
                           
                    }
                    else
                    {
                        Console.WriteLine("Empty");
                        Console.ReadLine();
                    }
                }

         }

        public static async Task DeleteTicketAsync(string email)
        {
            var _user = await _context.Users.Include(x => x.Departments).Include(x => x.Tickets).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);


            if (_user != null)
            {
                _context.Remove(_user);
                await _context.SaveChangesAsync();

                
            }
        }

    }
}
