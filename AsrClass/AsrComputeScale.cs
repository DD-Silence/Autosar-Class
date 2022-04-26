using Autosar;

namespace AutosarClass
{
    public partial class AsrComputeScale
    {
        public COMPUSCALE Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public List<String> Desc
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.DESC.L2)
                    {
                        result.Add(Convert.ToString(m.Untyped.Value));
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
                if (Model.DESC == null)
                Model.DESC = new ();
                if (Model.DESC.L2 == null)
                Model.DESC.L2 = new List<LOVERVIEWPARAGRAPH>();
                Model.DESC.L2.Clear();
                foreach (var v in value)
                {
                    var m = new LOVERVIEWPARAGRAPH();
                    m.Untyped.Value = v;
                    Model.DESC.L2.Add(m);
                }
            }
        }
        
        public String? LowerLimit
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.LOWERLIMIT.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (LowerLimit != value)
                {
                    if (Model.LOWERLIMIT == null)
                    {
                        Model.LOWERLIMIT = new ();
                    }
                    if (value is null)
                    {
                        Model.LOWERLIMIT = null;
                    }
                    else
                    {
                        Model.LOWERLIMIT.Untyped.Value = value;
                    }
                }
            }
        }
        
        public String? UpperLimit
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.UPPERLIMIT.Untyped.Value);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (UpperLimit != value)
                {
                    if (Model.UPPERLIMIT == null)
                    {
                        Model.UPPERLIMIT = new ();
                    }
                    if (value is null)
                    {
                        Model.UPPERLIMIT = null;
                    }
                    else
                    {
                        Model.UPPERLIMIT.Untyped.Value = value;
                    }
                }
            }
        }
        
        public String Constant
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.COMPUCONST.VT.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (Constant != value)
                {
                    if (Model.COMPUCONST == null)
                    {
                        Model.COMPUCONST = new ();
                    }
                    if (Model.COMPUCONST.VT == null)
                    {
                        Model.COMPUCONST.VT = new ();
                    }
                    Model.COMPUCONST.VT.TypedValue = value;
                }
            }
        }
        
        public List<String> CoefficienceNumerators
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.COMPURATIONALCOEFFS.COMPUNUMERATOR.V)
                    {
                        result.Add(Convert.ToString(m.Untyped.Value));
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
                if (Model.COMPURATIONALCOEFFS == null)
                Model.COMPURATIONALCOEFFS = new ();
                if (Model.COMPURATIONALCOEFFS.COMPUNUMERATOR == null)
                Model.COMPURATIONALCOEFFS.COMPUNUMERATOR = new ();
                if (Model.COMPURATIONALCOEFFS.COMPUNUMERATOR.V == null)
                Model.COMPURATIONALCOEFFS.COMPUNUMERATOR.V = new List<NUMERICALVALUEVARIATIONPOINT>();
                Model.COMPURATIONALCOEFFS.COMPUNUMERATOR.V.Clear();
                foreach (var v in value)
                {
                    var m = new NUMERICALVALUEVARIATIONPOINT();
                    m.Untyped.Value = v;
                    Model.COMPURATIONALCOEFFS.COMPUNUMERATOR.V.Add(m);
                }
            }
        }
        
        public List<String> CoefficienceDenomiators
        {
            get
            {
                try
                {
                    var result = new List<String>();
                    foreach (var m in Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR.V)
                    {
                        result.Add(Convert.ToString(m.Untyped.Value));
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
                if (Model.COMPURATIONALCOEFFS == null)
                Model.COMPURATIONALCOEFFS = new ();
                if (Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR == null)
                Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR = new ();
                if (Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR.V == null)
                Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR.V = new List<NUMERICALVALUEVARIATIONPOINT>();
                Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR.V.Clear();
                foreach (var v in value)
                {
                    var m = new NUMERICALVALUEVARIATIONPOINT();
                    m.Untyped.Value = v;
                    Model.COMPURATIONALCOEFFS.COMPUDENOMINATOR.V.Add(m);
                }
            }
        }
        
        public AsrComputeScale(COMPUSCALE model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
