using Autosar;

namespace AutosarClass
{
    public partial class AsrDataTypeMap
    {
        public DATATYPEMAP Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrReferenceInfo? ApplRecordTypeRef
        {
            get
            {
                try
                {
                    if (Model.APPLICATIONDATATYPEREF.DEST == "APPLICATION-RECORD-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.APPLICATIONDATATYPEREF);
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
                    if (value.AsrReferenceDest == "APPLICATION-RECORD-DATA-TYPE")
                    {
                        Model.APPLICATIONDATATYPEREF.DEST = value.AsrReferenceDest;
                        Model.APPLICATIONDATATYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.APPLICATIONDATATYPEREF = null;
                    }
                }
                else
                {
                    Model.APPLICATIONDATATYPEREF = null;
                }
            }
        }
        
        public AsrApplRecordDataType? ApplRecordType
        {
            get
            {
                try
                {
                    if (ApplRecordTypeRef is not null)
                    {
                        if (ApplRecordTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ApplRecordTypeRef.AsrPath);
                            if (m is APPLICATIONRECORDDATATYPE mm)
                            {
                                return new AsrApplRecordDataType(mm, PathManager);
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
        
        public AsrReferenceInfo? ApplPrimitiveTypeRef
        {
            get
            {
                try
                {
                    if (Model.APPLICATIONDATATYPEREF.DEST == "APPLICATION-PRIMITIVE-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.APPLICATIONDATATYPEREF);
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
                        Model.APPLICATIONDATATYPEREF.DEST = value.AsrReferenceDest;
                        Model.APPLICATIONDATATYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.APPLICATIONDATATYPEREF = null;
                    }
                }
                else
                {
                    Model.APPLICATIONDATATYPEREF = null;
                }
            }
        }
        
        public AsrApplPrimitiveDataType? ApplPrimitiveType
        {
            get
            {
                try
                {
                    if (ApplPrimitiveTypeRef is not null)
                    {
                        if (ApplPrimitiveTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ApplPrimitiveTypeRef.AsrPath);
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
        
        public AsrReferenceInfo? ApplArrayTypeRef
        {
            get
            {
                try
                {
                    if (Model.APPLICATIONDATATYPEREF.DEST == "APPLICATION-PRIMITIVE-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.APPLICATIONDATATYPEREF);
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
                        Model.APPLICATIONDATATYPEREF.DEST = value.AsrReferenceDest;
                        Model.APPLICATIONDATATYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.APPLICATIONDATATYPEREF = null;
                    }
                }
                else
                {
                    Model.APPLICATIONDATATYPEREF = null;
                }
            }
        }
        
        public AsrApplPrimitiveDataType? ApplArrayType
        {
            get
            {
                try
                {
                    if (ApplArrayTypeRef is not null)
                    {
                        if (ApplArrayTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ApplArrayTypeRef.AsrPath);
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
        
        public AsrReferenceInfo? ImplTypeRef
        {
            get
            {
                try
                {
                    if (Model.IMPLEMENTATIONDATATYPEREF.DEST == "IMPLEMENTATION-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.IMPLEMENTATIONDATATYPEREF);
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
                    if (value.AsrReferenceDest == "IMPLEMENTATION-DATA-TYPE")
                    {
                        Model.IMPLEMENTATIONDATATYPEREF.DEST = value.AsrReferenceDest;
                        Model.IMPLEMENTATIONDATATYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.IMPLEMENTATIONDATATYPEREF = null;
                    }
                }
                else
                {
                    Model.IMPLEMENTATIONDATATYPEREF = null;
                }
            }
        }
        
        public AsrImplDataType? ImplType
        {
            get
            {
                try
                {
                    if (ImplTypeRef is not null)
                    {
                        if (ImplTypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ImplTypeRef.AsrPath);
                            if (m is IMPLEMENTATIONDATATYPE mm)
                            {
                                return new AsrImplDataType(mm, PathManager);
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
        
        public AsrDataTypeMap(DATATYPEMAP model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
