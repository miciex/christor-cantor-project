using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolska_BookManager
{
    public class Record
    {
        public static string TypeToString(Record.Type type)
        {
            switch(type)
            {
                case Record.Type.Book:
                    return "Book";
                case Record.Type.Film:
                    return "Film";
            }

            return "type not handled";
        }

        public static Record.Type StringToRecordType(string type)
        {
            switch(type)
            {
                case "Book":
                    return Record.Type.Book;
                case "Film":
                    return Record.Type.Film;
            }
            return Record.Type.None;
        }
        public enum Type
        {
            Book = 0, Film = 1, None = 2
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Record.Type RecordType { get; set; }
        public int Year { get; set; }

        public Record(string title, string author, string genre, Type recordType, int year)
        {
            Author = author;
            Title = title;
            Genre = genre;
            RecordType = recordType;
            Year = year;
        }
    }
}
