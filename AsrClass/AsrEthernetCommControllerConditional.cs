using Autosar;

namespace AutosarClass
{
    public partial class AsrEthernetCommControllerConditional
    {
        public ETHERNETCOMMUNICATIONCONTROLLERCONDITIONAL Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrEthernetCommControllerConditional(ETHERNETCOMMUNICATIONCONTROLLERCONDITIONAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
