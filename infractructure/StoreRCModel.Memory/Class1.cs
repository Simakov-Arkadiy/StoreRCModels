using StoreRCModels;
using System;
using System.Linq;
namespace StoreRCModel.Memory
{
    public class RCModelsRepository : IRCModelsRepository
    {
        private readonly RCModel[] rcmodels = new[]
        {
            new RCModel(1,"fury","tank"),
            new RCModel(2,"faster", "fly"),
            new RCModel(3,"chit","car")

        };
        public RCModel[] GetAllByTitel(string title)
        {
            return rcmodels.Where(RCModel => RCModel.nameRCModel.Contains(title))
                .ToArray();
        }
    }
}
