using Autosar;

namespace AutosarClass
{
    public partial class AsrSystemSignal : IAsrIdentifier
    {
        public SYSTEMSIGNAL Model { get; }
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
        
        public List<String> Desc
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.DESC.L2)
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
                if (Model.DESC == null)
                Model.DESC = new ();
                if (Model.DESC.L2 == null)
                Model.DESC.L2 = new List<LOVERVIEWPARAGRAPH>();
                Model.DESC.L2.Clear();
                foreach (var v in value)
                {
                    var m = new LOVERVIEWPARAGRAPH();
                    m.Untyped.Value = v;
                    Model.DESC.L2.Add(m);
                }
            }
        }
        
        public String DynamicLength
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DYNAMICLENGTH.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (DynamicLength != value)
                {
                    if (Model.DYNAMICLENGTH == null)
                    {
                        Model.DYNAMICLENGTH = new ();
                    }
                    Model.DYNAMICLENGTH.TypedValue = value;
                }
            }
        }
        
        public List<AsrSwDataDefPropsConditional> SwDataDefPropsConditionals
        {
            get
            {
                try
                {
                    var result = new List<AsrSwDataDefPropsConditional>();
                    foreach (var m in Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
                    {
                        result.Add(new AsrSwDataDefPropsConditional(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrSwDataDefPropsConditional>();
                }
            }
        }
        
        public void AddSwDataDefPropsConditionals(AsrSwDataDefPropsConditional data)
        {
            if (Model.PHYSICALPROPS == null)
            {
                Model.PHYSICALPROPS = new ();
            }
            if (Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS == null)
            {
                Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS = new ();
            }
            if (Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL == null)
            {
                Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL = new List<SWDATADEFPROPSCONDITIONAL>();
            }
            foreach (var d in Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new SWDATADEFPROPSCONDITIONAL();
            m = data.Model;
            Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Add(m);
        }
        
        public void DelSwDataDefPropsConditionals(AsrSwDataDefPropsConditional data)
        {
            if (Model.PHYSICALPROPS == null)
            {
                return;
            }
            if (Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS == null)
            {
                return;
            }
            if (Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL == null)
            {
                return;
            }
            foreach (var m in Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
            {
                if (m.Equals(data.Model))
                {
                    Model.PHYSICALPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Remove(m);
                    break;
                }
            }
        }
        public AsrSystemSignal(SYSTEMSIGNAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
