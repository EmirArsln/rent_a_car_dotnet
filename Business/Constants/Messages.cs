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
    }
}

