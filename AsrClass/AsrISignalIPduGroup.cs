using Autosar;

namespace AutosarClass
{
    public partial class AsrISignalIPduGroup : IAsrIdentifier
    {
        public ISIGNALIPDUGROUP Model { get; }
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
        
        public COMMUNICATIONDIRECTIONTYPESIMPLE CommDirection
        {
            get
            {
                try
                {
                    return Model.COMMUNICATIONDIRECTION.TypedValue;
                }
                catch
                {
                    return COMMUNICATIONDIRECTIONTYPESIMPLE.IN;
                }
            }
            set
            {
                if (CommDirection != value)
                {
                    if (Model.COMMUNICATIONDIRECTION == null)
                    {
                        Model.COMMUNICATIONDIRECTION = new ();
                    }
                    Model.COMMUNICATIONDIRECTION.TypedValue = value;
                }
            }
        }
        
        public List<AsrReferenceInfo> ISignalIPdusRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL)
                    {
                        var r = PathManager.GetReferenceInfo(m.ISIGNALIPDUREF);
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
        
        public void AddISignalIPdus(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-I-PDU")
            {
                if (Model.ISIGNALIPDUS == null)
                {
                    Model.ISIGNALIPDUS = new ();
                }
                if (Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL == null)
                {
                    Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL = new List<ISIGNALIPDUREFCONDITIONAL>();
                }
                var m = new ISIGNALIPDUREFCONDITIONAL();
                m.ISIGNALIPDUREF = new ();
                m.ISIGNALIPDUREF.DEST = reference.AsrReferenceDest;
                m.ISIGNALIPDUREF.TypedValue = reference.AsrReference;
                PathManager.AddReference(m.ISIGNALIPDUREF, reference);
            }
        }
        
        public void DelISignalIPdus(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-I-PDU")
            {
                if (Model.ISIGNALIPDUS == null)
                {
                    return;
                }
                if (Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL == null)
                {
                    return;
                }
                foreach (var m in Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL)
                {
                    if (m.ISIGNALIPDUREF.DEST == reference.AsrReferenceDest && m.ISIGNALIPDUREF.TypedValue == reference.AsrReference)
                    {
                        Model.ISIGNALIPDUS.ISIGNALIPDUREFCONDITIONAL.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrISignalIPdu> ISignalIPdus
        {
            get
            {
                var result = new List<AsrISignalIPdu>();
                foreach (var r in ISignalIPdusRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is ISIGNALIPDU mm)
                        {
                            var c = new AsrISignalIPdu(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrISignalIPduGroup(ISIGNALIPDUGROUP model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
