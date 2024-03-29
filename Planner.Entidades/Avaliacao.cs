﻿using Planner.Entidades;
using Planner.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Avaliacao : IAgendavel
    {
        [Key]
        public int Id_Avaliacao { get; set; }
        public int MateriaId { get; set; }
        public virtual Materia materia { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public double? Nota { get; set; }
        public DateTime? Data_Hora { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
