using Autosar;

namespace AutosarClass
{
    public partial class AsrCanFrameTriggering : IAsrIdentifier
    {
        public CANFRAMETRIGGERING Model { get; }
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
        
        public List<AsrReferenceInfo> FramePortsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.FRAMEPORTREFS.FRAMEPORTREF)
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
        
        public void AddFramePorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "FRAME-PORT")
            {
                if (Model.FRAMEPORTREFS == null)
                {
                    Model.FRAMEPORTREFS = new ();
                }
                if (Model.FRAMEPORTREFS.FRAMEPORTREF == null)
                {
                    Model.FRAMEPORTREFS.FRAMEPORTREF = new List<CANFRAMETRIGGERING.FRAMEPORTREFSLocalType.FRAMEPORTREFLocalType>();
                }
                var m = new CANFRAMETRIGGERING.FRAMEPORTREFSLocalType.FRAMEPORTREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelFramePorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "FRAME-PORT")
            {
                if (Model.FRAMEPORTREFS == null)
                {
                    return;
                }
                if (Model.FRAMEPORTREFS.FRAMEPORTREF == null)
                {
                    return;
                }
                foreach (var m in Model.FRAMEPORTREFS.FRAMEPORTREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.FRAMEPORTREFS.FRAMEPORTREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrFramePort> FramePorts
        {
            get
            {
                var result = new List<AsrFramePort>();
                foreach (var r in FramePortsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is FRAMEPORT mm)
                        {
                            var c = new AsrFramePort(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrReferenceInfo? CanFrameRef
        {
            get
            {
                try
                {
                    if (Model.FRAMEREF.DEST == "CAN-FRAME")
                    {
                        return PathManager.GetReferenceInfo(Model.FRAMEREF);
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
                    if (value.AsrReferenceDest == "CAN-FRAME")
                    {
                        Model.FRAMEREF.DEST = value.AsrReferenceDest;
                        Model.FRAMEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.FRAMEREF = null;
                    }
                }
                else
                {
                    Model.FRAMEREF = null;
                }
            }
        }
        
        public AsrCanFrame? CanFrame
        {
            get
            {
                try
                {
                    if (CanFrameRef is not null)
                    {
                        if (CanFrameRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(CanFrameRef.AsrPath);
                            if (m is CANFRAME mm)
                            {
                                return new AsrCanFrame(mm, PathManager);
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
        
        public CANADDRESSINGMODETYPESIMPLE CanAddressingMode
        {
            get
            {
                try
                {
                    return Model.CANADDRESSINGMODE.TypedValue;
                }
                catch
                {
                    return CANADDRESSINGMODETYPESIMPLE.STANDARD;
                }
            }
            set
            {
                if (CanAddressingMode != value)
                {
                    if (Model.CANADDRESSINGMODE == null)
                    {
                        Model.CANADDRESSINGMODE = new ();
                    }
                    Model.CANADDRESSINGMODE.TypedValue = value;
                }
            }
        }
        
        public String FrameRxBehavior
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CANFRAMERXBEHAVIOR.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (FrameRxBehavior != value)
                {
                    if (Model.CANFRAMERXBEHAVIOR == null)
                    {
                        Model.CANFRAMERXBEHAVIOR = new ();
                    }
                    Model.CANFRAMERXBEHAVIOR.TypedValue = value;
                }
            }
        }
        
        public String FrameTxBehavior
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CANFRAMETXBEHAVIOR.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (FrameTxBehavior != value)
                {
                    if (Model.CANFRAMETXBEHAVIOR == null)
                    {
                        Model.CANFRAMETXBEHAVIOR = new ();
                    }
                    Model.CANFRAMETXBEHAVIOR.TypedValue = value;
                }
            }
        }
        
        public String Id
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.IDENTIFIER.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Id != value)
                {
                    if (Model.IDENTIFIER == null)
                    {
                        Model.IDENTIFIER = new ();
                    }
                    Model.IDENTIFIER.TypedValue = value;
                }
            }
        }
        
        public AsrCanFrameTriggering(CANFRAMETRIGGERING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
