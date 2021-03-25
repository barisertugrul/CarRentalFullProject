using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public class BrandScreen : ScreenBase
    {
        private BrandManager _brandManager;

        public BrandScreen(BrandManager brandManager)
        {
            _brandManager = brandManager;
        }

        public override void AddForm()
        {
            Brand brand = new Brand();
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderBrandAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeBrandName);
            brand.Name = consoleVal;
            _brandManager.Add(brand);
        }

        public override void DeleteForm()
        {
            Brand brand;
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderBrandDelete);
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrandSelect, StrBrandList());
            if (StrBrandList() != null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectBrandIdToDelete);
                if (consoleVal != "")
                {
                    brand = _brandManager.GetById(Convert.ToInt32(consoleVal)).Data;
                    if (ConsoleTexts.ConfirmAction(Messages.DeleteItemAttention)) _brandManager.Delete(brand);
                }
            }
        }

        public override void ListForm()
        {
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrand, StrBrandList());

            Console.Write(Messages.MessageForReturnToMenu);
            Console.ReadKey();
        }

        public override void Menu()
        {
            _menuTitle = Messages.ColorMenuTitle;
            base.Menu();
        }

        public override void UpdateForm()
        {
            Brand brand;
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderBrandUpdate);
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderBrandSelect, StrBrandList());
            if (StrBrandList() != null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectBrandIdToUpdate);
                if (consoleVal != "")
                {
                    brand = _brandManager.GetById(Convert.ToInt32(consoleVal)).Data;
                    consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeBrandName + Messages.LeaveBlank);
                    if (consoleVal != "")
                    {
                        brand.Name = consoleVal;
                    }
                    _brandManager.Update(brand);
                }
            }
        }

        public List<Brand> BrandList()
        {
            return _brandManager.GetAll().Data;
        }

        public string[] StrBrandList()
        {
            string[] brandList = new string[_brandManager.GetAll().Data.Count];
            int i = 0;
            foreach (Brand brand in _brandManager.GetAll().Data)
            {
                brandList[i] = Messages.IDTag + brand.Id + " - " + brand.Name;
                i++;
            }
            return brandList;
        }
    }
}
