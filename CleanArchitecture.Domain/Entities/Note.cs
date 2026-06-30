using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        private Note() { }
        public Note(string Title, string Content, int UserId)
        {
            this.Title = Title;
            this.Content = Content;
            this.UserId = UserId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            if (this.UserId == 0)
            {
                throw new DomainException("User ID cannot be empty.");
            }

            Validate(); 
        }

        public void Update(string Title, string Content)
        {
            this.Title = Title;
            this.Content = Content;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new DomainException("Title cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(Content))
            {
                throw new DomainException("Content cannot be empty.");
            }
        }
    }
}
