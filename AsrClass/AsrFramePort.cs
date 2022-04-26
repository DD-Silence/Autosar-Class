using Autosar;

namespace AutosarClass
{
    public partial class AsrFramePort : IAsrIdentifier
    {
        public FRAMEPORT Model { get; }
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
        
        public COMMUNICATIONDIRECTIONTYPESIMPLE Direction
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
                if (Direction != value)
                {
                    if (Model.COMMUNICATIONDIRECTION == null)
                    {
                        Model.COMMUNICATIONDIRECTION = new ();
                    }
                    Model.COMMUNICATIONDIRECTION.TypedValue = value;
                }
            }
        }
        
        public AsrFramePort(FRAMEPORT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
