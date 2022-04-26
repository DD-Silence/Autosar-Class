using Autosar;

namespace AutosarClass
{
    public partial class AsrISignalToIPduMapping : IAsrIdentifier
    {
        public ISIGNALTOIPDUMAPPING Model { get; }
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
        
        public String ByteOrder
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PACKINGBYTEORDER.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ByteOrder != value)
                {
                    if (Model.PACKINGBYTEORDER == null)
                    {
                        Model.PACKINGBYTEORDER = new ();
                    }
                    Model.PACKINGBYTEORDER.TypedValue = value;
                }
            }
        }
        
        public String StartPosition
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.STARTPOSITION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (StartPosition != value)
                {
                    if (Model.STARTPOSITION == null)
                    {
                        Model.STARTPOSITION = new ();
                    }
                    Model.STARTPOSITION.TypedValue = value;
                }
            }
        }
        
        public String TransferProperty
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.TRANSFERPROPERTY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (TransferProperty != value)
                {
                    if (Model.TRANSFERPROPERTY == null)
                    {
                        Model.TRANSFERPROPERTY = new ();
                    }
                    Model.TRANSFERPROPERTY.TypedValue = value;
                }
            }
        }
        
        public AsrISignalToIPduMapping(ISIGNALTOIPDUMAPPING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
