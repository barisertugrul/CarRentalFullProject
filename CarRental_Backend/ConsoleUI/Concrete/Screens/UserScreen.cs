using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public class UserScreen : ScreenBase
    {
        private UserManager _userManager;

        public UserScreen(UserManager userManager)
        {
            _userManager = userManager;
        }

        public override void AddForm()
        {
            User user = new User();
            string consoleVal;

            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderUserAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeUserFirstName);
            user.FirstName = consoleVal;

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeUserLastName);
            user.LastName = consoleVal;

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeUserEmail);
            user.Email = consoleVal;

            bool confirm = false;
            string password = null;
            while (!confirm) {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeUserPassword);
                password = consoleVal;

                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeUserConfirmPassword);
                string confirmPassword = consoleVal;

                confirm = (password != null && password == confirmPassword) ? true : false;
                Console.WriteLine(Messages.NotComfirmPassword);
            }
            user.PasswordHash = Encoding.ASCII.GetBytes(new string(' ', 100)); //Bu alan sonradan değiştirildiği için artık geçici bir atama yaptım
            user.PasswordSalt = Encoding.ASCII.GetBytes(new string(' ', 100)); //Bu alan da sonradan oluşturuldu

            _userManager.Add(user);
        }

        public override void DeleteForm()
        {
            throw new NotImplementedException();
        }

        public override void ListForm()
        {
            List<User> users = UserList();
            string[] headers = { "User ID", "First Name", "Last Name", "Email Address" };
            //Todo : Parola bilgisini listeden çıkar
            ConsoleTexts.WriteDataList<User>(Messages.ListHeaderUser, users, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        public override void Menu()
        {
            _menuTitle = Messages.UserMenuTitle;
            base.Menu();
        }

        public override void UpdateForm()
        {
            throw new NotImplementedException();
        }

        public List<User> UserList()
        {
            return _userManager.GetAll().Data;
        }
    }
}
