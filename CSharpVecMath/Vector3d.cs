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
    public abstract class Vector3d
    {
        ///<summary>
        /// Unity vector {@code (1, 1, 1)}.
        ///</summary>
        public static readonly IVector3d UNITY = new Vector3dImpl(1, 1, 1);

        ///<summary>
        /// Vector {@code (1, 0, 0)}.
        ///</summary>
        public static readonly IVector3d X_ONE = new Vector3dImpl(1, 0, 0);

        ///<summary>
        /// Vector {@code (0, 1, 0)}.
        ///</summary>
        public static readonly IVector3d Y_ONE = new Vector3dImpl(0, 1, 0);

        ///<summary>
        /// Vector {@code (0, 0, 0)}.
        ///</summary>
        public static readonly IVector3d ZERO = new Vector3dImpl(0, 0, 0);

        ///<summary>
        /// Vector {@code (0, 0, 1)}.
        ///</summary>
        public static readonly IVector3d Z_ONE = new Vector3dImpl(0, 0, 1);


        ///<summary>
        /// Creates a new vector with specified {@code x}
        ///</summary>
        ///
        /// @param x x value
        /// @return a new vector {@code [x,0,0]}
        public static IVector3d x(double x)
        {
            return new Vector3dImpl(x, 0, 0);
        }

        ///<summary>
        /// Creates a new vector with specified {@code y}
        ///</summary>
        ///
        /// @param y y value
        /// @return a new vector {@code [0,y,0]}
        public static IVector3d y(double y)
        {
            return new Vector3dImpl(0, y, 0);
        }

        ///<summary>
        /// Creates a new vector with specified {@code z}
        ///</summary>
        ///
        /// @param z z value
        /// @return a new vector {@code [0,0,z]}
        public static IVector3d z(double z)
        {
            return new Vector3dImpl(0, 0, z);
        }

        ///<summary>
        /// Creates a new vector with specified {@code x}, {@code y} and
        /// {@code z = 0}.
        ///</summary>
        ///
        /// @param x x value
        /// @param y y value
        /// @return
        public static IVector3d xy(double x, double y)
        {
            return new Vector3dImpl(x, y);
        }

        ///<summary>
        /// Creates a new vector with specified {@code x}, {@code y} and {@code z}.
        ///</summary>
        ///
        /// @param x x value
        /// @param y y value
        /// @param z z value
        /// @return a new vector
        public static IVector3d xyz(double x, double y, double z)
        {
            return new Vector3dImpl(x, y, z);
        }

        ///<summary>
        /// Creates a new vector with specified {@code y} and {@code z}.
        ///</summary>
        ///
        /// @param y y value
        /// @param z z value
        /// @return a new vector
        public static IVector3d yz(double y, double z)
        {
            return new Vector3dImpl(0, y, z);
        }

        ///<summary>
        /// Creates a new vector with specified {@code x} and {@code z}.
        ///</summary>
        ///
        /// @param x x value
        /// @param z z value
        /// @return a new vector
        public static IVector3d xz(double x, double z)
        {
            return new Vector3dImpl(x, 0, z);
        }

        ///<summary>
        /// Creates a new vector {@code (0,0,0)}.
        ///</summary>
        ///
        /// @return a new vector
        public static IVector3d zero()
        {
            return new Vector3dImpl(0, 0, 0);
        }

        ///<summary>
        /// Creates a new vector {@code (1,1,1)}.
        ///</summary>
        ///
        /// @return a new vector
        public static IVector3d unity()
        {
            return new Vector3dImpl(0, 0, 0);
        }

        ///<summary>
        /// Clones the specified vector.
        ///</summary>
        ///
        /// @param source vector toclone
        /// @return cloned vector
        public static IVector3d clone(IVector3d source)
        {
            return new Vector3dImpl(source.x(), source.y(), source.z());
        }


    }



    ///<summary>
    ///
    /// @author Michael Hoffer &lt;info@michaelhoffer.de&gt;
    ///</summary>
    public interface IVector3d
    {

        ///<summary>
        /// Returns the {@code x} component of this vector.
        ///</summary>
        ///
        /// @return the {@code x} component of this vector
        double getX();

        ///<summary>
        /// Returns the {@code y} component of this vector.
        ///</summary>
        ///
        /// @return the {@code y} component of this vector
        double getY();

        ///<summary>
        /// Returns the {@code z} component of this vector.
        ///</summary>
        ///
        /// @return the {@code z} component of this vector
        double getZ();

        ///<summary>
        /// Returns a clone of this vector.
        ///</summary>
        ///
        /// @return a clone of this vector
        IVector3d clone();

    }



}
