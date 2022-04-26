using Autosar;

namespace AutosarClass
{
    public partial class AsrISignalIPdu : IAsrIdentifier
    {
        public ISIGNALIPDU Model { get; }
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
        
        public String Length
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.LENGTH.TypedValue);
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Length != value)
                {
                    if (Model.LENGTH == null)
                    {
                        Model.LENGTH = new ();
                    }
                    Model.LENGTH.TypedValue = value;
                }
            }
        }
        
        public List<AsrIPduTiming> Timings
        {
            get
            {
                try
                {
                    var result = new List<AsrIPduTiming>();
                    foreach (var m in Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING)
                    {
                        result.Add(new AsrIPduTiming(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrIPduTiming>();
                }
            }
        }
        
        public void AddTimings(AsrIPduTiming data)
        {
            if (Model.IPDUTIMINGSPECIFICATIONS == null)
            {
                Model.IPDUTIMINGSPECIFICATIONS = new ();
            }
            if (Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING == null)
            {
                Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING = new List<IPDUTIMING>();
            }
            foreach (var d in Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new IPDUTIMING();
            m = data.Model;
            Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING.Add(m);
        }
        
        public void DelTimings(AsrIPduTiming data)
        {
            if (Model.IPDUTIMINGSPECIFICATIONS == null)
            {
                return;
            }
            if (Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING == null)
            {
                return;
            }
            foreach (var m in Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING)
            {
                if (m.Equals(data.Model))
                {
                    Model.IPDUTIMINGSPECIFICATIONS.IPDUTIMING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrISignalToIPduMapping> Mappings
        {
            get
            {
                try
                {
                    var result = new List<AsrISignalToIPduMapping>();
                    foreach (var m in Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING)
                    {
                        result.Add(new AsrISignalToIPduMapping(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrISignalToIPduMapping>();
                }
            }
        }
        
        public void AddMappings(AsrISignalToIPduMapping data)
        {
            if (Model.ISIGNALTOPDUMAPPINGS == null)
            {
                Model.ISIGNALTOPDUMAPPINGS = new ();
            }
            if (Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING == null)
            {
                Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING = new List<ISIGNALTOIPDUMAPPING>();
            }
            foreach (var d in Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ISIGNALTOIPDUMAPPING();
            m = data.Model;
            Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING.Add(m);
        }
        
        public void DelMappings(AsrISignalToIPduMapping data)
        {
            if (Model.ISIGNALTOPDUMAPPINGS == null)
            {
                return;
            }
            if (Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING == null)
            {
                return;
            }
            foreach (var m in Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING)
            {
                if (m.Equals(data.Model))
                {
                    Model.ISIGNALTOPDUMAPPINGS.ISIGNALTOIPDUMAPPING.Remove(m);
                    break;
                }
            }
        }
        public AsrISignalIPdu(ISIGNALIPDU model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
