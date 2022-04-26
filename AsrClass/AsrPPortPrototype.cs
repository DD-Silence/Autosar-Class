using Autosar;

namespace AutosarClass
{
    public partial class AsrPPortPrototype : IAsrIdentifier
    {
        public PPORTPROTOTYPE Model { get; }
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
                    if (Model.PROVIDEDINTERFACETREF.DEST == "SENDER-RECEIVER-INTERFACE")
                    {
                        return PathManager.GetReferenceInfo(Model.PROVIDEDINTERFACETREF);
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
                        Model.PROVIDEDINTERFACETREF.DEST = value.AsrReferenceDest;
                        Model.PROVIDEDINTERFACETREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.PROVIDEDINTERFACETREF = null;
                    }
                }
                else
                {
                    Model.PROVIDEDINTERFACETREF = null;
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
        
        public AsrPPortPrototype(PPORTPROTOTYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
