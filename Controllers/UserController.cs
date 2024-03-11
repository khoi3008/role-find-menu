// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Sieve.Models;
// using Sieve.Services;
// using HYEC.IkachiWebApi.Entities;
// using HYEC.IkachiWebApi.Helpers;

// namespace HYEC.IkachiWebApi.Services
// {
//     public interface IUserProfileService
//     {
//         UserProfile Authenticate(string email, string password);
//         IEnumerable<UserProfile> GetAll(SieveModel sieveModel);
//         UserProfile GetByEmail(string email);
//         UserProfile Create(UserProfile userProfile, string password);
//         UserProfile UpdatePassword(string email, string oldPassword, string newPassword);
//     }

//     public class UserProfileService : IUserProfileService
//     {
//         private readonly ApplicationDbContext _dbContext;
//         private readonly ISieveProcessor _sieveProcessor;

//         public UserProfileService(ApplicationDbContext dbContext, ISieveProcessor sieveProcessor)
//         {
//             _dbContext = dbContext;
//             _sieveProcessor = sieveProcessor;
//         }

//         public UserProfile Authenticate(string email, string password)
//         {
//             var userProfile = GetByEmail(email);

//             // check if this user exists && password is correct
//             if (userProfile != null && VerifyPasswordHash(password, userProfile.PasswordHash, userProfile.PasswordSalt))
//             {
//                 // authentication successful
//                 return userProfile;
//             }

//             return null;
//         }

//         public IEnumerable<UserProfile> GetAll(SieveModel sieveModel)
//         {
//             var userProfiles = _dbContext.UserProfiles.AsNoTracking();
//             userProfiles = _sieveProcessor.Apply(sieveModel, userProfiles);
//             return userProfiles.ToList();
//         }

//         public UserProfile GetByEmail(string email)
//         {
//             UserProfile userProfile = null;

//             if (!string.IsNullOrEmpty(email))
//             {
//                 userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Email == email);
//             }

//             return userProfile;
//         }

//         public UserProfile Create(UserProfile userProfile, string password)
//         {
//             // validation
//             if (string.IsNullOrWhiteSpace(password))
//                 throw new ValidationException("Password is required");

//             if (_dbContext.UserProfiles.Any(x => x.Email == userProfile.Email))
//                 throw new ValidationException("Email '" + userProfile.Email + "' is already taken");

//             string passwordHash, passwordSalt;
//             CreatePasswordHash(password, out passwordHash, out passwordSalt);

//             userProfile.PasswordHash = passwordHash;
//             userProfile.PasswordSalt = passwordSalt;

//             _dbContext.UserProfiles.Add(userProfile);
//             _dbContext.SaveChanges();
//             return userProfile;
//         }

//         public UserProfile UpdatePassword(string email, string oldPassword, string newPassword)
//         {
//             if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(oldPassword))
//                 throw new ValidationException("New password & old password are required");

//             var userProfile = GetByEmail(email);

//             if (userProfile == null)
//                 throw new ValidationException("User profile not found");

//             // Skip validation when password is not set for this user, just go update
//             if ((userProfile.PasswordHash == null && userProfile.PasswordSalt == null) ||
//                 (VerifyPasswordHash(oldPassword, userProfile.PasswordHash, userProfile.PasswordSalt)))
//             {
//                 string passwordHash, passwordSalt;
//                 CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

//                 userProfile.PasswordHash = passwordHash;
//                 userProfile.PasswordSalt = passwordSalt;

//                 _dbContext.UserProfiles.Update(userProfile);
//                 _dbContext.SaveChanges();

//                 return userProfile;
//             }

//             throw new ValidationException("Invalid");
//         }

//         // private helper methods

//         private static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
//         {
//             if (password == null) throw new ArgumentNullException("password");
//             if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

//             using (var hmac = new System.Security.Cryptography.HMACSHA512())
//             {
//                 passwordSalt = Convert.ToBase64String(hmac.Key);
//                 passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
//             }
//         }

//         private static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
//         {
//             if (password == null) throw new ArgumentNullException("password");
//             if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

//             byte[] storedHash = Convert.FromBase64String(passwordHash);
//             byte[] storedSalt = Convert.FromBase64String(passwordSalt);

//             if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
//             if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

//             using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
//             {
//                 var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                 for (int i = 0; i < computedHash.Length; i++)
//                 {
//                     if (computedHash[i] != storedHash[i]) return false;
//                 }
//             }

//             return true;
//         }
//     }
// }
