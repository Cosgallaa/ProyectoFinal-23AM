using Microsoft.Exchange.WebServices.Data;
using ProyectoFinal_23AM.Entities;
using ProyectoFinal_23AM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal_23AM.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        UsuarioServices services = new UsuarioServices();
        //Este boton tiene 2 funciones, (CUARDAR/EDITAR)
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //FUNCION GUARDAR
            if(txtPkUser.Text == "")
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                };

                services.AddUser(usuario);
                MessageBox.Show("Usuario agregado");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
            }
            //FUNCION EDITAR
            else
            {
                int userId = Convert.ToInt32(txtPkUser.Text);

                Usuario usuario = new Usuario()
                {
                    PkUsuario = userId,
                    Nombre = txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text
                };
                MessageBox.Show("Usuario actualizado");
                services.UpdateUser(usuario);
                txtPkUser.Clear();
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
                //hacer funcion editar y eliminar
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(txtPkUser.Text);
            Usuario usuario = new Usuario();
            usuario.PkUsuario = userId;
            services.DeleteUser(userId);
            MessageBox.Show("Registro Eliminado");

        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario;
            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
        }
        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }

    }
}
