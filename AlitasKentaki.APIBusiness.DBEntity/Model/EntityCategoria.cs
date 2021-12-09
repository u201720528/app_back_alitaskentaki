using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCategoria: EntityBase
    {
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
    }
}
