using Challenges.Model;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        string continuing = "S";

        while (continuing.ToUpper() != "N")
        {
            //Console.Write("Type DAY: ");
            //int day = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Type MONTH: ");
            //int month = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Type YEAR: ");
            //int year = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"Date is {day}/{month}/{year}");

            //var dayOfWeek = DayOfWeek(day, month, year);
            //Console.WriteLine($"Day of week is '{dayOfWeek}'");

            /////////////////////////////////////////////////////
            //var encoded = Base64Encode(word);
            //Console.WriteLine($"Word encoded is [{encoded}]");

            //var decoded = Base64Decode(word);
            //Console.WriteLine($"Word decoded is [{decoded}]");

            /////////////////////////////////////////////////////
            //Console.Write("Type a word: ");
            //string word = Console.ReadLine();

            //string mostRepeated = MostRepeatedCharacter(word);
            //Console.Write($"The letter most repeated is [{mostRepeated}]");

            //Console.Write("Type a word: ");
            //int rotations = Convert.ToInt32(Console.ReadLine());
            //string word = Console.ReadLine();

            ////////char repeated = MostRepeatedChar(word);
            ////////Console.WriteLine($"Most repeated char is [{repeated}]");
            ///
            //int countWords = wordsCounterd(word);
            //Console.WriteLine($"Number of words is {countWords}");

            ////////////string fibonacciArray = FibonacciNovo(rotations);
            ////////////Console.WriteLine($"Array de fibonacci is: {fibonacciArray}");

            //////////////int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //////////////int sum = SumOfEvensNew(array);
            //////////////Console.WriteLine($"Sum of evens is {sum}");

            //////int[] array1 = { 1, 2, 4, 100, 182, 5, 6, 7 };
            //////int[] array2 = { 3, 4, 5, 6, 7 };

            //////FindNumbers(array1, array2);

            int[] array1 = { 2, 2, 3, 3, 3 };
            //int[] array1 = { 2, 2, 3, 3 };
            //int[] array1 = { 3, 3, 3, 2, 2 };
            int lucky = LuckyNumber(array1);
            Console.WriteLine($"LuckyNumber is {lucky}");

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Se deseja sair digite 'N'");
            continuing = Console.ReadLine();

            Console.Clear();
        }

        #region tests
        //while (continuing.ToUpper() == "S")
        //{
        //    Console.WriteLine("Type something:");
        //    string listOfWords = Console.ReadLine();

        //    //Q0 - WordsCounter
        //    int numberOfWords = WordsCounter(listOfWords);
        //    Console.WriteLine($"Number of words is {numberOfWords}");
        //    Console.WriteLine("--------------------------------");
        //    Console.WriteLine("Se deseja testar mais palavras, digite 'S'");
        //    continuing = Console.ReadLine();

        //    Console.Clear();
        //}

        //while (continuing.ToUpper() != "N")
        //{
        //    Console.Write("Fibonacci - type number of rotations:");
        //    int rotation = Convert.ToInt32(Console.ReadLine());
        //    //Fibonacci(rotation);
        //    string sequence = FibonacciNew(rotation);
        //    Console.WriteLine(sequence);

        //    Console.WriteLine();
        //    Console.WriteLine("--------------------------------");
        //    Console.WriteLine("Se deseja sair digite 'N'");
        //    continuing = Console.ReadLine();

        //    Console.Clear();
        //}

        //https://www.fullstack.cafe/interview-questions/c

        //Q4-ReverseString
        //string someStringReversed = ReverseString(someString);
        //Console.WriteLine($"Reversed wor
        //d is '{someStringReversed}'");
        //Console.ReadKey();

        //Q9-SumOfEvens
        //int[] listofNumbers = [1, 2, 3, 4 ];
        //SumOfEvens(listofNumbers);

        //Q2-Filter out the first 3 even numbers from the list using LINQ.
        //int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        //ReturnEvensUsingLinq(numbers);

        //Working with LINQ
        //LinqExercise();

        //Jumping on the Clouds 29/02/2024
        //List<int> clouds = new List<int>();
        //0 0 1 0 0 1 0
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(1);
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(1);
        //clouds.Add(0);

        //0 0 0 0 1 0
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(1);
        //clouds.Add(0);

        //0 0 0 1 0 0 
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(0);
        //clouds.Add(1);
        //clouds.Add(0);
        //clouds.Add(0);

        //HackerRank hackerRank = new HackerRank();
        //int jumps = hackerRank.jumpingOnClouds(clouds);
        //Console.WriteLine($"Number of jumps is {jumps}");

        //Mollie HackerRank (Task2)
        //Console.WriteLine("Task2 (filter restaurants per 'city' & 'maxCost' params)");
        //Console.WriteLine("--------------------------------------------------------");

        //HashSet<string> listOfRestaurants = GetRelevantFoodOutlets("Houston", 30);
        //foreach (var restaurant in listOfRestaurants)
        //{
        //    Console.WriteLine(restaurant);
        //}

        //IMPORT Csv
        //List<DataInfo> dataInfo = ImportCsvData();

        //SERIALIZE Json
        //string jsonString = ConvertToJson(dataInfo);

        //EXPORT Csv
        //ExportCsvData();

        //DESERIALIZE Json
        //List<DataInfo> dataInfo = DeserializeJson();

        #endregion
    }

    public static void FindNumbers(int[] array1, int[] array2)
    {
        HashSet<int> newArray = new HashSet<int>(array2);

        foreach (int num in array1)
        {
            if (!newArray.Contains(num))
            {
                Console.WriteLine(num);
            }
        }
    }

    public static char MostRepeatedChar(string word)
    {
        Dictionary<char, int> newArray = new Dictionary<char, int>();
        int occurrences = 0;
        char mostRepeated = new char();

        foreach (char letter in word)
        {
            if (newArray.ContainsKey(letter))
            {
                newArray[letter]++;
            }
            else
            {
                newArray[letter] = 1;
            }
        }

        foreach (char letter in word)
        {
            int counter = newArray[letter];

            if (counter > occurrences)
            {
                occurrences = counter;
                mostRepeated = letter;
            }
        }

        return mostRepeated;
    }

    public static string DayOfWeek(int day, int month, int year)
    {
        DateTime dt = new DateTime(year, month, day);

        return dt.DayOfWeek.ToString();
    }

    public static void wordsCounterd(string word)
    {
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        string[] words = new string[] { "TEste", "validation" };
        Dictionary<char, int> dicto = new Dictionary<char, int>() { { 'A', 1 }, { 'B', 2 } };
        StringBuilder sb = new StringBuilder();
        Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();
    }

    #region methods
    public static string MostRepeatedCharacter(string word)
    {
        Dictionary<char, int> countLetters = new Dictionary<char, int>();
        int occurrences = 0;
        char mostRepeatedChar = new char();

        foreach (char letter in word)
        {
            //validar expressão regular

            if (countLetters.ContainsKey(letter))
            {
                countLetters[letter]++;
            }
            else
            {
                countLetters[letter] = 1;
            }
        }

        foreach (char letter in word)
        {
            int counter = countLetters[letter];

            if (counter > occurrences)
            {
                occurrences = counter;
                mostRepeatedChar = letter;
            }
        }

        return mostRepeatedChar.ToString();
    }

    public static string Base64Encode(string word)
    {
        var newWord = System.Text.Encoding.UTF8.GetBytes(word);
        return System.Convert.ToBase64String(newWord);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public static string GetDayOfWeek(int day, int month, int year)
    {
        DateTime date = new DateTime(year, month, day);

        return date.DayOfWeek.ToString();
    }

    public static int[] Fibonacci(int rotations)
    {
        int[] numbers = new int[rotations];

        int a = 0;
        int b = 1;
        int c = 0;

        for (int i = 0; i < rotations; i++)
        {
            c = a + b;

            numbers[i] = c;

            a = b;
            b = c;
        }

        return numbers;
    }

    public static string FibonacciString(int rotations)
    {
        string comment = "Sequence[";

        int a = 0; int b = 1; int c = 0;

        for (int i = 0; i < rotations; i++)
        {
            c = a + b;

            comment = comment + c + ",";

            a = b; b = c;
        }

        comment = comment + "]";

        return comment.Replace(",]", "]");
    }

    public static string FibonacciStringBuilder(int rotations)
    {
        int[] newArray = new int[rotations];
        StringBuilder sb = new StringBuilder();

        int a = 0; int b = 1; int c = 0;
        sb.Append("[");

        for (int i = 0; i < rotations; i++)
        {
            c = a + b;

            newArray[i] = c;
            sb.Append($"{c},");

            a = b;
            b = c;
        }
        sb.Append("]");

        return sb.ToString().Replace(",]", "]");
    }

    public static void LinqExercise()
    {
        List<User> users = new List<User>();

        User user1 = new User("Tiago", 33, "developer", "M");
        users.Add(user1);
        User user2 = new User("Joici", 34, "manager", "F");
        users.Add(user2);
        User user3 = new User("Nicolas", 31, "developer", "M");
        users.Add(user3);
        User user4 = new User("Maria", 35, "tester", "F");
        users.Add(user4);

        var firstTwoUsers = users.Take(2);

        var firstTwoUsersOrdered = users.OrderBy(x => x.Name).Take(2);

        var manAndDeveloper = users.Where(x => x.Gender == "M" && x.Job == "developer");

        var womanUsers = users.Where(x => x.Gender == "F");

        foreach (var user in womanUsers)
        {
            var name = user.Name;
        }

        var userJoici = womanUsers.Where(z => z.Name == "Joici");

        if (userJoici != null)
        {
            Console.WriteLine("Usuária Joici encontrada");
        }
        else
        {
            Console.WriteLine("Usuária Joici NÃO encontrada!");
        }
    }

    //Q0 Write a method to count the number of words(separated by whitespace) in a string. A word is a string of characters containing at least one number or letter.
    public static int WordsCounter(string words)
    {
        int counter = 1;

        foreach (var word in words)
        {
            if (word == ' ')
            {
                counter++;
            }
        }

        return counter;
    }

    //Q4 Reverese the ordering of words in a String
    public static string ReverseString(string word)
    {
        char[] reverseWord = new char[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            char letter = word[i];

            int j = word.Length - i;
            j--;
            reverseWord[j] = letter;
        }

        return new string(reverseWord);
    }

    //Q9 Given an array of ints, write a C# method to total all the values that are even(PARES) numbers
    public static int SumOfEvens(int[] numbers)
    {
        int adder = 0;

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                adder = number + adder;
            }
        }

        return adder;
    }

    public static int[] ReturnEvensUsingLinq(int[] numbers)
    {
        var evenNumbers = numbers.Where(x => x % 2 == 0).Take(3);

        int[] threeFirstNumbers = new int[3];
        int position = 0;

        foreach (int number in evenNumbers)
        {
            int even = number;
            threeFirstNumbers[position] = even;
            position++;
        }

        return threeFirstNumbers;
    }

    //RomanToDecimal
    private static int RomanToDecimal(string roman)
    {
        int result = 0;

        if (roman != null)
        {
            for (int i = 0; i < roman.Length; i++)
            {
                int num1 = ConvertToDecimal(roman[i]);

                if (i + 1 < roman.Length)
                {
                    int num2 = ConvertToDecimal(roman[i + 1]);

                    if (num1 >= num2)
                    {
                        result = result + num1;
                    }
                    else
                    {
                        result = result + (num2 - num1);
                        i++;
                    }
                }
                else
                {
                    result = result + num1;
                }
            }
        }

        return result;
    }

    private static int ConvertToDecimal(char letter)
    {
        switch (letter)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
        }
        return -1;
    }

    public static HashSet<string> GetRelevantFoodOutlets(string city, int maxCost)
    {
        HashSet<string> listOfRestaurants = new HashSet<string>();
        int pageNumber = 1;

        while (pageNumber < 5)
        {
            string url = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page={pageNumber}";

            string responseFromServer;
            try
            {
                WebRequest request = WebRequest.Create(url);

                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseFromServer = reader.ReadToEnd();
                    }
                }

                var data = JObject.Parse(responseFromServer);
                var restaurants = data["data"].ToObject<Restaurant[]>();

                var restaurantsFiltered = restaurants.Where(r => r.City == city && r.Estimated_cost <= maxCost).ToList();

                foreach (var restaurant in restaurantsFiltered)
                {
                    listOfRestaurants.Add(restaurant.Name);
                }

                pageNumber++;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception [{ex.Message}] in EmployeeService > GetRelevantFoodOutlets().", ex);
            }
        }

        return listOfRestaurants;
    }
    #endregion

    #region challenges
    //IMPORT Csv - Inscale 25/03/2024
    public static List<DataInfo> ImportCsvData()
    {
        List<DataInfo> list = new List<DataInfo>();

        using (var reader = new StreamReader(@"C:\Files\dataImport.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(";");

                var dataInfo = new DataInfo();

                dataInfo.OriginalSourceId = values[0];
                dataInfo.TransactionDate = Convert.ToDateTime(values[1]);
                dataInfo.Value = Convert.ToDecimal(values[2]);
                dataInfo.Rate = Convert.ToDecimal(values[3]);

                list.Add(dataInfo);
            }
        }

        return list;
    }

    //EXPORT Csv - Inscale 25/03/2024
    public static void ExportCsvData()
    {
        string fileName = @"C:\Files\dataExport-" + DateTime.Now.ToString("ddMMyyyy-HHmmss") + ".csv";

        DataInfo data = new DataInfo();

        data.OriginalSourceId = "Line11";
        data.TransactionDate = DateTime.Now;
        data.Value = 11000;
        data.Rate = 11000;

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(data.OriginalSourceId + ";" + data.TransactionDate + ";" + data.Value + ";" + data.Rate);
        }
    }

    //SERIALIZE Json
    public static string ConvertToJson(List<DataInfo> dataInfos)
    {
        string jsonString = JsonConvert.SerializeObject(dataInfos);
        Console.WriteLine(jsonString);

        return jsonString;
    }

    //DESERIALIZE Json
    public static List<DataInfo> DeserializeJson()
    {
        string fileName = @"C:\Files\dataImport.json";

        string jsonString;
        using (StreamReader reader = new StreamReader(fileName))
        {
            jsonString = reader.ReadToEnd();
        };

        var dataInfos = JsonConvert.DeserializeObject<List<DataInfo>>(jsonString);
        return dataInfos;
    }

    //Ardanis - 03/2024
    //Have the function DifferentCases(str) take the str parameter being passed and return it in upper camel case format where the first letter of each word is capitalized.
    //The string will only contain letters and some combination of delimiter punctuation characters separating each word.
    //For example: if str is "Daniel LikeS-coding" then your program should return the string 'DanielLikesCoding'.
    //For example: if str is "hAve A#goOd--cHAllengE*" then your program should return the string 'HaveAGoodChallenge'.
    private static string DifferentCases(string str)
    {
        // Usaremos StringBuilder para construir a string final
        StringBuilder result = new StringBuilder();
        bool capitalizeNext = true;

        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                if (capitalizeNext)
                {
                    result.Append(char.ToUpper(c));
                    capitalizeNext = false;  // Depois de capitalizar, volta ao estado normal
                }
                else
                {
                    result.Append(char.ToLower(c));
                }
            }
            else
            {
                // Encontramos um delimitador, então a próxima letra deve ser capitalizada
                capitalizeNext = true;
            }
        }

        return result.ToString();
    }

    //Ardanis - 08/2024
    //Have the function NonrepeatingCharacter(str) take the str parameter being passed, which will contain only alphabetic characters and spaces, and return the first
    //non-repeating character. For example: if str is "agettkgaeee" then your program should return "k". The string will always contain at least one character and there will always be at least one on-repeating character.
    //For example "abcdef" - Output is "a"
    //For example "hello world hi hey" - Output is "w"
    private static string NonrepeatingCharacter(string str)
    {
        // Dicionário para armazenar a contagem de cada caractere
        Dictionary<char, int> countLetters = new Dictionary<char, int>();

        // Contar as ocorrências de cada caractere na string
        foreach (char c in str)
        {
            if (countLetters.ContainsKey(c))
            {
                countLetters[c]++;
            }
            else
            {
                countLetters[c] = 1;
            }
        }

        // Encontrar o primeiro caractere com contagem 1
        foreach (char r in str)
        {
            if (countLetters[r] == 1)
            {
                return r.ToString();
            }
        }

        // Retorna um caractere padrão se nenhum caractere não repetido for encontrado (não ocorrerá conforme o enunciado)
        return "";
    }

    //Ardanis - 08/2024
    //Have the function MinWindowSubstring(strArr) take the array of strings stored in strArr, which will contain only two strings,
    //the first parameter being the string N and the second parameter being a string K of some characters, and your goal is to determine the smallest substring of N that contains all the characters in K.
    //For example: if strArr is ["aaabaaddae", "aed"] then the smallest substring of N that contains the characters a, e, and d is "dae" located at the end of the string.
    //So for this example your program should return the string "dae".

    //Another example: if strArr is ["aabdccdbcacd", "aad"] then the smallest substring of N that contains all of the characters in K is "aabd" which is located at the beginning of the string.
    //Both parameters will be strings ranging in length from 1 to 50 characters and all of K's characters will exist somewhere in the string N. Both strings will only contain lowercase alphabetic characters.

    //For example "new string[] {"ahffaksfajeeubsne", "jefaa"}" - Output is "aksfaje"
    //For example "new string[] {"aaffhkksemckelloe", "fhea"}"  - Output is "affhkkse"

    private static string MinWindowSubstring(string[] strArr)
    {
        string nArray = strArr[0];
        string kArray = strArr[1];

        Dictionary<char, int> validatedChars = new Dictionary<char, int>();

        foreach (char c in kArray)
        {
            if (validatedChars.ContainsKey(c))
            {
                validatedChars[c]++;
            }
            else
            {
                validatedChars[c] = 1;
            }
        }

        int leftChar = 0;
        int rightChar = 0;
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        int required = kArray.Length;
        int minimumSize = int.MaxValue;
        int minimumLeft = int.MaxValue;

        while (rightChar < nArray.Length)
        {
            char c = nArray[rightChar];

            if (validatedChars.ContainsKey(c))
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }

                if (charCounts[c] <= validatedChars[c])
                {
                    required--;
                }
            }

            while (required == 0)
            {
                if (rightChar - leftChar + 1 < minimumSize)
                {
                    minimumSize = rightChar - leftChar + 1;
                    minimumLeft = leftChar;
                }

                char beginChar = nArray[leftChar];

                if (validatedChars.ContainsKey(beginChar))
                {
                    charCounts[beginChar]--;

                    if (charCounts[beginChar] < validatedChars[beginChar])
                        required++;
                }
                leftChar++;
            }

            rightChar++;
        }

        return minimumSize == int.MaxValue ? "" : nArray.Substring(minimumLeft, minimumSize);
    }

    //Kaizen - 29/08/2024
    public static int LuckyNumber(int[] number)
    {
        Dictionary<int, int> array = new Dictionary<int, int>();
        int lucky = -1;

        foreach (int num in number)
        {
            if (array.ContainsKey(num))
            {
                array[num]++;
            }
            else
            {
                array[num] = 1;
            }
        }

        foreach (int num in number)
        {
            int counter = array[num];

            if (counter == num && num > lucky)
            {
                lucky = num;
            }
        }

        return lucky;
    }

    //Forte Group - 30/08/2024
    public static void FindNonRepeatedNumbers(int[] array1, int[] array2)
    {
        HashSet<int> newArray = new HashSet<int>(array2);

        foreach (int num in array1)
        {
            if (!newArray.Contains(num))
            {
                Console.WriteLine(num);
            }
        }
    }

    //XM - 04/09/2024
    public static async Task PrintNumbersAsync()
    {
        //private static async Task Main(string[] args)
        //{
        //    Console.Write("1");
        //    var task = PrintNumbersAsync();
        //    Console.Write("2");
        //    await task;
        //}

        Console.Write("3");
        await Task.Delay(10);
        Console.Write("4");
        await Task.Delay(10);
        Console.Write("5");
        await Task.Delay(10);
    }

    //Maersk - 18/09/2024 (validar o problema que está travando o processamento e como resolve-lo)

    // You are developing a multi-threaded C# application intended to perform large-scale data processing tasks.
    // The application utilizes the Task Parallel Library (TPL) for concurrency. However, you've encountered an intermittent issue where the application sometimes hangs indefinitely.

    // The application processes a large set of data items. Each item is processed by a task created using `Task.Factory.StartNew()`.
    // After processing, results are aggregated. Occasionally, the application does not complete the processing phase, appearing to hang without any exception or error message.

    public class DataProcessor
    {
        private List<DataItem> _dataItems;
        private ConcurrentBag<Result> _results;

        public DataProcessor(List<DataItem> dataItems)
        {
            _dataItems = dataItems;
            _results = new ConcurrentBag<Result>();
        }

        public void ProcessData()
        {
            List<Task> tasks = new List<Task>();

            foreach (var item in _dataItems)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var result = ProcessItem(item);
                    _results.Add(result);
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            AggregateResults();
        }

        private Result ProcessItem(DataItem item)
        {
            // Processing logic...
            return null;
        }

        private void AggregateResults()
        {
            // Aggregation logic...
        }
    }

    public class DataItem { /* ... */ }
    public class Result { /* ... */ }

    #endregion
}