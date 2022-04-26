using Autosar;

namespace AutosarClass
{
    public partial class AsrConsumedServiceInstance : IAsrIdentifier
    {
        public CONSUMEDSERVICEINSTANCE Model { get; }
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
                    Model.ROUTINGGROUPREFS.ROUTINGGROUPREF = new List<CONSUMEDSERVICEINSTANCE.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType>();
                }
                var m = new CONSUMEDSERVICEINSTANCE.ROUTINGGROUPREFSLocalType.ROUTINGGROUPREFLocalType();
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
        
        public List<AsrConsumedEventGroup> EventGroups
        {
            get
            {
                try
                {
                    var result = new List<AsrConsumedEventGroup>();
                    foreach (var m in Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP)
                    {
                        result.Add(new AsrConsumedEventGroup(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrConsumedEventGroup>();
                }
            }
        }
        
        public void AddEventGroups(AsrConsumedEventGroup data)
        {
            if (Model.CONSUMEDEVENTGROUPS == null)
            {
                Model.CONSUMEDEVENTGROUPS = new ();
            }
            if (Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP == null)
            {
                Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP = new List<CONSUMEDEVENTGROUP>();
            }
            foreach (var d in Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new CONSUMEDEVENTGROUP();
            m = data.Model;
            Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP.Add(m);
        }
        
        public void DelEventGroups(AsrConsumedEventGroup data)
        {
            if (Model.CONSUMEDEVENTGROUPS == null)
            {
                return;
            }
            if (Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP == null)
            {
                return;
            }
            foreach (var m in Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP)
            {
                if (m.Equals(data.Model))
                {
                    Model.CONSUMEDEVENTGROUPS.CONSUMEDEVENTGROUP.Remove(m);
                    break;
                }
            }
        }
        public AsrReferenceInfo? ProvidedServiceInstanceRef
        {
            get
            {
                try
                {
                    if (Model.PROVIDEDSERVICEINSTANCEREF.DEST == "PROVIDED-SERVICE-INSTANCE")
                    {
                        return PathManager.GetReferenceInfo(Model.PROVIDEDSERVICEINSTANCEREF);
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
                    if (value.AsrReferenceDest == "PROVIDED-SERVICE-INSTANCE")
                    {
                        Model.PROVIDEDSERVICEINSTANCEREF.DEST = value.AsrReferenceDest;
                        Model.PROVIDEDSERVICEINSTANCEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PROVIDEDSERVICEINSTANCEREF = null;
                    }
                }
                else
                {
                    Model.PROVIDEDSERVICEINSTANCEREF = null;
                }
            }
        }
        
        public AsrProvidedServiceInstance? ProvidedServiceInstance
        {
            get
            {
                try
                {
                    if (ProvidedServiceInstanceRef is not null)
                    {
                        if (ProvidedServiceInstanceRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ProvidedServiceInstanceRef.AsrPath);
                            if (m is PROVIDEDSERVICEINSTANCE mm)
                            {
                                return new AsrProvidedServiceInstance(mm, PathManager);
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
        
        public AsrConsumedServiceInstance(CONSUMEDSERVICEINSTANCE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
