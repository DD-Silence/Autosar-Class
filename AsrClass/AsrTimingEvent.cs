using Autosar;

namespace AutosarClass
{
    public partial class AsrTimingEvent : IAsrIdentifier
    {
        public TIMINGEVENT Model { get; }
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
        
        public Double Period
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.PERIOD.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (Period != value)
                {
                    if (Model.PERIOD == null)
                    {
                        Model.PERIOD = new ();
                    }
                    Model.PERIOD.TypedValue = value;
                }
            }
        }
        
        public AsrTimingEvent(TIMINGEVENT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
