using Excel;
using OfficeOpenXml;

#region Create Excel File
//ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//Etudiant etudiant1 = new("Bossis","Pierre",new DateTime(1994,11,14),"3A");
//Etudiant etudiant2 = new("Bossis","Nicolas",new DateTime(1994,11,14),"3B");
//Etudiant etudiant3 = new("Dupont","Jean",new DateTime(1990,2,14),"6A");
//Etudiant etudiant4 = new("Roger","Michel",new DateTime(1989,6,14),"6C");

//List<Etudiant> etudiantList = new() { etudiant1,etudiant2,etudiant3,etudiant4 };


//using (var package = new ExcelPackage())
//{
//    var worksheet = package.Workbook.Worksheets.Add("Etudiants");

//    worksheet.Cells[1, 1].Value = "Nom";
//    worksheet.Cells[1, 2].Value = "Prénom";
//    worksheet.Cells[1, 3].Value = "Date de naissance";
//    worksheet.Cells[1, 4].Value = "Classe";

//    int cells1 = 2;

//    for (int i = 0; i < etudiantList.Count; i++)
//    {
//            worksheet.Cells[cells1, 1].Value = etudiantList[i].Nom;
//            worksheet.Cells[cells1, 2].Value = etudiantList[i].Prenom;

//            worksheet.Cells[cells1, 3].Value = etudiantList[i].DateNaissance;
//            worksheet.Cells[cells1, 3].Style.Numberformat.Format = "dd-mm-yyyy";

//            worksheet.Cells[cells1, 4].Value = etudiantList[i].Classe;
//            cells1++;
//    }

//    string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
//    string filePath = Path.Combine(downloadPath, "Etudiants.xlsx");

//    var file = new FileInfo(filePath);
//    package.SaveAs(file);

//    Console.WriteLine($"Excel file created successfully at {filePath}");
//}
#endregion

#region Read Excel File
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
List<Etudiant> EtudiantList = new();
string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "Etudiants.xlsx");

if (!File.Exists(filePath))
{
    Console.WriteLine($"Le fichier n'existe pas : {filePath}");
    return;
}

using (var package = new ExcelPackage(new FileInfo(filePath)))
{
    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

    int rowCount = worksheet.Dimension.Rows;

    for (int row = 2; row <= rowCount; row++)
    {

        Etudiant etudiant =
            new(
                worksheet.Cells[row, 1].Text,
                worksheet.Cells[row, 2].Text,
                DateTime.Parse(worksheet.Cells[row, 3].Text),
                worksheet.Cells[row, 4].Text
                );

        EtudiantList.Add(etudiant);

    }
}

foreach(Etudiant etudiant in EtudiantList)
{
    Console.WriteLine(etudiant.Nom + " " + etudiant.Prenom);
    Console.WriteLine($"Date de naissance: {etudiant.DateNaissance.ToString("dd/MM/yyyy")}({etudiant.GetAge()} ans)");
    Console.WriteLine("Classe: " + etudiant.Classe);
    Console.WriteLine();
}
#endregion