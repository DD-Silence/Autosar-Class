using Autosar;

namespace AutosarClass
{
    public partial class AsrRPortPrototype : IAsrIdentifier
    {
        public RPORTPROTOTYPE Model { get; }
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
        
        public String Category
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CATEGORY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Category != value)
                {
                    if (Model.CATEGORY == null)
                    {
                        Model.CATEGORY = new ();
                    }
                    Model.CATEGORY.TypedValue = value;
                }
            }
        }
        
        public AsrReferenceInfo? SRInterfaceRef
        {
            get
            {
                try
                {
                    if (Model.REQUIREDINTERFACETREF.DEST == "SENDER-RECEIVER-INTERFACE")
                    {
                        return PathManager.GetReferenceInfo(Model.REQUIREDINTERFACETREF);
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
                    if (value.AsrReferenceDest == "SENDER-RECEIVER-INTERFACE")
                    {
                        Model.REQUIREDINTERFACETREF.DEST = value.AsrReferenceDest;
                        Model.REQUIREDINTERFACETREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.REQUIREDINTERFACETREF = null;
                    }
                }
                else
                {
                    Model.REQUIREDINTERFACETREF = null;
                }
            }
        }
        
        public AsrSRInterface? SRInterface
        {
            get
            {
                try
                {
                    if (SRInterfaceRef is not null)
                    {
                        if (SRInterfaceRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(SRInterfaceRef.AsrPath);
                            if (m is SENDERRECEIVERINTERFACE mm)
                            {
                                return new AsrSRInterface(mm, PathManager);
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
        
        public AsrRPortPrototype(RPORTPROTOTYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
