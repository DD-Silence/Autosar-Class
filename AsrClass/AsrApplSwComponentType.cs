using Autosar;

namespace AutosarClass
{
    public partial class AsrApplSwComponentType : IAsrIdentifier
    {
        public APPLICATIONSWCOMPONENTTYPE Model { get; }
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
        
        public List<AsrPPortPrototype> PPortPrototypes
        {
            get
            {
                try
                {
                    var result = new List<AsrPPortPrototype>();
                    foreach (var m in Model.PORTS.PPORTPROTOTYPE)
                    {
                        result.Add(new AsrPPortPrototype(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrPPortPrototype>();
                }
            }
        }
        
        public void AddPPortPrototypes(AsrPPortPrototype data)
        {
            if (Model.PORTS == null)
            {
                Model.PORTS = new ();
            }
            if (Model.PORTS.PPORTPROTOTYPE == null)
            {
                Model.PORTS.PPORTPROTOTYPE = new List<PPORTPROTOTYPE>();
            }
            foreach (var d in Model.PORTS.PPORTPROTOTYPE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new PPORTPROTOTYPE();
            m = data.Model;
            Model.PORTS.PPORTPROTOTYPE.Add(m);
        }
        
        public void DelPPortPrototypes(AsrPPortPrototype data)
        {
            if (Model.PORTS == null)
            {
                return;
            }
            if (Model.PORTS.PPORTPROTOTYPE == null)
            {
                return;
            }
            foreach (var m in Model.PORTS.PPORTPROTOTYPE)
            {
                if (m.Equals(data.Model))
                {
                    Model.PORTS.PPORTPROTOTYPE.Remove(m);
                    break;
                }
            }
        }
        public List<AsrRPortPrototype> RPortPrototypes
        {
            get
            {
                try
                {
                    var result = new List<AsrRPortPrototype>();
                    foreach (var m in Model.PORTS.RPORTPROTOTYPE)
                    {
                        result.Add(new AsrRPortPrototype(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrRPortPrototype>();
                }
            }
        }
        
        public void AddRPortPrototypes(AsrRPortPrototype data)
        {
            if (Model.PORTS == null)
            {
                Model.PORTS = new ();
            }
            if (Model.PORTS.RPORTPROTOTYPE == null)
            {
                Model.PORTS.RPORTPROTOTYPE = new List<RPORTPROTOTYPE>();
            }
            foreach (var d in Model.PORTS.RPORTPROTOTYPE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new RPORTPROTOTYPE();
            m = data.Model;
            Model.PORTS.RPORTPROTOTYPE.Add(m);
        }
        
        public void DelRPortPrototypes(AsrRPortPrototype data)
        {
            if (Model.PORTS == null)
            {
                return;
            }
            if (Model.PORTS.RPORTPROTOTYPE == null)
            {
                return;
            }
            foreach (var m in Model.PORTS.RPORTPROTOTYPE)
            {
                if (m.Equals(data.Model))
                {
                    Model.PORTS.RPORTPROTOTYPE.Remove(m);
                    break;
                }
            }
        }
        public List<AsrSwcInternalBehavior> SwcInternalBehavior
        {
            get
            {
                try
                {
                    var result = new List<AsrSwcInternalBehavior>();
                    foreach (var m in Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR)
                    {
                        result.Add(new AsrSwcInternalBehavior(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSwcInternalBehavior>();
                }
            }
        }
        
        public void AddSwcInternalBehavior(AsrSwcInternalBehavior data)
        {
            if (Model.INTERNALBEHAVIORS == null)
            {
                Model.INTERNALBEHAVIORS = new ();
            }
            if (Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR == null)
            {
                Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR = new List<SWCINTERNALBEHAVIOR>();
            }
            foreach (var d in Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SWCINTERNALBEHAVIOR();
            m = data.Model;
            Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR.Add(m);
        }
        
        public void DelSwcInternalBehavior(AsrSwcInternalBehavior data)
        {
            if (Model.INTERNALBEHAVIORS == null)
            {
                return;
            }
            if (Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR == null)
            {
                return;
            }
            foreach (var m in Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR)
            {
                if (m.Equals(data.Model))
                {
                    Model.INTERNALBEHAVIORS.SWCINTERNALBEHAVIOR.Remove(m);
                    break;
                }
            }
        }
        public AsrApplSwComponentType(APPLICATIONSWCOMPONENTTYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
