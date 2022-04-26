using Autosar;

namespace AutosarClass
{
    public partial class AsrCanFrame : IAsrIdentifier
    {
        public CANFRAME Model { get; }
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
                    return Convert.ToString(Model.FRAMELENGTH.TypedValue);
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
                    if (Model.FRAMELENGTH == null)
                    {
                        Model.FRAMELENGTH = new ();
                    }
                    Model.FRAMELENGTH.TypedValue = value;
                }
            }
        }
        
        public AsrCanFrame(CANFRAME model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
