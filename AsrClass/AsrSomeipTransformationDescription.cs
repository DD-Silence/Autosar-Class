using Autosar;

namespace AutosarClass
{
    public partial class AsrSomeipTransformationDescription
    {
        public SOMEIPTRANSFORMATIONDESCRIPTION Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String Alignment
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ALIGNMENT.TypedValue);
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
                    if (Model.ALIGNMENT == null)
                    {
                        Model.ALIGNMENT = new ();
                    }
                    Model.ALIGNMENT.TypedValue = value;
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
        
        public String InterfaceVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INTERFACEVERSION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (InterfaceVersion != value)
                {
                    if (Model.INTERFACEVERSION == null)
                    {
                        Model.INTERFACEVERSION = new ();
                    }
                    Model.INTERFACEVERSION.TypedValue = value;
                }
            }
        }
        
        public AsrSomeipTransformationDescription(SOMEIPTRANSFORMATIONDESCRIPTION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
