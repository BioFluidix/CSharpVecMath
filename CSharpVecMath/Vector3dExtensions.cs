/*
 * Copyright 2017-2019 Michael Hoffer <info@michaelhoffer.de>. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 *
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 *
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 *
 * If you use this software for scientific research then please cite the following publication(s):
 *
 * M. Hoffer, C. Poliwoda, & G. Wittum. (2013). Visual reflection library:
 * a framework for declarative GUI programming on the Java platform.
 * Computing and Visualization in Science, 2013, 16(4),
 * 181–192. http://doi.org/10.1007/s00791-014-0230-y
 *
 * THIS SOFTWARE IS PROVIDED BY Michael Hoffer <info@michaelhoffer.de> "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Michael Hoffer <info@michaelhoffer.de> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of Michael Hoffer <info@michaelhoffer.de>.
 */

using System;
using System.Globalization;
using System.Text;

namespace CSharpVecMath
{
    /// <summary>
    /// This class provides the mathematical operations for all
    /// vector3d classes.
    /// </summary>
    public static class Vector3dExtensions
    {

        /// <summary>
        /// Returns a modifiable copy of this vector.
        /// </summary>
        ///
        /// <returns>a modifiable copy of this vector</returns>
        /// 
        public static IModifiableVector3d asModifiable(this IVector3d vector)
        {
            return new ModifiableVector3dImpl(vector.x(), vector.y(), vector.z());
        }

        /// <summary>
        /// Returns the components <c>x,y,z</c> as double array.
        /// </summary>
        ///
        /// <returns>the components <c>code x,y,z</c> as double array</returns>
        /// 
        public static double[] get(this IVector3d vector)
        {
            return new double[] { vector.x(), vector.y(), vector.z() };
        }

        /// <summary>
        /// Returns the i-th component of this vector.
        /// </summary>
        ///
        /// <param name="i">component index</param>
        /// <returns>the i-th component of this vector</returns>
        /// 
        public static double get(this IVector3d vector, int i)
        {
            switch (i)
            {
                case 0:
                    return vector.x();
                case 1:
                    return vector.y();
                case 2:
                    return vector.z();
                default:
                    throw new IndexOutOfRangeException("Illegal index: " + i);
            }
        }

        /// <summary>
        /// Returns the x component of this vector
        /// </summary>
        ///
        /// <returns>x component of this vector</returns>
        /// 
        public static double x(this IVector3d vector)
        {
            return vector.getX();
        }

        /// <summary>
        /// Returns the y component of this vector
        /// </summary>
        ///
        /// <returns>y component of this vector</returns>
        /// 
        public static double y(this IVector3d vector)
        {
            return vector.getY();
        }

        /// <summary>
        /// Returns the z component of this vector
        /// </summary>
        ///
        /// <returns>z component of this vector</returns>
        /// 
        public static double z(this IVector3d vector)
        {
            return vector.getZ();
        }

        /// <summary>
        /// Returns the sum of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="IVector3d">the vector to add</param>
        /// <returns>the sum of this vector and the specified vector</returns>
        /// 
        public static IVector3d added(this IVector3d vector, IVector3d v)
        {
            return new Vector3dImpl(vector.x() + v.x(), vector.y() + v.y(), vector.z() + v.z());
        }

        /// <summary>
        /// Returns the sum of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified</b>.
        /// </remarks>
        ///
        /// <param name="IVector3d">the vector to add</param>
        /// <returns>the sum of this vector and the specified vector</returns>
        /// 
        public static IVector3d plus(this IVector3d vector, IVector3d v)
        {
            return new Vector3dImpl(vector.x() + v.x(), vector.y() + v.y(), vector.z() + v.z());
        }

        /// <summary>
        /// Returns the sum of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        /// 
        /// <param name="x">x coordinate of the vector to add</param>
        /// <param name="y">y coordinate of the vector to add</param>
        /// <param name="z">z coordinate of the vector to add</param>
        /// <returns>the sum of this vector and the specified vector</returns>
        /// 
        public static IVector3d plus(this IVector3d vector, double x, double y, double z)
        {
            return Vector3d.xyz(vector.x() + x, vector.y() + y, vector.z() + z);
        }

        /// <summary>
        /// Returns the difference of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="IVector3d">the vector to subtract</param>
        /// <returns>the difference of this vector and the specified vector</returns>
        /// 
        public static IVector3d subtracted(this IVector3d vector, IVector3d v)
        {
            return new Vector3dImpl(vector.x() - v.x(), vector.y() - v.y(), vector.z() - v.z());
        }

        /// <summary>
        /// Returns the difference of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="IVector3d">the vector to subtract</param>
        /// <returns>the difference of this vector and the specified vector</returns>
        /// 
        public static IVector3d minus(this IVector3d vector, IVector3d v)
        {
            return new Vector3dImpl(vector.x() - v.x(), vector.y() - v.y(), vector.z() - v.z());
        }

        /// <summary>
        /// Returns the difference of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="x">x coordinate of the vector to subtract</param>
        /// <param name="y">y coordinate of the vector to subtract</param>
        /// <param name="z">z coordinate of the vector to subtract</param>
        /// <returns>the difference of this vector and the specified vector</returns>
        /// 
        public static IVector3d minus(this IVector3d vector, double x, double y, double z)
        {
            return Vector3d.xyz(vector.x() - x, vector.y() - y, vector.z() - z);
        }

        /// <summary>
        /// Returns the product of this vector and the specified value.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the value</param>
        /// <returns>the product of this vector and the specified value</returns>
        /// 
        public static IVector3d times(this IVector3d vector, double a)
        {
            return new Vector3dImpl(vector.x() * a, vector.y() * a, vector.z() * a);
        }

        /// <summary>
        /// Returns the product of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the vector</param>
        /// <returns>the product of this vector and the specified vector</returns>
        /// 
        public static IVector3d times(this IVector3d vector, IVector3d a)
        {
            return new Vector3dImpl(vector.x() * a.x(), vector.y() * a.y(), vector.z() * a.z());
        }

        /// <summary>
        /// Returns the product of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="x">x coordinate of the vector to multiply</param>
        /// <param name="y">y coordinate of the vector to multiply</param>
        /// <param name="z">z coordinate of the vector to multiply</param>
        /// <returns>the product of this vector and the specified vector</returns>
        /// 
        public static IVector3d times(this IVector3d vector, double x, double y, double z)
        {
            return Vector3d.xyz(vector.x() * x, vector.y() * y, vector.z() * z);
        }

        /// <summary>
        /// Returns the product of this vector and the specified value.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the value</param>
        /// <returns>the product of this vector and the specified value</returns>
        /// 
        public static IVector3d multiplied(this IVector3d vector, double a)
        {
            return new Vector3dImpl(vector.x() * a, vector.y() * a, vector.z() * a);
        }

        /// <summary>
        /// Returns the product of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the vector</param>
        /// <returns>the product of this vector and the specified vector</returns>
        /// 
        public static IVector3d multiplied(this IVector3d vector, IVector3d a)
        {
            return new Vector3dImpl(vector.x() * a.x(), vector.y() * a.y(), vector.z() * a.z());
        }


        /// <summary>
        /// Returns this vector divided by the specified value.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the value</param>
        /// <returns>this vector divided by the specified value</returns>
        /// 
        public static IVector3d divided(this IVector3d vector, double a)
        {
            return new Vector3dImpl(vector.x() / a, vector.y() / a, vector.z() / a);
        }


        /// <summary>
        /// Returns the dot product of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the second vector</param>
        /// <returns>the dot product of this vector and the specified vector</returns>
        /// 
        public static double dot(this IVector3d vector, IVector3d a)
        {
            return vector.x() * a.x() + vector.y() * a.y() + vector.z() * a.z();
        }

        /// <summary>
        /// Returns the cross product of this vector and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">the vector</param>
        /// <returns>the cross product of this vector and the specified vector.</returns>
        /// 
        public static IVector3d crossed(this IVector3d vector, IVector3d a)
        {
            return new Vector3dImpl(
                    vector.y() * a.z() - vector.z() * a.y(),
                    vector.z() * a.x() - vector.x() * a.z(),
                    vector.x() * a.y() - vector.y() * a.x()
            );
        }


        /// <summary>
        /// Returns the magnitude of this vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <returns>the magnitude of this vector</returns>
        /// 
        public static double magnitude(this IVector3d vector)
        {
            return Math.Sqrt(vector.dot(vector));
        }

        /// <summary>
        /// Returns the squared magnitude of this vector
        /// (<c>vector.dot(this)</c>).
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <returns>the squared magnitude of this vector</returns>
        /// 
        public static double magnitudeSq(this IVector3d vector)
        {
            return vector.dot(vector);
        }

        /// <summary>
        /// Returns a normalized copy of this vector with length <c>1</c>.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <returns>a normalized copy of this vector with length <c>1</c></returns>
        /// 
        public static IVector3d normalized(this IVector3d vector)
        {
            return vector.divided(vector.magnitude());
        }

        /// <summary>
        /// Returns a negated copy of this vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified</b>.
        /// </remarks>
        ///
        /// <returns>a negated copy of this vector</returns>
        /// 
        public static IVector3d negated(this IVector3d vector)
        {
            return new Vector3dImpl(-vector.x(), -vector.y(), -vector.z());
        }

        /// <summary>
        /// Returns a new vector which is orthogonal to this vector.
        /// </summary>
        /// 
        /// <returns>a new vector which is orthogonal to this vector</returns>
        /// 
        public static IVector3d orthogonal(this IVector3d vector)
        {
            return Math.Abs(vector.z()) < Math.Abs(vector.x()) ? Vector3d.xy(vector.y(), -vector.x()) : Vector3d.yz(-vector.z(), vector.y());
        }


        /// <summary>
        /// Calculates the angle between this and the specified vector.
        /// </summary>
        ///
        /// <param name="IVector3d">vector</param>
        /// <returns>angle in degrees</returns>
        /// 
        public static double angle(this IVector3d vector, IVector3d v)
        {
            double val = vector.dot(v) / (vector.magnitude() * v.magnitude());
            return Math.Acos(Math.Max(Math.Min(val, 1), -1)) * 180.0 / Math.PI; // compensate rounding errors
        }

        /// <summary>
        /// Calculates the distance between the specified point and this point.
        /// </summary>
        ///
        /// <param name="p">point</param>
        /// <returns>the distance between the specified point and this point</returns>
        /// 
        public static double distance(this IVector3d vector, IVector3d p)
        {
            return vector.minus(p).magnitude();
        }


        /// <summary>
        /// Linearly interpolates between this and the specified vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="a">vector</param>
        /// <param name="t">interpolation value</param>
        /// <returns>copy of this vector if <c>t = 0</c>; copy of a if <c>t = 1</c>;
        /// the point midway between this and the specified vector if <c>t = 0.5</c></returns>
        /// 
        public static IVector3d lerp(this IVector3d vector, IVector3d a, double t)
        {
            return vector.plus(a.minus(vector).times(t));
        }

        /// <summary>
        /// Projects the specified vector onto this vector.
        /// </summary>
        ///
        /// <param name="IVector3d">vector to project onto this vector</param>
        /// <returns>the projection of the specified vector onto this vector</returns>
        /// 
        public static IVector3d project(this IVector3d vector, IVector3d v)
        {

            double pScale = v.dot(vector) / vector.magnitudeSq();

            return vector.times(pScale);
        }

        /// <summary>
        /// Indicates whether the two given points are collinear with this 
        /// vector/point. 
        /// </summary>
        /// 
        /// <param name="p2">second point</param>
        /// <param name="p3">third point</param>
        /// <returns><c>true</c> if all three points are collinear;
        ///         <c>false</c> otherwise</returns>
        ///         
        public static bool collinear(this IVector3d vector, IVector3d p2, IVector3d p3)
        {

            // The points p1, p2, p3 are collinear (are on the same line segment)
            // if and only if the largest of the lenghts of 
            //
            //   a = P1P2,
            //   b = P1P2
            //   c = P2P3
            //
            // is equal to the sum of the other two.
            //
            // Explanation: 
            //
            // If p1, p2 and p3 are on the same line then the point in the 'middle'
            // cuts the line segment into two smaller pieces. That is the sum of the
            // lengths of the smaller pieces is equal to the largest one.
            //
            // That is, the following expression determines whether the three points
            // are collinear
            //
            //   boolean collinear = largest > (second + third)

            double a = vector.distance(p2);
            double b = vector.distance(p3);
            double c = p2.distance(p3);

            double largest;
            double second;
            double third;

            if (a > b && a > c)
            {
                // a is largest
                largest = a;
                second = b;
                third = c;
            }
            else if (b > a && b > c)
            {
                // b is largest
                largest = b;
                second = a;
                third = c;
            }
            else if (c > a && c > b)
            {
                // c is largest
                largest = c;
                second = a;
                third = b;
            }
            else
            {
                // lengths are not distinct.
                //
                // there are two possibilities:
                //
                //   a: they are vertices of a equilateral triangle   -> false
                //   b: they are zero, i.e., all points are identical -> true
                //
                return a == 0 && b == 0 && c == 0;
            }

            return Math.Abs(largest - (second + third)) < Plane.TOL;

        }

        /// <summary>
        /// Returns a transformed copy of this vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        ///
        /// <param name="transform">the transform to apply</param>
        /// <returns>a transformed copy of this vector</returns>
        /// 
        public static IModifiableVector3d transformed(this IVector3d vector, Transform transform)
        {
            return transform.transform(vector.asModifiable());
        }

        /// <summary>
        /// Returns a transformed copy of this vector.
        /// </summary>
        /// <remarks>
        /// This vector is <b>not modified.</b>
        /// </remarks>
        /// 
        /// <param name="transform">the transform to apply</param>
        /// <param name="amount"></param>
        /// <returns>a transformed copy of this vector</returns>
        /// 
        public static IModifiableVector3d transformed(this IVector3d vector, Transform transform, double amount)
        {
            return transform.transform(vector.asModifiable(), amount);
        }

        /// <summary>
        /// Returns this vector in STL string format.
        /// </summary>
        ///
        /// <returns>this vector in STL string format</returns>
        /// 
        public static string toStlString(this IVector3d vector)
        {
            return vector.toStlString(new StringBuilder()).ToString();
        }

        /// <summary>
        /// Returns this vector in STL string format.
        /// </summary>
        ///
        /// <param name="sb">string builder</param>
        /// <returns>the specified string builder</returns>
        /// 
        public static StringBuilder toStlString(this IVector3d vector, StringBuilder sb)
        {
            return sb.Append(vector.x().ToString(frmt)).Append(" ").
                    Append(vector.y().ToString(frmt)).Append(" ").
                    Append(vector.z().ToString(frmt));
        }

        /// <summary>
        /// Returns this vector in OBJ string format.
        /// </summary>
        ///
        /// <returns>this vector in OBJ string format</returns>
        /// 
        public static string toObjString(this IVector3d vector)
        {
            return vector.toObjString(new StringBuilder()).ToString();
        }

        /// <summary>
        /// Returns this vector in OBJ string format.
        /// </summary>
        ///
        /// <param name="sb">string builder</param>
        /// <returns>the specified string builder</returns>
        /// 
        public static StringBuilder toObjString(this IVector3d vector, StringBuilder sb)
        {
            return sb.Append(vector.x().ToString(frmt)).Append(" ").
                    Append(vector.y().ToString(frmt)).Append(" ").
                    Append(vector.z().ToString(frmt));
        }

        private static readonly IFormatProvider frmt = CultureInfo.CreateSpecificCulture("en-US");

    }
}
