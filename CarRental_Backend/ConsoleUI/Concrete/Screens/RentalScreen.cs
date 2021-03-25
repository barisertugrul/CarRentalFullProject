using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public class RentalScreen : ScreenBase
    {
        private RentalManager _rentalManager;
        private CustomerScreen _customerScreen = new CustomerScreen(MainConsoleManager.GetCustomerManager().Data);
        private CarScreen _carScreen = new CarScreen(MainConsoleManager.GetCarManager().Data);

        public RentalScreen(RentalManager rentalManager)
        {
            _rentalManager = rentalManager;
        }

        public override void AddForm()
        {
            Rental rental = new Rental();
            string consoleVal;

            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderRentalAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            string[] headers = { "Car ID", "Car Name", "Brand Name", "Color Name", "Model Year", "Daily Price", "Description" };
            ConsoleTexts.WriteDataList<CarDetailDto>(Messages.ListHeaderCarSelect, _carScreen.RentableCarList(), headers);
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCarId);
            rental.CarId = Convert.ToInt32(consoleVal);

            ConsoleTexts.WriteDataList<CustomerDetailDto>(Messages.ListHeaderCustomerSelect, _customerScreen.CustomerList());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCustomerId);
            rental.CustomerId = Convert.ToInt32(consoleVal);

            Console.Write(Messages.TypeRentalDate);
            consoleVal = Console.ReadLine();
            DateTime rentDate;
            while (!DateTime.TryParseExact(consoleVal, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out rentDate))
            {
                Console.WriteLine(Messages.InvalidDate);
                consoleVal = Console.ReadLine();
            }
            rental.RentDate = rentDate;
            //rental.ReturnDate = null;

            Console.WriteLine(_rentalManager.Add(rental).Message);
        }

        public override void DeleteForm()
        {
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderRentalDelete);
            ConsoleTexts.FrameHeaderFooterLine();

            List<RentalDetailDto> rentals = RentalList();
            string[] headers = { "Rental ID", "Car Name", "Brand Name", "Color Name", "First Name", "Last Name", "Email Address", "Company Name", "Rent Date", "Return Date" };
            //Todo : Liste sütunlarını azalt
            ConsoleTexts.WriteDataList<RentalDetailDto>(Messages.ListHeaderRentalSelect, rentals, headers);
            if (rentals!= null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectRentalIdToDelete);
                if (consoleVal != "")
                {
                    Rental rental = _rentalManager.GetById(Convert.ToInt32(consoleVal)).Data;
                    if (ConsoleTexts.ConfirmAction(Messages.DeleteItemAttention)) _rentalManager.Delete(rental);
                }
            }
        }

        public override void ListForm()
        {
            List<RentalDetailDto> rentals = RentalList();
            string[] headers = { "Rental ID", "Car Name", "Brand Name", "Color Name", "First Name", "Last Name", "Email Address", "Company Name", "Rent Date", "Return Date" };
            //Todo : Liste sütunlarını azalt
            ConsoleTexts.WriteDataList<RentalDetailDto>(Messages.ListHeaderRental, rentals, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        public override void Menu()
        {
            _menuTitle = Messages.RentalMenuTitle;
            base.Menu();
        }

        public override void UpdateForm()
        {
            string consoleVal;
            
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderRentalDelete);
            ConsoleTexts.FrameHeaderFooterLine();

            List<RentalDetailDto> rentals = RentalList();
            string[] mainHeaders = { "Rental ID", "Car Name", "Brand Name", "Color Name", "First Name", "Last Name",
                "Email Address", "Company Name", "Rent Date", "Return Date" };
            //Todo : Liste sütunlarını azalt
            ConsoleTexts.WriteDataList<RentalDetailDto>(Messages.ListHeaderRentalSelect, rentals, mainHeaders);
            if (rentals != null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectRentalIdToUpdate);
                if (consoleVal != "")
                {

                    Rental rental = new Rental();

                    rental = _rentalManager.GetById(Convert.ToInt32(consoleVal)).Data;

                    string[] headers = { "Car ID", "Car Name", "Brand Name", "Color Name", "Model Year", "Daily Price", "Description" };
                    ConsoleTexts.WriteDataList<CarDetailDto>(Messages.ListHeaderCarSelect, _carScreen.RentableCarList(), headers);
                    consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCarId);
                    rental.CarId = Convert.ToInt32(consoleVal);

                    ConsoleTexts.WriteDataList<CustomerDetailDto>(Messages.ListHeaderCustomerSelect, _customerScreen.CustomerList());
                    consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectCustomerId);
                    rental.CustomerId = Convert.ToInt32(consoleVal);

                    Console.Write(Messages.TypeRentalDate);
                    consoleVal = Console.ReadLine();
                    DateTime rentDate;
                    while (!DateTime.TryParseExact(consoleVal, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out rentDate))
                    {
                        Console.WriteLine(Messages.InvalidDate);
                        consoleVal = Console.ReadLine();
                    }
                    rental.RentDate = rentDate;

                    Console.Write(Messages.TypeRentalDate);
                    consoleVal = Console.ReadLine();
                    DateTime returnDate;
                    while (!DateTime.TryParseExact(consoleVal, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out returnDate))
                    {
                        Console.WriteLine(Messages.InvalidDate);
                        consoleVal = Console.ReadLine();
                    }
                    rental.ReturnDate = returnDate;

                    _rentalManager.Update(rental);
                }
            }
        }

        public List<RentalDetailDto> RentalList()
        {
            return _rentalManager.GetAllRentalDetails().Data;
        }
    }
}