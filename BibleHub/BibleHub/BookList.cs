using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleHub
{
   
   public class BookList : ObservableCollection<Book>, INotifyPropertyChanged
    {
       AppSettings appSettings;
       
       
        public BookList()
        {
            appSettings = new AppSettings();
            //string visibilityValue = VisiblityMethod();

            Add(new Book("Genesis", "1445-1405 BC",
                    "Moses", "Law", 50, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Exodus", "1445-1405 BC",
                    "Moses", "Law", 40, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Leviticus", "1445-1405 BC",
                    "Moses", "Law", 27, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Numbers", "1445-1405 BC",
                    "Moses", "Law", 36, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Deuteronomy", "1445-1405 BC",
                   "Moses", "Law", 34, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));

            Add(new Book("Joshua", "1405-1385 BC",
                   "Joshua", "History", 24, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Judges", "c. 1043 BC",
                   "Samuel", "History", 21, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Ruth", "1030-1010 BC",
                   "Samuel(?)", "History", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Samuel", "931-722 BC",
                   "Anonymous", "History", 31, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Samuel", "931-722 BC",
                   "Anonymous", "History", 24, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Kings", "561-538 BC",
                   "Anonymous", "History", 22, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Kings", "561-538 BC",
                   "Anonymous", "History", 25, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Chronicles", "450-430 BC",
                   "Ezra(?)", "History", 29, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Chronicles", "450-430 BC",
                   "Ezra(?)", "History", 36, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Ezra", "457-444 BC",
                   "Ezra", "History", 10, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Nehemiah", "424-400 BC",
                   "Ezra", "History", 13, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Esther", "450-331 BC",
                   "Anonymous", "History", 10, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));

            Add(new Book("Job", "Unknown, prior to Genesis",
                   "Unknown", "Wisdom", 42, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Psalms", "1410-450 BC",
                   "Multiple Authors", "Wisdom", 150, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Proverbs", "971-686 BC",
                   "Solomon(+)", "Wisdom", 31, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Ecclesiastes", "940-931 BC",
                   "Solomon", "Wisdom", 12, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Song of Solomon", "971-965 BC",
                   "Solomon", "Wisdom", 8, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));

            Add(new Book("Isaiah", "700-681 BC",
                   "Isaiah", "Major Prophets", 66, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Jeremiah", "586-570 BC",
                   "Jeremiah", "Major Prophets", 52, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Lamentations", "c. 586 BC",
                   "Jeremiah", "Major Prophets", 5, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Ezekiel", "590-570 BC",
                   "Ezekiel", "Major Prophets", 48, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Daniel", "536-530 BC",
                   "Daniel", "Major Prophets", 12, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));

            Add(new Book("Hosea", "755-710 BC",
                   "Hosea", "Minor Prophets", 14, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Joel", "835-796 BC",
                   "Joel", "Minor Prophets", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Amos", "c. 755 BC",
                   "Amos", "Minor Prophets", 9, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Obadiah", "850-840 BC",
                   "Obadiah", "Minor Prophets", 21, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Jonah", "c. 760 BC",
                   "Jonah", "Minor Prophets", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Micah", "735-710 BC",
                   "Micah", "Minor Prophets", 7, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Nahum", "c. 650 BC",
                   "Nahum", "Minor Prophets", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Habakkuk", "615-605 BC",
                   "Habakkuk", "Minor Prophets", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Zephaniah", "635-625 BC",
                   "Zephaniah", "Minor Prophets", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Haggai", "c. 520 BC",
                   "Haggai", "Minor Prophets", 2, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Zechariah", "480-470 BC",
                   "Zechariah", "Minor Prophets", 14, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Malachi", "433-424 BC",
                   "Malachi", "Minor Prophets", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));


            Add(new Book("Matthew", "50-60 AD",
                   "Matthew", "Gospels", 28, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Mark", "50-60 AD",
                   "Mark", "Gospels", 16, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Luke", "60-61 AD",
                   "Luke", "Gospels", 24, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("John", "80-90 AD",
                   "John", "Gospels", 21, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Acts", "62 AD",
                   "Luke", "History", 28, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Romans", "56 AD",
                   "Paul", "Letters of Paul", 16, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Corinthians", "55 AD",
                   "Paul", "Letters of Paul", 16, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Corinthians", "55-56 AD",
                   "Paul", "Letters of Paul", 13, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Galatians", "49-50 AD",
                   "Paul", "Letters of Paul", 6, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Ephesians", "60-62 AD",
                   "Paul", "Letters of Paul", 6, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Philippians", "60-62 AD",
                   "Paul", "Letters of Paul", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Colossians", "60-62 AD",
                   "Paul", "Letters of Paul", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Thessalonians", "51 AD",
                   "Paul", "Letters of Paul", 5, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Thessalonians", "51-52 AD",
                   "Paul", "Letters of Paul", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Timothy", "62-64 AD",
                   "Paul", "Letters of Paul", 6, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Timothy", "66-67 AD",
                   "Paul", "Letters of Paul", 4, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Titus", "62-64 AD",
                   "Paul", "Letters of Paul", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Philemon", "60-62 AD",
                   "Paul", "Letters of Paul", 1, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Hebrews", "67-69 AD",
                   "Unknown", "General Letters", 13, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("James", "44-49 AD",
                   "James", "General Letters", 5, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 Peter", "64-65 AD",
                   "Peter", "General Letters", 5, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 Peter", "67-68 AD",
                   "Peter", "General Letters", 3, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("1 John", "90-95 AD",
                   "John", "General Letters", 5, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("2 John", "90-95 AD",
                   "John", "General Letters", 1, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("3 John", "90-95 AD",
                   "John", "General Letters", 1, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Jude", "68-70 AD",
                   "Jude", "General Letters", 1, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));
            Add(new Book("Revelation", "94-96 AD",
                   "John", "Prophesy", 22, appSettings.CompletedBooksSetting, appSettings.InProgressBooksSetting));

        }
       // public static string VisiblityMethod(object sender)
       //{
           //var completeSenderName = sender.ToString();
           //if (appSettings.CompletedBooksSetting.Contains(completeSenderName + "#"))
           //{
           //    return "Visible";
           //}
           //else
           //{
           //    return appSettings.CompletedBooksSetting;
           //}
           //throw new NotImplementedException();
       //}
    }
    
    public class Book:INotifyPropertyChanged
    {
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        private string bookName;
        private string bookDate;
        private string bookAuthor;
        private string bookCategory;
        private int bookChapters;
        private string completedStatus;
        private string inProgressStatus;

        public Book(String bname, String bdate, String bauthor, String bcategory, int bchapters, String bstatus, String prostatus)
    {
        this.bookName = bname;
        this.bookDate = bdate;
        this.bookAuthor = bauthor;
        this.bookCategory = bcategory;
        this.bookChapters = bchapters;
        this.completedStatus = bstatus;
        this.inProgressStatus = prostatus;
    }
    public String BookName 
    { 
        get { return bookName; }
        set { bookName = value; OnPropertyChanged(this, "BookName"); }
    }
    public String BookDate
    {
        get { return bookDate; }
        set { bookDate = value; OnPropertyChanged(this, "BookDate"); }
    }
    public String BookAuthor
    {
        get { return bookAuthor; }
        set { bookAuthor = value; OnPropertyChanged(this, "BookAuthor"); }
    }
    public String BookCategory
    {
        get { return bookCategory; }
        set { bookCategory = value; OnPropertyChanged(this, "BookCategory"); }
    }
    public int BookChapters
    {
        get { return bookChapters; }
        set { bookChapters = value; OnPropertyChanged(this, "BookChapters"); }
    }
    public String CompletedStatus
    {
        get
        {
            if (completedStatus.Contains("#" + bookName + "#"))
            {
                return "Visible";
            }
            else
            {
                return "Collapsed";
            }
        }
        set { completedStatus = value; OnPropertyChanged(this, "CompletedStatus"); }
    }
    public String InProgressStatus
    {
        get
        {
            if (inProgressStatus.Contains("#" + bookName + "#"))
            {
                return "Visible";
            }
            else
            {
                return "Collapsed";
            }
        }
        set { inProgressStatus = value; OnPropertyChanged(this, "InProgressStatus"); }
    }
    //public String BookDetails { get; set; }


    // OnPropertyChanged will raise the PropertyChanged event passing the
    // source property that is being updated.
    private void OnPropertyChanged(object sender, string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(sender, new PropertyChangedEventArgs(propertyName));
        }

        //if (this.PropertyChanged != null)
        //{
        //    PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
        //}
    }


    }
}
