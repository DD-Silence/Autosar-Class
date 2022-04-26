using Autosar;

namespace AutosarClass
{
    public partial class AsrApplEndPoint : IAsrIdentifier
    {
        public APPLICATIONENDPOINT Model { get; }
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
        
        public AsrReferenceInfo? NetworkEndPointRef
        {
            get
            {
                try
                {
                    if (Model.NETWORKENDPOINTREF.DEST == "NETWORK-ENDPOINT")
                    {
                        return PathManager.GetReferenceInfo(Model.NETWORKENDPOINTREF);
                    }
                    return null;
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
                    if (value.AsrReferenceDest == "NETWORK-ENDPOINT")
                    {
                        Model.NETWORKENDPOINTREF.DEST = value.AsrReferenceDest;
                        Model.NETWORKENDPOINTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.NETWORKENDPOINTREF = null;
                    }
                }
                else
                {
                    Model.NETWORKENDPOINTREF = null;
                }
            }
        }
        
        public AsrNetworkEndPoint? NetworkEndPoint
        {
            get
            {
                try
                {
                    if (NetworkEndPointRef is not null)
                    {
                        if (NetworkEndPointRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(NetworkEndPointRef.AsrPath);
                            if (m is NETWORKENDPOINT mm)
                            {
                                return new AsrNetworkEndPoint(mm, PathManager);
                            }
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        
        public List<AsrProvidedServiceInstance> ProvidedServiceInstances
        {
            get
            {
                try
                {
                    var result = new List<AsrProvidedServiceInstance>();
                    foreach (var m in Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE)
                    {
                        result.Add(new AsrProvidedServiceInstance(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrProvidedServiceInstance>();
                }
            }
        }
        
        public void AddProvidedServiceInstances(AsrProvidedServiceInstance data)
        {
            if (Model.PROVIDEDSERVICEINSTANCES == null)
            {
                Model.PROVIDEDSERVICEINSTANCES = new ();
            }
            if (Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE == null)
            {
                Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE = new List<PROVIDEDSERVICEINSTANCE>();
            }
            foreach (var d in Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new PROVIDEDSERVICEINSTANCE();
            m = data.Model;
            Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE.Add(m);
        }
        
        public void DelProvidedServiceInstances(AsrProvidedServiceInstance data)
        {
            if (Model.PROVIDEDSERVICEINSTANCES == null)
            {
                return;
            }
            if (Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE == null)
            {
                return;
            }
            foreach (var m in Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE)
            {
                if (m.Equals(data.Model))
                {
                    Model.PROVIDEDSERVICEINSTANCES.PROVIDEDSERVICEINSTANCE.Remove(m);
                    break;
                }
            }
        }
        public List<AsrConsumedServiceInstance> ConsumedServiceInstances
        {
            get
            {
                try
                {
                    var result = new List<AsrConsumedServiceInstance>();
                    foreach (var m in Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE)
                    {
                        result.Add(new AsrConsumedServiceInstance(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrConsumedServiceInstance>();
                }
            }
        }
        
        public void AddConsumedServiceInstances(AsrConsumedServiceInstance data)
        {
            if (Model.CONSUMEDSERVICEINSTANCES == null)
            {
                Model.CONSUMEDSERVICEINSTANCES = new ();
            }
            if (Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE == null)
            {
                Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE = new List<CONSUMEDSERVICEINSTANCE>();
            }
            foreach (var d in Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new CONSUMEDSERVICEINSTANCE();
            m = data.Model;
            Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE.Add(m);
        }
        
        public void DelConsumedServiceInstances(AsrConsumedServiceInstance data)
        {
            if (Model.CONSUMEDSERVICEINSTANCES == null)
            {
                return;
            }
            if (Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE == null)
            {
                return;
            }
            foreach (var m in Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE)
            {
                if (m.Equals(data.Model))
                {
                    Model.CONSUMEDSERVICEINSTANCES.CONSUMEDSERVICEINSTANCE.Remove(m);
                    break;
                }
            }
        }
        public AsrTcpTpPort? TcpTpPort
        {
            get
            {
                try
                {
                    return new AsrTcpTpPort(Model.TPCONFIGURATION.TCPTP.TCPTPPORT, PathManager);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (Model.TPCONFIGURATION == null)
                {
                    Model.TPCONFIGURATION = new ();
                }
                if (Model.TPCONFIGURATION.TCPTP == null)
                {
                    Model.TPCONFIGURATION.TCPTP = new ();
                }
                if (value is not null)
                {
                    Model.TPCONFIGURATION.TCPTP.TCPTPPORT = value.Model;
                }
                else
                {
                    Model.TPCONFIGURATION.TCPTP.TCPTPPORT = null;
                }
            }
        }
        
        public AsrApplEndPoint(APPLICATIONENDPOINT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
