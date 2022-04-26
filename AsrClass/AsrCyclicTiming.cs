using Autosar;

namespace AutosarClass
{
    public partial class AsrCyclicTiming
    {
        public CYCLICTIMING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public Double Period
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.TIMEPERIOD.VALUE.TypedValue);
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
                    if (Model.TIMEPERIOD == null)
                    {
                        Model.TIMEPERIOD = new ();
                    }
                    if (Model.TIMEPERIOD.VALUE == null)
                    {
                        Model.TIMEPERIOD.VALUE = new ();
                    }
                    Model.TIMEPERIOD.VALUE.TypedValue = value;
                }
            }
        }
        
        public AsrCyclicTiming(CYCLICTIMING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
