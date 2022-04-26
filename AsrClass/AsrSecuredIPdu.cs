using Autosar;

namespace AutosarClass
{
    public partial class AsrSecuredIPdu : IAsrIdentifier
    {
        public SECUREDIPDU Model { get; }
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
        
        public String Length
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.LENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Length != value)
                {
                    if (Model.LENGTH == null)
                    {
                        Model.LENGTH = new ();
                    }
                    Model.LENGTH.TypedValue = value;
                }
            }
        }
        
        public AsrReferenceInfo? AuthenticationPropsRef
        {
            get
            {
                try
                {
                    if (Model.AUTHENTICATIONPROPSREF.DEST == "SECURED-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.AUTHENTICATIONPROPSREF);
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
                    if (value.AsrReferenceDest == "SECURED-I-PDU")
                    {
                        Model.AUTHENTICATIONPROPSREF.DEST = value.AsrReferenceDest;
                        Model.AUTHENTICATIONPROPSREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.AUTHENTICATIONPROPSREF = null;
                    }
                }
                else
                {
                    Model.AUTHENTICATIONPROPSREF = null;
                }
            }
        }
        
        public AsrSecuredIPdu? AuthenticationProps
        {
            get
            {
                try
                {
                    if (AuthenticationPropsRef is not null)
                    {
                        if (AuthenticationPropsRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(AuthenticationPropsRef.AsrPath);
                            if (m is SECUREDIPDU mm)
                            {
                                return new AsrSecuredIPdu(mm, PathManager);
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
        
        public AsrReferenceInfo? FreshnessPropsRef
        {
            get
            {
                try
                {
                    if (Model.FRESHNESSPROPSREF.DEST == "SECURE-COMMUNICATION-FRESHNESS-PROPS")
                    {
                        return PathManager.GetReferenceInfo(Model.FRESHNESSPROPSREF);
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
                    if (value.AsrReferenceDest == "SECURE-COMMUNICATION-FRESHNESS-PROPS")
                    {
                        Model.FRESHNESSPROPSREF.DEST = value.AsrReferenceDest;
                        Model.FRESHNESSPROPSREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.FRESHNESSPROPSREF = null;
                    }
                }
                else
                {
                    Model.FRESHNESSPROPSREF = null;
                }
            }
        }
        
        public AsrSecureCommFresnnessProps? FreshnessProps
        {
            get
            {
                try
                {
                    if (FreshnessPropsRef is not null)
                    {
                        if (FreshnessPropsRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(FreshnessPropsRef.AsrPath);
                            if (m is SECURECOMMUNICATIONFRESHNESSPROPS mm)
                            {
                                return new AsrSecureCommFresnnessProps(mm, PathManager);
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
        
        public AsrReferenceInfo? PayloadRef
        {
            get
            {
                try
                {
                    if (Model.PAYLOADREF.DEST == "PDU-TRIGGERING")
                    {
                        return PathManager.GetReferenceInfo(Model.PAYLOADREF);
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
                        Model.PAYLOADREF.DEST = value.AsrReferenceDest;
                        Model.PAYLOADREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PAYLOADREF = null;
                    }
                }
                else
                {
                    Model.PAYLOADREF = null;
                }
            }
        }
        
        public AsrPduTriggering? Payload
        {
            get
            {
                try
                {
                    if (PayloadRef is not null)
                    {
                        if (PayloadRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(PayloadRef.AsrPath);
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
        
        public String AuthInfoTxLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SECURECOMMUNICATIONPROPS.AUTHINFOTXLENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (AuthInfoTxLength != value)
                {
                    if (Model.SECURECOMMUNICATIONPROPS == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS = new ();
                    }
                    if (Model.SECURECOMMUNICATIONPROPS.AUTHINFOTXLENGTH == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS.AUTHINFOTXLENGTH = new ();
                    }
                    Model.SECURECOMMUNICATIONPROPS.AUTHINFOTXLENGTH.TypedValue = value;
                }
            }
        }
        
        public String DataId
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SECURECOMMUNICATIONPROPS.DATAID.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (DataId != value)
                {
                    if (Model.SECURECOMMUNICATIONPROPS == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS = new ();
                    }
                    if (Model.SECURECOMMUNICATIONPROPS.DATAID == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS.DATAID = new ();
                    }
                    Model.SECURECOMMUNICATIONPROPS.DATAID.TypedValue = value;
                }
            }
        }
        
        public String FreshnessValueLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUELENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (FreshnessValueLength != value)
                {
                    if (Model.SECURECOMMUNICATIONPROPS == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS = new ();
                    }
                    if (Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUELENGTH == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUELENGTH = new ();
                    }
                    Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUELENGTH.TypedValue = value;
                }
            }
        }
        
        public String FreshnessValueTxLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUETXLENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (FreshnessValueTxLength != value)
                {
                    if (Model.SECURECOMMUNICATIONPROPS == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS = new ();
                    }
                    if (Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUETXLENGTH == null)
                    {
                        Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUETXLENGTH = new ();
                    }
                    Model.SECURECOMMUNICATIONPROPS.FRESHNESSVALUETXLENGTH.TypedValue = value;
                }
            }
        }
        
        public AsrSecuredIPdu(SECUREDIPDU model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
