using GestorReglaContratoCobertura.Extensores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestExtensores
{
    class PropClass
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
    }

    [TestClass]
    public class Extensores
    {
        #region IsNull
        [TestMethod]
        public void IsNull_StringNull()
        {
            string obj = null;
            var validacion = obj.IsNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNull_ObjetoNull()
        {
            object obj = null;
            var validacion = obj.IsNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNull_ListNull()
        {
            List<int> obj = null;
            var validacion = obj.IsNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNull_ClassNull()
        {
            PropClass obj = null;
            var validacion = obj.IsNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNull_ObjetoString()
        {
            object obj = "abc";
            var validacion = obj.IsNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNull_ObjetoInt()
        {
            object obj = 12;
            var validacion = obj.IsNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNull_ObjetoAnonymous()
        {
            object obj = new
            {
                Prop1 = "abc",
                Prop2 = 123
            };
            var validacion = obj.IsNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNull_ObjetoClass()
        {
            var obj = new PropClass
            {
                Prop1 = "abc",
                Prop2 = 123
            };
            var validacion = obj.IsNull2();
            Assert.IsFalse(validacion);
        }
        #endregion IsNull

        #region IsNullOrEmpty
        [TestMethod]
        public void IsNullOrEmpty_StringNull()
        {
            string obj = null;
            var validacion = obj.IsNullOrEmpty2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNullOrEmpty_StringEmpty()
        {
            string obj = string.Empty;
            var validacion = obj.IsNullOrEmpty2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNullOrEmpty_ListNull()
        {
            List<int> obj = null;
            var validacion = obj.IsNullOrEmpty2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNullOrEmpty_ListEmpty()
        {
            List<int> obj = new List<int>();
            var validacion = obj.IsNullOrEmpty2();
            Assert.IsTrue(validacion);
        }
        #endregion IsNullOrEmpty


        #region IsNotNull
        [TestMethod]
        public void IsNotNull_StringNull()
        {
            string obj = null;
            var validacion = obj.IsNotNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNull_ObjetoNull()
        {
            object obj = null;
            var validacion = obj.IsNotNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNull_ListNull()
        {
            List<int> obj = null;
            var validacion = obj.IsNotNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNull_ClassNull()
        {
            PropClass obj = null;
            var validacion = obj.IsNotNull2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNull_ObjetoString()
        {
            object obj = "abc";
            var validacion = obj.IsNotNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNotNull_ObjetoInt()
        {
            object obj = 12;
            var validacion = obj.IsNotNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNotNull_ObjetoAnonymous()
        {
            object obj = new
            {
                Prop1 = "abc",
                Prop2 = 123
            };
            var validacion = obj.IsNotNull2();
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void IsNotNull_ObjetoClass()
        {
            var obj = new PropClass
            {
                Prop1 = "abc",
                Prop2 = 123
            };
            var validacion = obj.IsNotNull2();
            Assert.IsTrue(validacion);
        }
        #endregion IsNotNull

        #region IsNullOrEmpty
        [TestMethod]
        public void IsNotNullOrEmpty_StringNull()
        {
            string obj = null;
            var validacion = obj.IsNotNullOrEmpty2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNullOrEmpty_StringEmpty()
        {
            string obj = string.Empty;
            var validacion = obj.IsNotNullOrEmpty2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNullOrEmpty_ListNull()
        {
            List<int> obj = null;
            var validacion = obj.IsNotNullOrEmpty2();
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void IsNotNullOrEmpty_ListEmpty()
        {
            List<int> obj = new List<int>();
            var validacion = obj.IsNotNullOrEmpty2();
            Assert.IsFalse(validacion);
        }
        #endregion IsNullOrEmpty
    }
}
