using System;
using System.IO;

namespace MyNewAsteroids.Model
{
    class RecordsJournal
    {
        int[] records;
        int currentRecord;
        readonly string fileName;
        StreamWriter writer;
        StreamReader reader;
        FileStream fileStream;

        public int Length { get; private set; } = 10;

        public RecordsJournal()
        {
            records = new int[Length];
            currentRecord = 0;
            fileName = "records_journal.txt";
            ReadFromFile();
        }

        public bool TryAddRecord(int newRecord)
        {
            if(currentRecord == records.Length - 1)
            {
                if (TryReplaceRecords(newRecord))
                {
                    SortRecords();
                    return true;
                }
            }
            return false;
        }
        private bool TryReplaceRecords(int newRecord)
        {
            int indexForReplace = GetMinIndex();
            if(records[indexForReplace] < newRecord)
            {
                records[indexForReplace] = newRecord;
                return true;
            }
            return false;
        }
        private int GetMinIndex()
        {
            int min = records[0];
            int minIndex = 0;
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i] < min)
                {
                    min = records[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private void SortRecords()
        {
            Array.Sort(records);
            Array.Reverse(records);
        }
        public void ReadFromFile()
        {
            fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(fileStream, System.Text.Encoding.UTF8);
            for (int i = 0; reader.Peek() != -1; i++)
            {
                records[i] = int.Parse(reader.ReadLine());
                currentRecord = i;
            }
            reader.Dispose();
            reader.Close();
            fileStream.Close();
        }
        public void WriteToFile()
        {
            fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
            for (int i = 0; i < records.Length; i++)
            {
                writer.WriteLine(records[i]);
            }
            writer.Dispose();
            writer.Close();
            fileStream.Close();
        }
        public int GetRecord(int index)
        {
            return records[index];
        }
    }
}
