using Autosar;

namespace AutosarClass
{
    public partial class AsrEthernetPhysicalChannel : IAsrIdentifier
    {
        public ETHERNETPHYSICALCHANNEL Model { get; }
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
        
        public String Category
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CATEGORY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Category != value)
                {
                    if (Model.CATEGORY == null)
                    {
                        Model.CATEGORY = new ();
                    }
                    Model.CATEGORY.TypedValue = value;
                }
            }
        }
        
        public List<AsrISignalTriggering> ISignalTriggerings
        {
            get
            {
                try
                {
                    var result = new List<AsrISignalTriggering>();
                    foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
                    {
                        result.Add(new AsrISignalTriggering(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrISignalTriggering>();
                }
            }
        }
        
        public void AddISignalTriggerings(AsrISignalTriggering data)
        {
            if (Model.ISIGNALTRIGGERINGS == null)
            {
                Model.ISIGNALTRIGGERINGS = new ();
            }
            if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING == null)
            {
                Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING = new List<ISIGNALTRIGGERING>();
            }
            foreach (var d in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ISIGNALTRIGGERING();
            m = data.Model;
            Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING.Add(m);
        }
        
        public void DelISignalTriggerings(AsrISignalTriggering data)
        {
            if (Model.ISIGNALTRIGGERINGS == null)
            {
                return;
            }
            if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING == null)
            {
                return;
            }
            foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
            {
                if (m.Equals(data.Model))
                {
                    Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrPduTriggering> PduTriggerings
        {
            get
            {
                try
                {
                    var result = new List<AsrPduTriggering>();
                    foreach (var m in Model.PDUTRIGGERINGS.PDUTRIGGERING)
                    {
                        result.Add(new AsrPduTriggering(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrPduTriggering>();
                }
            }
        }
        
        public void AddPduTriggerings(AsrPduTriggering data)
        {
            if (Model.PDUTRIGGERINGS == null)
            {
                Model.PDUTRIGGERINGS = new ();
            }
            if (Model.PDUTRIGGERINGS.PDUTRIGGERING == null)
            {
                Model.PDUTRIGGERINGS.PDUTRIGGERING = new List<PDUTRIGGERING>();
            }
            foreach (var d in Model.PDUTRIGGERINGS.PDUTRIGGERING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new PDUTRIGGERING();
            m = data.Model;
            Model.PDUTRIGGERINGS.PDUTRIGGERING.Add(m);
        }
        
        public void DelPduTriggerings(AsrPduTriggering data)
        {
            if (Model.PDUTRIGGERINGS == null)
            {
                return;
            }
            if (Model.PDUTRIGGERINGS.PDUTRIGGERING == null)
            {
                return;
            }
            foreach (var m in Model.PDUTRIGGERINGS.PDUTRIGGERING)
            {
                if (m.Equals(data.Model))
                {
                    Model.PDUTRIGGERINGS.PDUTRIGGERING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrNetworkEndPoint> NetworkEndPoints
        {
            get
            {
                try
                {
                    var result = new List<AsrNetworkEndPoint>();
                    foreach (var m in Model.NETWORKENDPOINTS.NETWORKENDPOINT)
                    {
                        result.Add(new AsrNetworkEndPoint(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrNetworkEndPoint>();
                }
            }
        }
        
        public void AddNetworkEndPoints(AsrNetworkEndPoint data)
        {
            if (Model.NETWORKENDPOINTS == null)
            {
                Model.NETWORKENDPOINTS = new ();
            }
            if (Model.NETWORKENDPOINTS.NETWORKENDPOINT == null)
            {
                Model.NETWORKENDPOINTS.NETWORKENDPOINT = new List<NETWORKENDPOINT>();
            }
            foreach (var d in Model.NETWORKENDPOINTS.NETWORKENDPOINT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new NETWORKENDPOINT();
            m = data.Model;
            Model.NETWORKENDPOINTS.NETWORKENDPOINT.Add(m);
        }
        
        public void DelNetworkEndPoints(AsrNetworkEndPoint data)
        {
            if (Model.NETWORKENDPOINTS == null)
            {
                return;
            }
            if (Model.NETWORKENDPOINTS.NETWORKENDPOINT == null)
            {
                return;
            }
            foreach (var m in Model.NETWORKENDPOINTS.NETWORKENDPOINT)
            {
                if (m.Equals(data.Model))
                {
                    Model.NETWORKENDPOINTS.NETWORKENDPOINT.Remove(m);
                    break;
                }
            }
        }
        public List<AsrSoAdSocketConnBundle> SoAdSocketConnBundles
        {
            get
            {
                try
                {
                    var result = new List<AsrSoAdSocketConnBundle>();
                    foreach (var m in Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE)
                    {
                        result.Add(new AsrSoAdSocketConnBundle(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSoAdSocketConnBundle>();
                }
            }
        }
        
        public void AddSoAdSocketConnBundles(AsrSoAdSocketConnBundle data)
        {
            if (Model.SOADCONFIG == null)
            {
                Model.SOADCONFIG = new ();
            }
            if (Model.SOADCONFIG.CONNECTIONBUNDLES == null)
            {
                Model.SOADCONFIG.CONNECTIONBUNDLES = new ();
            }
            if (Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE == null)
            {
                Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE = new List<SOCKETCONNECTIONBUNDLE>();
            }
            foreach (var d in Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SOCKETCONNECTIONBUNDLE();
            m = data.Model;
            Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE.Add(m);
        }
        
        public void DelSoAdSocketConnBundles(AsrSoAdSocketConnBundle data)
        {
            if (Model.SOADCONFIG == null)
            {
                return;
            }
            if (Model.SOADCONFIG.CONNECTIONBUNDLES == null)
            {
                return;
            }
            if (Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE == null)
            {
                return;
            }
            foreach (var m in Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE)
            {
                if (m.Equals(data.Model))
                {
                    Model.SOADCONFIG.CONNECTIONBUNDLES.SOCKETCONNECTIONBUNDLE.Remove(m);
                    break;
                }
            }
        }
        public List<AsrSocketAddress> SocketAddresses
        {
            get
            {
                try
                {
                    var result = new List<AsrSocketAddress>();
                    foreach (var m in Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS)
                    {
                        result.Add(new AsrSocketAddress(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSocketAddress>();
                }
            }
        }
        
        public void AddSocketAddresses(AsrSocketAddress data)
        {
            if (Model.SOADCONFIG == null)
            {
                Model.SOADCONFIG = new ();
            }
            if (Model.SOADCONFIG.SOCKETADDRESSS == null)
            {
                Model.SOADCONFIG.SOCKETADDRESSS = new ();
            }
            if (Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS == null)
            {
                Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS = new List<SOCKETADDRESS>();
            }
            foreach (var d in Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SOCKETADDRESS();
            m = data.Model;
            Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS.Add(m);
        }
        
        public void DelSocketAddresses(AsrSocketAddress data)
        {
            if (Model.SOADCONFIG == null)
            {
                return;
            }
            if (Model.SOADCONFIG.SOCKETADDRESSS == null)
            {
                return;
            }
            if (Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS == null)
            {
                return;
            }
            foreach (var m in Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS)
            {
                if (m.Equals(data.Model))
                {
                    Model.SOADCONFIG.SOCKETADDRESSS.SOCKETADDRESS.Remove(m);
                    break;
                }
            }
        }
        public AsrEthernetPhysicalChannel(ETHERNETPHYSICALCHANNEL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
