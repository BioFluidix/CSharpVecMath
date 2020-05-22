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

namespace CSharpVecMath
{
    public static class ModifiableVector3dExtensions
    {

        /// <summary>
        /// Sets the {@code x} component of this vector.
        /// </summary>
        ///
        /// @param x component to set
        public static void setX(this IModifiableVector3d vector, double x)
        {
            vector.set(0, x);
        }

        /// <summary>
        /// Sets the {@code y} component of this vector.
        /// </summary>
        ///
        /// @param y component to set
        public static void setY(this IModifiableVector3d vector, double y)
        {
            vector.set(1, y);
        }

        /// <summary>
        /// Sets the {@code z} component of this vector.
        /// </summary>
        ///
        /// @param z component to set
        public static void setZ(this IModifiableVector3d vector, double z)
        {
            vector.set(2, z);
        }

        /// <summary>
        /// Adds the specified vector to this vector.
        /// </summary>
        ///
        /// @param v the vector to add
        ///
        /// <b>Note:</b> this vector <b>is</b> not modified.
        ///
        /// @return this vector
        public static IModifiableVector3d add(this IModifiableVector3d vector, IVector3d v)
        {
            vector.setX(vector.x() + v.x());
            vector.setY(vector.y() + v.y());
            vector.setZ(vector.z() + v.z());

            return vector;
        }

        /// <summary>
        /// Adds the specified vector to this vector.
        /// </summary>
        ///
        /// @param x x coordinate of the vector to add
        /// @param y y coordinate of the vector to add
        /// @param z z coordinate of the vector to add
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d add(this IModifiableVector3d vector, double x, double y, double z)
        {
            vector.setX(vector.x() + x);
            vector.setX(vector.y() + y);
            vector.setX(vector.z() + z);

            return vector;
        }

        /// <summary>
        /// Subtracts the specified vector from this vector.
        /// </summary>
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @param v vector to subtract
        /// @return this vector
        public static IModifiableVector3d subtract(this IModifiableVector3d vector, IVector3d v)
        {
            vector.setX(vector.x() - v.x());
            vector.setY(vector.y() - v.y());
            vector.setZ(vector.z() - v.z());

            return vector;
        }

        /// <summary>
        /// Subtracts the specified vector from this vector.
        /// </summary>
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @param x x coordinate of the vector to subtract
        /// @param y y coordinate of the vector to subtract
        /// @param z z coordinate of the vector to subtract
        ///
        /// @return this vector
        public static IModifiableVector3d subtract(this IModifiableVector3d vector, double x, double y, double z)
        {
            vector.setX(vector.x() - x);
            vector.setY(vector.y() - y);
            vector.setZ(vector.z() - z);

            return vector;
        }

        /// <summary>
        /// Multiplies this vector with the specified value.
        /// </summary>
        ///
        /// @param a the value
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d multiply(this IModifiableVector3d vector, double a)
        {
            vector.setX(vector.x() * a);
            vector.setY(vector.y() * a);
            vector.setZ(vector.z() * a);

            return vector;
        }

        /// <summary>
        /// Multiplies this vector with the specified vector.
        /// </summary>
        ///
        /// @param a the vector
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d multiply(this IModifiableVector3d vector, IVector3d a)
        {
            vector.setX(vector.x() * a.x());
            vector.setY(vector.y() * a.y());
            vector.setZ(vector.z() * a.z());

            return vector;
        }

        /// <summary>
        /// Devides this vector with the specified value.
        /// </summary>
        ///
        /// @param a the value
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d divide(this IModifiableVector3d vector, double a)
        {
            vector.setX(vector.x() / a);
            vector.setY(vector.y() / a);
            vector.setZ(vector.z() / a);

            return vector;
        }

        /// <summary>
        /// Divides this vector with the specified vector.
        /// </summary>
        ///
        /// @param v the vector
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d divide(this IModifiableVector3d vector, IVector3d v)
        {
            vector.setX(vector.x() / v.x());
            vector.setY(vector.y() / v.y());
            vector.setZ(vector.z() / v.z());

            return vector;
        }

        /// <summary>
        /// Stores the cross product of this vector and the specified vector in this
        /// vector.
        /// </summary>
        ///
        /// <b>Note:</b> this vector <b>is</b>modified.
        ///
        /// @param a the vector
        ///
        /// @return this vector
        public static IModifiableVector3d cross(this IModifiableVector3d vector, IVector3d a)
        {
            vector.setX(vector.y() * a.z() - vector.z() * a.y());
            vector.setY(vector.z() * a.x() - vector.x() * a.z());
            vector.setZ(vector.x() * a.y() - vector.y() * a.x());

            return vector;
        }

        /// <summary>
        /// Negates this vector.
        /// </summary>
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d negate(this IModifiableVector3d vector)
        {
            return vector.multiply(-1.0);
        }

        /// <summary>
        /// Normalizes this vector with length {@code 1}.
        /// </summary>
        ///
        /// <b>Note:</b> this vector <b>is</b> modified.
        ///
        /// @return this vector
        public static IModifiableVector3d normalize(this IModifiableVector3d vector)
        {
            return vector.divide(vector.magnitude());
        }


    }
}
