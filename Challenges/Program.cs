using Challenges;
using Newtonsoft.Json.Linq;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        #region tests
        //Console.WriteLine("Type something:");
        //string listOfWords = Console.ReadLine();

        //Q0 - WordsCounter
        //int numberOfWords = WordsCounter(listOfWords);
        //Console.WriteLine($"Number of words is {numberOfWords}");
        //Console.ReadKey();

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
        #endregion

        Console.WriteLine("Task2 (filter restaurants per 'city' & 'maxCost' params)");
        Console.WriteLine("--------------------------------------------------------");

        HashSet<string> listOfRestaurants = GetRelevantFoodOutlets("Houston", 30);
        foreach (var restaurant in listOfRestaurants)
        {
            Console.WriteLine(restaurant);
        }
    }

    #region methods
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
    #endregion

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
}