using Autosar;

namespace AutosarClass
{
    public partial class AsrEventTiming
    {
        public EVENTCONTROLLEDTIMING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public Double Period
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.REPETITIONPERIOD.VALUE.TypedValue);
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
                    if (Model.REPETITIONPERIOD == null)
                    {
                        Model.REPETITIONPERIOD = new ();
                    }
                    if (Model.REPETITIONPERIOD.VALUE == null)
                    {
                        Model.REPETITIONPERIOD.VALUE = new ();
                    }
                    Model.REPETITIONPERIOD.VALUE.TypedValue = value;
                }
            }
        }
        
        public String Repetition
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.NUMBEROFREPETITIONS.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Repetition != value)
                {
                    if (Model.NUMBEROFREPETITIONS == null)
                    {
                        Model.NUMBEROFREPETITIONS = new ();
                    }
                    Model.NUMBEROFREPETITIONS.TypedValue = value;
                }
            }
        }
        
        public AsrEventTiming(EVENTCONTROLLEDTIMING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
