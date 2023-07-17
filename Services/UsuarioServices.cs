using ProyectoFinal_23AM.Context;
using ProyectoFinal_23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoFinal_23AM.Services
{
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new AppDBConttext())
                    {
                        Usuario res = new Usuario()
                        {
                            Nombre = request.Nombre,
                            UserName = request.UserName,
                            Password = request.Password,
                            // FkRol = request.FkRol,
                        };
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error "+ ex.Message);
            }
        }
       
        public void UpdateUser(Usuario request)
        {
            try
            {
               
                    using (var _context = new AppDBConttext())
                    {
                    Usuario update = _context.Usuarios.Find(request.PkUsuario);
                    Usuario res = new Usuario();


                        update.Nombre = request.Nombre;
                        update.UserName = request.UserName;
                        update.Password = request.Password;
                            // FkRol = request.FkRol,
                    
                        _context.Usuarios.Update(update);
                        _context.SaveChanges();
                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void DeleteUser(int UserId)
        {
            try
            {
                using (var _context = new AppDBConttext())
                {
                    Usuario usuario = _context.Usuarios.Find(UserId);
                    if (usuario!= null)
                    {
                        _context.Remove(usuario);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY REGISTRO");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new AppDBConttext())
                {
                    List<Usuario> usuarios = new List<Usuario>();

                    usuarios = _context.Usuarios.ToList();

                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new AppDBConttext())
                {
                    List<Rol> roles = new List<Rol>();

                    roles = _context.Roles.ToList();

                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
    }
}
