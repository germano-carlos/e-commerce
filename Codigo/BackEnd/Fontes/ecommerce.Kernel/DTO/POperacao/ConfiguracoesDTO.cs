using ecommerce.Kernel.DTO.PSubcategoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Kernel.DTO.POperacao
{
    public class ConfiguracoesDTO
    {
        public string nome { get; set; }
        public List<SubCategoriaDTO> subcategorias { get; set; }

    }
}
