using System;

public class Patient
{
    //Patient fields
    private string name;
    private int age;
    private string gender;
    private string medicalHistory;
    private string symptonCode;
    private string prescription;



    //set methods
    public void SetName(string name, out string errorMessage)
    {
        errorMessage = null;

        if (name == null || name == "")
        {
            errorMessage = "The patient name cannot be null or empty";
        }
        else
        {
            this.name = name;
        }
        
    }
    public void SetAge(int age, out string errorMessage)
    {
        errorMessage = null;
        if (age < 0)
        {
            errorMessage = "Please entry a valid age number";
        }
        else
        {
            this.age = age;
        }
    }
    public void SetGender(string gender, out string errorMessage)
    {
        errorMessage = null;
        if (gender == null || (gender != "male" && gender != "female"))
        {
            errorMessage = "Please enter a valid gender";
        }
        else
        {
            this.gender = gender;
        }
    }
    public void SetMedicalHistory(string medicalHistory)
    {
        this.medicalHistory = medicalHistory;
    }
    public void SetSymptonCode(string symptonCode, out string errorMessage)
    {
        errorMessage = null;
        if (symptonCode == null)
        {
            errorMessage = "Please input a valid sympton code";
        }
        else
        {
            this.symptonCode = symptonCode;
        }
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
    public string GetSymptonCode()
    {
        switch (symptonCode?.ToLower())
        {
            case "s1":
                return "Headache";
            case "s2":
                return "Skin rashes";
            case "s3":
                return "Dizziness";
            default:
                return "Unknown";
        }
    }
    public string GetPrescription()
    {
        return prescription;
    }



}

public class MedicalBot
{
    //MedicalBot fields
    private const string BotName = "Bob";



    //get methods
    public static string GetName()
    {
        return BotName;
    }



    //determine the medication based on patient symptoms
    public void PrescribeMedication(Patient patient)
    {
        string medicationName = "";
        if (patient.GetSymptonCode() == "headache")
        {
            medicationName = "ibuprofen";
        }
        else if (patient.GetSymptonCode() == "skin rashes")
        {
            medicationName = "diphenhydramine";
        }
        else if (patient.GetSymptonCode() == "dizzness")
        {
            if (patient.GetMedicalHistory() == "diabetes")
            {
                medicationName = "metformin";
            }
            else
            {
                medicationName = "dimenhydrinate";
            }
        }

        Console.WriteLine($"Based on your symptons and medical history, I prescribe you {medicationName} {GetDosage(medicationName)}");


        string GetDosage(string medicationName)
        {

            if (medicationName == "ibuprofen")
            {
                if (patient.GetAge() < 18)
                {
                    return "400mg";
                }
                else
                {
                    return "800mg";
                }
            }
            else if (medicationName == "diphenhydramine")
            {
                if (patient.GetAge() < 18)
                {
                    return "50mg";
                }
                else
                {
                    return "300mg";
                }
            }
            else if (medicationName == "dimenhydrinate")
            {
                if (patient.GetAge() < 18)
                {
                    return "50mg";
                }
                else
                {
                    return "400mg";
                }
            }
            else
            {
                return "500mg";
            }
        }
    }






}