using Autosar;

namespace AutosarClass
{
    public partial class AsrDataInternalConstraint
    {
        public INTERNALCONSTRS Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String? LowerLimit
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.LOWERLIMIT.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (LowerLimit != value)
                {
                    if (Model.LOWERLIMIT == null)
                    {
                        Model.LOWERLIMIT = new ();
                    }
                    if (value is null)
                    {
                        Model.LOWERLIMIT = null;
                    }
                    else
                    {
                        Model.LOWERLIMIT.Untyped.Value = value;
                    }
                }
            }
        }
        
        public INTERVALTYPEENUMSIMPLE? LowerLimitType
        {
            get
            {
                try
                {
                    return Model.LOWERLIMIT.INTERVALTYPE;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (LowerLimitType != value)
                {
                    if (Model.LOWERLIMIT == null)
                    {
                        Model.LOWERLIMIT = new ();
                    }
                    if (Model.LOWERLIMIT.INTERVALTYPE == null)
                    {
                        Model.LOWERLIMIT.INTERVALTYPE = new ();
                    }
                    if (value is null)
                    {
                        Model.LOWERLIMIT.INTERVALTYPE = null;
                    }
                    else
                    {
                        Model.LOWERLIMIT.INTERVALTYPE = value;
                    }
                }
            }
        }
        
        public String? UpperLimit
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.UPPERLIMIT.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (UpperLimit != value)
                {
                    if (Model.UPPERLIMIT == null)
                    {
                        Model.UPPERLIMIT = new ();
                    }
                    if (value is null)
                    {
                        Model.UPPERLIMIT = null;
                    }
                    else
                    {
                        Model.UPPERLIMIT.Untyped.Value = value;
                    }
                }
            }
        }
        
        public INTERVALTYPEENUMSIMPLE? UpperLimitType
        {
            get
            {
                try
                {
                    return Model.UPPERLIMIT.INTERVALTYPE;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (UpperLimitType != value)
                {
                    if (Model.UPPERLIMIT == null)
                    {
                        Model.UPPERLIMIT = new ();
                    }
                    if (Model.UPPERLIMIT.INTERVALTYPE == null)
                    {
                        Model.UPPERLIMIT.INTERVALTYPE = new ();
                    }
                    if (value is null)
                    {
                        Model.UPPERLIMIT.INTERVALTYPE = null;
                    }
                    else
                    {
                        Model.UPPERLIMIT.INTERVALTYPE = value;
                    }
                }
            }
        }
        
        public AsrDataInternalConstraint(INTERNALCONSTRS model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
