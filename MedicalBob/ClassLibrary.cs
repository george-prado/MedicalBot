using System;

public class MedicalBot
{
	public const string botName = "Bob";

	public static string GetBotName()
	{
		return botName;
	}
	public static void SymptomList()
	{
		Console.WriteLine("\nS1 - Headache");
		Console.WriteLine("S2 - Skin rashes");
		Console.WriteLine("S3 - Dizziness");
	}

	public static void PrescribeMedication(Patient patient)
	{
		string prescription = "";
		if (patient.GetSymptoms() == "Headache")
		{
			prescription = "Ibuprofen";
			Console.WriteLine($"Based on your symptoms, the prescription is {prescription} " + GetDosage(prescription.ToLower()));
		}
		else if (patient.GetSymptoms() == "Skin rashes")
		{
			prescription = "Diphenhydramine";
			Console.WriteLine($"Based on your symptoms, the prescription is {prescription} " + GetDosage(prescription.ToLower()));
		}
		else if (patient.GetSymptoms() == "Dizziness")
		{
			if (patient.GetMedicalHistory() == "diabetes")
			{
				prescription = "Metformin";
				Console.WriteLine($"Based on your symptoms, the prescription is {prescription} " + GetDosage(prescription.ToLower()));
			}
			else
			{
				prescription = "Dimenhydrinate";
				Console.WriteLine($"Based on your symptoms, the prescription is {prescription} " + GetDosage(prescription.ToLower()));
			}
		}

		string GetDosage(string medicineName)
		{
			string dosage = "";
			if (medicineName == "ibuprofen")
			{
				if (patient.GetAge() < 18)
				{
					dosage = "400mg";
					return dosage;
				}
				else
				{
					dosage = "800mg";
					return dosage;
				}
			}
			else if (medicineName == "diphenhydramine")
			{
				if (patient.GetAge() < 18)
				{
					dosage = "50mg";
					return dosage;
				}
				else
				{
					dosage = "300mg";
					return dosage;
				}
			}
			else if (medicineName == "dimenhydrinate")
			{
				if (patient.GetAge() < 18)
				{
					dosage = "50mg";
					return dosage;
				}
				else
				{
					dosage = "400mg";
					return dosage;
				}
			}
			else if (medicineName == "metformin")
			{
				dosage = "500mg";
				return dosage;
			}
			else
			{
				return null;
			}
		}
	}
}

public class Patient
{
	private string name;
	private int age;
	public string gender;
	private string medicalHistory;
	private string symptomCode;
	private string prescription;


	//set methods
	public bool SetName(string name, out string nameErrorMessage)
	{
		nameErrorMessage = null;
		bool validName = true;

		if (name == "" || name.Length < 2)
		{
			nameErrorMessage = "You must enter a valid name";
			validName = false;
			return validName;
		}

		this.name = name;
		return validName;
	}
	public bool SetAge(string age, out string errorMessage)
	{
		errorMessage = null;
		bool validAge = int.TryParse(age, out int _age);
		if (!validAge)
		{
			errorMessage = "Please enter a valid age (numbers only)";
			return false;
		}
		if (_age < 0 || _age > 100)
		{
			errorMessage = "Please enter a valid age (0~99 years old)";
			return false;
		}
		this.age = _age;
		return true;
	}
	public bool SetGender(string gender, out string genderErrorMessage)
	{
		genderErrorMessage = null;


		if (gender.ToLower() != "male" && gender.ToLower() != "female" && gender.ToLower() != "other")
		{
			genderErrorMessage = "You must input a valid gender (male/female/other)";
			return false;
		}

		this.gender = gender;
		return true;
	}
	public void SetMedicalHistory(string medicalHistory)
	{
		this.medicalHistory = medicalHistory;
	}
	public bool SetSymptomCode(string symptomCode, out string sympErrorMessage)
	{
		sympErrorMessage = null;

		if (symptomCode != "S1" && symptomCode != "S2" && symptomCode != "S3")
		{
			sympErrorMessage = "You must enter a valid symptom code";
			return false;
		}
		this.symptomCode = symptomCode;
		return true;
	}
	public void SetPrescription(string prescription)
	{
		this.prescription = prescription;
	}

	//get methods
	public string GetName()
	{
		return name;
	}
	public int GetAge()
	{
		return age;
	}
	public string GetGender()
	{
		return gender;
	}
	public string GetMedicalHistory()
	{
		return medicalHistory;
	}
	public string GetSymptoms()
	{
		string symptoms = "";
		switch (symptomCode)
		{
			case ("S1"): symptoms = "Headache"; break;
			case ("S2"): symptoms = "Skin rashes"; break;
			case ("S3"): symptoms = "Dizziness"; break;
			default: symptoms = "Unknown"; break;
		}
		return symptoms;
	}
}