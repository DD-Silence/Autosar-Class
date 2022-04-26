using Autosar;

namespace AutosarClass
{
    public partial class AsrConsumedEventGroup : IAsrIdentifier
    {
        public CONSUMEDEVENTGROUP Model { get; }
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
        
        public String EventGroupId
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.EVENTGROUPIDENTIFIER.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (EventGroupId != value)
                {
                    if (Model.EVENTGROUPIDENTIFIER == null)
                    {
                        Model.EVENTGROUPIDENTIFIER = new ();
                    }
                    Model.EVENTGROUPIDENTIFIER.TypedValue = value;
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
                    Model.ROUTINGGROUPREFS.ROUTINGGROUPREF = new List<CONSUMEDEVENTGROUP.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType>();
                }
                var m = new CONSUMEDEVENTGROUP.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType();
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
        
        public AsrSdClientConfig? SdClientConfig
        {
            get
            {
                try
                {
                    return new AsrSdClientConfig(Model.SDCLIENTCONFIG, PathManager);
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
                    Model.SDCLIENTCONFIG = value.Model;
                }
                else
                {
                    Model.SDCLIENTCONFIG = null;
                }
            }
        }
        
        public AsrConsumedEventGroup(CONSUMEDEVENTGROUP model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
