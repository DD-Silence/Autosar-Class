using Autosar;

namespace AutosarClass
{
    public partial class AsrSRInterface : IAsrIdentifier
    {
        public SENDERRECEIVERINTERFACE Model { get; }
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
        
        public String IsService
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.ISSERVICE.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (IsService != value)
                {
                    if (Model.ISSERVICE == null)
                    {
                        Model.ISSERVICE = new ();
                    }
                    Model.ISSERVICE.TypedValue = value;
                }
            }
        }
        
        public List<AsrVariableDataPrototype> VariableDataPrototypes
        {
            get
            {
                try
                {
                    var result = new List<AsrVariableDataPrototype>();
                    foreach (var m in Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE)
                    {
                        result.Add(new AsrVariableDataPrototype(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrVariableDataPrototype>();
                }
            }
        }
        
        public void AddVariableDataPrototypes(AsrVariableDataPrototype data)
        {
            if (Model.DATAELEMENTS == null)
            {
                Model.DATAELEMENTS = new ();
            }
            if (Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE == null)
            {
                Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE = new List<VARIABLEDATAPROTOTYPE>();
            }
            foreach (var d in Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new VARIABLEDATAPROTOTYPE();
            m = data.Model;
            Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE.Add(m);
        }
        
        public void DelVariableDataPrototypes(AsrVariableDataPrototype data)
        {
            if (Model.DATAELEMENTS == null)
            {
                return;
            }
            if (Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE == null)
            {
                return;
            }
            foreach (var m in Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE)
            {
                if (m.Equals(data.Model))
                {
                    Model.DATAELEMENTS.VARIABLEDATAPROTOTYPE.Remove(m);
                    break;
                }
            }
        }
        public AsrSRInterface(SENDERRECEIVERINTERFACE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
