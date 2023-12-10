using System;

public class Program
{
	public static void Main()
	{
		Patient p1 = new Patient();

		//getting needed infos
		Console.WriteLine($"Welcome to {MedicalBot.GetBotName()}, your personal Medical Bot\n");

		Console.Write("Please enter the patient name: ");
		while (!p1.SetName(Console.ReadLine(), out string nameErrorMessage))
		{
			Console.WriteLine(nameErrorMessage);
			Console.Write("Please enter the patient name: ");
		}

		Console.Write("Please enter the patient age: ");
		while (!p1.SetAge(Console.ReadLine(), out string errorMessage))
		{
			Console.WriteLine(errorMessage);
			Console.Write("Please enter the patient age: ");
		}

		Console.Write("Please enter the patient gender: ");
		while (!p1.SetGender(Console.ReadLine(), out string genderErrorMessage))
		{
			Console.WriteLine(genderErrorMessage);
			Console.Write("Please enter the patient gender: ");
		}

		Console.Write("Please enter the patient medical history: ");
		p1.SetMedicalHistory(Console.ReadLine());

		MedicalBot.SymptomList();
		Console.Write("\nPlease enter the patient symptom code: ");
		while (!p1.SetSymptomCode(Console.ReadLine().ToUpper(), out string sympErrorMessage))
		{
			Console.WriteLine(sympErrorMessage);
			Console.Write("\nPlease enter the patient symptom code: ");
		}

		MedicalBot.PrescribeMedication(p1);

		Console.WriteLine("Thanks for using Medical Bob, bye!");
		Console.ReadKey();
	}
}