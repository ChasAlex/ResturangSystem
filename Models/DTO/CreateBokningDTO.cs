﻿namespace ResturangSystem.Models.DTO
{
    public class CreateBokningDTO
    {
        public string Namn { get; set; }
        public string Email { get; set; }
        public int Antal { get; set; }
        public int Bordnummer { get; set; }

        public DateTime Datum { get; set; }
         



    }
}
