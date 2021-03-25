using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Concrete.Screens
{
    public class ColorScreen : ScreenBase
    {
        private ColorManager _colorManager;

        public ColorScreen(ColorManager colorManager)
        {
            _colorManager = colorManager;
        }

        public override void AddForm()
        {
            Color color = new Color();
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderColorAddNew);
            ConsoleTexts.FrameHeaderFooterLine();

            consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeColorName);
            color.Name = consoleVal;

            _colorManager.Add(color);
        }

        public override void DeleteForm()
        {
            Color color;
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderColorDelete);
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColorSelect, StrColorList());
            if (StrColorList() != null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectColorIdToDelete);
                if (consoleVal != "")
                {
                    color = _colorManager.GetById(Convert.ToInt32(consoleVal)).Data;
                    if (ConsoleTexts.ConfirmAction(Messages.DeleteItemAttention)) _colorManager.Delete(color);
                }
            }
        }

        public override void ListForm()
        {
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColor, StrColorList());

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
            Color color;
            string consoleVal;
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.Header(Messages.FormHeaderColorUpdate);
            ConsoleTexts.FrameHeaderFooterLine();
            ConsoleTexts.WriteConsoleMenuInFrame(Messages.ListHeaderColorSelect, StrColorList());
            if (StrColorList() != null)
            {
                consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.SelectColorIdToUpdate);
                if (consoleVal != "")
                {
                    color = _colorManager.GetById(Convert.ToInt32(consoleVal)).Data;

                    consoleVal = ConsoleTexts.ConsoleWriteReadLine(Messages.TypeColorName + Messages.LeaveBlank);
                    if (consoleVal != "")
                    {
                        color.Name = consoleVal;
                    }
                    _colorManager.Update(color);
                }
            }
        }

        public List<Color> ColorList()
        {
            return _colorManager.GetAll().Data;
        }

        public string[] StrColorList()
        {
            string[] colorList = new string[_colorManager.GetAll().Data.Count];
            int i = 0;
            foreach (Color color in _colorManager.GetAll().Data)
            {
                colorList[i] = Messages.IDTag + color.Id + " - " + color.Name;
                i++;
            }
            return colorList;
        }
    }
}
