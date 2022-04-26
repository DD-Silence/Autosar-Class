using Autosar;

namespace AutosarClass
{
    public partial class AsrCanFdBaudrate
    {
        public CANCONTROLLERFDCONFIGURATION Model { get; }
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
        
        public Double TdcOffset
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.TRCVDELAYCOMPENSATIONOFFSET.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (TdcOffset != value)
                {
                    if (Model.TRCVDELAYCOMPENSATIONOFFSET == null)
                    {
                        Model.TRCVDELAYCOMPENSATIONOFFSET = new ();
                    }
                    Model.TRCVDELAYCOMPENSATIONOFFSET.TypedValue = value;
                }
            }
        }
        
        public String Brs
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.TXBITRATESWITCH.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (Brs != value)
                {
                    if (Model.TXBITRATESWITCH == null)
                    {
                        Model.TXBITRATESWITCH = new ();
                    }
                    Model.TXBITRATESWITCH.TypedValue = value;
                }
            }
        }
        
        public AsrCanFdBaudrate(CANCONTROLLERFDCONFIGURATION model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
