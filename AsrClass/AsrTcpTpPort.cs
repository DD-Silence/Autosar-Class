using Autosar;

namespace AutosarClass
{
    public partial class AsrTcpTpPort
    {
        public TPPORT Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String Dynamic
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DYNAMICALLYASSIGNED.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (Dynamic != value)
                {
                    if (Model.DYNAMICALLYASSIGNED == null)
                    {
                        Model.DYNAMICALLYASSIGNED = new ();
                    }
                    Model.DYNAMICALLYASSIGNED.TypedValue = value;
                }
            }
        }
        
        public String PortNumber
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PORTNUMBER.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (PortNumber != value)
                {
                    if (Model.PORTNUMBER == null)
                    {
                        Model.PORTNUMBER = new ();
                    }
                    Model.PORTNUMBER.TypedValue = value;
                }
            }
        }
        
        public AsrTcpTpPort(TPPORT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
