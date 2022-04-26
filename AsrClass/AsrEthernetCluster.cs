using Autosar;

namespace AutosarClass
{
    public partial class AsrEthernetCluster : IAsrIdentifier
    {
        public ETHERNETCLUSTER Model { get; }
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
        
        public List<String> LongName
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.LONGNAME.L4)
                    {
                        result.Add(Convert.ToString(m.Untyped.Value));
                    }
                    return result;
                }
                catch
                {
                    return new List<String>();
                }
            }
            set
            {
                if (Model.LONGNAME == null)
                Model.LONGNAME = new ();
                if (Model.LONGNAME.L4 == null)
                Model.LONGNAME.L4 = new List<LLONGNAME>();
                Model.LONGNAME.L4.Clear();
                foreach (var v in value)
                {
                    var m = new LLONGNAME();
                    m.Untyped.Value = v;
                    Model.LONGNAME.L4.Add(m);
                }
            }
        }
        
        public List<AsrEthernetClusterConditional> EthernetClusterConditionals
        {
            get
            {
                try
                {
                    var result = new List<AsrEthernetClusterConditional>();
                    foreach (var m in Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL)
                    {
                        result.Add(new AsrEthernetClusterConditional(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrEthernetClusterConditional>();
                }
            }
        }
        
        public void AddEthernetClusterConditionals(AsrEthernetClusterConditional data)
        {
            if (Model.ETHERNETCLUSTERVARIANTS == null)
            {
                Model.ETHERNETCLUSTERVARIANTS = new ();
            }
            if (Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL == null)
            {
                Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL = new List<ETHERNETCLUSTERCONDITIONAL>();
            }
            foreach (var d in Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ETHERNETCLUSTERCONDITIONAL();
            m = data.Model;
            Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL.Add(m);
        }
        
        public void DelEthernetClusterConditionals(AsrEthernetClusterConditional data)
        {
            if (Model.ETHERNETCLUSTERVARIANTS == null)
            {
                return;
            }
            if (Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL == null)
            {
                return;
            }
            foreach (var m in Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL)
            {
                if (m.Equals(data.Model))
                {
                    Model.ETHERNETCLUSTERVARIANTS.ETHERNETCLUSTERCONDITIONAL.Remove(m);
                    break;
                }
            }
        }
        public AsrEthernetCluster(ETHERNETCLUSTER model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
