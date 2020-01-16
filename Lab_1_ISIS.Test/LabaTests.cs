using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime;
using Lab_1_ISIS;



namespace Lab_1_ISIS.Test
{
    [TestClass]
    public class LabaTests
    {
        //Проверка на пустоту
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test1("Жил-был старик со старухой"), "");
        }

        //Кол-во слов по условию
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test2("Каша Даша ваша Маша кура дура, василек", 4), (6));
        }

        //Кол-во пробелов
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test3("Жил-был старик со старухой   траляля"), 6);
        }

        //Сумма
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test4(3, 3), 6);
        }

        //Деление
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test5(10, 2), 5);
        }

        //Умножение
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test6(5, 2), 10);
        }

        //Кол-во букв по условию
        [TestMethod]
        public void Test7()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test7("На дворе трава, на траве дрова", "а"), (6));
        }

        //Длина текста
        [TestMethod]
        public void Test8()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test8("Мама "), (5));
        }

        [TestMethod]
        public void Test9()
        {
            var num = 10;
            Assert.AreEqual(num, 10);
        }
        //Значение
        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual(Lab_1_ISIS.MetodTest.Test9(5), 5);
        }
    }

}
