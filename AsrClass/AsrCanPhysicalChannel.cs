using Autosar;

namespace AutosarClass
{
    public partial class AsrCanPhysicalChannel : IAsrIdentifier
    {
        public CANPHYSICALCHANNEL Model { get; }
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
        
        public List<AsrReferenceInfo> CommConnectorsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL)
                    {
                        var r = PathManager.GetReferenceInfo(m.COMMUNICATIONCONNECTORREF);
                        if (r is not null)
                        {
                            result.Add(r);
                        }
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrReferenceInfo>();
                }
            }
        }
        
        public void AddCommConnectors(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "CAN-COMMUNICATION-CONNECTOR")
            {
                if (Model.COMMCONNECTORS == null)
                {
                    Model.COMMCONNECTORS = new ();
                }
                if (Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL == null)
                {
                    Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL = new List<COMMUNICATIONCONNECTORREFCONDITIONAL>();
                }
                var m = new COMMUNICATIONCONNECTORREFCONDITIONAL();
                m.COMMUNICATIONCONNECTORREF = new ();
                m.COMMUNICATIONCONNECTORREF.DEST = reference.AsrReferenceDest;
                m.COMMUNICATIONCONNECTORREF.TypedValue = reference.AsrReference;
                PathManager.AddReference(m.COMMUNICATIONCONNECTORREF, reference);
            }
        }
        
        public void DelCommConnectors(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "CAN-COMMUNICATION-CONNECTOR")
            {
                if (Model.COMMCONNECTORS == null)
                {
                    return;
                }
                if (Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL == null)
                {
                    return;
                }
                foreach (var m in Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL)
                {
                    if (m.COMMUNICATIONCONNECTORREF.DEST == reference.AsrReferenceDest && m.COMMUNICATIONCONNECTORREF.TypedValue == reference.AsrReference)
                    {
                        Model.COMMCONNECTORS.COMMUNICATIONCONNECTORREFCONDITIONAL.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrCanCommConnector> CommConnectors
        {
            get
            {
                var result = new List<AsrCanCommConnector>();
                foreach (var r in CommConnectorsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is CANCOMMUNICATIONCONNECTOR mm)
                        {
                            var c = new AsrCanCommConnector(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public List<AsrCanFrameTriggering> FrameTriggerings
        {
            get
            {
                try
                {
                    var result = new List<AsrCanFrameTriggering>();
                    foreach (var m in Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING)
                    {
                        result.Add(new AsrCanFrameTriggering(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrCanFrameTriggering>();
                }
            }
        }
        
        public void AddFrameTriggerings(AsrCanFrameTriggering data)
        {
            if (Model.FRAMETRIGGERINGS == null)
            {
                Model.FRAMETRIGGERINGS = new ();
            }
            if (Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING == null)
            {
                Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING = new List<CANFRAMETRIGGERING>();
            }
            foreach (var d in Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new CANFRAMETRIGGERING();
            m = data.Model;
            Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING.Add(m);
        }
        
        public void DelFrameTriggerings(AsrCanFrameTriggering data)
        {
            if (Model.FRAMETRIGGERINGS == null)
            {
                return;
            }
            if (Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING == null)
            {
                return;
            }
            foreach (var m in Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING)
            {
                if (m.Equals(data.Model))
                {
                    Model.FRAMETRIGGERINGS.CANFRAMETRIGGERING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrISignalTriggering> ISignalTriggerings
        {
            get
            {
                try
                {
                    var result = new List<AsrISignalTriggering>();
                    foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
                    {
                        result.Add(new AsrISignalTriggering(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrISignalTriggering>();
                }
            }
        }
        
        public void AddISignalTriggerings(AsrISignalTriggering data)
        {
            if (Model.ISIGNALTRIGGERINGS == null)
            {
                Model.ISIGNALTRIGGERINGS = new ();
            }
            if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING == null)
            {
                Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING = new List<ISIGNALTRIGGERING>();
            }
            foreach (var d in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new ISIGNALTRIGGERING();
            m = data.Model;
            Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING.Add(m);
        }
        
        public void DelISignalTriggerings(AsrISignalTriggering data)
        {
            if (Model.ISIGNALTRIGGERINGS == null)
            {
                return;
            }
            if (Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING == null)
            {
                return;
            }
            foreach (var m in Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING)
            {
                if (m.Equals(data.Model))
                {
                    Model.ISIGNALTRIGGERINGS.ISIGNALTRIGGERING.Remove(m);
                    break;
                }
            }
        }
        public List<AsrPduTriggering> PduTriggerings
        {
            get
            {
                try
                {
                    var result = new List<AsrPduTriggering>();
                    foreach (var m in Model.PDUTRIGGERINGS.PDUTRIGGERING)
                    {
                        result.Add(new AsrPduTriggering(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrPduTriggering>();
                }
            }
        }
        
        public void AddPduTriggerings(AsrPduTriggering data)
        {
            if (Model.PDUTRIGGERINGS == null)
            {
                Model.PDUTRIGGERINGS = new ();
            }
            if (Model.PDUTRIGGERINGS.PDUTRIGGERING == null)
            {
                Model.PDUTRIGGERINGS.PDUTRIGGERING = new List<PDUTRIGGERING>();
            }
            foreach (var d in Model.PDUTRIGGERINGS.PDUTRIGGERING)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new PDUTRIGGERING();
            m = data.Model;
            Model.PDUTRIGGERINGS.PDUTRIGGERING.Add(m);
        }
        
        public void DelPduTriggerings(AsrPduTriggering data)
        {
            if (Model.PDUTRIGGERINGS == null)
            {
                return;
            }
            if (Model.PDUTRIGGERINGS.PDUTRIGGERING == null)
            {
                return;
            }
            foreach (var m in Model.PDUTRIGGERINGS.PDUTRIGGERING)
            {
                if (m.Equals(data.Model))
                {
                    Model.PDUTRIGGERINGS.PDUTRIGGERING.Remove(m);
                    break;
                }
            }
        }
        public AsrCanPhysicalChannel(CANPHYSICALCHANNEL model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
