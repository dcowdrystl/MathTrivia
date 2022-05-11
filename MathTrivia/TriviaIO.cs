using System;
using System.Collections.Generic;
using System.Text;

namespace MathTrivia
{
	class TriviaIO
	{
		public void Start()
		{

			int userInput = 0;

			Console.WriteLine("Welcome to Trivia!");
			Console.WriteLine("Now, what's your name?");
			string name = Console.ReadLine();
			Logic logic = new Logic(new Player(name));
			Console.WriteLine("Hello " + name);
			logic.ReadFile();

			do
			{
				userInput = Menu();
				switch (userInput)
				{
					case 1:
						Console.WriteLine("Case 1: You have chosen addition quiz!");
						logic.Play(userInput);
						break;
					case 2:
						Console.WriteLine("Case 2: You have chosen subtraction quiz!");
						logic.Play(userInput);
						break;
					case 3:
						Console.WriteLine("Case 3: Mixed quiz!");
						logic.Play(userInput);
						break;
					case 4:
						Console.WriteLine("Case 4: You have chosen multipication quiz!");
						logic.Play(userInput);
						break;
					case 5:
						Console.WriteLine("This is " + name + " scoreboard:");
						logic.PrintPlayerScores();
						break;
					case 6:
						logic.PrintAllScores();
						break;
					case 7:
						Console.WriteLine("Bye, bye " + name);
						Console.ReadKey();
						logic.WriteFile();
						break;
					default:
						Console.WriteLine("Please enter a correct choice");
						break;
				}
			} while (userInput != 7);
		}

		public int Menu()
		{
			Console.WriteLine("1. Addition");
			Console.WriteLine("2. Subtraction");
			Console.WriteLine("3. Mixed");
			Console.WriteLine("4. Multipication");
			Console.WriteLine("5. Check your score");
			Console.WriteLine("6. Check all scores");
			Console.WriteLine("7. Exit");
			var result = Console.ReadLine();
			return Convert.ToInt32(result);
		}
	}
}

