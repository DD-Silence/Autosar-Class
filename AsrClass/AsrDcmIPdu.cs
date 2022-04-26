using Autosar;

namespace AutosarClass
{
    public partial class AsrDcmIPdu : IAsrIdentifier
    {
        public DCMIPDU Model { get; }
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
        
        public String Length
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.LENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Length != value)
                {
                    if (Model.LENGTH == null)
                    {
                        Model.LENGTH = new ();
                    }
                    Model.LENGTH.TypedValue = value;
                }
            }
        }
        
        public String DiagPduType
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DIAGPDUTYPE.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (DiagPduType != value)
                {
                    if (Model.DIAGPDUTYPE == null)
                    {
                        Model.DIAGPDUTYPE = new ();
                    }
                    Model.DIAGPDUTYPE.TypedValue = value;
                }
            }
        }
        
        public AsrDcmIPdu(DCMIPDU model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
