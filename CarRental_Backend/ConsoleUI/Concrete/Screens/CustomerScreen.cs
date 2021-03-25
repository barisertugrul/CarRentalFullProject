using Business.Concrete;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI.Concrete.Screens
{
    public class CustomerScreen : ScreenBase
    {
        private CustomerManager _customerManager;
        private UserScreen _userScreen = new UserScreen(MainConsoleManager.GetUserManager().Data);

        public CustomerScreen(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public override void AddForm()
        {
            Customer customer = new Customer();
            string consoleVal;

            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderCustomerAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            ConsoleTexts.WriteDataList(Messages.ListHeaderUserSelect, _userScreen.UserList());
            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectUserId);
            customer.UserId = Convert.ToInt32(consoleVal);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeCustomerCompanyName);
            customer.CompanyName = consoleVal;

            _customerManager.Add(customer);
        }

        public override void DeleteForm()
        {
            throw new NotImplementedException();
        }

        public override void ListForm()
        {
            List<CustomerDetailDto> customers = CustomerList();
            string[] headers = { "Customer ID", "First Name", "Last Name", "Email Address", "Company Name" };
            //Todo : Parola bilgisini listeden çıkar
            ConsoleTexts.WriteDataList<CustomerDetailDto>(Messages.ListHeaderCustomer, customers, headers);

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        public override void Menu()
        {
            _menuTitle = Messages.CustomerMenuTitle;
            base.Menu();
        }

        public override void UpdateForm()
        {
            throw new NotImplementedException();
        }

        public List<CustomerDetailDto> CustomerList()
        {
            return _customerManager.GetAllCustomerDetails().Data;
        }
    }
}
