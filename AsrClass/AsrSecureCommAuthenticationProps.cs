using Autosar;

namespace AutosarClass
{
    public partial class AsrSecureCommAuthenticationProps : IAsrIdentifier
    {
        public SECURECOMMUNICATIONAUTHENTICATIONPROPS Model { get; }
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
        
        public String AuthInfoTxLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.AUTHINFOTXLENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (AuthInfoTxLength != value)
                {
                    if (Model.AUTHINFOTXLENGTH == null)
                    {
                        Model.AUTHINFOTXLENGTH = new ();
                    }
                    Model.AUTHINFOTXLENGTH.TypedValue = value;
                }
            }
        }
        
        public AsrSecureCommAuthenticationProps(SECURECOMMUNICATIONAUTHENTICATIONPROPS model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
