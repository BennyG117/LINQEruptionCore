

using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
//! Example Query - Prints all Stratovolcano eruptions
Console.WriteLine("===========================================");
Console.WriteLine("===========(EXAMPLE)======================= \n");
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

//! Execute Assignment Tasks here! =================================================
Console.WriteLine("===========================================");
Console.WriteLine("===========(1)============================= \n");
//1) Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? chileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine($"First eruption in Chile: {chileEruption.ToString()}");


Console.WriteLine("===========================================");
Console.WriteLine("===========(2)============================= \n");
//2) Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption? hawaiianEruption = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (hawaiianEruption != null)
{
    Console.WriteLine($"First eruption from Hawwaiian Islands: {hawaiianEruption}");

} 
else
{
    Console.WriteLine("No Hawaiian Island Eruptions were found.");
}


Console.WriteLine("===========================================");
Console.WriteLine("===========(3)============================= \n");
// 3) Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Eruption? greenlandEruption = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (greenlandEruption != null)
{
    Console.WriteLine($"First eruption from Greenland: {greenlandEruption}");

} 
else
{
    Console.WriteLine("No Greenland Eruptions were found.");
}

Console.WriteLine("===========================================");
Console.WriteLine("===========(4)============================= \n");
// 4) Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? newZealandEruption = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
if (newZealandEruption != null)
{
    Console.WriteLine($"First eruption after 1900 in New Zealand: {newZealandEruption}");

} 
else
{
    Console.WriteLine("No New Zealand Eruptions were found.");
}


Console.WriteLine("===========================================");
Console.WriteLine("===========(5)============================ \n");
// 5) Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> all2000Eruptions = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(all2000Eruptions, "All volcano eruptions where the elevation is over 2000m: ");



Console.WriteLine("===========================================");
Console.WriteLine("===========(6)============================ \n");
// 6) Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> allLEruptions = eruptions.Where(n => n.Volcano.StartsWith("L")).ToList();
PrintEach(allLEruptions, "All volcano eruptions where Volcanoe's name starts with an 'L': ");
Console.WriteLine($"Total number of Eruptions from volcanoes that start with the letter 'L' is: {allLEruptions.Count()}");


Console.WriteLine("===========================================");
Console.WriteLine("===========(7)============================ \n");
// 7) Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int highestEruption = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"The highest eruption elevation is: {highestEruption}m");


Console.WriteLine("===========================================");
Console.WriteLine("===========(8)============================ \n");
// 8) Use the highest elevation variable to find and print the name of the Volcano with that elevation.
int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Eruption? highestElevationVocano = eruptions.FirstOrDefault(e => e.ElevationInMeters == highestElevation);
Console.WriteLine($"The volcano with the highest elevation is: {highestElevationVocano.Volcano}");



Console.WriteLine("===========================================");
Console.WriteLine("===========(9)============================== \n");
// 9) Print all Volcano names alphabetically.
IEnumerable<Eruption> alphabetizeVolcanoes = eruptions.OrderBy(e => e.Volcano);
PrintEach(alphabetizeVolcanoes, "The alpabetized list of volcanoes:");


Console.WriteLine("===========================================");
Console.WriteLine("===========(10)============================ \n");
// 10) Print the sum of all the elevations of the volcanoes combined.
int totalElevation = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Total Elevation of all the volcanoes: {totalElevation}m");



Console.WriteLine("===========================================");
Console.WriteLine("===========(11)============================ \n");
// 11) Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool eruptionsIn2000 = eruptions.Any(e => e.Year == 2000);
if (!eruptionsIn2000)
{
    Console.WriteLine("There were no eruptions in the year 2000.");
} 
else
{
    Console.WriteLine("There were eruption(s) in the year 2000.");
}



Console.WriteLine("===========================================");
Console.WriteLine("===========(12)============================ \n");
// 12) Find all stratovolcanoes and print just the first three (Hint: look up Take)
IEnumerable<Eruption> first3Strato = eruptions.Where(c => c.Type == "Stratovolcano").Take(3).ToList();
PrintEach(first3Strato, "The first three Stratovolcano eruptions from our Database: ");


Console.WriteLine("===========================================");
Console.WriteLine("===========(13)============================ \n");
// 13) Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> priorTo1000 = eruptions.Where(e => e.Year <1000).OrderBy(e => e.Volcano);
PrintEach(priorTo1000, "List of alphabetized volcanoes with eruptions prior to 1000 CE: ");


Console.WriteLine("===========================================");
Console.WriteLine("===========(14)============================ \n");
// 14) Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
IEnumerable<string> priorTo1000VolcanoNames = eruptions.Where(e => e.Year <1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
Console.WriteLine("List of alphabetized volcano names with eruptions prior to 1000 CE:");
Console.WriteLine("{0}", String.Join("\n", priorTo1000VolcanoNames));



Console.WriteLine("===========================================");
Console.WriteLine("================(THE END)================");

//! ================================================================================
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


// ===========================

app.Run();
