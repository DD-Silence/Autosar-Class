using Autosar;

namespace AutosarClass
{
    public partial class AsrCouplingPort : IAsrIdentifier
    {
        public COUPLINGPORT Model { get; }
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
        
        public ETHERNETCONNECTIONNEGOTIATIONENUMSIMPLE NegotiationBehavior
        {
            get
            {
                try
                {
                    return Model.CONNECTIONNEGOTIATIONBEHAVIOR.TypedValue;
                }
                catch
                {
                    return ETHERNETCONNECTIONNEGOTIATIONENUMSIMPLE.AUTO;
                }
            }
            set
            {
                if (NegotiationBehavior != value)
                {
                    if (Model.CONNECTIONNEGOTIATIONBEHAVIOR == null)
                    {
                        Model.CONNECTIONNEGOTIATIONBEHAVIOR = new ();
                    }
                    Model.CONNECTIONNEGOTIATIONBEHAVIOR.TypedValue = value;
                }
            }
        }
        
        public String PhysicalLayerType
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.PHYSICALLAYERTYPE.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (PhysicalLayerType != value)
                {
                    if (Model.PHYSICALLAYERTYPE == null)
                    {
                        Model.PHYSICALLAYERTYPE = new ();
                    }
                    Model.PHYSICALLAYERTYPE.TypedValue = value;
                }
            }
        }
        
        public AsrCouplingPort(COUPLINGPORT model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
