using Autosar;

namespace AutosarClass
{
    public partial class AsrISignalMapping
    {
        public ISIGNALMAPPING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrISignalMapping(ISIGNALMAPPING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
