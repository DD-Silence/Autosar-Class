using Autosar;

namespace AutosarClass
{
    public partial class AsrGateway
    {
        public GATEWAY Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrReferenceInfo? EcuRef
        {
            get
            {
                try
                {
                    if (Model.ECUREF.DEST == "APPLICATION-ARRAY-DATA-TYPE")
                    {
                        return PathManager.GetReferenceInfo(Model.ECUREF);
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "APPLICATION-ARRAY-DATA-TYPE")
                    {
                        Model.ECUREF.DEST = value.AsrReferenceDest;
                        Model.ECUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.ECUREF = null;
                    }
                }
                else
                {
                    Model.ECUREF = null;
                }
            }
        }
        
        public AsrApplArrayDataType? Ecu
        {
            get
            {
                try
                {
                    if (EcuRef is not null)
                    {
                        if (EcuRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(EcuRef.AsrPath);
                            if (m is APPLICATIONARRAYDATATYPE mm)
                            {
                                return new AsrApplArrayDataType(mm, PathManager);
                            }
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        
        public List<AsrIPduMapping> IPduMappings
        {
            get
            {
                try
                {
                    var result = new List<AsrIPduMapping>();
                    foreach (var m in Model.IPDUMAPPINGS.IPDUMAPPING)
                    {
                        result.Add(new AsrIPduMapping(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrIPduMapping>();
                }
            }
        }
        
        public void AddIPduMappings(AsrIPduMapping data)
        {
            if (Model.IPDUMAPPINGS == null)
            {
                Model.IPDUMAPPINGS = new ();
            }
            if (Model.IPDUMAPPINGS.IPDUMAPPING == null)
            {
                Model.IPDUMAPPINGS.IPDUMAPPING = new List<IPDUMAPPING>();
            }
            foreach (var d in Model.IPDUMAPPINGS.IPDUMAPPING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new IPDUMAPPING();
            m = data.Model;
            Model.IPDUMAPPINGS.IPDUMAPPING.Add(m);
        }
        
        public void DelIPduMappings(AsrIPduMapping data)
        {
            if (Model.IPDUMAPPINGS == null)
            {
                return;
            }
            if (Model.IPDUMAPPINGS.IPDUMAPPING == null)
            {
                return;
            }
            foreach (var m in Model.IPDUMAPPINGS.IPDUMAPPING)
            {
                if (m.Equals(data.Model))
                {
                    Model.IPDUMAPPINGS.IPDUMAPPING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrISignalMapping> ISignalMappings
        {
            get
            {
                try
                {
                    var result = new List<AsrISignalMapping>();
                    foreach (var m in Model.SIGNALMAPPINGS.ISIGNALMAPPING)
                    {
                        result.Add(new AsrISignalMapping(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrISignalMapping>();
                }
            }
        }
        
        public void AddISignalMappings(AsrISignalMapping data)
        {
            if (Model.SIGNALMAPPINGS == null)
            {
                Model.SIGNALMAPPINGS = new ();
            }
            if (Model.SIGNALMAPPINGS.ISIGNALMAPPING == null)
            {
                Model.SIGNALMAPPINGS.ISIGNALMAPPING = new List<ISIGNALMAPPING>();
            }
            foreach (var d in Model.SIGNALMAPPINGS.ISIGNALMAPPING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ISIGNALMAPPING();
            m = data.Model;
            Model.SIGNALMAPPINGS.ISIGNALMAPPING.Add(m);
        }
        
        public void DelISignalMappings(AsrISignalMapping data)
        {
            if (Model.SIGNALMAPPINGS == null)
            {
                return;
            }
            if (Model.SIGNALMAPPINGS.ISIGNALMAPPING == null)
            {
                return;
            }
            foreach (var m in Model.SIGNALMAPPINGS.ISIGNALMAPPING)
            {
                if (m.Equals(data.Model))
                {
                    Model.SIGNALMAPPINGS.ISIGNALMAPPING.Remove(m);
                    break;
                }
            }
        }
        public AsrGateway(GATEWAY model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
