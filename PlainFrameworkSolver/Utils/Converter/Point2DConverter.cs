using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Utils.Converter
{
    public class Point2DConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Point2D)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    var s = (string)value;
                    var parts = s.Split(',');
                    var left = parts[0];
                    var right = parts[1];
                    return new Point2D(double.Parse(left.Split(':')[1].Trim()), double.Parse(right.Split(':')[1].Trim()));
                }
                catch
                {
                    throw new ArgumentException($"{value} could not be converted to Point2D!");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Point2D)
            {
                Point2D p = (Point2D)value;
                return $"X: {p.X}, Y: {p.Y}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return base.GetProperties(context, value, attributes);
        }
    }
}
