using Autosar;

namespace AutosarClass
{
    public partial class AsrCanCluster : IAsrIdentifier
    {
        public CANCLUSTER Model { get; }
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
        
        public List<AsrCanClusterConditional> ClusterConditionals
        {
            get
            {
                try
                {
                    var result = new List<AsrCanClusterConditional>();
                    foreach (var m in Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL)
                    {
                        result.Add(new AsrCanClusterConditional(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrCanClusterConditional>();
                }
            }
        }
        
        public void AddClusterConditionals(AsrCanClusterConditional data)
        {
            if (Model.CANCLUSTERVARIANTS == null)
            {
                Model.CANCLUSTERVARIANTS = new ();
            }
            if (Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL == null)
            {
                Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL = new List<CANCLUSTERCONDITIONAL>();
            }
            foreach (var d in Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new CANCLUSTERCONDITIONAL();
            m = data.Model;
            Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL.Add(m);
        }
        
        public void DelClusterConditionals(AsrCanClusterConditional data)
        {
            if (Model.CANCLUSTERVARIANTS == null)
            {
                return;
            }
            if (Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL == null)
            {
                return;
            }
            foreach (var m in Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL)
            {
                if (m.Equals(data.Model))
                {
                    Model.CANCLUSTERVARIANTS.CANCLUSTERCONDITIONAL.Remove(m);
                    break;
                }
            }
        }
        public AsrCanCluster(CANCLUSTER model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
