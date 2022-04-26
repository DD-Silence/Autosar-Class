using Autosar;

namespace AutosarClass
{
    public partial class AsrSoAdSocketConnBundle : IAsrIdentifier
    {
        public SOCKETCONNECTIONBUNDLE Model { get; }
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
        
        public List<AsrSocketConnection> SocketConnections
        {
            get
            {
                try
                {
                    var result = new List<AsrSocketConnection>();
                    foreach (var m in Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION)
                    {
                        result.Add(new AsrSocketConnection(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSocketConnection>();
                }
            }
        }
        
        public void AddSocketConnections(AsrSocketConnection data)
        {
            if (Model.BUNDLEDCONNECTIONS == null)
            {
                Model.BUNDLEDCONNECTIONS = new ();
            }
            if (Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION == null)
            {
                Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION = new List<SOCKETCONNECTION>();
            }
            foreach (var d in Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SOCKETCONNECTION();
            m = data.Model;
            Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION.Add(m);
        }
        
        public void DelSocketConnections(AsrSocketConnection data)
        {
            if (Model.BUNDLEDCONNECTIONS == null)
            {
                return;
            }
            if (Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION == null)
            {
                return;
            }
            foreach (var m in Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION)
            {
                if (m.Equals(data.Model))
                {
                    Model.BUNDLEDCONNECTIONS.SOCKETCONNECTION.Remove(m);
                    break;
                }
            }
        }
        public AsrReferenceInfo? ServerPortRef
        {
            get
            {
                try
                {
                    if (Model.SERVERPORTREF.DEST == "SOCKET-ADDRESS")
                    {
                        return PathManager.GetReferenceInfo(Model.SERVERPORTREF);
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
                    if (value.AsrReferenceDest == "SOCKET-ADDRESS")
                    {
                        Model.SERVERPORTREF.DEST = value.AsrReferenceDest;
                        Model.SERVERPORTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.SERVERPORTREF = null;
                    }
                }
                else
                {
                    Model.SERVERPORTREF = null;
                }
            }
        }
        
        public AsrSocketAddress? ServerPort
        {
            get
            {
                try
                {
                    if (ServerPortRef is not null)
                    {
                        if (ServerPortRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ServerPortRef.AsrPath);
                            if (m is SOCKETADDRESS mm)
                            {
                                return new AsrSocketAddress(mm, PathManager);
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
        
        public AsrSoAdSocketConnBundle(SOCKETCONNECTIONBUNDLE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
