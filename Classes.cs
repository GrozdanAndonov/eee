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

    public ICommand CheckKeywordInTop50Command { get; set; }

    public MainWindowVM() {
        context = new ArticlesContext();
        AddCommand = new RelayCommand(getFileAndSend);
        CheckKeywordInTop50Command = new RelayCommand(isKeywordInTop50MostlyUsedKeywordsFromAllArticles);
    }
    private void getFileAndSend(object obj) {
        // има имплементация на getFileAndSend...
    }

    private bool isKeywordInTop50MostlyUsedKeywordsFromAllArticles(string keyword) {
       var allArticles = context.Articles;
       var dictionary = new Dictionary<string, int>();
       foreach(var article in allArticles) {
            string[] keywords = article.KeyWords.Split(',');
            foreach(var keyword in keywords) {
                if (dictionary[keyword] == null) {
                    dictionary[keyword] = 1;
                } else {
                    dictionary[keyword] = dictionary[keyword]++;
                }
            }
        }
        var sortedKeyValuePairs = dictionary.ToList();
        sortedKeyValuePairs.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
        sortedKeyValuePairs = sortedKeyValuePairs.Take(50).ToList();
        foreach(var pair in sortedKeyValuePairs) {
            if (pair.Key == keyword) {
                return true;
            } 
        }
        return false;
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

        public string GetStringFromPdfFile() {
            // има имплементация на getStringFromPdfFile
        }

    }

 }