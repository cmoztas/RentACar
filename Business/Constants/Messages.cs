﻿using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        internal static string AllDatasListed = "All data listed";
        internal static string BrandAdded = "Brand successfully added";
        internal static string BrandUpdated = "Brand successfully updated";
        internal static string BrandDeleted = "Brand successfully deleted";
        internal static string CarAdded = "Car successfully added";
        internal static string CarUpdated = "Car successfully updated";
        internal static string CarDeleted = "Car successfully deleted";
        internal static string ColorAdded = "Color successfully added";
        internal static string ColorUpdated = "Color successfully updated";
        internal static string ColorDeleted = "Color successfully deleted";
        internal static string CustomerAdded = "Customer successfully added";
        internal static string CustomerUpdated = "Customer successfully updated";
        internal static string CustomerDeleted = "Customer successfully deleted";
        internal static string RentalAdded = "Rental successfully added";
        internal static string RentalUpdated = "Rental successfully updated";
        internal static string RentalDeleted = "Rental successfully deleted";
        internal static string ImageAdded = "Image successfully added";
        internal static string ImageUpdated  = "Image successfully deleted";
        internal static string ImageDeleted  = "Image successfully added";
        internal static string FileUploadAmountExceeded = "The maximum file upload limit has been exceeded";
        internal static string CarImageNotFound = "The corresponding picture of car was not found";
        internal static string AllImageDeleted = "All images are successfully deleted";
        internal static string AuthorizationDenied = "Authorization denied";
        internal static string AccessTokenCreated = "User's access token is created";
        internal static string UserNotFound = "User not found";
        internal static string PasswordError = "Wrong password";
        internal static string SuccessfulLogin = "Login successful";
        internal static string UserRegistered = "User successfully registered";
        internal static string UserAdded = "User added";
        internal static string UserAlreadyExists = "This user is already exists";
    }
}