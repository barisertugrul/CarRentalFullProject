using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public class ScreenBase : IScreen
    {
        public string _menuTitle = Messages.DefaultMenuTitle;

        public virtual void AddForm()
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteForm()
        {
            throw new NotImplementedException();
        }

        public virtual void ListForm()
        {
            throw new NotImplementedException();
        }

        public virtual void Menu()
        {
            string consoleVal;
            string[] menuItems = new string[] { "1-Add New Form", "2-Update Form", "3-Delete Form", "4-View Form", "5-RETURN MAIN MENU" };

            ConsoleTexts.WriteConsoleMenuInFrame(_menuTitle, menuItems);

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectNumberOfMenuItem);
            if (consoleVal == "") consoleVal = "0";
            int selected = Convert.ToInt32(consoleVal);
            switch (selected)
            {
                case 1:
                    AddForm();
                    Menu();
                    break;
                case 2:
                    UpdateForm();
                    Menu();
                    break;
                case 3:
                    DeleteForm();
                    Menu();
                    break;
                case 4:
                    ListForm();
                    Menu();
                    break;
                case 5:
                    MainConsoleManager.MainMenu();
                    break;
                default:
                    Console.WriteLine(Messages.WrongChoice);
                    Menu();
                    break;
            }
        }

        public virtual void UpdateForm()
        {
            throw new NotImplementedException();
        }
    }
}
