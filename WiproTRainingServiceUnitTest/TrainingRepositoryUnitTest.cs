using Moq;
using NUnit.Framework;
using WiproTrainingService.Data;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllTrainings()
        {
            var mockRepository = new Mock<ITrainingRepository>();

            // We need to write logic to to the assertion for both expected and actual result form controller.
        }
    }
}