﻿using Challenges;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Type something:");
        string someString = Console.ReadLine();

        //Q0-WordsCounter
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
        LinqExercise();
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

        if(userJoici != null)
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
            if(number %2 == 0)
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
}