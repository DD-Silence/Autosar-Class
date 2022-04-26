using Autosar;

namespace AutosarClass
{
    public partial class AsrImplDataTypeElement : IAsrIdentifier
    {
        public IMPLEMENTATIONDATATYPEELEMENT Model { get; }
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
        
        public String Category
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CATEGORY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Category != value)
                {
                    if (Model.CATEGORY == null)
                    {
                        Model.CATEGORY = new ();
                    }
                    Model.CATEGORY.TypedValue = value;
                }
            }
        }
        
        public String ArraySize
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CATEGORY.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ArraySize != value)
                {
                    if (Model.CATEGORY == null)
                    {
                        Model.CATEGORY = new ();
                    }
                    Model.CATEGORY.TypedValue = value;
                }
            }
        }
        
        public String ArraSizeHandling
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ARRAYSIZEHANDLING.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ArraSizeHandling != value)
                {
                    if (Model.ARRAYSIZEHANDLING == null)
                    {
                        Model.ARRAYSIZEHANDLING = new ();
                    }
                    Model.ARRAYSIZEHANDLING.TypedValue = value;
                }
            }
        }
        
        public String ArraSizeSemantic
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ARRAYSIZESEMANTICS.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ArraSizeSemantic != value)
                {
                    if (Model.ARRAYSIZESEMANTICS == null)
                    {
                        Model.ARRAYSIZESEMANTICS = new ();
                    }
                    Model.ARRAYSIZESEMANTICS.TypedValue = value;
                }
            }
        }
        
        public AsrImplDataTypeElement(IMPLEMENTATIONDATATYPEELEMENT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
