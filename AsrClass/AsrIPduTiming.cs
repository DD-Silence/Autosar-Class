using Autosar;

namespace AutosarClass
{
    public partial class AsrIPduTiming
    {
        public IPDUTIMING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public Double MinimumDelay
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.MINIMUMDELAY.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (MinimumDelay != value)
                {
                    if (Model.MINIMUMDELAY == null)
                    {
                        Model.MINIMUMDELAY = new ();
                    }
                    Model.MINIMUMDELAY.TypedValue = value;
                }
            }
        }
        
        public AsrTransmissionMode? TransmissionFalse
        {
            get
            {
                try
                {
                    return new AsrTransmissionMode(Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODEFALSETIMING, PathManager);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (Model.TRANSMISSIONMODEDECLARATION == null)
                {
                    Model.TRANSMISSIONMODEDECLARATION = new ();
                }
                if (value is not null)
                {
                    Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODEFALSETIMING = value.Model;
                }
                else
                {
                    Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODEFALSETIMING = null;
                }
            }
        }
        
        public AsrTransmissionMode? TransmissionTrue
        {
            get
            {
                try
                {
                    return new AsrTransmissionMode(Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODETRUETIMING, PathManager);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (Model.TRANSMISSIONMODEDECLARATION == null)
                {
                    Model.TRANSMISSIONMODEDECLARATION = new ();
                }
                if (value is not null)
                {
                    Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODETRUETIMING = value.Model;
                }
                else
                {
                    Model.TRANSMISSIONMODEDECLARATION.TRANSMISSIONMODETRUETIMING = null;
                }
            }
        }
        
        public AsrIPduTiming(IPDUTIMING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
