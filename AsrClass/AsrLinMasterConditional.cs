using Autosar;

namespace AutosarClass
{
    public partial class AsrLinMasterConditional
    {
        public LINMASTERCONDITIONAL Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String ProtocolVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PROTOCOLVERSION.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ProtocolVersion != value)
                {
                    if (Model.PROTOCOLVERSION == null)
                    {
                        Model.PROTOCOLVERSION = new ();
                    }
                    Model.PROTOCOLVERSION.TypedValue = value;
                }
            }
        }
        
        public Double TimeBase
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.TIMEBASE.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (TimeBase != value)
                {
                    if (Model.TIMEBASE == null)
                    {
                        Model.TIMEBASE = new ();
                    }
                    Model.TIMEBASE.TypedValue = value;
                }
            }
        }
        
        public Double TimeBaseJitter
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.TIMEBASEJITTER.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (TimeBaseJitter != value)
                {
                    if (Model.TIMEBASEJITTER == null)
                    {
                        Model.TIMEBASEJITTER = new ();
                    }
                    Model.TIMEBASEJITTER.TypedValue = value;
                }
            }
        }
        
        public AsrLinMasterConditional(LINMASTERCONDITIONAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
