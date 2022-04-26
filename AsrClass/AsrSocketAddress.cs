using Autosar;

namespace AutosarClass
{
    public partial class AsrSocketAddress : IAsrIdentifier
    {
        public SOCKETADDRESS Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String ShortName
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SHORTNAME.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ShortName != value)
                {
                    if (Model.SHORTNAME == null)
                    {
                        Model.SHORTNAME = new ();
                    }
                    Model.SHORTNAME.TypedValue = value;
                }
            }
        }
        
        public AsrApplEndPoint? ApplEndPoint
        {
            get
            {
                try
                {
                    return new AsrApplEndPoint(Model.APPLICATIONENDPOINT, PathManager);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value is not null)
                {
                    Model.APPLICATIONENDPOINT = value.Model;
                }
                else
                {
                    Model.APPLICATIONENDPOINT = null;
                }
            }
        }
        
        public AsrSocketAddress(SOCKETADDRESS model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
