using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using SimsProjekat.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("User")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public string Jmbg { get; set; }

        [Required]
        public string Email {  get; set; }

        [Required]
        public string Password {  get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [EnumDataType(typeof(UserType))]
        [Required]
        public UserType UserType { get; set; }

        public bool IsBlocked { get; set; }

        public User() { }

        public User(string jmbg, string email, string password, string firstName, string lastName, string phoneNumber, UserType userType)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            UserType = userType;
            IsBlocked = false;
        }

        public User(string jmbg, string email, string password, string firstName, string lastName, string phoneNumber)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            IsBlocked = false;
        }
        public User(CreateUserDTO createUserDTO, UserType userType)
        {
            Jmbg = createUserDTO.Jmbg;
            Email = createUserDTO.Email;
            Password = createUserDTO.Password;
            FirstName = createUserDTO.FirstName;
            LastName = createUserDTO.LastName;
            PhoneNumber = createUserDTO.PhoneNumber;
            UserType = userType;
            IsBlocked = false;
        }

        public bool EqualsJmbg (string jmbg)
        {
            return Jmbg.Equals(jmbg);
        }

        public bool EqualsEmail(string email)
        {
            return Email.Equals(email);
        }

        public bool EqualsPassword(string password)
        {
            return Password.Equals(password);
        }
    }
}
