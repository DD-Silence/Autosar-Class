using Autosar;

namespace AutosarClass
{
    public partial class  AsrISignalTriggering : IAsrIdentifier
    {
        public ISIGNALTRIGGERING Model { get; }
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
        
        public List<AsrReferenceInfo> ISignalPortsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.ISIGNALPORTREFS.ISIGNALPORTREF)
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
        
        public void AddISignalPorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-PORT")
            {
                if (Model.ISIGNALPORTREFS == null)
                {
                    Model.ISIGNALPORTREFS = new ();
                }
                if (Model.ISIGNALPORTREFS.ISIGNALPORTREF == null)
                {
                    Model.ISIGNALPORTREFS.ISIGNALPORTREF = new List<ISIGNALTRIGGERING.ISIGNALPORTREFSLocalType.ISIGNALPORTREFLocalType>();
                }
                var m = new ISIGNALTRIGGERING.ISIGNALPORTREFSLocalType.ISIGNALPORTREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelISignalPorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-PORT")
            {
                if (Model.ISIGNALPORTREFS == null)
                {
                    return;
                }
                if (Model.ISIGNALPORTREFS.ISIGNALPORTREF == null)
                {
                    return;
                }
                foreach (var m in Model.ISIGNALPORTREFS.ISIGNALPORTREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.ISIGNALPORTREFS.ISIGNALPORTREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrISignalPort> ISignalPorts
        {
            get
            {
                var result = new List<AsrISignalPort>();
                foreach (var r in ISignalPortsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is ISIGNALPORT mm)
                        {
                            var c = new AsrISignalPort(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrReferenceInfo? ISignalRef
        {
            get
            {
                try
                {
                    if (Model.ISIGNALREF.DEST == "I-SIGNAL")
                    {
                        return PathManager.GetReferenceInfo(Model.ISIGNALREF);
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
                    if (value.AsrReferenceDest == "I-SIGNAL")
                    {
                        Model.ISIGNALREF.DEST = value.AsrReferenceDest;
                        Model.ISIGNALREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.ISIGNALREF = null;
                    }
                }
                else
                {
                    Model.ISIGNALREF = null;
                }
            }
        }
        
        public AsrISignal? ISignal
        {
            get
            {
                try
                {
                    if (ISignalRef is not null)
                    {
                        if (ISignalRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ISignalRef.AsrPath);
                            if (m is ISIGNAL mm)
                            {
                                return new AsrISignal(mm, PathManager);
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
        
        public  AsrISignalTriggering(ISIGNALTRIGGERING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
