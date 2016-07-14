using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Layer;

namespace Validator1
{
    /// <summary>
    /// Custom properties are added to the Layer Designer via a custom
    /// Property Descriptor. We have to export this Property Descriptor
    /// using MEF to make it available in the Layer Designer.
    /// </summary>
    [Export(typeof(IPropertyExtension))]
    public class Validator1Property : PropertyExtension<ILayer>
    {
        /// <summary>
        /// Each custom property needs to have a unique name. A good name
        /// is the full name of this class.
        /// </summary>
        public static readonly string FullName = typeof(Validator1Property).FullName;

        /// <summary>
        /// Construct the Validator1Property Property. This property is available only on Layers.
        /// </summary>
        public Validator1Property()
            : base(FullName)
        {
        }

        /// <summary>
        /// The display name is shown in the property browser.
        /// </summary>
        public override string DisplayName
        {
            get { return Resources.Validator1PropertyDisplayName; }
        }

        /// <summary>
        /// The description is shown at the bottom of the property browser.
        /// </summary>
        public override string Description
        {
            get { return Resources.Validator1PropertyDescription; }
        }

        /// <summary>
        /// This is called to set a new value for this property. We must
        /// throw an exception if the value is invalid.
        /// </summary>
        /// <param name="component">The target element (layer)</param>
        /// <param name="value">The new value</param>
        public override void SetValue(object component, object value)
        {
            ValidateValue(value);

            base.SetValue(component, value);
        }

        /// <summary>
        /// Helper to validate the value.
        /// </summary>
        /// <param name="value">The value to validate</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Text.RegularExpressions.Regex", Justification = "We dont need the Regex result.")]
        private static void ValidateValue(object value)
        {
            string pattern = value as string;
            if (pattern != null)
            {
                // throws for an invalid regular expression
                new Regex(pattern);
            }
        }
    }
}
