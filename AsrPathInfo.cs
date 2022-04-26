namespace AutosarClass
{
    /// <summary>
    /// Autosar path and reference information class.
    /// </summary>
    public class AsrPathInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string name, object oldValue, object newVaule)
        {
            PropertyChanged?.Invoke(this, name, oldValue, newVaule);
        }

        private string asrPathLiteral;

        /// <summary>
        /// Initialize Autosar path information class.
        /// </summary>
        /// <param name="pathLiteral">Path literal of Autosar model.</param>
        public AsrPathInfo(string pathLiteral)
        {
            var parts = pathLiteral.Split('@');
            if (parts.Length != 2)
            {
                throw new Exception("Invalid path literal to initialize AsrPathInfo");
            }
            else
            {
                asrPathLiteral = pathLiteral;
            }
        }

        /// <summary>
        /// Initialize Autosar path information class.
        /// </summary>
        /// <param name="path">Path of Autosar model.</param>
        /// <param name="tag">Tag of Autosar model.</param>
        public AsrPathInfo(string path, string tag)
        {
            tag = tag.Replace("Autosar.", "");
            asrPathLiteral = $"{path}@{tag}";
        }

        /// <summary>
        /// Autosar path literal information.
        /// AsrPathLiteral is composed by AsrPath and AsrPathTag.
        /// The literal form is AsrPath@AsrPathTag.
        /// </summary>
        public string AsrPathLiteral
        {
            get
            {
                return asrPathLiteral;
            }
            set
            {
                if (value != null)
                {
                    var oldPathLiteral = asrPathLiteral;
                    var parts = value.Split('@');
                    if (parts.Length != 2)
                    {
                        throw new Exception("Invalid Autosar path information");
                    }
                    asrPathLiteral = value;
                    RaisePropertyChanged("AsrPathLiteral", oldPathLiteral, value);
                }
            }
        }


        public string AsrPathLiteralShort
        {
            get
            {
                return $"{AsrPath}@{AsrPathTagShort}";
            }
        }

        /// <summary>
        /// Autosar path.
        /// </summary>
        public string AsrPath
        {
            get
            {
                var parts = AsrPathLiteral.Split('@');
                if (parts == null)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                if (parts.Length != 2)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                return parts[0];
            }
            set
            {
                if (value != AsrPath)
                {
                    var oldPathLiteral = AsrPathLiteral;
                    var parts = AsrPathLiteral.Split('@');
                    if (parts.Length != 2)
                    {
                        throw new Exception("Invalid Autosar path information");
                    }
                    parts[0] = value;
                    var newPathLiteral = string.Join('@', parts);
                    AsrPathLiteral = newPathLiteral;
                    RaisePropertyChanged("AsrPath", oldPathLiteral, newPathLiteral);
                }
            }
        }

        /// <summary>
        /// Short form of Autosar path.
        /// </summary>
        public string AsrPathShort
        {
            get
            {
                var parts = AsrPath.Split('/');
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
                if (value != AsrPathShort)
                {
                    var parts = AsrPath.Split("/");
                    if (parts.Length <= 1)
                    {
                        throw new Exception("Invalid Autosar path information");
                    }
                    parts[^1] = value;
                    AsrPath = string.Join('/', parts);
                }
            }
        }

        /// <summary>
        /// Tag of model.
        /// </summary>
        public string AsrPathTag
        {
            get
            {
                var parts = AsrPathLiteral.Split('@');
                if (parts.Length != 2)
                {
                    throw new Exception("Invalid Autosar path information");
                }
                return parts[1];
            }
            set
            {
                if (value != AsrPathTag)
                {
                    var oldPathLiteral = AsrPathLiteral;
                    var parts = AsrPathLiteral.Split('@');
                    if (parts.Length != 2)
                    {
                        throw new Exception("Invalid Autosar path information");
                    }
                    parts[1] = value;
                    var newPathLiteral = string.Join('@', parts);
                    asrPathLiteral = newPathLiteral;
                    RaisePropertyChanged("AsrPathTag", oldPathLiteral, newPathLiteral);
                }
            }
        }

        /// <summary>
        /// Short form of Autosar path.
        /// </summary>
        public string AsrPathTagShort
        {
            get
            {
                var parts = AsrPathTag.Split('/');
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
                if (value != AsrPathTagShort)
                {
                    var parts = AsrPathTag.Split("/");
                    if (parts.Length <= 1)
                    {
                        throw new Exception("Invalid Autosar path information");
                    }
                    parts[^1] = value;
                    AsrPathTag = string.Join('/', parts);
                }
            }
        }

        /// <summary>
        /// Create Autosar path information of child node.
        /// </summary>
        /// <param name="path">ShortName of child node.</param>
        /// <param name="tag">Tag of child node.</param>
        /// <returns>Created Autosar path information</returns>
        public AsrPathInfo CreateChildPathInfo(string path, string tag)
        {
            return new AsrPathInfo($"{AsrPathLiteral}/{path}", $"{tag}");
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
            if (obj is AsrPathInfo pathInfo)
            {
                if (pathInfo.AsrPathLiteral == AsrPathLiteral)
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
        /// <param name="a">One Autosar path information.</param>
        /// <param name="b">Another Autosar path information.</param>
        /// <returns>
        /// true: equal
        /// false: not equal
        /// </returns>
        public static bool operator ==(AsrPathInfo a, AsrPathInfo b)
        {
            return Equals(a, b);
        }

        /// <summary>
        /// Operator != function.
        /// </summary>
        /// <param name="a">One Autosar path information.</param>
        /// <param name="b">Another Autosar path information.</param>
        /// <returns>
        /// true: not equal
        /// false: equal
        /// </returns>
        public static bool operator !=(AsrPathInfo a, AsrPathInfo b)
        {
            return !Equals(a, b);
        }

        /// <summary>
        /// Covert to string.
        /// </summary>
        /// <returns>String converted.</returns>
        public override string ToString()
        {
            return $"{AsrPathShort}@{AsrPathTagShort}";
        }
    }
}
