using System;
using System.Collections.Generic;

namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>

		public static int Evaluate(string expression)
		{
			if (expression == null || expression == "")
				throw new Exception(message: "Argument shouldn't be null or empty");

			Dictionary<char, int> letters = new Dictionary<char, int>(7);
			letters.Add('M', 1000);
			letters.Add('D', 500);
			letters.Add('C', 100);
			letters.Add('L', 50);
			letters.Add('X', 10);
			letters.Add('V', 5);
			letters.Add('I', 1);

			string operators = "+-*";

			bool IsBadValue;
			foreach (char c in expression)
            {
				IsBadValue = true;
				foreach(var keys in letters)
                {
					if (c == keys.Key)
						IsBadValue = false;
                }
				foreach(var o in operators)
                {
					if (c == o)
						IsBadValue = false;
                }
				if (IsBadValue == true)
					throw new Exception(message: "Should contain only whitespaces, allowed operators: '+', '-', '*' and letters: M = 1000, D = 500, C = 100, L = 50, X = 10, V = 5, I = 1 \n and \nNo parentheses, punctuation mark or decimal digits");
            }
			

			int result = 0;


			List<int> operands = new List<int>();
			int tmp = 1;
			
			string word = "";

			bool IsMultiplying = false;

			for (int j = 0; j<expression.Length;j++)
            {
				if (operators.Contains($"{expression[j]}"))
				{
					#region ConvertingFromRoman
					int sum = 0;

					List<int> numbers = new List<int>(word.Length);
					foreach (char c in word)
					{
						foreach (KeyValuePair<char, int> keyValue in letters)
							if (c == keyValue.Key)
								numbers.Add(keyValue.Value);
					}

					bool breaker = false;
					try
					{
						for (int i = 0; i < numbers.Count - 1; i++)
						{
							if (numbers[i] < numbers[i + 1])
							{
								if (numbers[i + 1] / numbers[i] == 5 || numbers[i + 1] / numbers[i] == 10)
									sum -= numbers[i];
								else
									throw new ArithmeticException();
								if (breaker == true)
									throw new ArithmeticException();
								else if (i != 0)
									if (numbers[i - 1] <= numbers[i])
										throw new ArithmeticException();
								breaker = true;
							}
							else
							{
								sum += numbers[i];
								breaker = false;
							}
						}
						sum += numbers[numbers.Count - 1];
					}
					catch (Exception e)
					{
						System.Console.WriteLine(e.Message);
						return 0;
					}

					#endregion


					if (IsMultiplying == true)
					{
						operands[operands.Count - 1] *= sum;
						IsMultiplying = false;
					}
					else
					{
						operands.Add(sum * tmp);

						if (expression[j] == '+')
							tmp = 1;
						else if (expression[j] == '-')
							tmp = -1;
						else if (expression[j] == '*')
							IsMultiplying = true;
					}

					word = "";
				}
				else if (j == expression.Length - 1)
				{
					word += expression[j];

					#region ConvertingFromRoman
					int sum = 0;

					List<int> numbers = new List<int>(word.Length);
					foreach (char c in word)
					{
						foreach (KeyValuePair<char, int> keyValue in letters)
							if (c == keyValue.Key)
								numbers.Add(keyValue.Value);
					}

					bool breaker = false;
					try
					{
						for (int i = 0; i < numbers.Count - 1; i++)
						{
							if (numbers[i] < numbers[i + 1])
							{
								if (numbers[i + 1] / numbers[i] == 5 || numbers[i + 1] / numbers[i] == 10)
									sum -= numbers[i];
								else
									throw new ArithmeticException();
								if (breaker == true)
									throw new ArithmeticException();
								else if (i != 0)
									if (numbers[i - 1] <= numbers[i])
										throw new ArithmeticException();
								breaker = true;
							}
							else
							{
								sum += numbers[i];
								breaker = false;
							}
						}
						sum += numbers[numbers.Count - 1];
					}
					catch (Exception e)
					{
						System.Console.WriteLine(e.Message);
						return 0;
					}

					#endregion
					if (IsMultiplying == true)
					{
						operands[operands.Count - 1] *= sum;
						IsMultiplying = false;
					}
					else
					{
						operands.Add(sum * tmp);
					}
				}
				else
					word += expression[j];
            }

			foreach (int i in operands)
            {
				result += i;
            }

			return result;
		}

		
	}
}
