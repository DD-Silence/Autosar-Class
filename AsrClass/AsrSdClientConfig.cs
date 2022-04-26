using Autosar;

namespace AutosarClass
{
    public partial class AsrSdClientConfig
    {
        public SDCLIENTCONFIG Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String ClientServiceMajorVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CLIENTSERVICEMAJORVERSION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ClientServiceMajorVersion != value)
                {
                    if (Model.CLIENTSERVICEMAJORVERSION == null)
                    {
                        Model.CLIENTSERVICEMAJORVERSION = new ();
                    }
                    Model.CLIENTSERVICEMAJORVERSION.TypedValue = value;
                }
            }
        }
        
        public String ClientServiceMinorVersion
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CLIENTSERVICEMINORVERSION.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (ClientServiceMinorVersion != value)
                {
                    if (Model.CLIENTSERVICEMINORVERSION == null)
                    {
                        Model.CLIENTSERVICEMINORVERSION = new ();
                    }
                    Model.CLIENTSERVICEMINORVERSION.TypedValue = value;
                }
            }
        }
        
        public Double InitialDelayMaxValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALFINDBEHAVIOR.INITIALDELAYMAXVALUE.TypedValue);
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
                    if (Model.INITIALFINDBEHAVIOR == null)
                    {
                        Model.INITIALFINDBEHAVIOR = new ();
                    }
                    if (Model.INITIALFINDBEHAVIOR.INITIALDELAYMAXVALUE == null)
                    {
                        Model.INITIALFINDBEHAVIOR.INITIALDELAYMAXVALUE = new ();
                    }
                    Model.INITIALFINDBEHAVIOR.INITIALDELAYMAXVALUE.TypedValue = value;
                }
            }
        }
        
        public Double InitialDelayMinValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALFINDBEHAVIOR.INITIALDELAYMINVALUE.TypedValue);
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
                    if (Model.INITIALFINDBEHAVIOR == null)
                    {
                        Model.INITIALFINDBEHAVIOR = new ();
                    }
                    if (Model.INITIALFINDBEHAVIOR.INITIALDELAYMINVALUE == null)
                    {
                        Model.INITIALFINDBEHAVIOR.INITIALDELAYMINVALUE = new ();
                    }
                    Model.INITIALFINDBEHAVIOR.INITIALDELAYMINVALUE.TypedValue = value;
                }
            }
        }
        
        public Double InitialRepeBaseDelay
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSBASEDELAY.TypedValue);
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
                    if (Model.INITIALFINDBEHAVIOR == null)
                    {
                        Model.INITIALFINDBEHAVIOR = new ();
                    }
                    if (Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSBASEDELAY == null)
                    {
                        Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSBASEDELAY = new ();
                    }
                    Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSBASEDELAY.TypedValue = value;
                }
            }
        }
        
        public String InitialRepeMax
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSMAX.TypedValue);
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
                    if (Model.INITIALFINDBEHAVIOR == null)
                    {
                        Model.INITIALFINDBEHAVIOR = new ();
                    }
                    if (Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSMAX == null)
                    {
                        Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSMAX = new ();
                    }
                    Model.INITIALFINDBEHAVIOR.INITIALREPETITIONSMAX.TypedValue = value;
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
        
        public AsrSdClientConfig(SDCLIENTCONFIG model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
