﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Entities;

namespace CommonHelper
{
    public class Helper
    {
        public static string KeyString { get; set; } = string.Empty;
        public static string hashPassword(string password)
        {
            if (password != null)
            {
                var saltBytes = Encoding.ASCII.GetBytes(KeyString);
                var passwordBytes = Encoding.ASCII.GetBytes(password);
                var hmac = new HMACSHA256(saltBytes);
                var hash = hmac.ComputeHash(passwordBytes);
                var hexHash = BitConverter.ToString(hash).Replace("-", "");
                return hexHash;
            }
            return "";

        }
        public static bool verifyPassword(string password, string hashedPassword)
        {
            if (password != null)
            {
                string passwordInput = hashPassword(password);
                if (passwordInput == hashedPassword)
                    return true;
                else
                 return false; 
            }
            return false;
        }
        public static string GenerateToken(User user)
        {
            return "";
        }
    }
}
