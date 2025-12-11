
using DataBase_First.Views.Main;

namespace Cursos_Online
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frm_Principal());
        }
    }
}

//Scaffold-DbContext "Server=localhost;Port=3306;Database=cursos_online;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Modelos -ContextDir Config -Context CursoOnlineContext -DataAnnotations -Force
//Microsoft.EntityFrameworkCore.SqlServer - OutputDir Modelos - ContextDir Config - Context GestionAcademicaContext - DataAnnotations - Force