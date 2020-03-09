﻿using System;

namespace Skynet.Data.DataAccessModels
{
    public class CustomerData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CreditCard { get; set; }
    }
}
