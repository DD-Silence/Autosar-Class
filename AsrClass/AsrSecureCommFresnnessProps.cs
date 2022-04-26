using Autosar;

namespace AutosarClass
{
    public partial class AsrSecureCommFresnnessProps : IAsrIdentifier
    {
        public SECURECOMMUNICATIONFRESHNESSPROPS Model { get; }
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
        
        public String FreshnessValueLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.FRESHNESSVALUELENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (FreshnessValueLength != value)
                {
                    if (Model.FRESHNESSVALUELENGTH == null)
                    {
                        Model.FRESHNESSVALUELENGTH = new ();
                    }
                    Model.FRESHNESSVALUELENGTH.TypedValue = value;
                }
            }
        }
        
        public String FreshnessValueTxLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.FRESHNESSVALUETXLENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (FreshnessValueTxLength != value)
                {
                    if (Model.FRESHNESSVALUETXLENGTH == null)
                    {
                        Model.FRESHNESSVALUETXLENGTH = new ();
                    }
                    Model.FRESHNESSVALUETXLENGTH.TypedValue = value;
                }
            }
        }
        
        public AsrSecureCommFresnnessProps(SECURECOMMUNICATIONFRESHNESSPROPS model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
