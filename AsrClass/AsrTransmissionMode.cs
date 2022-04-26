using Autosar;

namespace AutosarClass
{
    public partial class AsrTransmissionMode
    {
        public TRANSMISSIONMODETIMING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrTransmissionMode(TRANSMISSIONMODETIMING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
