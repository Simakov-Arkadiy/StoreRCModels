namespace StoreRCModels
{
    public class RCModel
    {
        public int numberRCModdel { get; }
        public string nameRCModel { get; }
        public string typeRCModel { get; }

        public RCModel(int numberRCModel, string nameRCmodel, string typeRCModel) 
        {
            this.numberRCModdel = numberRCModel;
            this.nameRCModel = nameRCmodel;
            this.typeRCModel = typeRCModel;
        }
        
    }
}
