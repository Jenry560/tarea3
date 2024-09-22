
using System.ComponentModel.DataAnnotations;

namespace Tarea3.models
{
    public class Accidente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha del accidente es obligatoria.")]
        public DateTime FechaAccidente { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = "";

        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser un número positivo.")]
        public decimal CostoEconomico { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El número de muertos debe ser un número no negativo.")]
        public int NumeroMuertos { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El número de heridos debe ser un número no negativo.")]
        public int NumeroHeridos { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de vehículos debe ser un número no negativo.")]
        public int CantidadVehiculos { get; set; }
    }
}