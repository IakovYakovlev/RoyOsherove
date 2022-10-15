using NUnit.Framework;
using System;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void overrideTestWithoutStub()
        {
            TestableLogAnalyzer logan = new TestableLogAnalyzer();
            logan.IsSupported = true;

            bool result = logan.IsValidLogFileName("file.ext");
            Assert.True(result, "...");
        }

        class TestableLogAnalyzer: LogAnalyzerUsingFactoryMethod
        {
            public bool IsSupported;

            protected override bool IsValid(string fileName)
            {
                return IsSupported;
            }
        }
    }
}
