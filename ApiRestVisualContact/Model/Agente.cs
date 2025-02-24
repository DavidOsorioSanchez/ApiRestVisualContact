﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiRestVisualContact.enums;

namespace ApiRestVisualContact.Model
{
    public class Agente
    {
        //[Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Estados estado { get; set; }

        //public ICollection<Cliente> Clientes { get; set; }
    }
}
