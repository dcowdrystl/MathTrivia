using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathTrivia
{
	class Logic
	{
		public Logic(Player player)
		{
			Player = player;
		}
		public Player Player { get; private set; }
		public const int MAX_NUM = 100;
		public const int MIN_NUM = 1;
		public const int BASE = 100;
		public static int quizLength = 3;
		static Boolean success = false;
		//The List to write to when reading the file
		List<Score> listOfScores = new List<Score>();

		public void Play(int type)
		{
			int i = 0;
			int result = 0;
			while (i < quizLength)
			{
				success = GenerateQuestion(type);
				i++;
				if (success) { result++; }
			}
			AddToScore(result, type);
		}

		public int GenerateRandom(int min, int max)
		{

			Random random = new Random();
			int rand_number = random.Next(min, max);
			return rand_number;

		}

		private Boolean GenerateQuestion(int type)
		{
			int number1 = GenerateRandom(MIN_NUM, MAX_NUM + 1);
			int number2 = GenerateRandom(MIN_NUM, MAX_NUM + 1);
			Boolean success = false;
			const int MAX_TYPE = 2;
			int correct = 0;
			string question = "";
			if (type == 3)
			{
				type = GenerateRandom(MIN_NUM, MAX_TYPE + 1);
			}
			if (type == 1)
			{
				question = "What is " + number1 + " + " + number2 + " ?";
				correct = number1 + number2;
			}
			if (type == 2)
			{
				question = "What is " + number1 + " - " + number2 + " ?";
				correct = number1 - number2;
			}
			Console.WriteLine(question);

			string answerInput = Console.ReadLine();
			int answer = Convert.ToInt32(answerInput);

			if (answer == correct)
			{
				Console.WriteLine("Well done!");
				success = true;
			}
			else { Console.WriteLine("Sorry, better luck next time!"); }
			return success;
		}

		private void AddToScore(int result, int type)
		{
			DateTime dateTime = DateTime.Now;
			string timeStamp = String.Format("{0:g}", dateTime);
			string stringType = "";
			if (type == 1)
			{
				stringType = "Addition";
			}
			else if (type == 2) { stringType = "Subtraction"; }
			else { stringType = "Mixed"; }
			Score score = new Score(result, stringType, Player.Name, timeStamp);
			listOfScores.Add(score);
		}
		public void PrintAllScores()
		{
			foreach (Score score in listOfScores)
			{
				Console.WriteLine("Name: " + score.Name + " " + MakeStringScore(score));
			}
		}

		public void PrintPlayerScores()
		{
			Boolean playerFound = false;
			foreach (Score score in listOfScores)
			{
				if (score.Name.Equals(Player.Name))
				{
					playerFound = true;
					Console.WriteLine(MakeStringScore(score));
				}
			}
			if (!playerFound) { Console.WriteLine("Player " + Player.Name + " was not found"); }
		}

		private string MakeStringScore(Score score)
		{
			double percent = ((double)score.Correct / (double)quizLength) * BASE;
			int percentInt = Convert.ToInt32(percent);
			string makeString = "Score: " + percentInt + " % " + "Type: " + score.Type + " Time: " + score.TimeStamp;
			return makeString;
		}

		// There is Object Stream Reader?
		public void ReadFile()
		{
			using (StreamReader reader = new StreamReader("previous_scores.txt"))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					// Do something with the line.
					string[] parts = line.Split(';');
					int correct = Convert.ToInt32(parts[0]);
					listOfScores.Add(new Score(correct, parts[1], parts[2], parts[3]));
				}
			}
		}

		public void WriteFile()
		{
			using (var writer = new StreamWriter("previous_scores.txt"))
			{
				foreach (Score score in listOfScores)
				{
					writer.WriteLine(score.Correct + ";" + score.Type + ";" + score.Name + ";" + score.TimeStamp + ";");
				}
			}
		}

	}
}

