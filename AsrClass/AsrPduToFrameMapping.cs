using Autosar;

namespace AutosarClass
{
    public partial class AsrPduToFrameMapping : IAsrIdentifier
    {
        public PDUTOFRAMEMAPPING Model { get; }
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
        
        public AsrReferenceInfo? ISignalIPduRef
        {
            get
            {
                try
                {
                    if (Model.PDUREF.DEST == "I-SIGNAL-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.PDUREF);
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
                    if (value.AsrReferenceDest == "I-SIGNAL-I-PDU")
                    {
                        Model.PDUREF.DEST = value.AsrReferenceDest;
                        Model.PDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PDUREF = null;
                    }
                }
                else
                {
                    Model.PDUREF = null;
                }
            }
        }
        
        public AsrISignalIPdu? ISignalIPdu
        {
            get
            {
                try
                {
                    if (ISignalIPduRef is not null)
                    {
                        if (ISignalIPduRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ISignalIPduRef.AsrPath);
                            if (m is ISIGNALIPDU mm)
                            {
                                return new AsrISignalIPdu(mm, PathManager);
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
        
        public AsrReferenceInfo? SecuredIPduRef
        {
            get
            {
                try
                {
                    if (Model.PDUREF.DEST == "I-SIGNAL-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.PDUREF);
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
                    if (value.AsrReferenceDest == "I-SIGNAL-I-PDU")
                    {
                        Model.PDUREF.DEST = value.AsrReferenceDest;
                        Model.PDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PDUREF = null;
                    }
                }
                else
                {
                    Model.PDUREF = null;
                }
            }
        }
        
        public AsrISignalIPdu? SecuredIPdu
        {
            get
            {
                try
                {
                    if (SecuredIPduRef is not null)
                    {
                        if (SecuredIPduRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(SecuredIPduRef.AsrPath);
                            if (m is ISIGNALIPDU mm)
                            {
                                return new AsrISignalIPdu(mm, PathManager);
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
        
        public AsrReferenceInfo? DcmIPduRef
        {
            get
            {
                try
                {
                    if (Model.PDUREF.DEST == "DCM-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.PDUREF);
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
                    if (value.AsrReferenceDest == "DCM-I-PDU")
                    {
                        Model.PDUREF.DEST = value.AsrReferenceDest;
                        Model.PDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PDUREF = null;
                    }
                }
                else
                {
                    Model.PDUREF = null;
                }
            }
        }
        
        public AsrDcmIPdu? DcmIPdu
        {
            get
            {
                try
                {
                    if (DcmIPduRef is not null)
                    {
                        if (DcmIPduRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(DcmIPduRef.AsrPath);
                            if (m is DCMIPDU mm)
                            {
                                return new AsrDcmIPdu(mm, PathManager);
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
        
        public AsrPduToFrameMapping(PDUTOFRAMEMAPPING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
