using Autosar;

namespace AutosarClass
{
    public partial class AsrDataTransformation : IAsrIdentifier
    {
        public DATATRANSFORMATION Model { get; }
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
        
        public String Kind
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DATATRANSFORMATIONKIND.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Kind != value)
                {
                    if (Model.DATATRANSFORMATIONKIND == null)
                    {
                        Model.DATATRANSFORMATIONKIND = new ();
                    }
                    Model.DATATRANSFORMATIONKIND.TypedValue = value;
                }
            }
        }
        
        public String ExecuteDespiteDataUnavailability
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.EXECUTEDESPITEDATAUNAVAILABILITY.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (ExecuteDespiteDataUnavailability != value)
                {
                    if (Model.EXECUTEDESPITEDATAUNAVAILABILITY == null)
                    {
                        Model.EXECUTEDESPITEDATAUNAVAILABILITY = new ();
                    }
                    Model.EXECUTEDESPITEDATAUNAVAILABILITY.TypedValue = value;
                }
            }
        }
        
        public List<AsrReferenceInfo> TranformerChainsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF)
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
        
        public void AddTranformerChains(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "TRANSFORMATION-TECHNOLOGY")
            {
                if (Model.TRANSFORMERCHAINREFS == null)
                {
                    Model.TRANSFORMERCHAINREFS = new ();
                }
                if (Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF == null)
                {
                    Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF = new List<DATATRANSFORMATION.TRANSFORMERCHAINREFSLocalType.TRANSFORMERCHAINREFLocalType>();
                }
                var m = new DATATRANSFORMATION.TRANSFORMERCHAINREFSLocalType.TRANSFORMERCHAINREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelTranformerChains(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "TRANSFORMATION-TECHNOLOGY")
            {
                if (Model.TRANSFORMERCHAINREFS == null)
                {
                    return;
                }
                if (Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF == null)
                {
                    return;
                }
                foreach (var m in Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.TRANSFORMERCHAINREFS.TRANSFORMERCHAINREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrTransformationTechnology> TranformerChains
        {
            get
            {
                var result = new List<AsrTransformationTechnology>();
                foreach (var r in TranformerChainsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is TRANSFORMATIONTECHNOLOGY mm)
                        {
                            var c = new AsrTransformationTechnology(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public AsrDataTransformation(DATATRANSFORMATION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
