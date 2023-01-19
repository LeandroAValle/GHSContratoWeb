using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHSContratoWeb.Models.Business;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Helper
{
    public class DropDownList
    {
        public static List<SelectListItem> DropDownTipoCliente(int? id = null)
        {
            var list = new List<SelectListItem>();

            var TipoCliente = new TipoClienteBusiness().SelectTipoCliente();

            foreach (var item in TipoCliente)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Descricao,
                    Value = item.ID.ToString(),
                    Selected = item.ID == id
                });
            }

            list.Insert(0, new SelectListItem
            {
                Text = "-Selecione-",
                Value = "",
                Selected = (id == null)
            });

            return list;
        }

        public static List<SelectListItem> DropDownEstado(int? id = null)
        {

            var estados = new EstadoBusiness().SelectEstado();
            var list = new List<SelectListItem>();

            foreach (var estado in estados)
            {
                list.Add(new SelectListItem
                {
                    Text = estado.uf,
                    Value = estado.id.ToString(),
                    Selected = estado.id == id
                });
            }

            list.Insert(0, new SelectListItem
            {
                Text = "-Selecione-",
                Value = "",
                Selected = (id == 0 ? true : false)
            });

            return list;
        }

        public static List<SelectListItem> DropDownCidade(int? id = null, int? uf = null)
        {
            var list = new List<SelectListItem>();

            if (uf != null)
            {
                var cidades = new CidadeBusiness().ListarDropDown(uf.Value);

                foreach (var cidade in cidades)
                {
                    list.Add(new SelectListItem
                    {
                        Text = cidade.nome,
                        Value = cidade.ID.ToString(),
                        Selected = cidade.ID == id
                    });
                }
            }

            list.Insert(0, new SelectListItem
            {
                Text = "-Selecione-",
                Value = "",
                Selected = (id == null ? true : false)
            });

            return list;
        }

        public static List<SelectListItem> DropDownCidades(int? id = null)
        {
            var list = new List<SelectListItem>();
            var cidades = new CidadeBusiness().SelectCidade();

            foreach (var cidade in cidades)
            {
                list.Add(new SelectListItem
                {
                    Text = cidade.nome,
                    Value = cidade.ID.ToString(),
                    Selected = cidade.ID == id
                });
            }

            list.Insert(0, new SelectListItem
            {
                Text = "-Selecione-",
                Value = "",
                Selected = (id == null ? true : false)
            });

            return list;
        }

        public static List<SelectListItem> DropDownConcessionaria(int? id = null)
        {
            var list = new List<SelectListItem>();
            var concessionarias = new ConcessionariaBusiness().SelectConcessionaria();

            foreach (var concessionaria in concessionarias)
            {
                list.Add(new SelectListItem
                {
                    Text = concessionaria.Nome,
                    Value = concessionaria.ID.ToString(),
                    Selected = concessionaria.ID == id
                });
            }

            list.Insert(0, new SelectListItem
            {
                Text = "-Selecione-",
                Value = "",
                Selected = (id == null ? true : false)
            });

            return list;
        }


    }
}