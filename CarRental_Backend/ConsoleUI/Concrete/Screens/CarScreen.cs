using Business.Concrete;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI.Concrete.Screens
{
    public class CarScreen : ScreenBase
    {
        private CarManager _carManager;
        private BrandScreen _brandScreen = new BrandScreen(MainConsoleManager.GetBrandManager().Data);
        private ColorScreen _colorScreen = new ColorScreen(MainConsoleManager.GetColorManager().Data);
        public CarScreen(CarManager carManager)
        {
            _carManager = carManager;
        }

        public override void AddForm()
        {
            Car car = new Car();
            string consoleVal;

            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderCarAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeCarName);
            car.CarName = consoleVal;

            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrandSelect, _brandScreen.StrBrandList());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectBrandId);
            car.BrandId = Convert.ToInt32(consoleVal);

            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColorSelect, _colorScreen.StrColorList());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectColorId);
            car.ColorId = Convert.ToInt32(consoleVal);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeModelYear);
            car.ModelYear = Convert.ToInt16(consoleVal);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeDailyPrice);
            car.DailyPrice = Convert.ToDecimal(consoleVal);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeDescription);
            car.Description = consoleVal;

            _carManager.Add(car);
        }

        public override void DeleteForm()
        {
            Car car;
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderCarDelete);
            ConsoleTexts.FrameHeaderFooterLine();
            ListAllCars();
            if (_carManager.Count().Data > 0)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCarIdToDelete);
                if (consoleVal != "")
                {
                    car = _carManager.GetById(Convert.ToInt32(consoleVal)).Data;
                    if (ConsoleTexts.ConfirmAction(Messages.DeleteItemAttention)) _carManager.Delete(car);
                }
            }
        }

        public override void ListForm()
        {
            string consoleVal;
            _menuTitle = Messages.ListMenuHeaderCar;
            string[] menuItems = new string[] { "1-List of All Cars", "2-Cars List by Brands", "3-Cars List by Color", "4-Available Cars", "5-Already Rented", "6-RETURN MAIN MENU" };

            ConsoleTexts.WriteConsoleMenuInFrame(_menuTitle, menuItems);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectNumberOfMenuItem);
            if (consoleVal == "") consoleVal = "0";
            int selected = Convert.ToInt32(consoleVal);
            switch (selected)
            {
                case 1:
                    ListAllCars();
                    ListForm();
                    break;
                case 2:
                    ListByBrands();
                    ListForm();
                    break;
                case 3:
                    ListByColor();
                    ListForm();
                    break;
                case 4:
                    AvailableCars();
                    ListForm();
                    break;
                case 5:
                    Rented();
                    ListForm();
                    break;
                case 6:
                    Menu();
                    break;
                default:
                    Console.WriteLine(Messages.WrongChoice);
                    Menu();
                    break;
            }
        }

        private void Rented()
        {
            List<CarDetailDto> cars = RentedCarList();
            string[] headers = { "Car ID", "Car Name", "Brand Name", "Color Name", "Model Year", "Daily Price", "Description" };
            ConsoleTexts.WriteDataList<CarDetailDto>(Messages.ListHeaderRentedCars, cars, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        private void AvailableCars()
        {
            List<CarDetailDto> cars = RentableCarList();
            string[] headers = { "Car ID", "Car Name", "Brand Name", "Color Name", "Model Year", "Daily Price", "Description" };
            ConsoleTexts.WriteDataList<CarDetailDto>(Messages.ListHeaderAvailableCars, cars, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        private void ListByColor()
        {
            string consoleVal;
            ColorManager colorManager = MainConsoleManager.GetColorManager().Data;
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColorSelect, _colorScreen.StrColorList());
            //ConsoleTexts.WriteDataList("COLORS", _colorManager.GetAll());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectColorId);
            int colorId = Convert.ToInt32(consoleVal);

            string color = colorManager.GetById(colorId).Data.Name;
            List<CarDetailDto> cars = _carManager.GetCarDetailsByColorId(colorId).Data;
            ConsoleTexts.WriteDataList(color + Messages.ListHeaderColoredCar, cars);
        }

        private void ListByBrands()
        {
            string consoleVal;
            BrandManager brandManager = MainConsoleManager.GetBrandManager().Data;
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrandSelect, _brandScreen.StrBrandList());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectBrandId);
            int brandId = Convert.ToInt32(consoleVal);

            string brand = brandManager.GetById(brandId).Data.Name;
            List<CarDetailDto> cars = _carManager.GetCarDetailsByBrandId(brandId).Data;
            ConsoleTexts.WriteDataList(brand + Messages.ListHeaderBrandedCar, cars);

            Console.Write( Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        private void ListAllCars()
        {
            List<CarDetailDto> cars = CarList();
            string[] headers = { "Car ID", "Car Name", "Brand Name", "Color Name", "Model Year", "Daily Price", "Description" };
            ConsoleTexts.WriteDataList<CarDetailDto>(Messages.ListHeaderCar, cars, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        public override void Menu()
        {
            _menuTitle = Messages.CarMenuTitle;
            base.Menu();
        }

        public override void UpdateForm()
        {
            Car car;
            string consoleVal;

            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderCarUpdate);
            ConsoleTexts.FrameHeaderFooterLine();
            ListAllCars();
            if (_carManager.Count().Data > 0)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCarIdToUpdate);
                car = _carManager.GetById(Convert.ToInt32(consoleVal)).Data;

                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeCarName + Messages.LeaveBlank);
                car.CarName = consoleVal;
                if (consoleVal != "")
                {
                    car.CarName = consoleVal;
                }

                ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrandSelect, _brandScreen.StrBrandList());
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectBrandId + Messages.LeaveBlank);
                if (consoleVal != "")
                {
                    car.BrandId = Convert.ToInt32(consoleVal);
                }

                ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColorSelect, _colorScreen.StrColorList());
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectColorId + Messages.LeaveBlank);
                if (consoleVal != "")
                {
                    car.ColorId = Convert.ToInt32(consoleVal);
                }

                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeModelYear + Messages.LeaveBlank);
                if (consoleVal != "")
                {
                    car.ModelYear = Convert.ToInt16(consoleVal);
                }

                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeDailyPrice + Messages.LeaveBlank);
                if (consoleVal != "")
                {
                    car.DailyPrice = Convert.ToDecimal(consoleVal);
                }

                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeDescription + Messages.LeaveBlank);
                if (consoleVal != "")
                {
                    car.Description = consoleVal;
                }

                _carManager.Update(car);
            }
            else
            {
                Menu();
            }
                
        }
        
        public List<CarDetailDto> CarList()
        {
                return _carManager.GetAllCarDetails().Data;
        }

        public List<CarDetailDto> RentableCarList()
        {
            return _carManager.GetRentableCarDetails().Data;
        }

        public List<CarDetailDto> RentedCarList()
        {
            return _carManager.GetRentedCarDetails().Data;
        }
    }
}
