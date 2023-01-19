﻿namespace APIRessource.Models
{
    public class USER
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public string pseudo { get; set; }
        public DateTime dateCreation { get; set; }
        public bool isDeleted { get; set; }
        public bool isConfirm { get; set; }
        public int idZoneGeo { get; set; }
        public int idRole { get; set; }

    }
}
