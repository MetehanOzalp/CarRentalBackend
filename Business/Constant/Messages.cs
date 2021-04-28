using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string CarAdded = "Araç kayıt işlemi başarılı";
        public static string ColorAdded = "Renk kayıt işlemi başarılı";
        public static string BrandAdded = "Marka kayıt işlemi başarılı";
        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalAddedError = "Kiralama işlemi başarısız";
        public static string CarDeleted = "Araç silme işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı";
        public static string ColorDeleted = "Renk silme işlemi başarılı";
        public static string BrandDeleted = "Marka silme işlemi başarılı";
        public static string CarAddError = "Ürün ismi veya fiyat geçersiz";
        public static string ColorAddError = "Eklemek istediğiniz renk zaten mevcut.Farklı bir renk giriniz.";
        public static string BrandAddError = "Eklemek istediğiniz marka zaten mevcut.Farklı bir renk giriniz.";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string imageAdditionLimitExceeded = "Resim ekleme limiti aşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfullLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı kayıt edildi";
        public static string AccessTokenCreated = "Giriş yapıldı";
        public static string AuthorizationDenied = "Yetki yok";
        public static string SuccessfullyPaid = "Ödeme Başarılı";
        public static string CreditCardAdded = "Kart eklendi";
        public static string CreditCardDeleted = "Kart silindi";
        public static string NotEnoughFindeksScore = "Findeks puanı yetersiz";
        public static string RentalSuccessful = "Kiralama başarılı";
        public static string CardAlreadyExists = "Kart zaten kayıtlı";
        public static string NotAvailable = "Bu tarihler arasında kiralanamaz";
        public static string BrandAlreadyExists = "Marka zaten mevcut";
        public static string ColorAlreadyExists = "Renk zaten mevcut";
        public static string CarImageAdded = "Resim eklendi";
        public static string ClaimAlreadyExists = "Kullanıcı bu yetkiye zaten sahip";
    }
}
