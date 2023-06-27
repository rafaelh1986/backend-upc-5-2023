using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestPago
    {
        public UnitTestPago()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact, TestPriority(0)]
        public void Pago_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar M�todos
            var result = PagoServicios.Get<Pago>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Pago_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = PagoServicios.GetById<Pago>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Pago_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Pago pago = new();
            pago.Monto = 25;
            pago.IdAlumno = 1;

            // Act
            var result = PagoServicios.Insert(pago);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Pago_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Pago pago = new();
            pago.Id = 3;
            pago.Monto = 30;
            pago.IdAlumno = 1;

            var result = PagoServicios.Update(pago);

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