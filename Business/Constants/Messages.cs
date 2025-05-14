using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public readonly static string CarAdded = "ürün eklendi";
        public readonly static string UserNotFound = "Kullanıcı bulunamadı";
        public readonly static string PasswordError = "Şifre hatalı";
        public readonly static string SuccessfulLogin = "Sisteme giriş başarılı";
        public readonly static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public readonly static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public readonly static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public readonly static string AuthorizationDenied = "Yetkiniz yok";
        public readonly static string CarDeleted = "Araba Silindi";
        public readonly static string CarUpdated = "Araba Güncellendi";
        public readonly static string EntitiesListed = "Arabalar Listelendi";
        public readonly static string AddedMessage = "Entity Added!";
        public readonly static string DeletedMessage = "Entity Deleted!";
        public readonly static string UpdatedMessage = "Entity Updated!";
        public readonly static string ErrorMessage = "shit";
        public readonly static string RentalAddedErrorMessage = "you cant";
        public readonly static string RentalAddedMessage = "yes you can see";
        public readonly static string FailAddedImageLimit = " no more ";
        public readonly static string ImageFound = "I found";
        public readonly static string FileFound = "we found";
        public readonly static string ImageCount = "just 5 brother ";
    }
}

