using Json;
using System.Text.Json;
#region Create Json File

//Article article1 = new Article("Article1", "Description1", 15.99m);
//Article article2 = new Article("Article2", "Description2", 6.99m);
//Article article3 = new Article("Article3", "Description3", 9);
//List<Article> articles = new List<Article>() { article1, article2, article3 };

//string jsonArticle = JsonSerializer.Serialize(articles, new JsonSerializerOptions { WriteIndented = true });

//string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
//string filePath = Path.Combine(downloadPath, "Articles.json");

//try
//{
//    File.WriteAllText(filePath, jsonArticle);

//    Console.WriteLine($"Fichier JSON créé avec succès à l'emplacement : {filePath}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Erreur: " + ex.Message);
//}


#endregion

#region Read Json File

string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
string filePath = Path.Combine(downloadPath, "Articles.json");

if (!File.Exists(filePath))
{
    Console.WriteLine("Fichier introuvable.");
    return;
}

try
{
    string jsonString = File.ReadAllText(filePath);

    List<Article> articles = JsonSerializer.Deserialize<List<Article>>(jsonString);

    foreach(Article a in articles)
    {
        Console.WriteLine(a.Nom);
    }
}
catch (Exception ex)
{

    Console.WriteLine("Erreur: " + ex.Message);
}
#endregion