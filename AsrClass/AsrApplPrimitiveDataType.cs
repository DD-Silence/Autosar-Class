using Autosar;

namespace AutosarClass
{
    public partial class AsrApplPrimitiveDataType : IAsrIdentifier
    {
        public APPLICATIONPRIMITIVEDATATYPE Model { get; }
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
        
        public String Category
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CATEGORY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Category != value)
                {
                    if (Model.CATEGORY == null)
                    {
                        Model.CATEGORY = new ();
                    }
                    Model.CATEGORY.TypedValue = value;
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
                    foreach (var m in Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
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
            if (Model.SWDATADEFPROPS == null)
            {
                Model.SWDATADEFPROPS = new ();
            }
            if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS == null)
            {
                Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS = new ();
            }
            if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL == null)
            {
                Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL = new List<SWDATADEFPROPSCONDITIONAL>();
            }
            foreach (var d in Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
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
            Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Add(m);
        }
        
        public void DelSwDataDefPropsConditionals(AsrSwDataDefPropsConditional data)
        {
            if (Model.SWDATADEFPROPS == null)
            {
                return;
            }
            if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS == null)
            {
                return;
            }
            if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL == null)
            {
                return;
            }
            foreach (var m in Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
            {
                if (m.Equals(data.Model))
                {
                    Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Remove(m);
                    break;
                }
            }
        }
        public AsrApplPrimitiveDataType(APPLICATIONPRIMITIVEDATATYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
