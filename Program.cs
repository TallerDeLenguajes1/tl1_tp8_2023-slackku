// Console.Write("Ingrese el path de una carpeta: ");
// Por razones de optimizacion de tiempo, la ruta sera predefinida.

Random rnd = new Random();
List<int> listaRndInt = new List<int>();

for (int i = 0; i < 6; i++)
{
    listaRndInt.Add(rnd.Next(0, 100));
}
string? currentFolderPath = Directory.GetCurrentDirectory();
string? pruebaFolderPath = currentFolderPath + @"\prueba\";
// Genera carpetas en el espacio actual
listaRndInt.ForEach(num =>
{
    using (StreamWriter file = File.AppendText(pruebaFolderPath + num.ToString() + ".txt"))
    {
        file.Write("This is a pre-stablished message to fill the .txt files generated");
        file.Close();
    }
});

string[] fileNames = Directory.GetFiles(pruebaFolderPath);
Console.WriteLine(fileNames[0]);
for (int x = 0; x < fileNames.Length; x++)
{
    string nameFileWE = fileNames[x].Split(pruebaFolderPath)[1];
    string[] nameFile = nameFileWE.Split(".");
    using (StreamWriter filelog = File.AppendText(currentFolderPath + @"\index.csv"))
    {
        filelog.Write($"Indice: {x} - ");
        filelog.Write($"Nombre del Archivo: {nameFile[0]} - ");
        filelog.WriteLine($"Extension del Archivo: {nameFile[1]},");
        filelog.Close();
    }
}