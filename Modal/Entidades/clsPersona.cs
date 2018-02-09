using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersona
    {
        private int _idPersona;
        private DateTime _fechaNac;
        private String _nombre;
        private String _apellidos;
        private String _direccion;
        private String _telefono;

        public clsPersona()
        {
            this._idPersona = 1;
            this._nombre = "Luis";
            this._apellidos = "Gutierrez";
            this._fechaNac = DateTime.Now;
            this._direccion = "aaay";
            this._telefono = "123456789";

        }
        public int idPersona { get; set; }
        public DateTime fechaNac { get; set; }
        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public String apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        public String direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        public String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        public String toString()
        {
            return "ID: " + idPersona + "Nombre: " + nombre;
        }

    }
}
