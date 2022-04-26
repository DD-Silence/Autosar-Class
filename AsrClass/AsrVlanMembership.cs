using Autosar;

namespace AutosarClass
{
    public partial class AsrVlanMembership
    {
        public VLANMEMBERSHIP Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String DefaultPriority
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DEFAULTPRIORITY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (DefaultPriority != value)
                {
                    if (Model.DEFAULTPRIORITY == null)
                    {
                        Model.DEFAULTPRIORITY = new ();
                    }
                    Model.DEFAULTPRIORITY.TypedValue = value;
                }
            }
        }
        
        public AsrVlanMembership(VLANMEMBERSHIP model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
