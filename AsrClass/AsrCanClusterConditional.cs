using Autosar;

namespace AutosarClass
{
    public partial class AsrCanClusterConditional
    {
        public CANCLUSTERCONDITIONAL Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public String BaudRate
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.BAUDRATE.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (BaudRate != value)
                {
                    if (Model.BAUDRATE == null)
                    {
                        Model.BAUDRATE = new ();
                    }
                    Model.BAUDRATE.TypedValue = value;
                }
            }
        }
        
        public List<AsrCanPhysicalChannel> Channels
        {
            get
            {
                try
                {
                    var result = new List<AsrCanPhysicalChannel>();
                    foreach (var m in Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL)
                    {
                        result.Add(new AsrCanPhysicalChannel(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrCanPhysicalChannel>();
                }
            }
        }
        
        public void AddChannels(AsrCanPhysicalChannel data)
        {
            if (Model.PHYSICALCHANNELS == null)
            {
                Model.PHYSICALCHANNELS = new ();
            }
            if (Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL == null)
            {
                Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL = new List<CANPHYSICALCHANNEL>();
            }
            foreach (var d in Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new CANPHYSICALCHANNEL();
            m = data.Model;
            Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL.Add(m);
        }
        
        public void DelChannels(AsrCanPhysicalChannel data)
        {
            if (Model.PHYSICALCHANNELS == null)
            {
                return;
            }
            if (Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL == null)
            {
                return;
            }
            foreach (var m in Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL)
            {
                if (m.Equals(data.Model))
                {
                    Model.PHYSICALCHANNELS.CANPHYSICALCHANNEL.Remove(m);
                    break;
                }
            }
        }
        public AsrCanClusterConditional(CANCLUSTERCONDITIONAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
