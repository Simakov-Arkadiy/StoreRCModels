using StoreRCModels;

namespace StoreRCModels.Test
{
    public class RCModelTests
    {
        [Fact]
        public void IsTypeRCModel_WithNull_ReturnFalse()
        {
            bool actual = RCModel.IsTypeRCModel(null);

            Assert.False(actual);
        }
        [Fact]
        public void IsTypeRCModel_WithBlanString_ReturnFalse()
        {
            bool actual = RCModel.IsTypeRCModel("    ");

            Assert.False(actual);
        }
        [Fact]
        public void IsTypeRCModel_WithInvalidType_ReturnFalse()
        {
            bool actual = RCModel.IsTypeRCModel("trum");

            Assert.False(actual);
        }
    }
}
