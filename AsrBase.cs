using Autosar;

namespace AutosarClass
{
    public delegate void PropertyChangedEventHandler(object? sender, string name, object oldVaule, object newVaule);

    /// <summary>
    /// Asr Class represent a single arxml file
    /// </summary>
    public class Asr
    {
        /// <summary>
        /// File name of arxml file.
        /// </summary>
        private string FileName { get; } = "";
        /// <summary>
        /// Whether arxml model is modified or not.
        /// </summary>
        private bool isDirty = false;
        /// <summary>
        /// Converted data model of arxml file.
        /// </summary>
        public AUTOSAR? Model { get; } = null;
        /// <summary>
        /// Packages of Autosar in arxml file.
        /// </summary>
        public List<ARPACKAGE> ArPackages { get; } = new List<ARPACKAGE>();
        /// <summary>
        /// Autosar path and reference manager.
        /// </summary>
        public AsrPathReferenceManager PathReferenceManager { get; } = new AsrPathReferenceManager();

        /// <summary>
        /// Whether arxml model is modified or not.
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
            set
            {
                if (value != IsDirty)
                {
                    isDirty = value;
                }
            }
        }

        /// <summary>
        /// Initialze Asr from filename.
        /// File will be converted to data model. All Autosar packages will be extracted.
        /// Autosar path dictionary will be generated.
        /// </summary>
        /// <param name="filename">Filename of file want to be converted.</param>
        public Asr(string filename)
        {
            FileName = filename;
            Model = AUTOSAR.Load(filename);

            if (Model != null)
            {
                // get all autosar packages
                FindAllArPackage(ArPackages);
                // iterate all elements to generate Autosar path dictionary
                CreateAsrPath(PathReferenceManager);
                CreateAsrReference(PathReferenceManager);
            }
        }

        /// <summary>
        /// Iterate all ARPACKAGE and ARPACKAGES tag to get all Autosar package from Model.
        /// ARPACKAGES tag can have ARPACKAGE member and ARPACKAGE tag can have ARPACKAGES member.
        /// All ARPACKAGES and ARPACKAGE tag shall be checked to find all Autosar packages.
        /// </summary>
        private void FindAllArPackage(List<ARPACKAGE> result)
        {
            if (Model == null)
            {
                return;
            }

            var query = from package in Model.ARPACKAGES.ARPACKAGE
                        select package;
            query.ToList().ForEach(x =>
            {
                if (x.ARPACKAGES != null)
                {
                    // Tag ARPACKAGE has ARPACKAGES member, step deeper.
                    FindAllArPackage(x, result);
                }
                // Tag ARPACKAGE has no ARPACKAGES member, get it.
                result.Add(x);
            });
        }

        /// <summary>
        /// Iterate all ARPACKAGE and ARPACKAGES tag to get all Autosar package from ARPACKAGE.
        /// </summary>
        /// <param name="arPackage">Autosar package to be checked</param>
        public void FindAllArPackage(ARPACKAGE arPackage, List<ARPACKAGE> result)
        {
            var query = from package in arPackage.ARPACKAGES.ARPACKAGE
                        select package;
            query.ToList().ForEach(x =>
            {
                if (x.ARPACKAGES != null)
                {
                    // Tag ARPACKAGE has ARPACKAGES member, step deeper.
                    FindAllArPackage(x, result);
                }
                // Tag ARPACKAGE has no ARPACKAGES member, get it.
                result.Add(x);
            });
        }

        /// <summary>
        /// Iterate all tag in Model to genereate Autosar path dictionary.
        /// Any tag has SHORTNAME member can be treated as a dictionary.
        /// SHORTNAME with seperator "/" from top can idenfify tags in Model.
        /// as directory path in file system.
        /// </summary>
        public void CreateAsrPath(AsrPathReferenceManager manager)
        {
            if (Model != null)
            {
                // start from top with ARPACKAGES tag
                CreateAsrPath(Model.ARPACKAGES, "", "", manager);
            }
        }

        /// <summary>
        /// Iterate all tag in model to genereate Autosar path dictionary.
        /// Any tag has SHORTNAME member can be treated as a dictionary.
        /// SHORTNAME with seperator "/" from top can idenfify tags in Model.
        /// </summary>
        /// <param name="model">model to be checked</param>
        /// <param name="asrPath">current Autosar path</param>
        /// <param name="asrPathDest">current Autosar dest path</param>
        private void CreateAsrPath(object model, string asrPath, string asrPathDest, AsrPathReferenceManager manager)
        {
            // Reflect all properties to get SHORTNAME in model
            foreach (var prop in model.GetType().GetProperties())
            {
                if (prop.Name == "SHORTNAME")
                {
                    // Property with member "SHORTNAME"
                    if (prop.GetValue(model) is IDENTIFIER identifier)
                    {
                        // It is an IDENTIFIER instance, generate new path and put it into dictionary
                        asrPath += $"/{identifier.TypedValue}";
                        asrPathDest += $"/{model.GetType()}";
                        manager.AddPath(model, asrPath, asrPathDest);
                    }
                }
            }

            // Reflect all properties to decide it is needed to check deeper
            foreach (var prop in model.GetType().GetProperties())
            {
                if ((prop.PropertyType.Namespace == "Autosar") || (prop.PropertyType.Namespace == "System.Collections.Generic"))
                {
                    // Property with namespace "Autosar" or it is a Generic Collection instance
                    var v = prop.GetValue(model);
                    if ((v != null) && (prop.Name != "SHORTNAME"))
                    {
                        // Property is not null and not "SHORTNAME"
                        if (v is IEnumerable<object> valueList)
                        {
                            // Property is a Generic Collection instance, check each member deeper
                            foreach (var v2 in valueList)
                            {
                                CreateAsrPath(v2, asrPath, asrPathDest, manager);
                            }
                        }
                        else
                        {
                            // Property is not Generic Collection instance, check it deeper
                            CreateAsrPath(v, asrPath, asrPathDest, manager);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Iterate all tag in Model to genereate Autosar path dictionary.
        /// Any tag has SHORTNAME member can be treated as a dictionary.
        /// SHORTNAME with seperator "/" from top can idenfify tags in Model.
        /// as directory path in file system.
        /// </summary>
        public void CreateAsrReference(AsrPathReferenceManager manager)
        {
            if (Model != null)
            {
                // start from top with ARPACKAGES tag
                foreach (var package in ArPackages)
                {
                    CreateAsrReference(package, manager);
                }
            }
        }

        /// <summary>
        /// Iterate all tag in model to genereate Autosar path dictionary.
        /// Any tag has SHORTNAME member can be treated as a dictionary.
        /// SHORTNAME with seperator "/" from top can idenfify tags in Model.
        /// </summary>
        /// <param name="model">model to be checked</param>
        /// <param name="asrPathLiteral">current Autosar path</param>
        private void CreateAsrReference(object model, AsrPathReferenceManager manager)
        {
            // Reflect all properties to get SHORTNAME in model
            foreach (var prop in model.GetType().GetProperties())
            {
                try
                {
                    var v = prop.GetValue(model);

                    if (v == null)
                    {
                        continue;
                    }

                    if (prop.Name.EndsWith("REF"))
                    {
                        if (prop.PropertyType.Namespace == "System.Collections.Generic")
                        {
                            // Property is not null and not "SHORTNAME"
                            if (v is IEnumerable<REF> valueList)
                            {
                                // Property is a Generic Collection instance, check each member deeper
                                foreach (var v1 in valueList)
                                {
                                    var isRef = false;
                                    var asrReference = v1.TypedValue;
                                    var asrReferenceTag = v1.GetType().Name;
                                    foreach (var prop2 in v1.GetType().GetProperties())
                                    {
                                        if (prop2.Name == "DEST")
                                        {
                                            var v2 = prop2.GetValue(v1);
                                            if (v2 != null)
                                            {
                                                var asrReferenceDest = v2.ToString();
                                                if (asrReferenceDest != null)
                                                {
                                                    manager.AddReference(v1, asrReference, asrReferenceTag, asrReferenceDest);
                                                    isRef = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (isRef == false)
                                    {
                                        CreateAsrReference(v1, manager);
                                    }
                                }
                            }
                        }
                        else if (prop.GetValue(model) is REF reference)
                        {
                            var isRef = false;
                            var asrReference = reference.TypedValue;
                            var asrReferenceTag = reference.GetType().Name;
                            foreach (var prop2 in reference.GetType().GetProperties())
                            {
                                if (prop2.Name == "DEST")
                                {
                                    var v1 = prop2.GetValue(reference);
                                    if (v1 != null)
                                    {
                                        var asrReferenceDest = v1.ToString();
                                        if (asrReferenceDest != null)
                                        {
                                            manager.AddReference(reference, asrReference, asrReferenceTag, asrReferenceDest);
                                            isRef = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (isRef == false)
                            {
                                CreateAsrReference(v, manager);
                            }
                        }
                        else
                        {
                            CreateAsrReference(v, manager);
                        }
                    }
                    else
                    {
                        if (prop.PropertyType.Namespace == "System.Collections.Generic")
                        {
                            if (v is IEnumerable<object> valueList)
                            {
                                // Property is a Generic Collection instance, check each member deeper
                                foreach (var v1 in valueList)
                                {
                                    if (v1.GetType().Namespace == "Autosar")
                                    {
                                        CreateAsrReference(v1, manager);
                                    }
                                }
                            }
                        }
                        else if (prop.PropertyType.Namespace == "Autosar")
                        {
                            CreateAsrReference(v, manager);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Save model to file.
        /// After save, all module shall make IsDirty to false.
        /// </summary>
        public void Save()
        {
            if (FileName != "" && Model != null)
            {
                Model.Save(FileName);
                IsDirty = false;
            }
        }
    }
}