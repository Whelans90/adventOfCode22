int mostCalories = 0;
int currentElfCalories = 0;
List<int> calories = new List<int>();
int total = 0;

foreach (string line in System.IO.File.ReadLines(AppContext.BaseDirectory+"elfCalories.txt"))
{
    
    if (line == "")
    {
        //mostCalories = Math.Max(mostCalories, currentElfCalories);
        calories.Add(currentElfCalories);
        currentElfCalories = 0;
        continue;
    }

    currentElfCalories += Int32.Parse(line);
}

calories.Add(currentElfCalories);
calories.Sort();
calories.Reverse();
total = calories[0] + calories[1] + calories[2];

Console.WriteLine(total);

Console.ReadKey();