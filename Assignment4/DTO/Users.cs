using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Users
    {
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public char gender { get; set; }
        public string NIC { get; set; }
        public DateTime date { get; set; }
        public string ImageName { get; set; }
        public bool cricket { get; set; }
        public bool hockey { get; set; }
        public bool chess { get; set; }
    }
}