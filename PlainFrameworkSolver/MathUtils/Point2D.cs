using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using PlainFrameworkSolver.Utils.Converter;
using System.Runtime.CompilerServices;

namespace Artentus
{
    namespace Utils
    {
        namespace Math
        {
            [TypeConverter(typeof(Point2DConverter))]
            public struct Point2D : IVector, INotifyPropertyChanged
            {
                public static Point2D Zero => new Point2D(0, 0);

                public event PropertyChangedEventHandler PropertyChanged;


                private double x, y;
                /// <summary>
                /// Die X-Koordinate.
                /// </summary>
                public double X { get { return x; } set { x = value; RaisePropertyChanged(); } }

                /// <summary>
                /// Die Y-Koordinate.
                /// </summary>
                public double Y { get { return y; } set { y = value; RaisePropertyChanged(); } }

                /// <summary>
                /// Gibt 2 zurück.
                /// </summary>
                [Browsable(false)]
                public int Dimension { get { return 2; } }

                /// <summary>
                /// Gibt die Koordinate an dem angegebenen Index zurück oder legt diese fest.
                /// </summary>
                public double this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 0:
                                return X;
                            case 1:
                                return Y;
                            default:
                                throw new ArgumentException("Der angegebene Index war für einen zweidimensionalen Vektor zu hoch.");
                        }
                    }
                    set
                    {
                        switch (index)
                        {
                            case 0:
                                X = value;
                                break;
                            case 1:
                                Y = value;
                                break;
                            default:
                                throw new ArgumentException("Der angegebene Index war für einen zweidimensionalen Vektor zu hoch.");
                        }
                    }
                }

                /// <summary>
                /// Erstellt einen neuen Point2D.
                /// </summary>
                public Point2D(double x, double y)
                    : this()
                {
                    X = x;
                    Y = y;
                }

                /// <summary>
                /// Erstellt einen neuen Point2D.
                /// </summary>
                public Point2D(Point2D p)
                    : this()
                {
                    X = p.X;
                    Y = p.Y;
                }

                /// <summary>
                /// Erstellt einen neuen Point2D.
                /// </summary>
                public Point2D(Point p)
                    : this()
                {
                    X = p.X;
                    Y = p.Y;
                }

                /// <summary>
                /// Erstellt einen neuen Point2D.
                /// </summary>
                public Point2D(PointF p)
                    : this()
                {
                    X = p.X;
                    Y = p.Y;
                }

                /// <summary>
                /// Gibt das Kreuzprodukt dieses Vektors zurück.
                [Browsable(false)]
                public Point2D CrossProduct
                {
                    get
                    {
                        return new Point2D(-Y, X);
                    }
                }

                /// <summary>
                /// Konvertiert diesen Point2D zu einem Point.
                /// </summary>
                public Point ToPoint()
                {
                    return new Point((int)X, (int)Y);
                }

                /// <summary>
                /// Konvertiert diesen Point2D zu einem PointF.
                /// </summary>
                public PointF ToPointF()
                {
                    return new PointF((float)X, (float)Y);
                }

                /// <summary>
                /// Prüft ob ein Punkt dicht an einem anderen Punkt liegt. (Bei gegebenem delta)
                /// </summary>
                /// <param name="other">Der zu prüfende Punkt.</param>
                /// <param name="delta">Der maximale Abstand der Punkte in eine Koordinaten Richtung.</param>
                public bool IsNear(Point2D other, double delta)
                {
                    return DistanceTo(other) <= delta;
                }

                /// <summary>
                /// Berechnet den Abstand zwischen zwei Punkten.
                /// </summary>
                public double DistanceTo(Point2D other)
                {
                    return System.Math.Abs((this - other).Length);
                }

                public override string ToString()
                {
                    return $"X: {X} Y:{Y}";
                }

                private void RaisePropertyChanged([CallerMemberName] string name = "")
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

                }

                /// <summary>
                /// Berechnet das Vektorprodukt aus zwei Vektoren.
                /// </summary>
                public static double GetVectorProduct(Point2D left, Point2D right)
                {
                    return left.X * right.Y - left.Y * right.X;
                }

                public IEnumerator<double> GetEnumerator()
                {
                    return new VectorEnumerator(this);
                }

                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return new VectorEnumerator(this);
                }

                public bool Equals(IVector other)
                {
                    return Vector.CheckForEquality(this, other);
                }

                public static Point2D operator +(Point2D left, Point2D right)
                {
                    return Vector.Add(left, right);
                }

                public static Point2D operator +(Point2D left, Vector2 right)
                {
                    return Vector.Add(left, right.As<Point2D>());
                }

                public static Point2D operator -(Point2D left, Vector2 right)
                {
                    return Vector.Subtract(left, right.As<Point2D>());
                }

                public static Vector2 operator -(Point2D left, Point2D right)
                {
                    return Vector.Subtract(left, right).As<Vector2>();
                }

                public static Point2D operator -(Point2D value)
                {
                    return Vector.Negate(value);
                }

                public static implicit operator Point2D(PointF point)
                {
                    return new Point2D(point.X, point.Y);
                }
                public static implicit operator Point2D(Point point)
                {
                    return new Point2D(point.X, point.Y);
                }
            }
        }
    }
}
