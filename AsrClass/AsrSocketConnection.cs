using Autosar;

namespace AutosarClass
{
    public partial class AsrSocketConnection
    {
        public SOCKETCONNECTION Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String AutosarConnector
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.AUTOSARCONNECTOR.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (AutosarConnector != value)
                {
                    if (Model.AUTOSARCONNECTOR == null)
                    {
                        Model.AUTOSARCONNECTOR = new ();
                    }
                    Model.AUTOSARCONNECTOR.TypedValue = value;
                }
            }
        }
        
        public AsrReferenceInfo? ClientPortRef
        {
            get
            {
                try
                {
                    if (Model.CLIENTPORTREF.DEST == "SOCKET-ADDRESS")
                    {
                        return PathManager.GetReferenceInfo(Model.CLIENTPORTREF);
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
                        Model.CLIENTPORTREF.DEST = value.AsrReferenceDest;
                        Model.CLIENTPORTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.CLIENTPORTREF = null;
                    }
                }
                else
                {
                    Model.CLIENTPORTREF = null;
                }
            }
        }
        
        public AsrSocketAddress? ClientPort
        {
            get
            {
                try
                {
                    if (ClientPortRef is not null)
                    {
                        if (ClientPortRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ClientPortRef.AsrPath);
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
        
        public List<AsrSocketConnectionIPduId> SocketConnectionIPduIds
        {
            get
            {
                try
                {
                    var result = new List<AsrSocketConnectionIPduId>();
                    foreach (var m in Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER)
                    {
                        result.Add(new AsrSocketConnectionIPduId(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSocketConnectionIPduId>();
                }
            }
        }
        
        public void AddSocketConnectionIPduIds(AsrSocketConnectionIPduId data)
        {
            if (Model.PDUS == null)
            {
                Model.PDUS = new ();
            }
            if (Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER == null)
            {
                Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER = new List<SOCKETCONNECTIONIPDUIDENTIFIER>();
            }
            foreach (var d in Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SOCKETCONNECTIONIPDUIDENTIFIER();
            m = data.Model;
            Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER.Add(m);
        }
        
        public void DelSocketConnectionIPduIds(AsrSocketConnectionIPduId data)
        {
            if (Model.PDUS == null)
            {
                return;
            }
            if (Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER == null)
            {
                return;
            }
            foreach (var m in Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER)
            {
                if (m.Equals(data.Model))
                {
                    Model.PDUS.SOCKETCONNECTIONIPDUIDENTIFIER.Remove(m);
                    break;
                }
            }
        }
        public AsrSocketConnection(SOCKETCONNECTION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
