namespace AutosarClass
{
    /// <summary>
    /// Autosar reference information class.
    /// </summary>
    public class AsrReferenceInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private AsrPathInfo? asrPath = null;
        public void RaisePropertyChanged(string name, object oldValue, object newVaule)
        {
            PropertyChanged?.Invoke(this, name, oldValue, newVaule);
        }

        /// <summary>
        /// Autosar path literal information.
        /// AsrReferenceLiteral is composed by AsrReference, AsrReferenceDest
        /// and AsrReferenceTag attribute.
        /// The literal form is AsrReference@AsrReferenceTag@AsrReferenceDest.
        /// </summary>
        public string AsrReferenceLiteral { get; set; }

        /// <summary>
        /// AsrPath of this reference. It can be null
        /// </summary>
        public AsrPathInfo? AsrPath
        {
            get
            {
                return asrPath;
            }
            set
            {
                if (AsrPath is null)
                {
                    asrPath = value;
                }
            }
        }

        /// <summary>
        /// Initialize Autosar reference information class.
        /// </summary>
        /// <param name="asrPath">Autosar path of Autosar reference.</param>
        /// <param name="tag">Tag of Autosar reference.</param>
        public AsrReferenceInfo(AsrPathInfo asrPath, string tag)
        {
            AsrPath = asrPath;
            AsrReferenceLiteral = $"{asrPath.AsrPathLiteral}@{tag}";
            AsrPath.PropertyChanged += AsrPathPropertyChanged;
        }

        public AsrReferenceInfo(string reference, string dest, string tag)
        {
            AsrPath = null;
            AsrReferenceLiteral = $"{reference}@{dest}@{tag}";
        }

        /// <summary>
        /// Autosasr reference.
        /// </summary>
        public string AsrReference
        {
            get
            {
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                return parts[0];
            }
            set
            {
                if (value == AsrReference)
                {
                    return;
                }

                // Can not direct change AsrReference if AsrPath is not null
                if (AsrPath is not null)
                {
                    return;
                }
                var oldLiteral = AsrReferenceLiteral;
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                parts[0] = value;
                var newLiteral = string.Join('@', parts);
                RaisePropertyChanged("AsrReference", oldLiteral, newLiteral);
            }
        }

        /// <summary>
        /// Short form of Autosar reference.
        /// </summary>
        public string AsrReferenceShort
        {
            get
            {
                var parts = AsrReference.Split('/');
                if (parts.Length <= 1)
                {
                    throw new Exception("Invalid Autosar path information");

                }
                else
                {
                    return parts[^1];
                }
            }
            set
            {
                if (value == AsrReferenceShort)
                {
                    return;
                }

                // Can not direct change AsrReferenceShort if AsrPath is not null
                if (AsrPath is not null)
                {
                    return;
                }

                var parts = AsrReference.Split("/");
                if (parts.Length <= 1)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                parts[^1] = value;
                AsrReference = string.Join('/', parts);
            }
        }

        /// <summary>
        /// Autosar reference dest attribute.
        /// </summary>
        public string AsrReferenceDest
        {
            get
            {
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar reference information");
                }
                return parts[1];
            }
            set
            {
                if (value == AsrReferenceDest)
                {
                    return;
                }

                // Can not direct change AsrReferenceTag if AsrPath is not null
                if (AsrPath is not null)
                {
                    return;
                }

                var oldLiteral = AsrReferenceLiteral;
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar reference information");
                }
                parts[1] = value;
                var newLiteral = string.Join('@', parts);
                RaisePropertyChanged("AsrReferenceDest", oldLiteral, newLiteral);
            }
        }

        /// <summary>
        /// Short form of AsrReferenceDest
        /// </summary>
        public string AsrReferenceDestShort
        {
            get
            {
                return AsrReferenceDest.Replace("-", "");
            }
        }

        /// <summary>
        /// Tag of Autosar reference.
        /// </summary>
        public string AsrReferenceTag
        {
            get
            {
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar reference information");
                }
                return parts[2];
            }
            set
            {
                if (value == AsrReferenceTag)
                {
                    return;
                }

                // Can not direct change AsrReferenceTag if AsrPath is not null
                if (AsrPath is not null)
                {
                    return;
                }

                var oldLiteral = AsrReferenceLiteral;
                var parts = AsrReferenceLiteral.Split('@');
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid Autosar reference information");
                }
                parts[2] = value;
                var newLiteral = string.Join('@', parts);
                RaisePropertyChanged("AsrReferenceTag", oldLiteral, newLiteral);
            }
        }

        /// <summary>
        /// Short form of tag.
        /// </summary>
        public string AsrReferenceTagShort
        {
            get
            {
                var parts = AsrReferenceTag.Split('.');
                if (parts.Length <= 1)
                {
                    return AsrReferenceTag;

                }
                else
                {
                    return parts[^1];
                }
            }
            set
            {
                if (value == AsrReferenceTagShort)
                {
                    return;
                }

                // Can not direct change AsrReferenceTag if AsrPath is not null
                if (AsrPath is not null)
                {
                    return;
                }

                var parts = AsrReferenceTag.Split(".");
                if (parts.Length <= 1)
                {
                    AsrReferenceTag = value;
                }
                else
                {
                    parts[^1] = value;
                    AsrReferenceTag = string.Join('/', parts);
                }
            }
        }

        /// <summary>
        /// Equal determination function.
        /// </summary>
        /// <param name="obj">Other object to check.</param>
        /// <returns>
        /// true: equal
        /// false: not equal
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is AsrReferenceInfo referenceInfo)
            {
                if (referenceInfo.AsrReferenceLiteral == AsrReferenceLiteral)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hash code generator.
        /// </summary>
        /// <returns>Hash code generated.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Operator == function.
        /// </summary>
        /// <param name="a">One Autosar reference information.</param>
        /// <param name="b">Another Autosar reference information.</param>
        /// <returns>
        /// true: equal
        /// false: not equal
        /// </returns>
        public static bool operator ==(AsrReferenceInfo a, AsrReferenceInfo b)
        {
            return Equals(a, b);
        }

        /// <summary>
        /// Operator != function.
        /// </summary>
        /// <param name="a">One Autosar reference information.</param>
        /// <param name="b">Another Autosar reference information.</param>
        /// <returns>
        /// true: not equal
        /// false: equal
        /// </returns>
        public static bool operator !=(AsrReferenceInfo a, AsrReferenceInfo b)
        {
            return !Equals(a, b);
        }

        /// <summary>
        /// Covert to string.
        /// </summary>
        /// <returns>String converted.</returns>
        public override string ToString()
        {
            return $"{AsrReferenceShort}@{AsrReferenceTagShort}@{AsrReferenceDest}";
        }

        private void AsrPathPropertyChanged(object? sender, string name, object oldValue, object newValue)
        {
            if (sender is AsrPathInfo && oldValue is string && newValue is string newLiteral)
            {
                var oldReferenceLiteral = AsrReferenceLiteral;
                AsrReferenceLiteral = $"{newLiteral}@{AsrReferenceTag}";
                RaisePropertyChanged("AsrReferenceLiteral", oldReferenceLiteral, AsrReferenceLiteral);
            }
        }
    }
}
