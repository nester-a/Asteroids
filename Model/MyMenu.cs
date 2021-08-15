using System.Collections.Generic;
using System.Drawing;

namespace MyNewAsteroids.Model
{
    class MyMenu
    {
        List<MyButton> buttons;
        int CurrentButtonIndex;
        public string CurrentButtonName { get; set; }
        public MyMenu()
        {
            buttons = new List<MyButton>();
            buttons.Add(new NewGameButton(new Point(265, 30), new Size(256, 166)));
            buttons.Add(new RecordsButton(new Point(265, 30 + 166), new Size(256, 166)));
            buttons.Add(new ExitButton(new Point(265, 30 + 166 * 2), new Size(256, 166)));
            CurrentButtonIndex = 0;
            CurrentButtonName = buttons[CurrentButtonIndex].Name;
        }
        public void Draw()
        {
            foreach (var button in buttons)
            {
                button.Draw();
            }
        }
        public void ScrollUp()
        {
            if (CurrentButtonIndex == 0 && buttons[CurrentButtonIndex].isSelected)
            {
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonIndex = buttons.Count - 1;
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonName = buttons[CurrentButtonIndex].Name;
            }
            else
            {
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonIndex -= 1;
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonName = buttons[CurrentButtonIndex].Name;
            }
        }
        public void ScrollDown()
        {
            if(CurrentButtonIndex == buttons.Count - 1 && buttons[CurrentButtonIndex].isSelected)
            {
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonIndex = 0;
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonName = buttons[CurrentButtonIndex].Name;
            }
            else
            {
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonIndex += 1;
                buttons[CurrentButtonIndex].ChangeSelection();
                CurrentButtonName = buttons[CurrentButtonIndex].Name;   
            }
        }

    }
}
