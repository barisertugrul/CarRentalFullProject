using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public interface IScreen
    {
        void Menu();
        void AddForm();
        void UpdateForm();
        void DeleteForm();
        void ListForm();
    }
}
