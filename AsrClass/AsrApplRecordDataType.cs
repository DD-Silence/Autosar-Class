using Autosar;

namespace AutosarClass
{
    public partial class AsrApplRecordDataType : IAsrIdentifier
    {
        public APPLICATIONRECORDDATATYPE Model { get; }
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
        
        public List<AsrApplRecordElement> Elements
        {
            get
            {
                try
                {
                    var result = new List<AsrApplRecordElement>();
                    foreach (var m in Model.ELEMENTS.APPLICATIONRECORDELEMENT)
                    {
                        result.Add(new AsrApplRecordElement(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrApplRecordElement>();
                }
            }
        }
        
        public void AddElements(AsrApplRecordElement data)
        {
            if (Model.ELEMENTS == null)
            {
                Model.ELEMENTS = new ();
            }
            if (Model.ELEMENTS.APPLICATIONRECORDELEMENT == null)
            {
                Model.ELEMENTS.APPLICATIONRECORDELEMENT = new List<APPLICATIONRECORDELEMENT>();
            }
            foreach (var d in Model.ELEMENTS.APPLICATIONRECORDELEMENT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new APPLICATIONRECORDELEMENT();
            m = data.Model;
            Model.ELEMENTS.APPLICATIONRECORDELEMENT.Add(m);
        }
        
        public void DelElements(AsrApplRecordElement data)
        {
            if (Model.ELEMENTS == null)
            {
                return;
            }
            if (Model.ELEMENTS.APPLICATIONRECORDELEMENT == null)
            {
                return;
            }
            foreach (var m in Model.ELEMENTS.APPLICATIONRECORDELEMENT)
            {
                if (m.Equals(data.Model))
                {
                    Model.ELEMENTS.APPLICATIONRECORDELEMENT.Remove(m);
                    break;
                }
            }
        }
        public AsrApplRecordDataType(APPLICATIONRECORDDATATYPE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
