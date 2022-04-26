using Autosar;

namespace AutosarClass
{
    public partial class AsrIpv4Configuration
    {
        public IPV4CONFIGURATION Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String DefaultGateway
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DEFAULTGATEWAY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (DefaultGateway != value)
                {
                    if (Model.DEFAULTGATEWAY == null)
                    {
                        Model.DEFAULTGATEWAY = new ();
                    }
                    Model.DEFAULTGATEWAY.TypedValue = value;
                }
            }
        }
        
        public String Ipv4Address
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.IPV4ADDRESS.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Ipv4Address != value)
                {
                    if (Model.IPV4ADDRESS == null)
                    {
                        Model.IPV4ADDRESS = new ();
                    }
                    Model.IPV4ADDRESS.TypedValue = value;
                }
            }
        }
        
        public String Ipv4AddressSource
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.IPV4ADDRESSSOURCE.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Ipv4AddressSource != value)
                {
                    if (Model.IPV4ADDRESSSOURCE == null)
                    {
                        Model.IPV4ADDRESSSOURCE = new ();
                    }
                    Model.IPV4ADDRESSSOURCE.TypedValue = value;
                }
            }
        }
        
        public String NetworkMask
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.NETWORKMASK.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (NetworkMask != value)
                {
                    if (Model.NETWORKMASK == null)
                    {
                        Model.NETWORKMASK = new ();
                    }
                    Model.NETWORKMASK.TypedValue = value;
                }
            }
        }
        
        public AsrIpv4Configuration(IPV4CONFIGURATION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
