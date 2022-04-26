using Autosar;

namespace AutosarClass
{
    public partial class AsrUnit : IAsrIdentifier
    {
        public UNIT Model { get; }
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
        
        public String? DisplayName
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DISPLAYNAME.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (DisplayName != value)
                {
                    if (Model.DISPLAYNAME == null)
                    {
                        Model.DISPLAYNAME = new ();
                    }
                    if (value is null)
                    {
                        Model.DISPLAYNAME = null;
                    }
                    else
                    {
                        Model.DISPLAYNAME.Untyped.Value = value;
                    }
                }
            }
        }
        
        public AsrUnit(UNIT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
