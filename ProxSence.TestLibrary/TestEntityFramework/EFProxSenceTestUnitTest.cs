using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;
using ProxSence.Library.InterfacesLibrary;
using ProxSence.Library.ProxSenceModels;
using ProxSenceWebProj.Controllers;
using ProxSenceWebProj.ProjectInfrastructure;

namespace ProxSence.TestLibrary
{
    [TestClass]
    public class EFProxSenceTestUnitTest
    {
        [TestMethod]
        public void TestCan_Pignate()
        {
            Mock<IPortfolioAdding> mock = 
                new Mock<IPortfolioAdding>();
            mock.Setup(m => m.PList).Returns(new PortfolioList[]
            {
                new PortfolioList {Id = 1, ProjectName = "P1"},
                new PortfolioList {Id = 2, ProjectName = "P2"},
                new PortfolioList {Id = 3, ProjectName = "P3"},
                new PortfolioList {Id = 4, ProjectName = "P4"},
            });
            PortfolioController controller = 
                new PortfolioController(mock.Object);

            IEnumerable<PortfolioList> result = 
                (IEnumerable<PortfolioList>)controller.AsyncManager();

            PortfolioList[] proxArray = result.ToArray();
            Assert.IsTrue(proxArray.Length == 2);
            Assert.AreEqual(proxArray[0].ProjectName, "P1");
            Assert.AreEqual(proxArray[1].ProjectName, "P2");
        }
    }
}
