using Autosar;

namespace AutosarClass
{
    public partial class AsrRunnableEntity : IAsrIdentifier
    {
        public RUNNABLEENTITY Model { get; }
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
        
        public Double MinStartInterval
        {
            get
            {
                try
                {
                    return Convert.ToDouble(Model.MINIMUMSTARTINTERVAL.TypedValue);
                }
                catch
                {
                    return 0.0f;
                }
            }
            set
            {
                if (MinStartInterval != value)
                {
                    if (Model.MINIMUMSTARTINTERVAL == null)
                    {
                        Model.MINIMUMSTARTINTERVAL = new ();
                    }
                    Model.MINIMUMSTARTINTERVAL.TypedValue = value;
                }
            }
        }
        
        public String InvokedConcurrent
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.CANBEINVOKEDCONCURRENTLY.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (InvokedConcurrent != value)
                {
                    if (Model.CANBEINVOKEDCONCURRENTLY == null)
                    {
                        Model.CANBEINVOKEDCONCURRENTLY = new ();
                    }
                    Model.CANBEINVOKEDCONCURRENTLY.TypedValue = value;
                }
            }
        }
        
        public List<AsrVariableAccess> DataReadVariableAccesses
        {
            get
            {
                try
                {
                    var result = new List<AsrVariableAccess>();
                    foreach (var m in Model.DATAREADACCESSS.VARIABLEACCESS)
                    {
                        result.Add(new AsrVariableAccess(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrVariableAccess>();
                }
            }
        }
        
        public void AddDataReadVariableAccesses(AsrVariableAccess data)
        {
            if (Model.DATAREADACCESSS == null)
            {
                Model.DATAREADACCESSS = new ();
            }
            if (Model.DATAREADACCESSS.VARIABLEACCESS == null)
            {
                Model.DATAREADACCESSS.VARIABLEACCESS = new List<VARIABLEACCESS>();
            }
            foreach (var d in Model.DATAREADACCESSS.VARIABLEACCESS)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new VARIABLEACCESS();
            m = data.Model;
            Model.DATAREADACCESSS.VARIABLEACCESS.Add(m);
        }
        
        public void DelDataReadVariableAccesses(AsrVariableAccess data)
        {
            if (Model.DATAREADACCESSS == null)
            {
                return;
            }
            if (Model.DATAREADACCESSS.VARIABLEACCESS == null)
            {
                return;
            }
            foreach (var m in Model.DATAREADACCESSS.VARIABLEACCESS)
            {
                if (m.Equals(data.Model))
                {
                    Model.DATAREADACCESSS.VARIABLEACCESS.Remove(m);
                    break;
                }
            }
        }
        public List<AsrVariableAccess> DataReceiveVariableAccesses
        {
            get
            {
                try
                {
                    var result = new List<AsrVariableAccess>();
                    foreach (var m in Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS)
                    {
                        result.Add(new AsrVariableAccess(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrVariableAccess>();
                }
            }
        }
        
        public void AddDataReceiveVariableAccesses(AsrVariableAccess data)
        {
            if (Model.DATARECEIVEPOINTBYARGUMENTS == null)
            {
                Model.DATARECEIVEPOINTBYARGUMENTS = new ();
            }
            if (Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS == null)
            {
                Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS = new List<VARIABLEACCESS>();
            }
            foreach (var d in Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new VARIABLEACCESS();
            m = data.Model;
            Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS.Add(m);
        }
        
        public void DelDataReceiveVariableAccesses(AsrVariableAccess data)
        {
            if (Model.DATARECEIVEPOINTBYARGUMENTS == null)
            {
                return;
            }
            if (Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS == null)
            {
                return;
            }
            foreach (var m in Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS)
            {
                if (m.Equals(data.Model))
                {
                    Model.DATARECEIVEPOINTBYARGUMENTS.VARIABLEACCESS.Remove(m);
                    break;
                }
            }
        }
        public String Symbol
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SYMBOL.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Symbol != value)
                {
                    if (Model.SYMBOL == null)
                    {
                        Model.SYMBOL = new ();
                    }
                    Model.SYMBOL.TypedValue = value;
                }
            }
        }
        
        public AsrRunnableEntity(RUNNABLEENTITY model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
