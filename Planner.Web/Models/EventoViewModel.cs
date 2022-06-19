using Planner.Interfaces;
using Planner.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Planner.Web.Models
{
    public class EventoViewModel : IAgendavelViewModel
    {
        [JsonPropertyName("id_Evento")]
        [Key]
        public int Id_Evento { get; set; }
        [JsonPropertyName("titulo")]
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string Titulo { get; set; }
        //[DataType(DataType.DateTime)]
        [JsonPropertyName("data_Hora")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode =true)]
        public DateTime? Data_Hora { get; set; }
        [JsonPropertyName("id_Usuario")]
        public int Id_Usuario { get; set; }

        public EventoViewModel()
        {

        }
        public EventoViewModel(string titulo, DateTime? data_hora, int id_usuario)
        {
            Titulo = titulo;
            Data_Hora = data_hora;
            Id_Usuario = id_usuario;
        }
    }
}
