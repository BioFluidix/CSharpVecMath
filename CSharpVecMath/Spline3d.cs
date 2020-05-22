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


using System.Collections.Generic;

namespace CSharpVecMath
{
    /// <summary>
    /// 3d Spline.
    /// </summary>
    /// @author Michael Hoffer (info@michaelhoffer.de)
    /// 
    public sealed class Spline3d : Spline
    {

        private readonly List<IVector3d> points;

        private readonly List<Cubic> xCubics;
        private readonly List<Cubic> yCubics;
        private readonly List<Cubic> zCubics;

        /// <summary>
        /// Creates a new spline.
        /// </summary>
        public Spline3d()
        {
            this.points = new List<IVector3d>();

            this.xCubics = new List<Cubic>();
            this.yCubics = new List<Cubic>();
            this.zCubics = new List<Cubic>();

        }

        /// <summary>
        /// Adds a control point to this spline.
        /// @param point point to add
        /// </summary>
        public void addPoint(IVector3d point)
        {
            this.points.Add(point);
        }

        /// <summary>
        /// Returns all control points.
        /// @return control points
        /// </summary>
        public List<IVector3d> getPoints()
        {
            return points;
        }

        /// <summary>
        /// Calculates this spline.
        /// </summary>
        public void calcSpline()
        {
            calcNaturalCubic(points, 0, xCubics);
            calcNaturalCubic(points, 1, yCubics);
            calcNaturalCubic(points, 2, zCubics);
        }

        /// <summary>
        /// Returns a point on the spline curve.
        /// </summary>
        /// 
        /// @param position position on the curve, range {@code [0, 1)}
        /// 
        /// @return a point on the spline curve
        /// 
        public IVector3d getPoint(double position)
        {
            position = position * xCubics.Count;
            int cubicNum = (int)position;
            double cubicPos = (position - cubicNum);

            return Vector3d.xyz(xCubics[cubicNum].eval(cubicPos),
                    yCubics[cubicNum].eval(cubicPos),
                    zCubics[cubicNum].eval(cubicPos));
        }
    }
}
