using Autosar;

namespace AutosarClass
{
    public partial class AsrImplDataType : IAsrIdentifier
    {
        public IMPLEMENTATIONDATATYPE Model { get; }
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
        
        public List<String> CalibrationAccesses
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL)
                    {
                        result.Add(Convert.ToString(m.SWCALIBRATIONACCESS.TypedValue));
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
                if (Model.SWDATADEFPROPS == null)
                Model.SWDATADEFPROPS = new ();
                if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS == null)
                Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS = new ();
                if (Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL == null)
                Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL = new List<SWDATADEFPROPSCONDITIONAL>();
                Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Clear();
                foreach (var v in value)
                {
                    var m = new SWDATADEFPROPSCONDITIONAL();
                    m.SWCALIBRATIONACCESS.TypedValue = v;
                    Model.SWDATADEFPROPS.SWDATADEFPROPSVARIANTS.SWDATADEFPROPSCONDITIONAL.Add(m);
                }
            }
        }
        
        public List<AsrImplDataTypeElement> ImplDataTypeElements
        {
            get
            {
                try
                {
                    var result = new List<AsrImplDataTypeElement>();
                    foreach (var m in Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT)
                    {
                        result.Add(new AsrImplDataTypeElement(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrImplDataTypeElement>();
                }
            }
        }
        
        public void AddImplDataTypeElements(AsrImplDataTypeElement data)
        {
            if (Model.SUBELEMENTS == null)
            {
                Model.SUBELEMENTS = new ();
            }
            if (Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT == null)
            {
                Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT = new List<IMPLEMENTATIONDATATYPEELEMENT>();
            }
            foreach (var d in Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new IMPLEMENTATIONDATATYPEELEMENT();
            m = data.Model;
            Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT.Add(m);
        }
        
        public void DelImplDataTypeElements(AsrImplDataTypeElement data)
        {
            if (Model.SUBELEMENTS == null)
            {
                return;
            }
            if (Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT == null)
            {
                return;
            }
            foreach (var m in Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT)
            {
                if (m.Equals(data.Model))
                {
                    Model.SUBELEMENTS.IMPLEMENTATIONDATATYPEELEMENT.Remove(m);
                    break;
                }
            }
        }
        public AsrImplDataType(IMPLEMENTATIONDATATYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
