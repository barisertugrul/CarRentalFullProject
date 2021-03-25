using Business.Concrete;
using Business.Constants;
using ConsoleUI.Concrete.Screens;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI.Concrete
{

    /****************************************************************************
     * 
     * Console işlemleri merkezi
     * 
     ***************************************************************************/
    /* 
     * Performans açısından manager sınıflarını burada atamak mı
     * Yoksa yeri geldikçe, fonksiyonlar içinde tekrar tekrar newlemek mi 
     * daha mantıklı bilemiyorum. Şimdilik newlemeyi burada yapıyorum
     * Sanırım bir overdesign örneği gerçekleştiriyorum
     */
    public static class MainConsoleManager
    {
        public static void MainMenu()
        {
            IScreen _screen = null;
            string consoleVal;
            string[] menuItems = new string[] { "1-Car Manager", "2-Brand Manager", "3-Color Manager",
            "4-User Manager", "5-Customer Manager", "6-Rental Manager", "7-Settings", "8-EXIT" };
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.MainMenuTitle, menuItems);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectNumberOfMenuItem);
            if (consoleVal == "") consoleVal = "0";
            int selected = Convert.ToInt32(consoleVal);
            switch (selected)
            {
                case 1:
                    _screen = new CarScreen(GetCarManager().Data);
                    break;
                case 2:
                    _screen = new BrandScreen(GetBrandManager().Data);
                    break;
                case 3:
                    _screen = new ColorScreen(GetColorManager().Data);
                    break;
                case 4:
                    _screen = new UserScreen(GetUserManager().Data);
                    break;
                case 5:
                    _screen = new CustomerScreen(GetCustomerManager().Data);
                    break;
                case 6:
                    _screen = new RentalScreen(GetRentalManager().Data);
                    break;
                case 7:
                    //SettingMenu();
                    //MainMenu();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(Messages.WrongChoice);
                    MainMenu();
                    break;
            }
            if(_screen != null) _screen.Menu();
            MainMenu();
        }

        public static IDataResult<CarManager> GetCarManager()
        {
            return new SuccessDataResult<CarManager>(new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal())));
        }

        public static IDataResult<ColorManager> GetColorManager()
        {
            return new SuccessDataResult<ColorManager>(new ColorManager(new EfColorDal()));
        }

        public static IDataResult<BrandManager> GetBrandManager()
        {
            return new SuccessDataResult<BrandManager>(new BrandManager(new EfBrandDal()));
        }

        public static IDataResult<UserManager> GetUserManager()
        {
            return new SuccessDataResult<UserManager>(new UserManager(new EfUserDal()));
        }

        public static IDataResult<CustomerManager> GetCustomerManager()
        {
            return new SuccessDataResult<CustomerManager>(new CustomerManager(new EfCustomerDal()));
        }

        public static IDataResult<RentalManager> GetRentalManager()
        {
            return new SuccessDataResult<RentalManager>(new RentalManager(new EfRentalDal()));
        }
    }
}
