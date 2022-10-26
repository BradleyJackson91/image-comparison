using ImageComparriosn.src;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Image Comparison: Starting Process");

// Step 1: Create a list of imgset1 files
List<string> imgset1list = new List<string>();
try
{
   imgset1list = Directory.GetFiles(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\ImageComparison\\imgset1")).ToList();
}
catch(Exception ex)
{
    Console.WriteLine("Error: Please make sure that the following folders exist on your desktop:");
    Console.WriteLine("ImageComparion, ImageComparison/imgset1, ImageComparison/imgset2");
    System.Environment.Exit(1);    
}
// Step 2: Create a list of imgset2 files
List<string> imgset2list = new List<String>();
try
{
    imgset2list = Directory.GetFiles(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\ImageComparison\\imgset2")).ToList();
}
catch (Exception ex)
{
    Console.WriteLine("Error: Please make sure that the following folders exist on your desktop:");
    Console.WriteLine("ImageComparion, ImageComparison/imgset1, ImageComparison/imgset2");
    System.Environment.Exit(2);
}


// Step 3: For-each imgset1 file: for-each imgset2 file: execute DeepAILocal comparison
List<DeepAIComparison> results = new List<DeepAIComparison>();
//DeepAILocal dailocal = new DeepAILocal();

foreach(string file in imgset1list)
{
    foreach(string file2 in imgset2list)
    {
        Console.WriteLine(String.Concat("Comparing image ", (imgset1list.IndexOf(file) + 1).ToString(), " of ", imgset1list.Count.ToString(), " with image ", (imgset2list.IndexOf(file2)+1).ToString(), " of ", imgset2list.Count.ToString()));
        DeepAIComparison thisComparison = new DeepAIComparison(file, file2);
        
        DeepAILocal.compareImages(ref thisComparison);

        results.Add(thisComparison);

    }
}

// Step 4: Sort the results based on response value ASC
results = DeepAIComparison.BubbleSort(results);

// Step 5: Output results to CSV file.
FileIO.WriteCSV(results);

Console.WriteLine("Image Comparison: Goodbye");