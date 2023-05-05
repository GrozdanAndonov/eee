// View Model
class MainWindowVM {
    private Article article;
    public Article DisplayArticle
    {
        get { return article; }
        set { article = value; }
    }

    public string FileAddr { get; set; }
    public ICommand AddCommand { get; set; }

    public MainWindowVM() {
        AddCommand = new RelayCommand(getFileAndSend);
    }
    private void getFileAndSend(object obj) {
        // има имплементация на getFileAndSend...
    }

    private string checkDate(DateTime givenDate) {
        DateTime now = DateTime.Now;
        if (now.Date > givenDate.Date) {
            return "The period has expired";
        } else {
            TimeSpan ts = givenDate - now;
            return String.Format("Time remaining: days:{0}, hours:{1}, minutes: {2}", ts.Days, ts.Hours, ts.Minutes);  
        }
    }
}

 // има имплементация на RelayCommand...

 // Model
 public class ArticlesContext : DbContext {
    
    public ArticleContext() : base() { }
    public DbSet<Article> Articles { get; set; }

    class Article {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Autors { get; set; }
        public string KeyWords { get; set; }
        public byte[] PdfFile { get; set; }

        public int GetNumberOfAutors {
            get {
                return Autors.Split(',').Length;
            }
        }

        public string GetStringFromPdfFile {
            get {
                // има имплементация на getStringFromPdfFile
            }
           
        }

    }

 }