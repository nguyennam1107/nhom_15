using Nhom_15.Model;
using System;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;

namespace Nhom_15.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        private string _userName;
        private SecureString _password;
        private string _emailSignUp;
        private string _usernameSignUp;
        private string _passwordSignUp;
        private string _confirmPasswordSignUp;
        private bool _isVisibleFormLogin;
        private bool _isShowSignForm;
        private string _errorMessage;
        private bool _isVisibleForm=true;
        private string _tenHienThi;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string EmailSignUp
        {
            get => _emailSignUp;
            set
            {
                _emailSignUp = value;
                OnPropertyChanged(nameof(EmailSignUp));
            }
        }

        public string UsernameSignUp
        {
            get => _usernameSignUp;
            set
            {
                _usernameSignUp = value;
                OnPropertyChanged(nameof(UsernameSignUp));
            }
        }
        public string TenHienThi
        {
            get => _tenHienThi;
            set
            {
                _tenHienThi = value;
                OnPropertyChanged(nameof(TenHienThi));
            }
        }
        public string PasswordSignUp
        {
            get => _passwordSignUp;
            set
            {
                _passwordSignUp = value;
                OnPropertyChanged(nameof(PasswordSignUp));
            }
        }

        public string ConfirmPasswordSignUp
        {
            get => _confirmPasswordSignUp;
            set
            {
                _confirmPasswordSignUp = value;
                OnPropertyChanged(nameof(ConfirmPasswordSignUp));
            }
        }

        public bool IsVisibleFormLogin
        {
            get => _isVisibleFormLogin;
            set
            {
                _isVisibleFormLogin = value;
                OnPropertyChanged(nameof(IsVisibleFormLogin));
            }
        }
        public bool IsVisibleForm
        {
            get => _isVisibleForm;
            set
            {
                _isVisibleForm = value;
                OnPropertyChanged(nameof(IsVisibleForm));
            }
        }
        public bool IsShowSignForm
        {
            get => _isShowSignForm;
            set
            {
                _isShowSignForm = value;
                OnPropertyChanged(nameof(IsShowSignForm));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }
        public ICommand ShowLoginCommand { get; }
        public ICommand ShowSignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(Login);
            SignUpCommand = new ViewModelCommand(SignUp);
            ShowLoginCommand = new ViewModelCommand(ShowLogin);
            ShowSignUpCommand = new ViewModelCommand(ShowSignUp);
            IsVisibleFormLogin = false;
            IsShowSignForm = true;
        }

        private void Login(object obj)
        {
            DataProvider dataProvider = new DataProvider();
            var isValidUser = dataProvider.KiemtraUser(new NetworkCredential(UserName, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                 new GenericIdentity(UserName), null);
                IsVisibleForm = false;
            }
            else
            {
                ErrorMessage = "* Tài khoản hoặc mật khẩu không chính xác";
            }
        }
        private void SignUp(object obj)
        {
            if (string.IsNullOrWhiteSpace(EmailSignUp) ||
                string.IsNullOrWhiteSpace(UsernameSignUp) ||
                string.IsNullOrWhiteSpace(PasswordSignUp) ||
                string.IsNullOrWhiteSpace(TenHienThi))
            {
                ErrorMessage = "Nhập đầy đủ thông tin.";
                return;
            }

            try
            {
                using (var context = new DataProvider())
                {
                    var existingUser = context.DB.TaiKhoans
                                                     .FirstOrDefault(u => u.TenDangNhap == UsernameSignUp);
                    if (existingUser != null)
                    {
                        ErrorMessage = "Tên đăng nhập đã tồn tại.";
                        return;
                    }

                    // Hash the password before storing it
                    string hashedPassword = HashPassword(PasswordSignUp);

                    var user = new TaiKhoan
                    {
                        TenDangNhap = UsernameSignUp,
                        Email = EmailSignUp,
                        TenHienThi=TenHienThi,
                        MatKhau = hashedPassword
                    };
                    context.AddUser(user);
                    ErrorMessage = "Đăng ký thành công vui lòng! Vui lòng đăng nhập";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }
        private string HashPassword(string password)
        {
            // Implement your password hashing logic here, e.g., using BCrypt
            // For demonstration purposes, we'll return the plain password.
            // You should replace this with actual hashing.
            return password; // Use BCrypt.Net.BCrypt.HashPassword(password);
        }
        private void ShowLogin(object obj)
        {
            IsVisibleFormLogin = true;
            IsShowSignForm = false;
        }

        private void ShowSignUp(object obj)
        {
            IsVisibleFormLogin = false;
            IsShowSignForm = true;
        }


    }

}
