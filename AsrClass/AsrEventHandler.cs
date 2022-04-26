using Autosar;

namespace AutosarClass
{
    public partial class AsrEventHandler : IAsrIdentifier
    {
        public EVENTHANDLER Model { get; }
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
        
        public AsrReferenceInfo? ApplEndPointRef
        {
            get
            {
                try
                {
                    if (Model.APPLICATIONENDPOINTREF.DEST == "APPLICATION-ENDPOINT")
                    {
                        return PathManager.GetReferenceInfo(Model.APPLICATIONENDPOINTREF);
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
                    if (value.AsrReferenceDest == "APPLICATION-ENDPOINT")
                    {
                        Model.APPLICATIONENDPOINTREF.DEST = value.AsrReferenceDest;
                        Model.APPLICATIONENDPOINTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.APPLICATIONENDPOINTREF = null;
                    }
                }
                else
                {
                    Model.APPLICATIONENDPOINTREF = null;
                }
            }
        }
        
        public AsrApplEndPoint? ApplEndPoint
        {
            get
            {
                try
                {
                    if (ApplEndPointRef is not null)
                    {
                        if (ApplEndPointRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ApplEndPointRef.AsrPath);
                            if (m is APPLICATIONENDPOINT mm)
                            {
                                return new AsrApplEndPoint(mm, PathManager);
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
        
        public List<AsrReferenceInfo> ConsumedEventGroupsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF)
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
        
        public void AddConsumedEventGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "CONSUMED-EVENT-GROUP")
            {
                if (Model.CONSUMEDEVENTGROUPREFS == null)
                {
                    Model.CONSUMEDEVENTGROUPREFS = new ();
                }
                if (Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF == null)
                {
                    Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF = new List<EVENTHANDLER.CONSUMEDEVENTGROUPREFSLocalType.CONSUMEDEVENTGROUPREFLocalType>();
                }
                var m = new EVENTHANDLER.CONSUMEDEVENTGROUPREFSLocalType.CONSUMEDEVENTGROUPREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelConsumedEventGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "CONSUMED-EVENT-GROUP")
            {
                if (Model.CONSUMEDEVENTGROUPREFS == null)
                {
                    return;
                }
                if (Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF == null)
                {
                    return;
                }
                foreach (var m in Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.CONSUMEDEVENTGROUPREFS.CONSUMEDEVENTGROUPREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrConsumedEventGroup> ConsumedEventGroups
        {
            get
            {
                var result = new List<AsrConsumedEventGroup>();
                foreach (var r in ConsumedEventGroupsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is CONSUMEDEVENTGROUP mm)
                        {
                            var c = new AsrConsumedEventGroup(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public String MulticastThreshold
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.MULTICASTTHRESHOLD.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (MulticastThreshold != value)
                {
                    if (Model.MULTICASTTHRESHOLD == null)
                    {
                        Model.MULTICASTTHRESHOLD = new ();
                    }
                    Model.MULTICASTTHRESHOLD.TypedValue = value;
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
                    Model.ROUTINGGROUPREFS.ROUTINGGROUPREF = new List<EVENTHANDLER.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType>();
                }
                var m = new EVENTHANDLER.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType();
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
        
        public AsrEventHandler(EVENTHANDLER model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
