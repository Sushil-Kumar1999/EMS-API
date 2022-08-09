﻿using System.ComponentModel.DataAnnotations;

namespace EMS.Core.DataTransfer.Users.DataContracts
{
    public class UserRegistrationRequestDataContract
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
