using Autosar;

namespace AutosarClass
{
    public partial class AsrVariableAccess : IAsrIdentifier
    {
        public VARIABLEACCESS Model { get; }
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
        
        public AsrReferenceInfo? AccessedRPortPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF.DEST == "R-PORT-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF);
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
                if (Model.ACCESSEDVARIABLE == null)
                {
                    Model.ACCESSEDVARIABLE = new ();
                }
                if (Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF == null)
                {
                    Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF = new ();
                }
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "R-PORT-PROTOTYPE")
                    {
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF.DEST = value.AsrReferenceDest;
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF = null;
                    }
                }
                else
                {
                    Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.PORTPROTOTYPEREF = null;
                }
            }
        }
        
        public AsrRPortPrototype? AccessedRPortPrototype
        {
            get
            {
                try
                {
                    if (AccessedRPortPrototypeRef is not null)
                    {
                        if (AccessedRPortPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(AccessedRPortPrototypeRef.AsrPath);
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
        
        public AsrReferenceInfo? AccessedTargetDataPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF.DEST == "VARIABLE-DATA-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF);
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
                if (Model.ACCESSEDVARIABLE == null)
                {
                    Model.ACCESSEDVARIABLE = new ();
                }
                if (Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF == null)
                {
                    Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF = new ();
                }
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "VARIABLE-DATA-PROTOTYPE")
                    {
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF.DEST = value.AsrReferenceDest;
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF = null;
                    }
                }
                else
                {
                    Model.ACCESSEDVARIABLE.AUTOSARVARIABLEIREF.TARGETDATAPROTOTYPEREF = null;
                }
            }
        }
        
        public AsrVariableDataPrototype? AccessedTargetDataPrototype
        {
            get
            {
                try
                {
                    if (AccessedTargetDataPrototypeRef is not null)
                    {
                        if (AccessedTargetDataPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(AccessedTargetDataPrototypeRef.AsrPath);
                            if (m is VARIABLEDATAPROTOTYPE mm)
                            {
                                return new AsrVariableDataPrototype(mm, PathManager);
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
        
        public AsrVariableAccess(VARIABLEACCESS model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
