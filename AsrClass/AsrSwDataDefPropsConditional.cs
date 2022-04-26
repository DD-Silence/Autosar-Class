using Autosar;

namespace AutosarClass
{
    public partial class AsrSwDataDefPropsConditional
    {
        public SWDATADEFPROPSCONDITIONAL Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrReferenceInfo? ComputeMethodRef
        {
            get
            {
                try
                {
                    if (Model.COMPUMETHODREF.DEST == "COMPU-METHOD")
                    {
                        return PathManager.GetReferenceInfo(Model.COMPUMETHODREF);
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
                    if (value.AsrReferenceDest == "COMPU-METHOD")
                    {
                        Model.COMPUMETHODREF.DEST = value.AsrReferenceDest;
                        Model.COMPUMETHODREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.COMPUMETHODREF = null;
                    }
                }
                else
                {
                    Model.COMPUMETHODREF = null;
                }
            }
        }
        
        public AsrComputeMethod? ComputeMethod
        {
            get
            {
                try
                {
                    if (ComputeMethodRef is not null)
                    {
                        if (ComputeMethodRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(ComputeMethodRef.AsrPath);
                            if (m is COMPUMETHOD mm)
                            {
                                return new AsrComputeMethod(mm, PathManager);
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
        
        public AsrReferenceInfo? DataConstrainRef
        {
            get
            {
                try
                {
                    if (Model.DATACONSTRREF.DEST == "DATA-CONSTR")
                    {
                        return PathManager.GetReferenceInfo(Model.DATACONSTRREF);
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
                    if (value.AsrReferenceDest == "DATA-CONSTR")
                    {
                        Model.DATACONSTRREF.DEST = value.AsrReferenceDest;
                        Model.DATACONSTRREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.DATACONSTRREF = null;
                    }
                }
                else
                {
                    Model.DATACONSTRREF = null;
                }
            }
        }
        
        public AsrDataConstraint? DataConstrain
        {
            get
            {
                try
                {
                    if (DataConstrainRef is not null)
                    {
                        if (DataConstrainRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(DataConstrainRef.AsrPath);
                            if (m is DATACONSTR mm)
                            {
                                return new AsrDataConstraint(mm, PathManager);
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
        
        public AsrSwDataDefPropsConditional(SWDATADEFPROPSCONDITIONAL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
