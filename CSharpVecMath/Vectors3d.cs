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
using System.Collections.Generic;
using System.Linq;

namespace CSharpVecMath
{
    /// <summary>
    /// Utility class for generating large amounts of vectors.
    /// </summary>
    ///
    /// @author Michael Hoffer (info@michaelhoffer.de)
    public sealed class Vectors3d
    {

        private Vectors3d()
        {
            throw new NotSupportedException("Don't instantiate me!");
        }

        /// <summary>
        /// Converts the specified x-values to a list of vectors.
        /// </summary>
        ///
        /// @param xValues x values
        /// @return list of vectors
        public static List<IVector3d> x(params double[] xValues)
        {
            return xValues.Select(x => Vector3d.x(x)).ToList();
        }

        /// <summary>
        /// Converts the specified y-values to a list of vectors.
        /// </summary>
        ///
        /// @param yValues y values
        /// @return list of vectors
        public static List<IVector3d> y(params double[] yValues)
        {
            return yValues.Select(y => Vector3d.y(y)).ToList();
        }

        /// <summary>
        /// Converts the specified z-values to a list of vectors.
        /// </summary>
        ///
        /// @param zValues z values
        /// @return list of vectors
        public static List<IVector3d> z(params double[] zValues)
        {
            return zValues.Select(z => Vector3d.z(z)).ToList();
        }

        /// <summary>
        /// Converts the specified (x,y)-values to a list of vectors.
        /// </summary>
        ///
        /// @param xyValues (x,y) values
        /// @return list of vectors
        public static List<IVector3d> xy(params double[] xyValues)
        {

            if (xyValues.Length % 2 != 0)
            {
                throw new ArgumentException("Number of specified values must be a multiple of 2!");
            }

            return Enumerable.Range(1, xyValues.Length).Where(i => (i + 1) % 2 == 0)
                    .Select(i => Vector3d.xy(xyValues[i - 1], xyValues[i])).
                    ToList();
        }

        /// <summary>
        /// Converts the specified (x,z)-values to a list of vectors.
        /// </summary>
        ///
        /// @param xzValues (x,z) values
        /// @return list of vectors
        public static List<IVector3d> xz(params double[] xzValues)
        {

            if (xzValues.Length % 2 != 0)
            {
                throw new ArgumentException("Number of specified values must be a multiple of 2!");
            }

            return Enumerable.Range(1, xzValues.Length).Where(i => (i + 1) % 2 == 0)
                    .Select(i => Vector3d.xz(xzValues[i - 1], xzValues[i])).
                    ToList();
        }

        /// <summary>
        /// Converts the specified (y,z)-values to a list of vectors.
        /// </summary>
        ///
        /// @param yzValues (y,z) values
        /// @return list of vectors
        public static List<IVector3d> yz(params double[] yzValues)
        {

            if (yzValues.Length % 2 != 0)
            {
                throw new ArgumentException("Number of specified values must be a multiple of 2!");
            }

            return Enumerable.Range(1, yzValues.Length).Where(i => (i + 1) % 2 == 0)
                    .Select(i => Vector3d.xy(yzValues[i - 1], yzValues[i])).
                    ToList();
        }

        /// <summary>
        /// Converts the specified (x,y,z)-values to a list of vectors.
        /// </summary>
        ///
        /// @param xyzValues (x,y,z) values
        /// @return list of vectors
        public static List<IVector3d> xyz(params double[] xyzValues)
        {

            if (xyzValues.Length % 3 != 0)
            {
                throw new ArgumentException("Number of specified values must be a multiple of 3!");
            }

            return Enumerable.Range(2, xyzValues.Length).Where(i => (i + 1) % 3 == 0)
                    .Select(i => Vector3d.xyz(xyzValues[i - 2], xyzValues[i - 1], xyzValues[i])).
                    ToList();
        }
    }
}
