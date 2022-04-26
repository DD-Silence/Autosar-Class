using Autosar;

namespace AutosarClass
{
    public partial class AsrIPduMapping
    {
        public IPDUMAPPING Model { get; }
        public AsrPathReferenceManager PathManager { get; }
        
        public AsrReferenceInfo? SourceRef
        {
            get
            {
                try
                {
                    if (Model.SOURCEIPDUREF.DEST == "PDU-TRIGGERING")
                    {
                        return PathManager.GetReferenceInfo(Model.SOURCEIPDUREF);
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
                    if (value.AsrReferenceDest == "PDU-TRIGGERING")
                    {
                        Model.SOURCEIPDUREF.DEST = value.AsrReferenceDest;
                        Model.SOURCEIPDUREF.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.SOURCEIPDUREF = null;
                    }
                }
                else
                {
                    Model.SOURCEIPDUREF = null;
                }
            }
        }
        
        public AsrPduTriggering? Source
        {
            get
            {
                try
                {
                    if (SourceRef is not null)
                    {
                        if (SourceRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(SourceRef.AsrPath);
                            if (m is PDUTRIGGERING mm)
                            {
                                return new AsrPduTriggering(mm, PathManager);
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
        
        public AsrReferenceInfo? TargetRef
        {
            get
            {
                try
                {
                    if (Model.TARGETIPDU.TARGETIPDUREF1.DEST == "PDU-TRIGGERING")
                    {
                        return PathManager.GetReferenceInfo(Model.TARGETIPDU.TARGETIPDUREF1);
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
                if (Model.TARGETIPDU == null)
                {
                    Model.TARGETIPDU = new ();
                }
                if (value is not null)
                {
                    if (value.AsrReferenceDest == "PDU-TRIGGERING")
                    {
                        Model.TARGETIPDU.TARGETIPDUREF1.DEST = value.AsrReferenceDest;
                        Model.TARGETIPDU.TARGETIPDUREF1.TypedValue = value.AsrReference;
                    }
                    else
                    {
                        Model.TARGETIPDU.TARGETIPDUREF1 = null;
                    }
                }
                else
                {
                    Model.TARGETIPDU.TARGETIPDUREF1 = null;
                }
            }
        }
        
        public AsrPduTriggering? Target
        {
            get
            {
                try
                {
                    if (TargetRef is not null)
                    {
                        if (TargetRef.AsrPath is not null)
                        {
                            var m = PathManager.GetModel(TargetRef.AsrPath);
                            if (m is PDUTRIGGERING mm)
                            {
                                return new AsrPduTriggering(mm, PathManager);
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
        
        public AsrIPduMapping(IPDUMAPPING model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
