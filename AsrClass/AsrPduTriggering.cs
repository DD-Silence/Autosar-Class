using Autosar;

namespace AutosarClass
{
    public partial class AsrPduTriggering : IAsrIdentifier
    {
        public PDUTRIGGERING Model { get; }
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
        
        public List<AsrReferenceInfo> IPduPortsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.IPDUPORTREFS.IPDUPORTREF)
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
        
        public void AddIPduPorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-PDU-PORT")
            {
                if (Model.IPDUPORTREFS == null)
                {
                    Model.IPDUPORTREFS = new ();
                }
                if (Model.IPDUPORTREFS.IPDUPORTREF == null)
                {
                    Model.IPDUPORTREFS.IPDUPORTREF = new List<PDUTRIGGERING.IPDUPORTREFSLocalType.IPDUPORTREFLocalType>();
                }
                var m = new PDUTRIGGERING.IPDUPORTREFSLocalType.IPDUPORTREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelIPduPorts(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-PDU-PORT")
            {
                if (Model.IPDUPORTREFS == null)
                {
                    return;
                }
                if (Model.IPDUPORTREFS.IPDUPORTREF == null)
                {
                    return;
                }
                foreach (var m in Model.IPDUPORTREFS.IPDUPORTREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.IPDUPORTREFS.IPDUPORTREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrIPduPort> IPduPorts
        {
            get
            {
                var result = new List<AsrIPduPort>();
                foreach (var r in IPduPortsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is IPDUPORT mm)
                        {
                            var c = new AsrIPduPort(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrReferenceInfo? ISignalIPduRef
        {
            get
            {
                try
                {
                    if (Model.IPDUREF.DEST == "I-SIGNAL-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.IPDUREF);
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
                        Model.IPDUREF.DEST = value.AsrReferenceDest;
                        Model.IPDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.IPDUREF = null;
                    }
                }
                else
                {
                    Model.IPDUREF = null;
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
                    if (Model.IPDUREF.DEST == "SECURED-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.IPDUREF);
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
                        Model.IPDUREF.DEST = value.AsrReferenceDest;
                        Model.IPDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.IPDUREF = null;
                    }
                }
                else
                {
                    Model.IPDUREF = null;
                }
            }
        }
        
        public AsrSecuredIPdu? SecuredIPdu
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
        
        public AsrReferenceInfo? DcmIPduRef
        {
            get
            {
                try
                {
                    if (Model.IPDUREF.DEST == "DCM-I-PDU")
                    {
                        return PathManager.GetReferenceInfo(Model.IPDUREF);
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
                        Model.IPDUREF.DEST = value.AsrReferenceDest;
                        Model.IPDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.IPDUREF = null;
                    }
                }
                else
                {
                    Model.IPDUREF = null;
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
        
        public List<AsrReferenceInfo> ISignalTriggeringsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL)
                    {
                        var r = PathManager.GetReferenceInfo(m.ISIGNALTRIGGERINGREF);
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
        
        public void AddISignalTriggerings(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-TRIGGERING")
            {
                if (Model.ISIGNALTRIGGERINGS == null)
                {
                    Model.ISIGNALTRIGGERINGS = new ();
                }
                if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL == null)
                {
                    Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL = new List<ISIGNALTRIGGERINGREFCONDITIONAL>();
                }
                var m = new ISIGNALTRIGGERINGREFCONDITIONAL();
                m.ISIGNALTRIGGERINGREF = new ();
                m.ISIGNALTRIGGERINGREF.DEST = reference.AsrReferenceDest;
                m.ISIGNALTRIGGERINGREF.TypedValue = reference.AsrReference;
                PathManager.AddReference(m.ISIGNALTRIGGERINGREF, reference);
            }
        }
        
        public void DelISignalTriggerings(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "I-SIGNAL-TRIGGERING")
            {
                if (Model.ISIGNALTRIGGERINGS == null)
                {
                    return;
                }
                if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL == null)
                {
                    return;
                }
                foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL)
                {
                    if (m.ISIGNALTRIGGERINGREF.DEST == reference.AsrReferenceDest && m.ISIGNALTRIGGERINGREF.TypedValue == reference.AsrReference)
                    {
                        Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERINGREFCONDITIONAL.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrISignalTriggering> ISignalTriggerings
        {
            get
            {
                var result = new List<AsrISignalTriggering>();
                foreach (var r in ISignalTriggeringsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is ISIGNALTRIGGERING mm)
                        {
                            var c = new AsrISignalTriggering(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrPduTriggering(PDUTRIGGERING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
