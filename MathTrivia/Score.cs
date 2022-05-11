using System;
using System.Collections.Generic;
using System.Text;

namespace MathTrivia
{
	class Score
	{

		public Score(int correct, String type, String name, String date)
		{
			Correct = correct;
			Type = type;
			Name = name;
			TimeStamp = date;

		}

		public int Correct { get; private set; }
		public String Type { get; private set; }
		public string Name { get; set; }
		public string TimeStamp { get; set; }
	}
}
