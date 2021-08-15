using MyNewAsteroids.Scenes;
using System.Collections.Generic;
using System.Drawing;

namespace MyNewAsteroids.Model
{
    class RecordsList
    {
        RecordsJournal recordsJournal;
        List<string> recordsList;

        public RecordsList()
        {
            recordsJournal = new RecordsJournal();
            recordsList = new List<string>(recordsJournal.Length);
            for (int i = 0; i < recordsJournal.Length; i++)
            {
                recordsList.Add(recordsJournal.GetRecord(i).ToString());
            }
        }
        public void Draw()
        {
            int space = 30;
            for (int i = 0; i < recordsList.Count; i++)
            {
                RecordsScene.Buffer.Graphics.DrawString($"{i + 1}. {recordsList[i]}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Black, 325, space);
                space += 50;
            }
        }
    }
}
