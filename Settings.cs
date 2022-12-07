using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healty_Panda
{
    internal static class Settings
    {
        static Button previusButton,activeButton;
        public static void LoginWritingActive(TextBox textBox,Panel panel, bool isActive)
        {
            if (isActive)
            {
               textBox.BackColor = Color.White;
               panel.BackColor = Color.White;
            }
            else
            {
                textBox.BackColor = Color.WhiteSmoke;
                panel.BackColor = Color.WhiteSmoke;
            }
        }

        public static void SetButtonActive(Button newButton)
        {
            previusButton = activeButton; 
            if (newButton != activeButton)
            {
                activeButton = newButton;
                activeButton.BackColor = Color.ForestGreen;
                if (previusButton != null)
                {
                    previusButton.BackColor = Color.FromArgb(51, 51, 76);
                }
            }
        }
    }
}
