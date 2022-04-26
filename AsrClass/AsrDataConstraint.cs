using Autosar;

namespace AutosarClass
{
    public partial class AsrDataConstraint : IAsrIdentifier
    {
        public DATACONSTR Model { get; }
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
        
        public List<AsrDataInternalConstraint> InternalRules
        {
            get
            {
                try
                {
                    var result = new List<AsrDataInternalConstraint>();
                    foreach (var m in Model.DATACONSTRRULES.DATACONSTRRULE)
                    {
                        result.Add(new AsrDataInternalConstraint(m.INTERNALCONSTRS, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrDataInternalConstraint>();
                }
            }
        }
        
        public void AddInternalRules(AsrDataInternalConstraint data)
        {
            if (Model.DATACONSTRRULES == null)
            {
                Model.DATACONSTRRULES = new ();
            }
            if (Model.DATACONSTRRULES.DATACONSTRRULE == null)
            {
                Model.DATACONSTRRULES.DATACONSTRRULE = new List<DATACONSTRRULE>();
            }
            foreach (var d in Model.DATACONSTRRULES.DATACONSTRRULE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new DATACONSTRRULE();
            m.INTERNALCONSTRS = data.Model;
            Model.DATACONSTRRULES.DATACONSTRRULE.Add(m);
        }
        
        public void DelInternalRules(AsrDataInternalConstraint data)
        {
            if (Model.DATACONSTRRULES == null)
            {
                return;
            }
            if (Model.DATACONSTRRULES.DATACONSTRRULE == null)
            {
                return;
            }
            foreach (var m in Model.DATACONSTRRULES.DATACONSTRRULE)
            {
                if (m.INTERNALCONSTRS.Equals(data.Model))
                {
                    Model.DATACONSTRRULES.DATACONSTRRULE.Remove(m);
                    break;
                }
            }
        }
        public AsrDataConstraint(DATACONSTR model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
