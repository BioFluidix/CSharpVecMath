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

namespace CSharpVecMath
{
    /// <summary>
    ///
    /// @author Michael Hoffer &lt;info@michaelhoffer.de&gt;
    /// </summary>
    public class Vector3dImpl : IVector3d, IEquatable<Vector3dImpl>
    {

        protected double x;
        protected double y;
        protected double z;

        /// <summary>
        /// Creates a new vector.
        /// </summary>
        ///
        /// @param x x value
        /// @param y y value
        /// @param z z value
        public Vector3dImpl(double x, double y, double z)
        {

            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Creates a new vector with specified {@code x}, {@code y} and
        /// {@code z = 0}.
        /// </summary>
        ///
        /// @param x x value
        /// @param y y value
        public Vector3dImpl(double x, double y)
        {

            this.x = x;
            this.y = y;
            this.z = 0;
        }




        public double getX()
        {
            return x;
        }


        public double getY()
        {
            return y;
        }


        public double getZ()
        {
            return z;
        }

        public IVector3d clone()
        {
            return new Vector3dImpl(x, y, z);
        }


        public virtual IVector3d set(params double[] xyz)
        {

            if (xyz.Length > 3)
            {
                throw new ArgumentException(
                        "Wrong number of components. "
                                + "Expected number of components <= 3, got: " + xyz.Length);
            }

            for (int i = 0; i < xyz.Length; i++)
            {
                set(i, xyz[i]);
            }

            return this;
        }

        public virtual void setX(double x)
        {
            this.x = x;
        }

        public virtual void setY(double y)
        {
            this.y = y;
        }

        public virtual void setZ(double z)
        {
            this.z = z;
        }

        public virtual IVector3d set(int i, double value)
        {
            switch (i)
            {
                case 0:
                    setX(value);
                    break;
                case 1:
                    setY(value);
                    break;
                case 2:
                    setZ(value);
                    break;
                default:
                    throw new Exception("Illegal index: " + i);
            }

            return this;
        }

        public override string ToString()
        {
            return VectorUtilInternal.toString(this);
        }


        public override int GetHashCode()
        {
            return VectorUtilInternal.getHashCode(this);
        }

        public override bool Equals(object obj)
        {
            return VectorUtilInternal.equals(this, obj);
        }

        public bool Equals(Vector3dImpl obj)
        {
            return VectorUtilInternal.equals(this, obj);
        }

        public static bool operator ==(Vector3dImpl v1, Vector3dImpl v2)
        {
            if (ReferenceEquals(v1, v2)) return true;
            if (ReferenceEquals(v1, null)) return false;
            if (ReferenceEquals(v2, null)) return false;

            return v1.Equals(v2);
        }

        public static bool operator !=(Vector3dImpl v1, Vector3dImpl v2)
        {
            if (ReferenceEquals(v1, v2)) return false;
            if (ReferenceEquals(v1, null)) return true;
            if (ReferenceEquals(v2, null)) return true;

            return !v1.Equals(v2);
        }

    }
}
