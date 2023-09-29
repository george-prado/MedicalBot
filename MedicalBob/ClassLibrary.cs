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
    public bool SetName(string name, out string errorMessage)
    {
        bool isValid;
        errorMessage = "";

        if (name == null || name.Length == 0)
        {
            isValid = false;
            errorMessage = "The patient name cannot be blank or invalid";
            return isValid;
        }
        else if (name.Length < 2)
        {
            isValid = false;
            errorMessage = "Patient name should contain at least two or more characters";
            return isValid;
        } else
        {
            isValid = true;
            foreach (char c in name) 
            { 
            if (!char.IsLetter(c))
                {
                    isValid = false;
                    errorMessage = "Patient name must contain only letters";
                    break;
                }
            }

        }
        
        this.name = name;
        return isValid;
    }
    public bool SetAge(int age, out string errorMessage)
    {
        bool isValid;
        errorMessage = "";

        if (age < 0)
        {
            isValid = false;
            errorMessage = "Age can't be negative";
            return isValid;
        }
        else if (age > 100)
        {
            isValid = false;
            errorMessage = "Age cannot be higher than 100";
            return isValid;
        }

        isValid = true;

        this.age = age;
        return isValid;
    }
    public bool SetGender(string gender, out string errorMessage)
    {
        bool isValid;
        errorMessage = null;
        if (string.IsNullOrEmpty(gender) || (gender.ToLower() != "male" && gender != "female" && gender != "Male" && gender != "Female"))
        {
            isValid = false;
            errorMessage = "Please enter a valid gender";
            return isValid;
        }
        isValid = true;
      
        this.gender = gender;
        return isValid;
    }
    public void SetMedicalHistory(string medicalHistory)
    {
        this.medicalHistory = medicalHistory;
    }
    public bool SetSymptonCode(string symptonCode, out string errorMessage)
    {
        bool isValid;
        errorMessage = null;
        if (symptonCode != "S1" && symptonCode != "S2" && symptonCode != "S3" && symptonCode != "s1" && symptonCode != "s2" && symptonCode != "s3")
        {
            isValid = false;
            errorMessage = "Please input a valid sympton code";
            return isValid;
        }
        isValid = true;
      
        this.symptonCode = symptonCode;
        return isValid;
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
        string sympton;
        switch (symptonCode?.ToLower())
        {
            case "s1": sympton = "Headache"; break;
            case "s2": sympton = "Skin rashes"; break;
            case "s3": sympton = "Dizziness"; break;
            default: sympton = "Unknown"; break;
        }
        return sympton;
    }
    public string GetPrescription()
    {
        return prescription;
    }
}

public class MedicalBot
{
    //field && encapsulating
    private const string BotName = "Bob";
    public static string GetBotName()
    {
        return BotName;
    }

    //Prescribe method - used for: determine the medication based on patient symptoms
    public void PrescribeMedication(Patient patient)
    {
        string medicationName = "";
        if (patient.GetSymptonCode() == "Headache")
        {
            medicationName = "Ibuprofen";
        }
        else if (patient.GetSymptonCode() == "Skin rashes")
        {
            medicationName = "Diphenhydramine";
        }
        else if (patient.GetSymptonCode() == "Dizziness")
        {
            if (patient.GetMedicalHistory().ToLower() == "diabetes")
            {
                medicationName = "Metformin";
            }
            else
            {
                medicationName = "Dimenhydrinate";
            }
        }

        string prescription = $"Based on your symptons and medical history, I prescribe you {medicationName} {GetDosage(medicationName)}";
        patient.SetPrescription(prescription);


        //local function - used for: defining the dose based on the medication name
        string GetDosage(string medicationName)
        {

            if (medicationName == "Ibuprofen")
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
            else if (medicationName == "Diphenhydramine")
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
            else if (medicationName == "Dimenhydrinate")
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