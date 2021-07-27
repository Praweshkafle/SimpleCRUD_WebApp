using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrud.ViewModels
{
    public class BaseModel
    {
        List<UserViewModel> userModel = new List<UserViewModel>();
    }
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
}
