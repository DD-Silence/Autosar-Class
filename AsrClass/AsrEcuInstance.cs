using Autosar;

namespace AutosarClass
{
    public partial class AsrEcuInstance : IAsrIdentifier
    {
        public ECUINSTANCE Model { get; }
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
        
        public List<AsrReferenceInfo> AssociatedIPduGroupsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF)
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
        
        public void AddAssociatedIPduGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-I-PDU-GROUP")
            {
                if (Model.ASSOCIATEDCOMIPDUGROUPREFS == null)
                {
                    Model.ASSOCIATEDCOMIPDUGROUPREFS = new ();
                }
                if (Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF == null)
                {
                    Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF = new List<ECUINSTANCE.ASSOCIATEDCOMIPDUGROUPREFSLocalType.ASSOCIATEDCOMIPDUGROUPREFLocalType>();
                }
                var m = new ECUINSTANCE.ASSOCIATEDCOMIPDUGROUPREFSLocalType.ASSOCIATEDCOMIPDUGROUPREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelAssociatedIPduGroups(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-I-PDU-GROUP")
            {
                if (Model.ASSOCIATEDCOMIPDUGROUPREFS == null)
                {
                    return;
                }
                if (Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF == null)
                {
                    return;
                }
                foreach (var m in Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.ASSOCIATEDCOMIPDUGROUPREFS.ASSOCIATEDCOMIPDUGROUPREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrISignalIPduGroup> AssociatedIPduGroups
        {
            get
            {
                var result = new List<AsrISignalIPduGroup>();
                foreach (var r in AssociatedIPduGroupsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is ISIGNALIPDUGROUP mm)
                        {
                            var c = new AsrISignalIPduGroup(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public String SleepModeSupport
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SLEEPMODESUPPORTED.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (SleepModeSupport != value)
                {
                    if (Model.SLEEPMODESUPPORTED == null)
                    {
                        Model.SLEEPMODESUPPORTED = new ();
                    }
                    Model.SLEEPMODESUPPORTED.TypedValue = value;
                }
            }
        }
        
        public String WakeupOverBusSupport
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.WAKEUPOVERBUSSUPPORTED.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (WakeupOverBusSupport != value)
                {
                    if (Model.WAKEUPOVERBUSSUPPORTED == null)
                    {
                        Model.WAKEUPOVERBUSSUPPORTED = new ();
                    }
                    Model.WAKEUPOVERBUSSUPPORTED.TypedValue = value;
                }
            }
        }
        
        public AsrEcuInstance(ECUINSTANCE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
