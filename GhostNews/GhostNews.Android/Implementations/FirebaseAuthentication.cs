using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using GhostNews.Constants;
using GhostNews.Droid.Implementations;
using GhostNews.Droid.Services;
using GhostNews.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace GhostNews.Droid.Implementations
{
    public class FirebaseAuthentication : IAuthentication 
    {
        public bool IsSignIn()
        {
            var user = FirebaseHelper.GetAuth().CurrentUser;

            return user != null;
        }
        public string GetUID()
        {
            if (!IsSignIn()) return null;
            return FirebaseHelper.GetAuth().CurrentUser.Uid;
        }
        public async Task<LoginQueryResponse> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                await FirebaseHelper.GetAuth().SignInWithEmailAndPasswordAsync(email, password);
                return LoginQueryResponse.LoggedIn;
            }
            catch (FirebaseAuthInvalidUserException)
            {
                return LoginQueryResponse.InvalidEmail;
            }
            catch (FirebaseAuthInvalidCredentialsException)
            {
                return LoginQueryResponse.WrongPassword;
            }
        }
        public async Task<SignupQueryResponse> RegisterUser(string email, string password)
        {
            try
            {
                await FirebaseHelper.GetAuth().CreateUserWithEmailAndPasswordAsync(email, password);
                await FirebaseHelper.GetAuth().SignInWithEmailAndPasswordAsync(email, password);
                return SignupQueryResponse.Created;
            }
            catch (FirebaseAuthUserCollisionException)
            {
                return SignupQueryResponse.AlreadyExists;
            }
            catch (FirebaseAuthWeakPasswordException)
            {
                return SignupQueryResponse.WeakPassword;
            }
            catch (FirebaseAuthInvalidCredentialsException)
            {
                return SignupQueryResponse.InvalidEmail;
            }
        }
        public bool SignOut()
        {
            try
            {
                FirebaseHelper.GetAuth().SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}