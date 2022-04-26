using Autosar;

namespace AutosarClass
{
    public partial class AsrPortApiOption
    {
        public PORTAPIOPTION Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String EnableTakeAddress
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ENABLETAKEADDRESS.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (EnableTakeAddress != value)
                {
                    if (Model.ENABLETAKEADDRESS == null)
                    {
                        Model.ENABLETAKEADDRESS = new ();
                    }
                    Model.ENABLETAKEADDRESS.TypedValue = value;
                }
            }
        }
        
        public String IndirectApi
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INDIRECTAPI.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (IndirectApi != value)
                {
                    if (Model.INDIRECTAPI == null)
                    {
                        Model.INDIRECTAPI = new ();
                    }
                    Model.INDIRECTAPI.TypedValue = value;
                }
            }
        }
        
        public AsrReferenceInfo? PPortPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.PORTREF.DEST == "P-PORT-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.PORTREF);
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
                    if (value.AsrReferenceDest == "P-PORT-PROTOTYPE")
                    {
                        Model.PORTREF.DEST = value.AsrReferenceDest;
                        Model.PORTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PORTREF = null;
                    }
                }
                else
                {
                    Model.PORTREF = null;
                }
            }
        }
        
        public AsrPPortPrototype? PPortPrototype
        {
            get
            {
                try
                {
                    if (PPortPrototypeRef is not null)
                    {
                        if (PPortPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(PPortPrototypeRef.AsrPath);
                            if (m is PPORTPROTOTYPE mm)
                            {
                                return new AsrPPortPrototype(mm, PathManager);
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
        
        public AsrReferenceInfo? RPortPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.PORTREF.DEST == "R-PORT-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.PORTREF);
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
                    if (value.AsrReferenceDest == "R-PORT-PROTOTYPE")
                    {
                        Model.PORTREF.DEST = value.AsrReferenceDest;
                        Model.PORTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PORTREF = null;
                    }
                }
                else
                {
                    Model.PORTREF = null;
                }
            }
        }
        
        public AsrRPortPrototype? RPortPrototype
        {
            get
            {
                try
                {
                    if (RPortPrototypeRef is not null)
                    {
                        if (RPortPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(RPortPrototypeRef.AsrPath);
                            if (m is RPORTPROTOTYPE mm)
                            {
                                return new AsrRPortPrototype(mm, PathManager);
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
        
        public List<String> SupportBufferLocking
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.SUPPORTEDFEATURES.COMMUNICATIONBUFFERLOCKING)
                    {
                        result.Add(Convert.ToString(m.SUPPORTBUFFERLOCKING.TypedValue));
                    }
                    return result;
                }
                catch
                {
                    return new List<String>();
                }
            }
            set
            {
                if (Model.SUPPORTEDFEATURES == null)
                Model.SUPPORTEDFEATURES = new ();
                if (Model.SUPPORTEDFEATURES.COMMUNICATIONBUFFERLOCKING == null)
                Model.SUPPORTEDFEATURES.COMMUNICATIONBUFFERLOCKING = new List<COMMUNICATIONBUFFERLOCKING>();
                Model.SUPPORTEDFEATURES.COMMUNICATIONBUFFERLOCKING.Clear();
                foreach (var v in value)
                {
                    var m = new COMMUNICATIONBUFFERLOCKING();
                    m.SUPPORTBUFFERLOCKING.TypedValue = v;
                    Model.SUPPORTEDFEATURES.COMMUNICATIONBUFFERLOCKING.Add(m);
                }
            }
        }
        
        public AsrPortApiOption(PORTAPIOPTION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
