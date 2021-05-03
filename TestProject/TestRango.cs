using Logica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class TestRango
    {
        private Random rnd;
        private Rangos rangos;

        [TestInitialize]
        public void Inicio()
        {
            rnd = new Random();
            rangos = new Rangos();
        }
        [TestMethod]
        public void PruebaCompletar()
        {
            var listaData = new List<List<int>> {
                new List<int> { 2, 1, 4, 5 },
                new List<int> { 100, 96, 101, 102, 105 },
                new List<int> { 22, 25 }
            };

            foreach (var dataInput in listaData)
            {
                validar(dataInput);
            }
        }
        void validar(List<int> data)
        {
            var retorno = rangos.CompletarRango(data);

            var aleatorio = rnd.Next(data.Min(), data.Max());
            var indiceAleatorio = aleatorio - data.Min();

            Assert.IsInstanceOfType(retorno, typeof(List<int>));
            Assert.AreEqual(data.Max() - data.Min() + 1, retorno.Count);
            Assert.AreEqual(aleatorio, retorno[indiceAleatorio]);
        }
    }
}
