using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeDemo.Models
{
    public class HomeViewModel
    {
        public string UserName { get; private set; }

        public HomeViewModel(int? id)
        {
            UserName = $"User {id}";
        }

    }
}