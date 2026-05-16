using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class UserRegisterDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName {  get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email {  get; set; } = string.Empty;
        [Required]
        public string Password {  get; set; } = string.Empty;

    }
}
