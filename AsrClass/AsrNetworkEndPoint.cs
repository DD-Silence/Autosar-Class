using Autosar;

namespace AutosarClass
{
    public partial class AsrNetworkEndPoint : IAsrIdentifier
    {
        public NETWORKENDPOINT Model { get; }
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
        
        public List<AsrIpv4Configuration> Ipv4Configurations
        {
            get
            {
                try
                {
                    var result = new List<AsrIpv4Configuration>();
                    foreach (var m in Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION)
                    {
                        result.Add(new AsrIpv4Configuration(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrIpv4Configuration>();
                }
            }
        }
        
        public void AddIpv4Configurations(AsrIpv4Configuration data)
        {
            if (Model.NETWORKENDPOINTADDRESSES == null)
            {
                Model.NETWORKENDPOINTADDRESSES = new ();
            }
            if (Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION == null)
            {
                Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION = new List<IPV4CONFIGURATION>();
            }
            foreach (var d in Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new IPV4CONFIGURATION();
            m = data.Model;
            Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION.Add(m);
        }
        
        public void DelIpv4Configurations(AsrIpv4Configuration data)
        {
            if (Model.NETWORKENDPOINTADDRESSES == null)
            {
                return;
            }
            if (Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION == null)
            {
                return;
            }
            foreach (var m in Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION)
            {
                if (m.Equals(data.Model))
                {
                    Model.NETWORKENDPOINTADDRESSES.IPV4CONFIGURATION.Remove(m);
                    break;
                }
            }
        }
        public AsrNetworkEndPoint(NETWORKENDPOINT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
