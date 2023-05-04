// View Model
class MainWindowVM {
    private DbContext context;
    private Article article;
    public Article DisplayArticle
    {
        get { return article; }
        set { article = value; }
    }

    public string FileAddr { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand AddNewKeywordsCommand { get; set; }

    public MainWindowVM() {
        context = new ArticlesContext();
        article = context.Articles.First();
        AddCommand = new RelayCommand(getFileAndSend);
        AddNewKeywordsCommand = new RelayCommand(addNonExistingKeywords);
    }
    private void getFileAndSend(object obj) {
        // има имплементация на getFileAndSend...
    }

    private void addNonExistingKeywords(string keywords) {
        string[] keywords = keywords.Split(',');
        foreach (string keyword in keywords) {
            if (context.KeyWords.Find(keyword) == null) {
                context.KeyWords.Add(keyword);
            }
        }
    }
}

 // има имплементация на RelayCommand...

 // Model
 public class ArticlesContext : DbContext {
    
    public ArticleContext() : base() { }
    public DbSet<Article> Articles { get; set; }
    public DbSet<KeyWord> KeyWords { get; set; }

    class Article {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Autors { get; set; }
        public string KeyWords { get; set; }
        public byte[] PdfFile { get; set; }

        public string GetStringFromPdfFile() {
            // има имплементация на getStringFromPdfFile
        }

    }

    class KeyWord {
        public string keyword { get; set; }
    }

 }