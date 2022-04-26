using Autosar;

namespace AutosarClass
{
    /// <summary>
    /// Autosar path manager class.
    /// </summary>
    public class AsrPathReferenceManager
    {
        /// <summary>
        /// Dictionary between Autosar path and model.
        /// </summary>
        public Dictionary<AsrPathInfo, object> AsrPathModelDict { get; }
        /// <summary>
        /// Dictionary between model and Autosar path.
        /// </summary>
        public Dictionary<object, AsrPathInfo> ModelAsrPathDict { get; }
        /// <summary>
        /// Dictionary between Autosar reference and model.
        /// </summary>
        public Dictionary<AsrReferenceInfo, List<object>> AsrReferenceModelDict { get; }
        /// <summary>
        /// Dictionary between model and Autosar reference.
        /// </summary>
        public Dictionary<object, AsrReferenceInfo> ModelAsrReferenceDict { get; }
        /// <summary>
        /// Dictionary between Autosar path literal and Autosar path
        /// </summary>
        public Dictionary<string, List<AsrPathInfo>> LiteralAsrPathDict { get; }
        /// <summary>
        /// Dictionary between short form of Autosar path literal and Autosar path
        /// </summary>
        public Dictionary<string, AsrPathInfo> LiteralShortAsrPathDict { get; }
        /// <summary>
        /// Dictionary between short form of Autosar path literal and Autosar path
        /// </summary>
        public Dictionary<AsrPathInfo, List<AsrReferenceInfo>> AsrPathAsrReferenceDict { get; }

        /// <summary>
        /// Initialize Autosar path manager class.
        /// </summary>
        public AsrPathReferenceManager()
        {
            AsrPathModelDict = new ();
            ModelAsrPathDict = new();
            AsrReferenceModelDict = new();
            ModelAsrReferenceDict = new();
            LiteralAsrPathDict = new();
            LiteralShortAsrPathDict = new();
            AsrPathAsrReferenceDict = new();
        }

        private AsrPathInfo? FindAsrPathInfo(string asrPathLiteral)
        {
            if (LiteralAsrPathDict.ContainsKey(asrPathLiteral) == true)
            {
                if (LiteralAsrPathDict[asrPathLiteral].Count > 0)
                {
                    return LiteralAsrPathDict[asrPathLiteral][0];
                }
            }
            return null;
        }

        private AsrPathInfo? FindAsrPathInfo(string asrPath, string asrPathTag)
        {
            return FindAsrPathInfo($"{asrPath}@{asrPathTag}");
        }

        private AsrPathInfo? FindAsrPathInfoByShort(string asrPathLiteralShort)
        {
            if (LiteralShortAsrPathDict.ContainsKey(asrPathLiteralShort) == true)
            {
                return LiteralShortAsrPathDict[asrPathLiteralShort];
            }
            return null;
        }

        private AsrPathInfo? FindAsrPathInfoByShort(string asrPath, string asrPathTagShort)
        {
            return FindAsrPathInfoByShort($"{asrPath}@{asrPathTagShort}");
        }

        private List<AsrPathInfo> FindRelatedAsrPathInfo(string asrPathLiteral)
        {
            if (LiteralAsrPathDict.ContainsKey(asrPathLiteral) == true)
            {
                return LiteralAsrPathDict[asrPathLiteral];
            }
            return new();
        }

        private List<AsrPathInfo> FindRelatedAsrPathInfo(string asrPath, string asrPathTag)
        {
            return FindRelatedAsrPathInfo($"{asrPath}@{asrPathTag}");
        }

        /// <summary>
        /// Add Autosar path information.
        /// </summary>
        /// <param name="model">Model of path.</param>
        /// <param name="asrPath">Autosar path literal.</param>
        /// <param name="asrPathTag">Autosar path tag.</param>
        public void AddPath(object model, string asrPath, string asrPathTag)
        {
            var pathInfo = new AsrPathInfo(asrPath, asrPathTag);

            AddPath(model, pathInfo);
        }

        /// <summary>
        /// Add Autosar path information.
        /// </summary>
        /// <param name="model">Model of path.</param>
        /// <param name="pathInfo">Autosar path information.</param>
        public void AddPath(object model, AsrPathInfo pathInfo)
        {
            try
            {
                AsrPathModelDict.Add(pathInfo, model);
                ModelAsrPathDict.Add(model, pathInfo);
                LiteralAsrPathDict.Add(pathInfo.AsrPathLiteral, new());
                LiteralAsrPathDict[pathInfo.AsrPathLiteral].Add(pathInfo);
                LiteralShortAsrPathDict.Add(pathInfo.AsrPathLiteralShort, pathInfo);
                AsrPathAsrReferenceDict.Add(pathInfo, new());
                var pathParts = pathInfo.AsrPath.Split('/');
                var pathTagParts = pathInfo.AsrPathTag.Split('/');
                for (int i = 0; i < pathParts.Length - 1; i++)
                {
                    var subPathParts = new string[i + 1];
                    for (int j = 0; j <= i; j++)
                    {
                        subPathParts[j] = pathParts[j];
                    }
                    var subPath = string.Join("/", subPathParts);

                    var subPathTagParts = new string[i + 1];
                    for (int j = 0; j <= i; j++)
                    {
                        subPathTagParts[j] = pathTagParts[j];
                    }
                    var subPathTag = string.Join("/", subPathTagParts);

                    var subPathLiteral = $"{subPath}@{subPathTag}";
                    if (LiteralAsrPathDict.ContainsKey(subPathLiteral))
                    {
                        LiteralAsrPathDict[subPathLiteral].Add(pathInfo);
                    }
                }
                pathInfo.PropertyChanged += PathPropertyChanged;
            }
            catch
            {
                throw new Exception($"Can not add path information {pathInfo}");
            }
        }

        /// <summary>
        /// Add Autosar path information.
        /// </summary>
        /// <param name="model">Model of path.</param>
        /// <param name="asrReference">Autosar reference.</param>
        /// <param name="asrReferenceTag">Autosar reference tag.</param>
        /// <param name="asrReferenceDest">Autosar reference dest.</param>
        public void AddReference(object model, string asrReference, string asrReferenceTag, string asrReferenceDest)
        {
            var asrReferenceDestShort = asrReferenceDest.Replace("-", "");
            AsrReferenceInfo referenceInfo;
            var asrPathInfo = FindAsrPathInfoByShort(asrReference, asrReferenceDestShort);

            if (asrPathInfo is null)
            {
                referenceInfo = new AsrReferenceInfo(asrReference, asrReferenceTag, asrReferenceDestShort);
            }
            else
            {
                referenceInfo = new AsrReferenceInfo(asrPathInfo, asrReferenceTag);
            }
            AddReference(model, referenceInfo);
        }

        /// <summary>
        /// Add Autosar path information.
        /// </summary>
        /// <param name="model">Model of path.</param>
        /// <param name="referenceInfo">Autosar reference information.</param>
        public void AddReference(object model, AsrReferenceInfo referenceInfo)
        {
            try
            {
                if (!AsrReferenceModelDict.ContainsKey(referenceInfo))
                {
                    AsrReferenceModelDict[referenceInfo] = new List<object>();
                }
                AsrReferenceModelDict[referenceInfo].Add(model);
                ModelAsrReferenceDict[model] = referenceInfo;
                if (referenceInfo.AsrPath is not null)
                {
                    if (AsrPathAsrReferenceDict.ContainsKey(referenceInfo.AsrPath))
                    {
                        AsrPathAsrReferenceDict[referenceInfo.AsrPath].Add(referenceInfo);
                    }
                }
                referenceInfo.PropertyChanged += ReferencePropertyChanged;
            }
            catch
            {
                throw new Exception($"Can not add reference information {referenceInfo}");
            }
        }

        /// <summary>
        /// Remove Autosar path information.
        /// </summary>
        /// <param name="pathInfo">Autosar path information to remove.</param>
        /// <exception cref="Exception"></exception>
        public void RemovePath(AsrPathInfo pathInfo)
        {
            try
            {
                var model = AsrPathModelDict[pathInfo];
                AsrPathModelDict.Remove(pathInfo);
                ModelAsrPathDict.Remove(model);
                LiteralAsrPathDict.Remove(pathInfo.AsrPathLiteral);
                LiteralShortAsrPathDict.Remove(pathInfo.AsrPathLiteralShort);
                if (AsrPathAsrReferenceDict.ContainsKey(pathInfo))
                {
                    foreach (var referenceInfo in AsrPathAsrReferenceDict[pathInfo])
                    {
                        referenceInfo.AsrPath = null;
                    }
                    AsrPathAsrReferenceDict.Remove(pathInfo);
                }
            }
            catch
            {
                throw new Exception($"Error when remove {pathInfo} from AsrPathManager");
            }
        }

        /// <summary>
        /// Remove model.
        /// </summary>
        /// <param name="model">Model to remove.</param>
        public void RemovePath(object model)
        {
            try
            {
                var pathInfo = ModelAsrPathDict[model];
                AsrPathModelDict.Remove(pathInfo);
                ModelAsrPathDict.Remove(model);
                LiteralAsrPathDict.Remove(pathInfo.AsrPathLiteral);
                LiteralShortAsrPathDict.Remove(pathInfo.AsrPathLiteralShort);
                if (AsrPathAsrReferenceDict.ContainsKey(pathInfo))
                {
                    foreach (var referenceInfo in AsrPathAsrReferenceDict[pathInfo])
                    {
                        referenceInfo.AsrPath = null;
                    }
                    AsrPathAsrReferenceDict.Remove(pathInfo);
                }
            }
            catch
            {
                throw new Exception($"Error when remove {model} from AsrPathManager");
            }
        }

        /// <summary>
        /// Remove Autosar reference information.
        /// </summary>
        /// <param name="referenceInfo">Autosar reference information to remove.</param>
        /// <exception cref="Exception"></exception>
        public void RemoveReference(AsrReferenceInfo referenceInfo)
        {
            try
            {
                var models = AsrReferenceModelDict[referenceInfo];
                AsrReferenceModelDict.Remove(referenceInfo);
                foreach (var model in models)
                {
                    ModelAsrReferenceDict.Remove(model);
                }
                if (referenceInfo.AsrPath is not null)
                {
                    if (AsrPathAsrReferenceDict.ContainsKey(referenceInfo.AsrPath))
                    {
                        AsrPathAsrReferenceDict[referenceInfo.AsrPath].Remove(referenceInfo);
                    }
                }
            }
            catch
            {
                throw new Exception($"Error when remove {referenceInfo} from AsrReferenceManager");
            }
        }

        /// <summary>
        /// Remove model.
        /// </summary>
        /// <param name="model">Model to remove.</param>
        public void RemoveReference(object model)
        {
            try
            {
                var referenceInfo = ModelAsrReferenceDict[model];
                ModelAsrReferenceDict.Remove(model);
                var models = AsrReferenceModelDict[referenceInfo];
                models.Remove(model);
                if (models.Count == 0)
                {
                    AsrReferenceModelDict.Remove(referenceInfo);
                }
            }
            catch
            {
                throw new Exception($"Error when remove {model} from AsrReferenceManager");
            }
        }

        /// <summary>
        /// Get objects by path.
        /// </summary>
        /// <param name="path">Autosar path to lookup.</param>
        /// <returns>Models with required Autosar path.</returns>
        public List<object> this[string path]
        {
            get
            {
                var query = from item in AsrPathModelDict
                            where item.Key.AsrPath == path
                            select item.Value;

                return query.ToList();
            }
        }

        /// <summary>
        /// Get Autosar path information by model.
        /// </summary>
        /// <param name="model">Model to lookup.</param>
        /// <returns>Autosar path information according to model.</returns>
        public AsrPathInfo? GetPathInfo(object model)
        {
            try
            {
                return ModelAsrPathDict[model];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Autosar reference information by model.
        /// </summary>
        /// <param name="model">Model to lookup.</param>
        /// <returns>Autosar path information according to model.</returns>
        public AsrReferenceInfo? GetReferenceInfo(object model)
        {
            try
            {
                return ModelAsrReferenceDict[model];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get model by Autosar reference information.
        /// </summary>
        /// <param name="reference">Autosar reference information to lookup.</param>
        /// <returns>Model according to Autosar reference information.</returns>
        public object? GetModel(AsrReferenceInfo reference)
        {
            try
            {
                return AsrReferenceModelDict[reference];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get model by Autosar path information.
        /// </summary>
        /// <param name="path">Autosar path information to lookup.</param>
        /// <returns>Model according to Autosar path information.</returns>
        public object? GetModel(AsrPathInfo path)
        {
            try
            {
                return AsrPathModelDict[path];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Autosar path property changed handler.
        /// </summary>
        /// <param name="sender">Model of changed property.</param>
        /// <param name="name">Name of changed property.</param>
        /// <param name="oldValue">Old value of changed property.</param>
        /// <param name="newValue">New value of changed property.</param>
        /// <exception cref="Exception"></exception>
        private void PathPropertyChanged(object? sender, string name, object oldValue, object newValue)
        {
            if (sender is AsrPathInfo newAsrPathInfo && oldValue is string oldLiteral && newValue is string newLiteral)
            {
                var oldAsrPathInfo = new AsrPathInfo(oldLiteral);

                switch (name)
                {
                    case "AsrPath":
                        {
                            LiteralAsrPathDict.Add(newLiteral, LiteralAsrPathDict[oldLiteral]);
                            LiteralAsrPathDict.Remove(oldLiteral);
                            LiteralShortAsrPathDict.Add(newAsrPathInfo.AsrPathLiteralShort, LiteralShortAsrPathDict[oldAsrPathInfo.AsrPathLiteralShort]);
                            LiteralShortAsrPathDict.Remove(oldAsrPathInfo.AsrPathLiteralShort);

                            // Iterate all in dictionary
                            foreach (var asrPathInfo in FindRelatedAsrPathInfo(newLiteral))
                            {
                                if (asrPathInfo == newAsrPathInfo)
                                {
                                    continue;
                                }
                                var partsKey = asrPathInfo.AsrPath.Split("/");
                                var parts = newAsrPathInfo.AsrPath.Split("/");

                                if (partsKey.Length >= parts.Length)
                                {
                                    for (int i = 0; i < parts.Length; i++)
                                    {
                                        partsKey[i] = parts[i];
                                    }

                                    var newKeyAsrPath = string.Join('/', partsKey);
                                    // Check name duplication
                                    var asrPathInfoFound = FindAsrPathInfo(newKeyAsrPath, asrPathInfo.AsrPathTag);
                                    if (asrPathInfoFound is not null)
                                    {
                                        Console.WriteLine($"Already have model with name {newKeyAsrPath}");
                                        continue;
                                    }
                                    // Update ModelAsrPathDict
                                    asrPathInfo.AsrPathLiteral = $"{newKeyAsrPath}@{asrPathInfo.AsrPathTag}";
                                }
                            }

                            // Update model
                            var modelUpdate = AsrPathModelDict[newAsrPathInfo];
                            foreach (var prop in modelUpdate.GetType().GetProperties())
                            {
                                if (prop.Name == "SHORTNAME")
                                {
                                    // Property with member "SHORTNAME"
                                    if (prop.GetValue(modelUpdate) is IDENTIFIER identifier)
                                    {
                                        // It is an IDENTIFIER instance, generate new path and put it into dictionary
                                        identifier.TypedValue = newAsrPathInfo.AsrPathShort;
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Autosar reference changed handler.
        /// </summary>
        /// <param name="sender">Model of changed property.</param>
        /// <param name="name">Name of changed property.</param>
        /// <param name="oldValue">Old value of changed property.</param>
        /// <param name="newValue">New value of changed property.</param>
        /// <exception cref="Exception"></exception>
        private void ReferencePropertyChanged(object? sender, string name, object oldValue, object newValue)
        {
            if (sender is AsrReferenceInfo newAsrReferenceInfo && oldValue is string oldLiteral && newValue is string newLiteral)
            {
                var newAsrReferenceParts = newLiteral.Split("@");
                if (newAsrReferenceParts.Length != 3)
                {
                    return;
                }
                var newAsrReference = newAsrReferenceParts[0];
                var newAsrReferenceDest = newAsrReferenceParts[1];
                var newAsrReferenceTag = newAsrReferenceParts[2];

                var oldAsrReferenceParts = oldLiteral.Split("@");
                if (oldAsrReferenceParts.Length != 3)
                {
                    return;
                }
                var oldAsrReferenceDest = oldAsrReferenceParts[1];
                var oldAsrReferenceTag = oldAsrReferenceParts[2];

                switch (name)
                {
                    case "AsrReference":
                        {
                            var asrPathInfoFound = FindAsrPathInfo(newAsrReference, newAsrReferenceDest);
                            if (asrPathInfoFound is not null)
                            {
                                newAsrReferenceInfo.AsrPath = asrPathInfoFound;
                            }
                            else
                            {
                                newAsrReferenceInfo.AsrReferenceLiteral = newLiteral;
                            }
                        }
                        break;

                    case "AsrReferenceTag":
                        {
                            var asrPathInfoFound = FindAsrPathInfo(newAsrReference, newAsrReferenceDest);
                            if (asrPathInfoFound is not null)
                            {
                                newAsrReferenceInfo.AsrPath = asrPathInfoFound;
                                newAsrReferenceInfo.AsrReferenceTag = newAsrReferenceTag;
                            }
                            else
                            {
                                newAsrReferenceInfo.AsrReferenceLiteral = newLiteral;
                            }
                        }
                        break;

                    case "AsrReferenceDest":
                        {
                            var asrPathInfoFound = FindAsrPathInfo(newAsrReference, newAsrReferenceDest);
                            if (asrPathInfoFound is not null)
                            {
                                newAsrReferenceInfo.AsrPath = asrPathInfoFound;
                            }
                            else
                            {
                                newAsrReferenceInfo.AsrReferenceLiteral = newLiteral;
                            }
                        }
                        break;

                    default:
                        break;
                }

                var models = AsrReferenceModelDict[newAsrReferenceInfo];
                foreach (var model in models)
                {
                    if (oldAsrReferenceTag == newAsrReferenceTag)
                    {
                        if (oldAsrReferenceDest == newAsrReferenceDest)
                        {
                            foreach (var prop2 in model.GetType().GetProperties())
                            {
                                if (prop2.Name == "TypedValue")
                                {
                                    prop2.SetValue(model, newAsrReference);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
