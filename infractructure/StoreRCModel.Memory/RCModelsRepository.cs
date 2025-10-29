using StoreRCModels;
using System;
using System.Linq;
namespace StoreRCModel.Memory
{
    public class RCModelsRepository : IRCModelsRepository
    {
        private readonly RCModel[] rcmodels = new[]
        {
            new RCModel(1,"fury","tank","blow"),
            new RCModel(2,"faster", "fly","rad"),
            new RCModel(3,"chit","car","ellow")

        };

        public RCModel[] GetAllByType(string color)
        {
            throw new NotImplementedException();
        }

        public RCModel[] GetAllByTitel(string title)
        {
            return rcmodels.Where(RCModel => RCModel.nameRCModel.Contains(title))
                .ToArray();
        }
    }
}
