﻿namespace DocSeeker.API.DocSeeker.Domain.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public Patient CPatient { get; set; }


        public string DateIssue { get; set; }

        public string DateExpiration { get; set; }

       
        public string MedicalSpeciality{ get; set; }

        public string RecipCode { get; set; }

        public string Condition { get; set; }

        public string Rest { get; set; }

        public string Drink { get; set; }

        public string Food { get; set; }

        public int NumberDose { get; set; }
        public string Medicines { get; set; }
        public string Meals { get; set; } 
        public string Hours { get; set; }


    }
}
