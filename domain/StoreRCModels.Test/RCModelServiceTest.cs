using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreRCModels.Test
{
    public class RCModelServiceTest
    {
        [Fact]
        public void GetAllByQuery_WithType_CallsGetAllByType()
        {
            var RCModelsRepository = new Mock<IRCModelsRepository>();
            RCModelsRepository.Setup(Xunit => Xunit.GetAllByType(It.IsAny<string>()))
                .Returns(new[] { new RCModel(1, " ", " ", " ") });

            RCModelsRepository.Setup(Xunit => Xunit.GetAllByTitel(It.IsAny<string>()))
                .Returns(new[] { new RCModel(2, " ", " ", " ") });

            var rcmodelService = new RCModelService(RCModelsRepository.Object);
            var actual = rcmodelService.GetAllByQuery("Tank");
            Assert.Collection(actual, rcmodel => Assert.Equal(1, rcmodel.numberRCModdel));
        }

        [Fact]
        public void GetAllByQuery_WithInvalidType_CallsGetAllByTitel()
        {
            var RCModelsRepository = new Mock<IRCModelsRepository>();
            RCModelsRepository.Setup(Xunit => Xunit.GetAllByType(It.IsAny<string>()))
                .Returns(new[] { new RCModel(1, " ", " ", " ") });

            RCModelsRepository.Setup(Xunit => Xunit.GetAllByTitel(It.IsAny<string>()))
                .Returns(new[] { new RCModel(2, " ", " ", " ") });

            var rcmodelService = new RCModelService(RCModelsRepository.Object);
            var actual = rcmodelService.GetAllByQuery("Tank23");
            Assert.Collection(actual, rcmodel => Assert.Equal(2, rcmodel.numberRCModdel));
        }
    }
}
