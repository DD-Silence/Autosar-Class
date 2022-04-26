using Autosar;

namespace AutosarClass
{
    public partial class AsrSwBaseType : IAsrIdentifier
    {
        public SWBASETYPE Model { get; }
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
        
        public String Size
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BASETYPESIZE.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Size != value)
                {
                    if (Model.BASETYPESIZE == null)
                    {
                        Model.BASETYPESIZE = new ();
                    }
                    Model.BASETYPESIZE.TypedValue = value;
                }
            }
        }
        
        public String Encoding
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BASETYPEENCODING.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Encoding != value)
                {
                    if (Model.BASETYPEENCODING == null)
                    {
                        Model.BASETYPEENCODING = new ();
                    }
                    Model.BASETYPEENCODING.TypedValue = value;
                }
            }
        }
        
        public String Alignment
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.MEMALIGNMENT.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Alignment != value)
                {
                    if (Model.MEMALIGNMENT == null)
                    {
                        Model.MEMALIGNMENT = new ();
                    }
                    Model.MEMALIGNMENT.TypedValue = value;
                }
            }
        }
        
        public String ByteOrder
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BYTEORDER.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (ByteOrder != value)
                {
                    if (Model.BYTEORDER == null)
                    {
                        Model.BYTEORDER = new ();
                    }
                    Model.BYTEORDER.TypedValue = value;
                }
            }
        }
        
        public AsrSwBaseType(SWBASETYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
