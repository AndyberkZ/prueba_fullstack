using API.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation
{
    public class ProductoValidator : AbstractValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.Nombre)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("No ha indicado el nombre de producto.")
            .Length(5, 25)
            .WithMessage("{PropertyNombre} tiene {TotalLength} letras. Debe tener una longitud entre 5 y 25 letras.");

            RuleFor(producto => producto.Precio)
                .Must(MayorCero)
                .WithMessage("Precio mayor de cero para registrarse.");
            RuleFor(producto => producto.Stock)
                .Must(MayorCeroInt)
                .WithMessage("Stock mayor de cero para registrarse.");
            RuleFor(producto => producto.FechaRegistro)
                .Must(FechaMayor)
                .WithMessage("La fecha es pasada, cambiar para registrarse.");
        }

        private bool FechaMayor(DateTime fecha)
        {
            return DateTime.Now <= fecha;
        }

        private bool MayorCeroInt(int stock)
        {
            return 0 < stock;
        }

        private bool MayorCero(decimal precio)
        {
            return 0 < precio;
        }
    }

    }

