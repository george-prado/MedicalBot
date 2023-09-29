using System;
using System.Security.Cryptography;

public class Program
{
    static void Main()
    {
        Patient p1;
        p1 = new Patient();

        Console.WriteLine("Hi, I'm here to help you in your medication.");
        
        Console.WriteLine("\nLet's get started. Please enter your name: ");
        string tempName = Console.ReadLine();

        Console.WriteLine("Please enter your age: ");
        int tempAge;
        string userAgeInput;
        do
        {
            userAgeInput = Console.ReadLine();
            if (!int.TryParse(userAgeInput, out tempAge))
            {
                Console.WriteLine("Invalid age input. Age must be a valid number.");
            }
        } while (!int.TryParse(userAgeInput, out tempAge));


        Console.WriteLine("Please enter your gender (e.g. Male/Female): ");
        string tempGender = Console.ReadLine();
       
        Console.WriteLine("Please enter your medical history (e.g. Diabetes). Press enter for none: ");
        string tempMedicalHistory = Console.ReadLine();


        p1.SetName(tempName, out string isNameValid);
        p1.SetAge(tempAge, out string isAgeValid);
        p1.SetGender(tempGender, out string isGenderValid);
        p1.SetMedicalHistory(tempMedicalHistory);



        Console.WriteLine($"\n\n\nWelcome, {p1.GetName()}, {p1.GetAge()}.");
        Console.WriteLine("Which of the following symptons do you have:\nS1. Headache\nS2. Skin rashes\nS3. Dizziness\n\nEnter the sympton " +
            "code from the above list (S1, S2 or S3): ");
        string tempSympton = Console.ReadLine();

        p1.SetSymptonCode(tempSympton, out string isCodeValid);

        MedicalBot medicalbot = new MedicalBot();

        medicalbot.PrescribeMedication(p1);

        string prescription = p1.GetPrescription();

        Console.WriteLine("\n\n");
        Console.WriteLine(prescription);

        Console.WriteLine("\n\nThanks for coming.");
        Console.ReadKey();
    }
}