using Autosar;

namespace AutosarClass
{
    public partial class AsrSdServerConfig
    {
        public SDSERVERCONFIG Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public Double InitialDelayMaxValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALOFFERBEHAVIOR.INITIALDELAYMAXVALUE.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (InitialDelayMaxValue != value)
                {
                    if (Model.INITIALOFFERBEHAVIOR == null)
                    {
                        Model.INITIALOFFERBEHAVIOR = new ();
                    }
                    if (Model.INITIALOFFERBEHAVIOR.INITIALDELAYMAXVALUE == null)
                    {
                        Model.INITIALOFFERBEHAVIOR.INITIALDELAYMAXVALUE = new ();
                    }
                    Model.INITIALOFFERBEHAVIOR.INITIALDELAYMAXVALUE.TypedValue = value;
                }
            }
        }
        
        public Double InitialDelayMinValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALOFFERBEHAVIOR.INITIALDELAYMINVALUE.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (InitialDelayMinValue != value)
                {
                    if (Model.INITIALOFFERBEHAVIOR == null)
                    {
                        Model.INITIALOFFERBEHAVIOR = new ();
                    }
                    if (Model.INITIALOFFERBEHAVIOR.INITIALDELAYMINVALUE == null)
                    {
                        Model.INITIALOFFERBEHAVIOR.INITIALDELAYMINVALUE = new ();
                    }
                    Model.INITIALOFFERBEHAVIOR.INITIALDELAYMINVALUE.TypedValue = value;
                }
            }
        }
        
        public Double InitialRepeBaseDelay
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSBASEDELAY.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (InitialRepeBaseDelay != value)
                {
                    if (Model.INITIALOFFERBEHAVIOR == null)
                    {
                        Model.INITIALOFFERBEHAVIOR = new ();
                    }
                    if (Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSBASEDELAY == null)
                    {
                        Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSBASEDELAY = new ();
                    }
                    Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSBASEDELAY.TypedValue = value;
                }
            }
        }
        
        public String InitialRepeMax
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSMAX.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (InitialRepeMax != value)
                {
                    if (Model.INITIALOFFERBEHAVIOR == null)
                    {
                        Model.INITIALOFFERBEHAVIOR = new ();
                    }
                    if (Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSMAX == null)
                    {
                        Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSMAX = new ();
                    }
                    Model.INITIALOFFERBEHAVIOR.INITIALREPETITIONSMAX.TypedValue = value;
                }
            }
        }
        
        public Double OfferCycleDelay
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.OFFERCYCLICDELAY.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (OfferCycleDelay != value)
                {
                    if (Model.OFFERCYCLICDELAY == null)
                    {
                        Model.OFFERCYCLICDELAY = new ();
                    }
                    Model.OFFERCYCLICDELAY.TypedValue = value;
                }
            }
        }
        
        public Double RequestResponseDelayMax
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.REQUESTRESPONSEDELAY.MAXVALUE.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (RequestResponseDelayMax != value)
                {
                    if (Model.REQUESTRESPONSEDELAY == null)
                    {
                        Model.REQUESTRESPONSEDELAY = new ();
                    }
                    if (Model.REQUESTRESPONSEDELAY.MAXVALUE == null)
                    {
                        Model.REQUESTRESPONSEDELAY.MAXVALUE = new ();
                    }
                    Model.REQUESTRESPONSEDELAY.MAXVALUE.TypedValue = value;
                }
            }
        }
        
        public Double RequestResponseDelayMin
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.REQUESTRESPONSEDELAY.MINVALUE.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (RequestResponseDelayMin != value)
                {
                    if (Model.REQUESTRESPONSEDELAY == null)
                    {
                        Model.REQUESTRESPONSEDELAY = new ();
                    }
                    if (Model.REQUESTRESPONSEDELAY.MINVALUE == null)
                    {
                        Model.REQUESTRESPONSEDELAY.MINVALUE = new ();
                    }
                    Model.REQUESTRESPONSEDELAY.MINVALUE.TypedValue = value;
                }
            }
        }
        
        public String ServerServiceMajorVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SERVERSERVICEMAJORVERSION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ServerServiceMajorVersion != value)
                {
                    if (Model.SERVERSERVICEMAJORVERSION == null)
                    {
                        Model.SERVERSERVICEMAJORVERSION = new ();
                    }
                    Model.SERVERSERVICEMAJORVERSION.TypedValue = value;
                }
            }
        }
        
        public String ServerServiceMinorVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SERVERSERVICEMINORVERSION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ServerServiceMinorVersion != value)
                {
                    if (Model.SERVERSERVICEMINORVERSION == null)
                    {
                        Model.SERVERSERVICEMINORVERSION = new ();
                    }
                    Model.SERVERSERVICEMINORVERSION.TypedValue = value;
                }
            }
        }
        
        public String Ttl
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.TTL.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Ttl != value)
                {
                    if (Model.TTL == null)
                    {
                        Model.TTL = new ();
                    }
                    Model.TTL.TypedValue = value;
                }
            }
        }
        
        public AsrSdServerConfig(SDSERVERCONFIG model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
