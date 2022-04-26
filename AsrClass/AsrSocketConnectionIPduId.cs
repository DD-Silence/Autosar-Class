using Autosar;

namespace AutosarClass
{
    public partial class AsrSocketConnectionIPduId
    {
        public SOCKETCONNECTIONIPDUIDENTIFIER Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String HeaderId
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.HEADERID.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (HeaderId != value)
                {
                    if (Model.HEADERID == null)
                    {
                        Model.HEADERID = new ();
                    }
                    Model.HEADERID.TypedValue = value;
                }
            }
        }
        
        public AsrReferenceInfo? PduTriggeringRef
        {
            get
            {
                try
                {
                    if (Model.PDUTRIGGERINGREF.DEST == "PDU-TRIGGERING")
                    {
                        return PathManager.GetReferenceInfo(Model.PDUTRIGGERINGREF);
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
                    if (value.AsrReferenceDest == "PDU-TRIGGERING")
                    {
                        Model.PDUTRIGGERINGREF.DEST = value.AsrReferenceDest;
                        Model.PDUTRIGGERINGREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PDUTRIGGERINGREF = null;
                    }
                }
                else
                {
                    Model.PDUTRIGGERINGREF = null;
                }
            }
        }
        
        public AsrPduTriggering? PduTriggering
        {
            get
            {
                try
                {
                    if (PduTriggeringRef is not null)
                    {
                        if (PduTriggeringRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(PduTriggeringRef.AsrPath);
                            if (m is PDUTRIGGERING mm)
                            {
                                return new AsrPduTriggering(mm, PathManager);
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
                    Model.ROUTINGGROUPREFS.ROUTINGGROUPREF = new List<SOCKETCONNECTIONIPDUIDENTIFIER.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType>();
                }
                var m = new SOCKETCONNECTIONIPDUIDENTIFIER.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType();
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
        
        public AsrSocketConnectionIPduId(SOCKETCONNECTIONIPDUIDENTIFIER model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
