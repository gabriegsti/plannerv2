using Planner.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Planner.Entidades
{
    public class Evento : IAgendavel
    {
        [Key]
        public int Id_Evento { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public DateTime? Data_Hora { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        //public bool Concluido { get; set; }
        public Evento()
        {

        }
        public Evento(string titulo, DateTime? data_hora, int? id_usuario)
        {
            Titulo = titulo;
            Data_Hora = data_hora;
            UsuarioId = id_usuario;
        }
    }
}
