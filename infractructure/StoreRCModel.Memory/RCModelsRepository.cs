using StoreRCModels;
using System;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;
namespace StoreRCModel.Memory
{
    public class RCModelsRepository : IRCModelsRepository
    {
        private readonly RCModel[] rcmodels = new[]
        {
            new RCModel(1,"fury","tank","blow","very buitiful",100m),
            new RCModel(2,"faster", "fly","rad","very buitiful",110m),
            new RCModel(3,"chit","car","ellow","very buitiful",120m)

        };

        public RCModel[] GetAllByType(string type)
        {
            return rcmodels.Where(RCModel => RCModel.typeRCModel.Contains(type))
            .ToArray();
        }

        public RCModel[] GetAllByTitel(string title)
        {
            return rcmodels.Where(RCModel => RCModel.nameRCModel.Contains(title) || RCModel.color.Contains(title))
                .ToArray();
        }

        public RCModel GetById(int numberRCModel2)
        {
            return rcmodels.Single(rcmodel => rcmodel.numberRCModel == numberRCModel2);
        }

        public RCModel[] GetAllById(IEnumerable<int> rcmodelIds)
        {
            var foundRCModels = from rcmodel in rcmodels
                             join rcmodelId in rcmodelIds on rcmodel.numberRCModel equals rcmodelId
                             select rcmodel;

            return foundRCModels.ToArray();
        }
    }
}
