using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GHSContratoWeb.Aggregation;
using GHSContratoWeb.Models.Mapping;

namespace GHSContratoWeb.Models.Business
{
    public class MenuBusiness
    {
        public List<Menu> SelectMenu()
        {    
            try
            {
                // Select
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT * FROM [Menus]";
                    List<Menu> lista = db.Query<Menu>(sql).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<Menu> lista = new List<Menu>();
                return lista;                
            }
        }

        public int? InsertMenu(Menu menu)
        {
            // Insert          
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"INSERT INTO [Menu] (Nome) VALUES (@Nome)";
                    int? res = db.Execute(sql, new { Nome = menu.Nome });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? UpdateMenu(Menu menu)
        {
            // Update
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"UPDATE [Menu] SET Nome = @Nome WHERE ID = @ID";
                    int? res = db.Execute(sql, new { ID = menu.ID, Nome = menu.Nome });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? DeleteMenu(Menu menu)
        {
            // Delete       
            try
            {
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"DELETE FROM [Menu] WHERE ID = @ID";
                    int? res = db.Execute(sql, new { menu.ID });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public Menu Detalhes(int? ID)
        {
            try
            {
                // Select
                using (var db = new Conexao().GetCon())
                {
                    string sql = @"SELECT ID, Nome FROM [Menus] where ID = @ID";
                    Menu menu = db.Query<Menu>(sql, new {ID = ID}).SingleOrDefault();
                    return menu;
                }
            }
            catch (Exception ex)
            {
                Menu menu = new Menu();
                return menu;
            }
        }

        public List<MenuAggregation> ListarMenus()
        {
            try
            {
                // Select
                using (var db = new Conexao().GetCon())
                {
                    string sqlMenu = @"SELECT * FROM [Menus] Order by ordem";
                    List<MenuAggregation> listaMenu = db.Query<MenuAggregation>(sqlMenu).ToList();

                    string sqlSubMenu = @"Select * from subMenus";
                    List<SubMenuAggregation> listaSubMenu = db.Query<SubMenuAggregation>(sqlSubMenu).ToList();

                    List<MenuAggregation> lista = new List<MenuAggregation>();
                    if (listaMenu.Count > 0)
                    {
                        foreach (var menu in listaMenu)
                        {
                            MenuAggregation menuAggregation = new MenuAggregation();
                            menuAggregation.ID = menu.ID;
                            menuAggregation.Nome = menu.Nome;
                            menuAggregation.Action = menu.Action;
                            menuAggregation.Controller = menu.Controller;
                            menuAggregation.Ordem = menu.Ordem;
                            menuAggregation.Icone = menu.Icone;
                            List<SubMenuAggregation> subLista = new List<SubMenuAggregation>();
                            if (listaSubMenu.Count > 0)
                            {
                                foreach (var subMenu in listaSubMenu)
                                {
                                    if (subMenu.IDMenu == menu.ID)
                                    {
                                        SubMenuAggregation subMenuAggregation = new SubMenuAggregation();
                                        subMenuAggregation.ID = subMenu.ID;
                                        subMenuAggregation.Nome = subMenu.Nome;
                                        subMenuAggregation.IDMenu = subMenu.IDMenu;
                                        subMenuAggregation.Action = subMenu.Action;
                                        subMenuAggregation.Controller = subMenu.Controller;
                                        subMenuAggregation.Ordem = subMenu.Ordem;
                                        subMenuAggregation.SubIcone = subMenu.SubIcone;
                                        subLista.Add(subMenuAggregation);
                                    }                                   
                                }
                            }
                            menuAggregation.Submenu = subLista;
                            lista.Add(menuAggregation);
                        }
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {
                List<MenuAggregation> lista = new List<MenuAggregation>();
                return lista ;
            }
        }


    }
}
