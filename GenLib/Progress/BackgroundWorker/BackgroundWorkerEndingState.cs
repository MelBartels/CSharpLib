using GenLib.SFT;

namespace GenLib.Progress.BackgroundWorker
{
    public class BackgroundWorkerEndingState : SFTFacadeBase
    {
        protected static SFTContainer SFTContainer = new SFTContainer(typeof (BackgroundWorkerEndingState));

        public static SFTPrototype Cancelled = new SFTPrototype(SFTContainer, "Cancelled");
        public static SFTPrototype EncounteredError = new SFTPrototype(SFTContainer, "Encountered Error");
        public static SFTPrototype Failed = new SFTPrototype(SFTContainer, "Failed");
        public static SFTPrototype NotSet = new SFTPrototype(SFTContainer, "Not set");
        public static SFTPrototype Successful = new SFTPrototype(SFTContainer, "Successful");

        public override ISFT FirstItem
        {
            get { return SFTContainer.FirstItem(); }
        }

        public static ISFT Isft
        {
            get { return SFTContainer.FirstItem(); }
        }
    }
}