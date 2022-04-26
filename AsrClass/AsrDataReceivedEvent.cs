using Autosar;

namespace AutosarClass
{
    public partial class AsrDataReceivedEvent : IAsrIdentifier
    {
        public DATARECEIVEDEVENT Model { get; }
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
        
        public AsrReferenceInfo? StartOnEventRef
        {
            get
            {
                try
                {
                    if (Model.STARTONEVENTREF.DEST == "RUNNABLE-ENTITY")
                    {
                        return PathManager.GetReferenceInfo(Model.STARTONEVENTREF);
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
                    if (value.AsrReferenceDest == "RUNNABLE-ENTITY")
                    {
                        Model.STARTONEVENTREF.DEST = value.AsrReferenceDest;
                        Model.STARTONEVENTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.STARTONEVENTREF = null;
                    }
                }
                else
                {
                    Model.STARTONEVENTREF = null;
                }
            }
        }
        
        public AsrRunnableEntity? StartOnEvent
        {
            get
            {
                try
                {
                    if (StartOnEventRef is not null)
                    {
                        if (StartOnEventRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(StartOnEventRef.AsrPath);
                            if (m is RUNNABLEENTITY mm)
                            {
                                return new AsrRunnableEntity(mm, PathManager);
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
        
        public AsrReferenceInfo? ContextRPortPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.DATAIREF.CONTEXTRPORTREF.DEST == "R-PORT-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.DATAIREF.CONTEXTRPORTREF);
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
                if (Model.DATAIREF == null)
                {
                    Model.DATAIREF = new ();
                }
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "R-PORT-PROTOTYPE")
                    {
                        Model.DATAIREF.CONTEXTRPORTREF.DEST = value.AsrReferenceDest;
                        Model.DATAIREF.CONTEXTRPORTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.DATAIREF.CONTEXTRPORTREF = null;
                    }
                }
                else
                {
                    Model.DATAIREF.CONTEXTRPORTREF = null;
                }
            }
        }
        
        public AsrRPortPrototype? ContextRPortPrototype
        {
            get
            {
                try
                {
                    if (ContextRPortPrototypeRef is not null)
                    {
                        if (ContextRPortPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ContextRPortPrototypeRef.AsrPath);
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
        
        public AsrReferenceInfo? TargetDataPrototypeRef
        {
            get
            {
                try
                {
                    if (Model.DATAIREF.TARGETDATAELEMENTREF.DEST == "VARIABLE-DATA-PROTOTYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.DATAIREF.TARGETDATAELEMENTREF);
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
                if (Model.DATAIREF == null)
                {
                    Model.DATAIREF = new ();
                }
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "VARIABLE-DATA-PROTOTYPE")
                    {
                        Model.DATAIREF.TARGETDATAELEMENTREF.DEST = value.AsrReferenceDest;
                        Model.DATAIREF.TARGETDATAELEMENTREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.DATAIREF.TARGETDATAELEMENTREF = null;
                    }
                }
                else
                {
                    Model.DATAIREF.TARGETDATAELEMENTREF = null;
                }
            }
        }
        
        public AsrVariableDataPrototype? TargetDataPrototype
        {
            get
            {
                try
                {
                    if (TargetDataPrototypeRef is not null)
                    {
                        if (TargetDataPrototypeRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(TargetDataPrototypeRef.AsrPath);
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
        
        public AsrDataReceivedEvent(DATARECEIVEDEVENT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
