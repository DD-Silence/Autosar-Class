using Autosar;

namespace AutosarClass
{
    public partial class AsrApplArrayElement : IAsrIdentifier
    {
        public APPLICATIONARRAYELEMENT Model { get; }
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
        
        public String ArraSizeHandling
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ARRAYSIZEHANDLING.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ArraSizeHandling != value)
                {
                    if (Model.ARRAYSIZEHANDLING == null)
                    {
                        Model.ARRAYSIZEHANDLING = new ();
                    }
                    Model.ARRAYSIZEHANDLING.TypedValue = value;
                }
            }
        }
        
        public String ArraSizeSemantic
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ARRAYSIZESEMANTICS.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ArraSizeSemantic != value)
                {
                    if (Model.ARRAYSIZESEMANTICS == null)
                    {
                        Model.ARRAYSIZESEMANTICS = new ();
                    }
                    Model.ARRAYSIZESEMANTICS.TypedValue = value;
                }
            }
        }
        
        public String? MaxNumber
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.MAXNUMBEROFELEMENTS.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (MaxNumber != value)
                {
                    if (Model.MAXNUMBEROFELEMENTS == null)
                    {
                        Model.MAXNUMBEROFELEMENTS = new ();
                    }
                    if (value is null)
                    {
                        Model.MAXNUMBEROFELEMENTS = null;
                    }
                    else
                    {
                        Model.MAXNUMBEROFELEMENTS.Untyped.Value = value;
                    }
                }
            }
        }
        
        public AsrApplArrayElement(APPLICATIONARRAYELEMENT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
