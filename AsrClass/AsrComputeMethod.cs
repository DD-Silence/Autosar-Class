using Autosar;

namespace AutosarClass
{
    public partial class AsrComputeMethod : IAsrIdentifier
    {
        public COMPUMETHOD Model { get; }
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
        
        public List<AsrComputeScale> Scales
        {
            get
            {
                try
                {
                    var result = new List<AsrComputeScale>();
                    foreach (var m in Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE)
                    {
                        result.Add(new AsrComputeScale(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrComputeScale>();
                }
            }
        }
        
        public void AddScales(AsrComputeScale data)
        {
            if (Model.COMPUINTERNALTOPHYS == null)
            {
                Model.COMPUINTERNALTOPHYS = new ();
            }
            if (Model.COMPUINTERNALTOPHYS.COMPUSCALES == null)
            {
                Model.COMPUINTERNALTOPHYS.COMPUSCALES = new ();
            }
            if (Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE == null)
            {
                Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE = new List<COMPUSCALE>();
            }
            foreach (var d in Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new COMPUSCALE();
            m = data.Model;
            Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE.Add(m);
        }
        
        public void DelScales(AsrComputeScale data)
        {
            if (Model.COMPUINTERNALTOPHYS == null)
            {
                return;
            }
            if (Model.COMPUINTERNALTOPHYS.COMPUSCALES == null)
            {
                return;
            }
            if (Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE == null)
            {
                return;
            }
            foreach (var m in Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE)
            {
                if (m.Equals(data.Model))
                {
                    Model.COMPUINTERNALTOPHYS.COMPUSCALES.COMPUSCALE.Remove(m);
                    break;
                }
            }
        }
        public AsrComputeMethod(COMPUMETHOD model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
