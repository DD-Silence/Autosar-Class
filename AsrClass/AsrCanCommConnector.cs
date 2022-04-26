using Autosar;

namespace AutosarClass
{
    public partial class AsrCanCommConnector : IAsrIdentifier
    {
        public CANCOMMUNICATIONCONNECTOR Model { get; }
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
        
        public AsrReferenceInfo? ControllerRef
        {
            get
            {
                try
                {
                    if (Model.COMMCONTROLLERREF.DEST == "CAN-COMMUNICATION-CONNECTOR")
                    {
                        return PathManager.GetReferenceInfo(Model.COMMCONTROLLERREF);
                    }
                    return null;
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
                    if (value.AsrReferenceDest == "CAN-COMMUNICATION-CONNECTOR")
                    {
                        Model.COMMCONTROLLERREF.DEST = value.AsrReferenceDest;
                        Model.COMMCONTROLLERREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.COMMCONTROLLERREF = null;
                    }
                }
                else
                {
                    Model.COMMCONTROLLERREF = null;
                }
            }
        }
        
        public AsrCanCommConnector? Controller
        {
            get
            {
                try
                {
                    if (ControllerRef is not null)
                    {
                        if (ControllerRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ControllerRef.AsrPath);
                            if (m is CANCOMMUNICATIONCONNECTOR mm)
                            {
                                return new AsrCanCommConnector(mm, PathManager);
                            }
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        
        public AsrCanCommConnector(CANCOMMUNICATIONCONNECTOR model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
