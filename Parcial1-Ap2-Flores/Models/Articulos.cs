using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Parcial1_Ap2_Flores.Models
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir la descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad en existencia")]
        [Phone(ErrorMessage ="No se permite letras")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el costo")]
        [Phone(ErrorMessage = "No se permite letras")]
        public decimal Costo { get; set; }
        public decimal ValorInvetario { get; set; }

        public Articulos(int productoId, string descripcion, int existencia, decimal costo, decimal valorInvetario)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Existencia = existencia;
            Costo = costo;
            ValorInvetario = valorInvetario;
        }

        public Articulos()
        {
        }
    }
}
