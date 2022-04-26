using Autosar;

namespace AutosarClass
{
    public partial class AsrISignal : IAsrIdentifier
    {
        public ISIGNAL Model { get; }
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
        
        public String Policy
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.DATATYPEPOLICY.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Policy != value)
                {
                    if (Model.DATATYPEPOLICY == null)
                    {
                        Model.DATATYPEPOLICY = new ();
                    }
                    Model.DATATYPEPOLICY.TypedValue = value;
                }
            }
        }
        
        public ISIGNALTYPEENUMSIMPLE Type
        {
            get
            {
                try
                {
                    return Model.ISIGNALTYPE.TypedValue;
                }
                catch
                {
                    return ISIGNALTYPEENUMSIMPLE.PRIMITIVE;
                }
            }
            set
            {
                if (Type != value)
                {
                    if (Model.ISIGNALTYPE == null)
                    {
                        Model.ISIGNALTYPE = new ();
                    }
                    Model.ISIGNALTYPE.TypedValue = value;
                }
            }
        }
        
        public String? NumericalInitValue
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.INITVALUE.NUMERICALVALUESPECIFICATION.VALUE.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (NumericalInitValue != value)
                {
                    if (Model.INITVALUE == null)
                    {
                        Model.INITVALUE = new ();
                    }
                    if (Model.INITVALUE.NUMERICALVALUESPECIFICATION == null)
                    {
                        Model.INITVALUE.NUMERICALVALUESPECIFICATION = new ();
                    }
                    if (Model.INITVALUE.NUMERICALVALUESPECIFICATION.VALUE == null)
                    {
                        Model.INITVALUE.NUMERICALVALUESPECIFICATION.VALUE = new ();
                    }
                    if (value is null)
                    {
                        Model.INITVALUE.NUMERICALVALUESPECIFICATION.VALUE = null;
                    }
                    else
                    {
                        Model.INITVALUE.NUMERICALVALUESPECIFICATION.VALUE.Untyped.Value = value;
                    }
                }
            }
        }
        
        public List<String> ArrayInitValues
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS.NUMERICALVALUESPECIFICATION)
                    {
                        result.Add(Convert.ToString(m.VALUE.Untyped.Value));
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
                if (Model.INITVALUE == null)
                Model.INITVALUE = new ();
                if (Model.INITVALUE.ARRAYVALUESPECIFICATION == null)
                Model.INITVALUE.ARRAYVALUESPECIFICATION = new ();
                if (Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS == null)
                Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS = new ();
                if (Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS.NUMERICALVALUESPECIFICATION == null)
                Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS.NUMERICALVALUESPECIFICATION = new List<NUMERICALVALUESPECIFICATION>();
                Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS.NUMERICALVALUESPECIFICATION.Clear();
                foreach (var v in value)
                {
                    var m = new NUMERICALVALUESPECIFICATION();
                    m.VALUE.Untyped.Value = v;
                    Model.INITVALUE.ARRAYVALUESPECIFICATION.ELEMENTS.NUMERICALVALUESPECIFICATION.Add(m);
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
        
        public AsrReferenceInfo? SystemSignalRef
        {
            get
            {
                try
                {
                    if (Model.SYSTEMSIGNALREF.DEST == "SYSTEM-SIGNAL")
                    {
                        return PathManager.GetReferenceInfo(Model.SYSTEMSIGNALREF);
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
                    if (value.AsrReferenceDest == "SYSTEM-SIGNAL")
                    {
                        Model.SYSTEMSIGNALREF.DEST = value.AsrReferenceDest;
                        Model.SYSTEMSIGNALREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.SYSTEMSIGNALREF = null;
                    }
                }
                else
                {
                    Model.SYSTEMSIGNALREF = null;
                }
            }
        }
        
        public AsrSystemSignal? SystemSignal
        {
            get
            {
                try
                {
                    if (SystemSignalRef is not null)
                    {
                        if (SystemSignalRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(SystemSignalRef.AsrPath);
                            if (m is SYSTEMSIGNAL mm)
                            {
                                return new AsrSystemSignal(mm, PathManager);
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
        
        public AsrISignal(ISIGNAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
