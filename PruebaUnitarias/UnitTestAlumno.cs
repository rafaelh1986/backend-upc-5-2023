using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestAlumno
    {
        public UnitTestAlumno()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact, TestPriority(0)]
        public void Alumno_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar M�todos
            var result = AlumnoServicios.Get<Alumno>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Alumno_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = AlumnoServicios.GetById<Alumno>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Alumno_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Alumno alumno = new();
            alumno.NombreCompleto = "Alumno UnitTest";
            alumno.Curso = "Curso Unitest";
            alumno.Gestion = 2023;

            // Act
            var result = AlumnoServicios.Insert(alumno);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Alumno_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Alumno alumno = new();
            alumno.Id = 3;
            alumno.NombreCompleto = "Update UnitTest";
            alumno.Curso = "Curso Unitest";

            var result = AlumnoServicios.Update(alumno);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Alumno_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = AlumnoServicios.Delete(3);

            Assert.Equal(1, result);
        }
    }
}