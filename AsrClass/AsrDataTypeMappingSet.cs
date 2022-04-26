using Autosar;

namespace AutosarClass
{
    public partial class AsrDataTypeMappingSet : IAsrIdentifier
    {
        public DATATYPEMAPPINGSET Model { get; }
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
        
        public List<AsrDataTypeMap> Mappings
        {
            get
            {
                try
                {
                    var result = new List<AsrDataTypeMap>();
                    foreach (var m in Model.DATATYPEMAPS.DATATYPEMAP)
                    {
                        result.Add(new AsrDataTypeMap(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrDataTypeMap>();
                }
            }
        }
        
        public void AddMappings(AsrDataTypeMap data)
        {
            if (Model.DATATYPEMAPS == null)
            {
                Model.DATATYPEMAPS = new ();
            }
            if (Model.DATATYPEMAPS.DATATYPEMAP == null)
            {
                Model.DATATYPEMAPS.DATATYPEMAP = new List<DATATYPEMAP>();
            }
            foreach (var d in Model.DATATYPEMAPS.DATATYPEMAP)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new DATATYPEMAP();
            m = data.Model;
            Model.DATATYPEMAPS.DATATYPEMAP.Add(m);
        }
        
        public void DelMappings(AsrDataTypeMap data)
        {
            if (Model.DATATYPEMAPS == null)
            {
                return;
            }
            if (Model.DATATYPEMAPS.DATATYPEMAP == null)
            {
                return;
            }
            foreach (var m in Model.DATATYPEMAPS.DATATYPEMAP)
            {
                if (m.Equals(data.Model))
                {
                    Model.DATATYPEMAPS.DATATYPEMAP.Remove(m);
                    break;
                }
            }
        }
        public AsrDataTypeMappingSet(DATATYPEMAPPINGSET model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
