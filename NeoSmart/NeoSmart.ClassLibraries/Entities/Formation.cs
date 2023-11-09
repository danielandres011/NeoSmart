﻿using NeoSmart.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace NeoSmart.ClassLibraries.Entities
{
    public class Formation : ISoftDetete
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Cod { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Cargo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int OccupationId { get; set; }
        public Occupation? Occupation { get; set; }

        public ICollection<FormationTopic>? FormationTopics { get; set; }

        [Display(Name = "Temas")]
        public int FormationTopicsNumber => FormationTopics == null ? 0 : FormationTopics.Count;
    }
}