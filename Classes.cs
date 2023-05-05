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
        article.DateOfCreation = DateTime.Now;
        // има имплементация на getFileAndSend...
    }
}

 // има имплементация на RelayCommand...

 // Model
 public class ArticlesContext : DbContext {
    
    public ArticleContext() : base() {}
    public DbSet<Article> Articles { get; set; }

    class Article {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public IList<Autor> Autors { get; set; }
        public string KeyWords { get; set; }
        public byte[] PdfFile { get; set; }
        public DateTime DateOfCreation { get; set; }

        public string GetStringFromPdfFile() {
            // има имплементация на getStringFromPdfFile
        }

    }

    class Autor {
        public string Name { get; set; }
    }

 }