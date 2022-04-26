using Autosar;

namespace AutosarClass
{
    public partial class AsrISignalPort : IAsrIdentifier
    {
        public ISIGNALPORT Model { get; }
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
        
        public COMMUNICATIONDIRECTIONTYPESIMPLE CommDirection
        {
            get
            {
                try
                {
                    return Model.COMMUNICATIONDIRECTION.TypedValue;
                }
                catch
                {
                    return COMMUNICATIONDIRECTIONTYPESIMPLE.IN;
                }
            }
            set
            {
                if (CommDirection != value)
                {
                    if (Model.COMMUNICATIONDIRECTION == null)
                    {
                        Model.COMMUNICATIONDIRECTION = new ();
                    }
                    Model.COMMUNICATIONDIRECTION.TypedValue = value;
                }
            }
        }
        
        public AsrISignalPort(ISIGNALPORT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
