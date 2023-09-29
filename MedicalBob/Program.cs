using System;
using System.Security.Cryptography;

public class Program
{
    static void Main()
    {

        //Welcoming the new patient
        Console.WriteLine($"Hello, I'm {MedicalBot.GetBotName()},\nI'm here to help you in your medication.");
        Console.WriteLine("First, let's proceed with the clinical anamnesis.");

        //Creating new patient 
        Patient patient;
        patient = new Patient();

        //Read and validate patient fields
        Console.Write("\nLet's get started. Please enter the patient name: ");
        while (!patient.SetName(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter patient name: ");
        }

        Console.Write("Please enter patient age: ");
        while (!patient.SetAge(int.Parse(Console.ReadLine()), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Please enter patient age: ");
        }

        Console.Write("Please enter your gender (e.g. Male/Female): ");
        while (!patient.SetGender(Console.ReadLine(), out string errorMessage))
            {
            Console.WriteLine(errorMessage);
            Console.Write("Please enter your gender: ");
        }
       
        Console.WriteLine("Please enter your medical history (e.g. Diabetes). Press enter for none: ");
        patient.SetMedicalHistory(Console.ReadLine());


        //Next stage of diagnosis - symptons
        Console.WriteLine($"\n\n\nWelcome, {patient.GetName()}, {patient.GetAge()}.");
        Console.WriteLine("Which of the following symptons do you have:\nS1. Headache\nS2. Skin rashes\nS3. " +
            "Dizziness\n\nEnter the sympton " + "code from the above list (S1, S2 or S3): ");
        
        while (!patient.SetSymptonCode(Console.ReadLine(), out string errorMessage)){
            Console.WriteLine(errorMessage);
            Console.Write("Please choose again your sympton code: ");
        }


        //Next stage - calling MedicalBot + creating prescription
        MedicalBot medicalbot = new MedicalBot();
        medicalbot.PrescribeMedication(patient);

        string prescription = patient.GetPrescription();

        //Printing prescription
        Console.WriteLine("\n\n");
        Console.WriteLine(prescription);

        //Goodbye message
        Console.WriteLine("\n\nThanks for coming.");
        Console.ReadKey();
    }
}