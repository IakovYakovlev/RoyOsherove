using NUnit.Framework;
using System;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        //[TestCase("filewithbadextension.SLF", true)]
        //[TestCase("filewithbadextension.slf", true)]
        //[TestCase("filewithbadextension.foo", false)]
        //public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected)
        //{
        //    LogAnalyzer analyzer = new LogAnalyzer();

        //    bool result = analyzer.IsValidLogFileName(file);

        //    Assert.AreEqual(expected, result);
        //}

        private LogAnalyzer m_analyzer = null;

        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            bool result = m_analyzer
                .IsValidLogFileName("whatever.slf");

            Assert.IsTrue(result, "имя файла должно быть правильным!");
        }

        [Test]
        [Ignore("в этом тесте имеется ошибка")]
        
        public void IsValidFileName_ValidFile_ReturnsTrue()
        {

        }

        [Test]
        [Category("Быстрые тесты")]
        public void IsValidFileName_validFileUpperCased_ReturnsTrue()
        {
            bool result = m_analyzer
                .IsValidLogFileName("whatever.SLF");

            Assert.IsTrue(result, "имя файла должно быть правильным!");
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    // Следующая строка включена для демонстрации антипаттерна.
        //    // На самом деле, она не нужна. Не поступайте так.
        //    m_analyzer = null;
        //}

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = MakeAnalyzer();

            //var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

            //StringAssert.Contains("имя файла должно быть задано", ex.Message);

            var ex = Assert.Catch<ArgumentException>(() => la.IsValidLogFileName(""));

            Assert.That(ex.Message, Does.Contain("имя файла должно быть задано"));
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName(file);

            Assert.AreEqual(expected, la.WasLastFileNameValid);     // Утверждение о состоянии системы
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
