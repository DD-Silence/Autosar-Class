using Autosar;

namespace AutosarClass
{
    public partial class AsrProvidedServiceInstance : IAsrIdentifier
    {
        public PROVIDEDSERVICEINSTANCE Model { get; }
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
        
        public List<AsrReferenceInfo> RoutingGroupsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.ROUTINGGROUPREFS.ROUTINGGROUPREF)
                    {
                        var r = PathManager.GetReferenceInfo(m);
                        if (r is not null)
                        {
                            result.Add(r);
                        }
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrReferenceInfo>();
                }
            }
        }
        
        public void AddRoutingGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "SO-AD-ROUTING-GROUP")
            {
                if (Model.ROUTINGGROUPREFS == null)
                {
                    Model.ROUTINGGROUPREFS = new ();
                }
                if (Model.ROUTINGGROUPREFS.ROUTINGGROUPREF == null)
                {
                    Model.ROUTINGGROUPREFS.ROUTINGGROUPREF = new List<PROVIDEDSERVICEINSTANCE.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType>();
                }
                var m = new PROVIDEDSERVICEINSTANCE.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelRoutingGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "SO-AD-ROUTING-GROUP")
            {
                if (Model.ROUTINGGROUPREFS == null)
                {
                    return;
                }
                if (Model.ROUTINGGROUPREFS.ROUTINGGROUPREF == null)
                {
                    return;
                }
                foreach (var m in Model.ROUTINGGROUPREFS.ROUTINGGROUPREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.ROUTINGGROUPREFS.ROUTINGGROUPREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrSoAdRoutingGroup> RoutingGroups
        {
            get
            {
                var result = new List<AsrSoAdRoutingGroup>();
                foreach (var r in RoutingGroupsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is SOADROUTINGGROUP mm)
                        {
                            var c = new AsrSoAdRoutingGroup(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public List<AsrEventHandler> EventHandlers
        {
            get
            {
                try
                {
                    var result = new List<AsrEventHandler>();
                    foreach (var m in Model.EVENTHANDLERS.EVENTHANDLER)
                    {
                        result.Add(new AsrEventHandler(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrEventHandler>();
                }
            }
        }
        
        public void AddEventHandlers(AsrEventHandler data)
        {
            if (Model.EVENTHANDLERS == null)
            {
                Model.EVENTHANDLERS = new ();
            }
            if (Model.EVENTHANDLERS.EVENTHANDLER == null)
            {
                Model.EVENTHANDLERS.EVENTHANDLER = new List<EVENTHANDLER>();
            }
            foreach (var d in Model.EVENTHANDLERS.EVENTHANDLER)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new EVENTHANDLER();
            m = data.Model;
            Model.EVENTHANDLERS.EVENTHANDLER.Add(m);
        }
        
        public void DelEventHandlers(AsrEventHandler data)
        {
            if (Model.EVENTHANDLERS == null)
            {
                return;
            }
            if (Model.EVENTHANDLERS.EVENTHANDLER == null)
            {
                return;
            }
            foreach (var m in Model.EVENTHANDLERS.EVENTHANDLER)
            {
                if (m.Equals(data.Model))
                {
                    Model.EVENTHANDLERS.EVENTHANDLER.Remove(m);
                    break;
                }
            }
        }
        public String InstanceId
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INSTANCEIDENTIFIER.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (InstanceId != value)
                {
                    if (Model.INSTANCEIDENTIFIER == null)
                    {
                        Model.INSTANCEIDENTIFIER = new ();
                    }
                    Model.INSTANCEIDENTIFIER.TypedValue = value;
                }
            }
        }
        
        public AsrSdServerConfig? SdServerConfig
        {
            get
            {
                try
                {
                    return new AsrSdServerConfig(Model.SDSERVERCONFIG, PathManager);
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
                    Model.SDSERVERCONFIG = value.Model;
                }
                else
                {
                    Model.SDSERVERCONFIG = null;
                }
            }
        }
        
        public String ServiceId
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SERVICEIDENTIFIER.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ServiceId != value)
                {
                    if (Model.SERVICEIDENTIFIER == null)
                    {
                        Model.SERVICEIDENTIFIER = new ();
                    }
                    Model.SERVICEIDENTIFIER.TypedValue = value;
                }
            }
        }
        
        public AsrProvidedServiceInstance(PROVIDEDSERVICEINSTANCE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
