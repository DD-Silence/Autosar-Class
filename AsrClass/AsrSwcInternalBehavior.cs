using Autosar;

namespace AutosarClass
{
    public partial class AsrSwcInternalBehavior : IAsrIdentifier
    {
        public SWCINTERNALBEHAVIOR Model { get; }
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
        
        public List<AsrReferenceInfo> DataTypeMappingSetsRef
        {
            get
            {
                try
                {
                    var result = new List<AsrReferenceInfo>();
                    foreach (var m in Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF)
                    {
                        var r = PathManager.GetReferenceInfo(m);
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
        
        public void AddDataTypeMappingSets(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "DATA-TYPE-MAPPING-SET")
            {
                if (Model.DATATYPEMAPPINGREFS == null)
                {
                    Model.DATATYPEMAPPINGREFS = new ();
                }
                if (Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF == null)
                {
                    Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF = new List<SWCINTERNALBEHAVIOR.DATATYPEMAPPINGREFSLocalType.DATATYPEMAPPINGREFLocalType>();
                }
                var m = new SWCINTERNALBEHAVIOR.DATATYPEMAPPINGREFSLocalType.DATATYPEMAPPINGREFLocalType();
                m.DEST = reference.AsrReferenceDest;
                m.TypedValue = reference.AsrReference;
                PathManager.AddReference(m, reference);
            }
        }
        
        public void DelDataTypeMappingSets(AsrReferenceInfo reference)
        {
            if (reference.AsrReferenceDest == "DATA-TYPE-MAPPING-SET")
            {
                if (Model.DATATYPEMAPPINGREFS == null)
                {
                    return;
                }
                if (Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF == null)
                {
                    return;
                }
                foreach (var m in Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF)
                {
                    if (m.DEST == reference.AsrReferenceDest && m.TypedValue == reference.AsrReference)
                    {
                        Model.DATATYPEMAPPINGREFS.DATATYPEMAPPINGREF.Remove(m);
                        PathManager.RemoveReference(reference);
                        break;
                    }
                }
            }
        }
        
        public List<AsrDataTypeMappingSet> DataTypeMappingSets
        {
            get
            {
                var result = new List<AsrDataTypeMappingSet>();
                foreach (var r in DataTypeMappingSetsRef)
                {
                    if (r.AsrPath is not null)
                    {
                        var path = PathManager.GetModel(r.AsrPath);
                        if (path is DATATYPEMAPPINGSET mm)
                        {
                            var c = new AsrDataTypeMappingSet(mm, PathManager);
                            result.Add(c);
                        }
                    }
                }
                return result;
            }
        }
        
        public List<AsrDataReceivedEvent> DataReceivedEvents
        {
            get
            {
                try
                {
                    var result = new List<AsrDataReceivedEvent>();
                    foreach (var m in Model.EVENTS.DATARECEIVEDEVENT)
                    {
                        result.Add(new AsrDataReceivedEvent(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrDataReceivedEvent>();
                }
            }
        }
        
        public void AddDataReceivedEvents(AsrDataReceivedEvent data)
        {
            if (Model.EVENTS == null)
            {
                Model.EVENTS = new ();
            }
            if (Model.EVENTS.DATARECEIVEDEVENT == null)
            {
                Model.EVENTS.DATARECEIVEDEVENT = new List<DATARECEIVEDEVENT>();
            }
            foreach (var d in Model.EVENTS.DATARECEIVEDEVENT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new DATARECEIVEDEVENT();
            m = data.Model;
            Model.EVENTS.DATARECEIVEDEVENT.Add(m);
        }
        
        public void DelDataReceivedEvents(AsrDataReceivedEvent data)
        {
            if (Model.EVENTS == null)
            {
                return;
            }
            if (Model.EVENTS.DATARECEIVEDEVENT == null)
            {
                return;
            }
            foreach (var m in Model.EVENTS.DATARECEIVEDEVENT)
            {
                if (m.Equals(data.Model))
                {
                    Model.EVENTS.DATARECEIVEDEVENT.Remove(m);
                    break;
                }
            }
        }
        public List<AsrInitEvent> InitEvents
        {
            get
            {
                try
                {
                    var result = new List<AsrInitEvent>();
                    foreach (var m in Model.EVENTS.INITEVENT)
                    {
                        result.Add(new AsrInitEvent(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrInitEvent>();
                }
            }
        }
        
        public void AddInitEvents(AsrInitEvent data)
        {
            if (Model.EVENTS == null)
            {
                Model.EVENTS = new ();
            }
            if (Model.EVENTS.INITEVENT == null)
            {
                Model.EVENTS.INITEVENT = new List<INITEVENT>();
            }
            foreach (var d in Model.EVENTS.INITEVENT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new INITEVENT();
            m = data.Model;
            Model.EVENTS.INITEVENT.Add(m);
        }
        
        public void DelInitEvents(AsrInitEvent data)
        {
            if (Model.EVENTS == null)
            {
                return;
            }
            if (Model.EVENTS.INITEVENT == null)
            {
                return;
            }
            foreach (var m in Model.EVENTS.INITEVENT)
            {
                if (m.Equals(data.Model))
                {
                    Model.EVENTS.INITEVENT.Remove(m);
                    break;
                }
            }
        }
        public List<AsrTimingEvent> TimingEvents
        {
            get
            {
                try
                {
                    var result = new List<AsrTimingEvent>();
                    foreach (var m in Model.EVENTS.TIMINGEVENT)
                    {
                        result.Add(new AsrTimingEvent(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrTimingEvent>();
                }
            }
        }
        
        public void AddTimingEvents(AsrTimingEvent data)
        {
            if (Model.EVENTS == null)
            {
                Model.EVENTS = new ();
            }
            if (Model.EVENTS.TIMINGEVENT == null)
            {
                Model.EVENTS.TIMINGEVENT = new List<TIMINGEVENT>();
            }
            foreach (var d in Model.EVENTS.TIMINGEVENT)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new TIMINGEVENT();
            m = data.Model;
            Model.EVENTS.TIMINGEVENT.Add(m);
        }
        
        public void DelTimingEvents(AsrTimingEvent data)
        {
            if (Model.EVENTS == null)
            {
                return;
            }
            if (Model.EVENTS.TIMINGEVENT == null)
            {
                return;
            }
            foreach (var m in Model.EVENTS.TIMINGEVENT)
            {
                if (m.Equals(data.Model))
                {
                    Model.EVENTS.TIMINGEVENT.Remove(m);
                    break;
                }
            }
        }
        public String TerminationAndRestart
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.HANDLETERMINATIONANDRESTART.TypedValue);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                if (TerminationAndRestart != value)
                {
                    if (Model.HANDLETERMINATIONANDRESTART == null)
                    {
                        Model.HANDLETERMINATIONANDRESTART = new ();
                    }
                    Model.HANDLETERMINATIONANDRESTART.TypedValue = value;
                }
            }
        }
        
        public List<AsrPortApiOption> PortApiOptions
        {
            get
            {
                try
                {
                    var result = new List<AsrPortApiOption>();
                    foreach (var m in Model.PORTAPIOPTIONS.PORTAPIOPTION)
                    {
                        result.Add(new AsrPortApiOption(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrPortApiOption>();
                }
            }
        }
        
        public void AddPortApiOptions(AsrPortApiOption data)
        {
            if (Model.PORTAPIOPTIONS == null)
            {
                Model.PORTAPIOPTIONS = new ();
            }
            if (Model.PORTAPIOPTIONS.PORTAPIOPTION == null)
            {
                Model.PORTAPIOPTIONS.PORTAPIOPTION = new List<PORTAPIOPTION>();
            }
            foreach (var d in Model.PORTAPIOPTIONS.PORTAPIOPTION)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new PORTAPIOPTION();
            m = data.Model;
            Model.PORTAPIOPTIONS.PORTAPIOPTION.Add(m);
        }
        
        public void DelPortApiOptions(AsrPortApiOption data)
        {
            if (Model.PORTAPIOPTIONS == null)
            {
                return;
            }
            if (Model.PORTAPIOPTIONS.PORTAPIOPTION == null)
            {
                return;
            }
            foreach (var m in Model.PORTAPIOPTIONS.PORTAPIOPTION)
            {
                if (m.Equals(data.Model))
                {
                    Model.PORTAPIOPTIONS.PORTAPIOPTION.Remove(m);
                    break;
                }
            }
        }
        public List<AsrRunnableEntity> RunnableEntities
        {
            get
            {
                try
                {
                    var result = new List<AsrRunnableEntity>();
                    foreach (var m in Model.RUNNABLES.RUNNABLEENTITY)
                    {
                        result.Add(new AsrRunnableEntity(m, PathManager));
                    }
                    return result;
                }
                catch
                {
                    return new List<AsrRunnableEntity>();
                }
            }
        }
        
        public void AddRunnableEntities(AsrRunnableEntity data)
        {
            if (Model.RUNNABLES == null)
            {
                Model.RUNNABLES = new ();
            }
            if (Model.RUNNABLES.RUNNABLEENTITY == null)
            {
                Model.RUNNABLES.RUNNABLEENTITY = new List<RUNNABLEENTITY>();
            }
            foreach (var d in Model.RUNNABLES.RUNNABLEENTITY)
            {
                if (d is IAsrIdentifier dIdentifier && data is IAsrIdentifier dataIdentifier)
                {
                    if(dIdentifier.ShortName == dataIdentifier.ShortName)
                    {
                        return;
                    }
                }
            }
            var m = new RUNNABLEENTITY();
            m = data.Model;
            Model.RUNNABLES.RUNNABLEENTITY.Add(m);
        }
        
        public void DelRunnableEntities(AsrRunnableEntity data)
        {
            if (Model.RUNNABLES == null)
            {
                return;
            }
            if (Model.RUNNABLES.RUNNABLEENTITY == null)
            {
                return;
            }
            foreach (var m in Model.RUNNABLES.RUNNABLEENTITY)
            {
                if (m.Equals(data.Model))
                {
                    Model.RUNNABLES.RUNNABLEENTITY.Remove(m);
                    break;
                }
            }
        }
        public String SupportMultipleInstance
        {
            get
            {
                try
                {
                    return Convert.ToString(Model.SUPPORTSMULTIPLEINSTANTIATION.TypedValue);
                }
                catch
                {
                    return "false";
                }
            }
            set
            {
                if (SupportMultipleInstance != value)
                {
                    if (Model.SUPPORTSMULTIPLEINSTANTIATION == null)
                    {
                        Model.SUPPORTSMULTIPLEINSTANTIATION = new ();
                    }
                    Model.SUPPORTSMULTIPLEINSTANTIATION.TypedValue = value;
                }
            }
        }
        
        public AsrSwcInternalBehavior(SWCINTERNALBEHAVIOR model, AsrPathReferenceManager pathManager)
        {
            Model = model;
            PathManager = pathManager;
        }
    }
}
