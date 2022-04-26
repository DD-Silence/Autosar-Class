using Autosar;

namespace AutosarClass
{
    public partial class AsrApplRecordElement : IAsrIdentifier
    {
        public APPLICATIONRECORDELEMENT Model { get; }
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
        
        public AsrReferenceInfo? PrimitiveTypeRef
        {
            get
            {
                try
                {
                    if (Model.TYPETREF.DEST == "APPLICATION-PRIMITIVE-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.TYPETREF);
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
                    if (value.AsrReferenceDest == "APPLICATION-PRIMITIVE-DATA-TYPE")
                    {
                        Model.TYPETREF.DEST = value.AsrReferenceDest;
                        Model.TYPETREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.TYPETREF = null;
                    }
                }
                else
                {
                    Model.TYPETREF = null;
                }
            }
        }
        
        public AsrApplPrimitiveDataType? PrimitiveType
        {
            get
            {
                try
                {
                    if (PrimitiveTypeRef is not null)
                    {
                        if (PrimitiveTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(PrimitiveTypeRef.AsrPath);
                            if (m is APPLICATIONPRIMITIVEDATATYPE mm)
                            {
                                return new AsrApplPrimitiveDataType(mm, PathManager);
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
        
        public AsrReferenceInfo? ArrayTypeRef
        {
            get
            {
                try
                {
                    if (Model.TYPETREF.DEST == "APPLICATION-ARRAY-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.TYPETREF);
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
                    if (value.AsrReferenceDest == "APPLICATION-ARRAY-DATA-TYPE")
                    {
                        Model.TYPETREF.DEST = value.AsrReferenceDest;
                        Model.TYPETREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.TYPETREF = null;
                    }
                }
                else
                {
                    Model.TYPETREF = null;
                }
            }
        }
        
        public AsrApplArrayDataType? ArrayType
        {
            get
            {
                try
                {
                    if (ArrayTypeRef is not null)
                    {
                        if (ArrayTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ArrayTypeRef.AsrPath);
                            if (m is APPLICATIONARRAYDATATYPE mm)
                            {
                                return new AsrApplArrayDataType(mm, PathManager);
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
        
        public AsrApplRecordElement(APPLICATIONRECORDELEMENT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
