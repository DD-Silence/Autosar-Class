using Autosar;

namespace AutosarClass
{
    public partial class AsrEthernetClusterConditional
    {
        public ETHERNETCLUSTERCONDITIONAL Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public List<AsrEthernetPhysicalChannel> Channels
        {
            get
            {
                try
                {
                    var result = new List<AsrEthernetPhysicalChannel>();
                    foreach (var m in Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL)
                    {
                        result.Add(new AsrEthernetPhysicalChannel(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrEthernetPhysicalChannel>();
                }
            }
        }
        
        public void AddChannels(AsrEthernetPhysicalChannel data)
        {
            if (Model.PHYSICALCHANNELS == null)
            {
                Model.PHYSICALCHANNELS = new ();
            }
            if (Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL == null)
            {
                Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL = new List<ETHERNETPHYSICALCHANNEL>();
            }
            foreach (var d in Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ETHERNETPHYSICALCHANNEL();
            m = data.Model;
            Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL.Add(m);
        }
        
        public void DelChannels(AsrEthernetPhysicalChannel data)
        {
            if (Model.PHYSICALCHANNELS == null)
            {
                return;
            }
            if (Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL == null)
            {
                return;
            }
            foreach (var m in Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL)
            {
                if (m.Equals(data.Model))
                {
                    Model.PHYSICALCHANNELS.ETHERNETPHYSICALCHANNEL.Remove(m);
                    break;
                }
            }
        }
        public AsrEthernetClusterConditional(ETHERNETCLUSTERCONDITIONAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
