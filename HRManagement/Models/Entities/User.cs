using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace HRManagement.Models.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        [Required, MaxLength(50)]
        public virtual string Email { get; set; }
        [Required, MaxLength(80)]
        public virtual string Password { get; set; }
        [NotMapped, Compare("Password")]
        public virtual string ConfirmPassword { get; set; }

        [Required, ForeignKey("Group")]
        public virtual int GroupId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Group Group { get; set; }

        public string GetFullName()
        {
            return Employee.FirstName + " " + Employee.LastName;
        }

        public static string Md5EncryptPassword(string password)
        {
            byte[] originalBytes;
            byte[] encryptedBytes;

            MD5 md5 = new MD5CryptoServiceProvider();

            originalBytes = System.Text.ASCIIEncoding.Default.GetBytes(password);
            encryptedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encryptedBytes);
        }
    }
}