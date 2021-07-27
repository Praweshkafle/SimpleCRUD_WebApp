using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.Models
{
    public class User
    {
        private string _name;
        private string _address;
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name
        {
            get=> _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid ");
                }
                _name = value;
            }
        }
        [Required]
        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid");
                }
                _address = value;
            }
        }
        public string Number { get; set; }

    }
}
