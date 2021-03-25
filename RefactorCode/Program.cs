using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorCode
{
	class Program
	{
		static void Main()
		{
			int counter = 0;
			StringBuilder output = new StringBuilder();
			string line1="";
			string line2="";
			string line3;

			// Read the file and display it line by line.  
			System.IO.StreamReader file = new System.IO.StreamReader(@"c:\БАРС\code.txt");

			while ((line3 = file.ReadLine()) != null)
			{
				if (counter == 0)
				{
					output.AppendLine(line3);
				}


				line3 = line3.Trim(' ');
				line3 = line3.Trim('	');
				output.AppendLine(Refactor(line1, line2, line3));

				line1 = line2;
				line2 = line3;

				counter++;
			}

			file.Close();

			using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(@"C:\БАРС\refactoredCode.cs"))
			{
				outputFile.WriteLine(output.ToString()); 
			}

			Console.WriteLine("There were {0} lines.", counter);
			// Suspend the screen.  
			Console.ReadLine();
		}

		private static string Refactor(string line1, string line2, string line3)
		{
			string outputString = line2;

			outputString = outputString.Trim(' ');
			outputString = outputString.Trim('	');

			if (outputString.Contains("ОписаниеОшибкиПроверкиУвязки описаниеОшибки"))
			{
				outputString = "ОписаниеОшибкиПроверкиУвязки описаниеОшибки = new ОписаниеОшибкиПроверкиУвязки(null)\n{";

				return outputString;
			}

			if (outputString.Contains("описаниеОшибки."))
			{
				outputString = outputString.Remove(outputString.IndexOf("описаниеОшибки."), "описаниеОшибки.".Length);						
			}

			if (line2.Contains("описаниеОшибки.") || line1.Contains("ОписаниеОшибкиПроверкиУвязки описаниеОшибки") || line1.StartsWith("описаниеОшибки") || line3.StartsWith("описаниеОшибки"))
			{
				outputString = outputString.Replace(';', ',');	
			}

			if (outputString.Contains("ТипОшибкиПроверки"))
			{
				outputString += "\n};";
			}

			return outputString;
		}
	}
}
