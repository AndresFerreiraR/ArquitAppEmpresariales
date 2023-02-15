using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Services.WebApi;
using System.IO;
using System.Net;

namespace Pacagroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        /// <summary>
        /// 
        /// </summary>
        private static IConfiguration _configuration;

        private static IServiceScopeFactory _scopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_"></param>
        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            /// Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Error en la validacion";

            /// Act
            
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            /// Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExitoso()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            /// Arrange
            var userName = "aferreira";
            var password = "123456";
            var expected = "Autenticacion exitosa!";

            /// Act

            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            /// Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            /// Arrange
            var userName = "aferreira5";
            var password = "1234567";
            var expected = "Usuario no existe";

            /// Act

            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            /// Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
