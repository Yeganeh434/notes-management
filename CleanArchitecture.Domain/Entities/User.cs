using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt {  get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IEnumerable<Note> Notes { get; private set; }

        private User() { }
        public User(string Username,string Password,string Email)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            if (string.IsNullOrWhiteSpace(this.Password))
            {
                throw new DomainException("Password cannot be empty.");
            }

            Validate();
        }

        public void Update(string Username, string Email)
        {
            Username = this.Username;
            Email = this.Email;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                throw new DomainException("Username cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new DomainException("Email cannot be empty.");
            }
        }
    }
}
