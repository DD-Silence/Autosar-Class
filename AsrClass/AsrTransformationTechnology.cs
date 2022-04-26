using Autosar;

namespace AutosarClass
{
    public partial class AsrTransformationTechnology : IAsrIdentifier
    {
        public TRANSFORMATIONTECHNOLOGY Model { get; }
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
        
        public String BufferHeadLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BUFFERPROPERTIES.HEADERLENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (BufferHeadLength != value)
                {
                    if (Model.BUFFERPROPERTIES == null)
                    {
                        Model.BUFFERPROPERTIES = new ();
                    }
                    if (Model.BUFFERPROPERTIES.HEADERLENGTH == null)
                    {
                        Model.BUFFERPROPERTIES.HEADERLENGTH = new ();
                    }
                    Model.BUFFERPROPERTIES.HEADERLENGTH.TypedValue = value;
                }
            }
        }
        
        public String BufferInPlace
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BUFFERPROPERTIES.INPLACE.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (BufferInPlace != value)
                {
                    if (Model.BUFFERPROPERTIES == null)
                    {
                        Model.BUFFERPROPERTIES = new ();
                    }
                    if (Model.BUFFERPROPERTIES.INPLACE == null)
                    {
                        Model.BUFFERPROPERTIES.INPLACE = new ();
                    }
                    Model.BUFFERPROPERTIES.INPLACE.TypedValue = value;
                }
            }
        }
        
        public String Protocol
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PROTOCOL.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Protocol != value)
                {
                    if (Model.PROTOCOL == null)
                    {
                        Model.PROTOCOL = new ();
                    }
                    Model.PROTOCOL.TypedValue = value;
                }
            }
        }
        
        public TRANSFORMERCLASSENUMSIMPLE TransformerClass
        {
            get
            {
                try
                {
                    return Model.TRANSFORMERCLASS.TypedValue;
                }
                catch
                {
                    return TRANSFORMERCLASSENUMSIMPLE.SERIALIZER;
                }
            }
            set
            {
                if (TransformerClass != value)
                {
                    if (Model.TRANSFORMERCLASS == null)
                    {
                        Model.TRANSFORMERCLASS = new ();
                    }
                    Model.TRANSFORMERCLASS.TypedValue = value;
                }
            }
        }
        
        public String Version
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.VERSION.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Version != value)
                {
                    if (Model.VERSION == null)
                    {
                        Model.VERSION = new ();
                    }
                    Model.VERSION.TypedValue = value;
                }
            }
        }
        
        public AsrTransformationTechnology(TRANSFORMATIONTECHNOLOGY model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
