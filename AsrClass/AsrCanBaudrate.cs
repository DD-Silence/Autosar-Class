using Autosar;

namespace AutosarClass
{
    public partial class AsrCanBaudrate
    {
        public CANCONTROLLERCONFIGURATION Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String PropSeg
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PROPSEG.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (PropSeg != value)
                {
                    if (Model.PROPSEG == null)
                    {
                        Model.PROPSEG = new ();
                    }
                    Model.PROPSEG.TypedValue = value;
                }
            }
        }
        
        public String Seg1
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.TIMESEG1.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Seg1 != value)
                {
                    if (Model.TIMESEG1 == null)
                    {
                        Model.TIMESEG1 = new ();
                    }
                    Model.TIMESEG1.TypedValue = value;
                }
            }
        }
        
        public String Seg2
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.TIMESEG2.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Seg2 != value)
                {
                    if (Model.TIMESEG2 == null)
                    {
                        Model.TIMESEG2 = new ();
                    }
                    Model.TIMESEG2.TypedValue = value;
                }
            }
        }
        
        public String Sjw
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SYNCJUMPWIDTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Sjw != value)
                {
                    if (Model.SYNCJUMPWIDTH == null)
                    {
                        Model.SYNCJUMPWIDTH = new ();
                    }
                    Model.SYNCJUMPWIDTH.TypedValue = value;
                }
            }
        }
        
        public AsrCanFdBaudrate? Fd
        {
            get
            {
                try
                {
                    return new AsrCanFdBaudrate(Model.CANCONTROLLERFDATTRIBUTES, PathManager);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value is not null)
                {
                    Model.CANCONTROLLERFDATTRIBUTES = value.Model;
                }
                else
                {
                    Model.CANCONTROLLERFDATTRIBUTES = null;
                }
            }
        }
        
        public AsrCanBaudrate(CANCONTROLLERCONFIGURATION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
