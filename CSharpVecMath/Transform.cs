﻿/*
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
    /// Transform. Transformations (translation, rotation, scale) can be applied to
    /// geometrical objects like <see cref="CSharpCSG.CSG"/>, <see cref="CSharpCSG.Polygon"/>
    /// <see cref="CSharpCSG.Vertex"/> and <see cref="Vector3d"/>.
    ///
    /// This transform class uses the builder pattern to define combined
    /// transformations.
    /// </summary>
    /// <example>
    /// <code>
    /// // t applies rotation and translation
    /// Transform t = Transform.unity().rotX(45).translate(2,1,0);
    /// </code>
    /// </example>
    ///
    /// <b>TODO:</b> use quaternions for rotations.
    ///
    /// author: Michael Hoffer &lt;info@michaelhoffer.de&gt;
    /// 
    public class Transform
    {

        /// <summary>
        /// Internal 4x4 matrix.
        /// </summary>
        private readonly Matrix4d m;

        /// <summary>
        /// Constructor.
        /// Creates a unit transform.
        /// </summary>
        public Transform()
        {
            m = new Matrix4d();
            m.m00 = 1;
            m.m11 = 1;
            m.m22 = 1;
            m.m33 = 1;
        }

        /// <summary>
        /// Returns a new transform based on the specified matrix values (4x4).
        /// </summary>
        ///
        /// <param name="values">16 double values that represent the transformation matrix</param>
        /// <returns>a new transform</returns>
        /// 
        public static Transform from(params double[] values)
        {
            Matrix4d m = new Matrix4d(values);
            return new Transform(m);
        }

        /// <summary>
        /// Returns this transform as matrix (4x4).
        /// </summary>
        ///
        /// <param name="values">target array (16 values)</param>
        /// <returns>a new transform</returns>
        /// 
        public double[] to(double[] values)
        {
            return m.get(values);
        }

        /// <summary>
        /// Returns this transform as matrix (4x4).
        /// </summary>
        ///
        /// <returns>a new transform</returns>
        /// 
        public double[] to()
        {
            return m.get(null);
        }

        /// <summary>
        /// Returns a new unity transform.
        /// </summary>
        ///
        /// <returns>unity transform</returns>
        /// 
        public static Transform unity()
        {
            return new Transform();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="m">matrix</param>
        /// 
        private Transform(Matrix4d m)
        {
            this.m = m;
        }

        /// <summary>
        /// Applies rotation operation around the <c>x</c> axis to this transform.
        /// </summary>
        ///
        /// <param name="degrees">degrees</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rotX(double degrees)
        {
            double radians = degrees * Math.PI * (1.0 / 180.0);
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            double[] elements = new double []
            {
                1,   0,   0,  0,
                0, cos, sin,  0,
                0, -sin, cos, 0,
                0,    0,   0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies rotation operation around the <c>y</c> axis to this transform.
        /// </summary>
        ///
        /// <param name="degrees">degrees</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rotY(double degrees)
        {
            double radians = degrees * Math.PI * (1.0 / 180.0);
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            double[] elements = new double []
            {
                cos, 0, -sin, 0,
                0, 1, 0, 0,
                sin, 0, cos, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies rotation operation around the <c>z</c> axis to this transform.
        /// </summary>
        ///
        /// <param name="degrees">degrees</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rotZ(double degrees)
        {
            double radians = degrees * Math.PI * (1.0 / 180.0);
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            double[] elements = new double []
            {
                cos, sin, 0, 0,
                -sin, cos, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a rotation operation to this transform.
        /// </summary>
        ///
        /// <param name="x">x axis rotation (degrees)</param>
        /// <param name="y">y axis rotation (degrees)</param>
        /// <param name="z">z axis rotation (degrees)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rot(double x, double y, double z)
        {
            return rotX(x).rotY(y).rotZ(z);
        }

        /// <summary>
        /// Applies a rotation operation to this transform.
        /// </summary>
        ///
        /// <param name="vec">axis rotation for x, y, z (degrees)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rot(IVector3d vec)
        {

            // TODO: use quaternions
            return rotX(vec.x()).rotY(vec.y()).rotZ(vec.z());
        }

        /// <summary>
        /// Applies a transformation that rotates one vector into another.
        /// </summary>
        ///
        /// <param name="from">source vector</param>
        /// <param name="to">target vector</param>
        /// <returns>this transformation</returns>
        /// 
        public Transform rot(IVector3d from, IVector3d to)
        {
            IVector3d a = from.normalized();
            IVector3d b = to.normalized();

            IVector3d c = a.crossed(b);

            double l = c.magnitude(); // sine of angle

            if (l > 1e-9)
            {

                IVector3d axis = c.normalized();
                double angle = a.angle(b);

                rot(Vector3d.ZERO, axis, angle);
            }

            return this;
        }

        /// <summary>
        /// Applies a rotation operation about the specified rotation axis.
        /// </summary>
        ///
        /// <param name="axisPos">axis point</param>
        /// <param name="axisDir">axis direction (may be unnormalized)</param>
        /// <param name="degrees">rotantion angle in degrees</param>
        /// <returns>this transform</returns>
        /// 
        public Transform rot(IVector3d axisPos, IVector3d axisDir, double degrees)
        {
            Transform tmp = Transform.unity();

            axisDir = axisDir.normalized();

            IVector3d dir2 = axisDir.times(axisDir);

            double posx = axisPos.x();
            double posy = axisPos.y();
            double posz = axisPos.z();

            double dirx = axisDir.x();
            double diry = axisDir.y();
            double dirz = axisDir.z();

            double dirxSquare = dir2.x();
            double dirySquare = dir2.y();
            double dirzSquare = dir2.z();

            double radians = degrees * Math.PI * (1.0 / 180.0);

            double cosOfAngle = Math.Cos(radians);
            double oneMinusCosOfangle = 1 - cosOfAngle;
            double sinOfangle = Math.Sin(radians);

            tmp.m.m00 = dirxSquare + (dirySquare + dirzSquare) * cosOfAngle;
            tmp.m.m01 = dirx * diry * oneMinusCosOfangle - dirz * sinOfangle;
            tmp.m.m02 = dirx * dirz * oneMinusCosOfangle + diry * sinOfangle;
            tmp.m.m03 = (posx * (dirySquare + dirzSquare)
                    - dirx * (posy * diry + posz * dirz)) * oneMinusCosOfangle
                    + (posy * dirz - posz * diry) * sinOfangle;

            tmp.m.m10 = dirx * diry * oneMinusCosOfangle + dirz * sinOfangle;
            tmp.m.m11 = dirySquare + (dirxSquare + dirzSquare) * cosOfAngle;
            tmp.m.m12 = diry * dirz * oneMinusCosOfangle - dirx * sinOfangle;
            tmp.m.m13 = (posy * (dirxSquare + dirzSquare)
                    - diry * (posx * dirx + posz * dirz)) * oneMinusCosOfangle
                    + (posz * dirx - posx * dirz) * sinOfangle;

            tmp.m.m20 = dirx * dirz * oneMinusCosOfangle - diry * sinOfangle;
            tmp.m.m21 = diry * dirz * oneMinusCosOfangle + dirx * sinOfangle;
            tmp.m.m22 = dirzSquare + (dirxSquare + dirySquare) * cosOfAngle;
            tmp.m.m23 = (posz * (dirxSquare + dirySquare)
                    - dirz * (posx * dirx + posy * diry)) * oneMinusCosOfangle
                    + (posx * diry - posy * dirx) * sinOfangle;

            apply(tmp);

            return this;
        }

        /// <summary>
        /// Applies a translation operation to this transform.
        /// </summary>
        ///
        /// <param name="vec">translation vector (x,y,z)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform translate(IVector3d vec)
        {
            return translate(vec.x(), vec.y(), vec.z());
        }

        /// <summary>
        /// Applies a translation operation to this transform.
        /// </summary>
        ///
        /// <param name="x">translation (x axis)</param>
        /// <param name="y">translation (y axis)</param>
        /// <param name="z">translation (z axis)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform translate(double x, double y, double z)
        {
            double[] elements = new double []
            {
                1, 0, 0, x,
                0, 1, 0, y,
                0, 0, 1, z,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a translation operation to this transform.
        /// </summary>
        ///
        /// <param name="value">translation (x axis)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform translateX(double value)
        {
            double[] elements = new double []
            {
                1, 0, 0, value,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a translation operation to this transform.
        /// </summary>
        ///
        /// <param name="value">translation (y axis)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform translateY(double value)
        {
            double[] elements = new double []
            {
                1, 0, 0, 0,
                0, 1, 0, value,
                0, 0, 1, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a translation operation to this transform.
        /// </summary>
        ///
        /// <param name="value">translation (z axis)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform translateZ(double value)
        {
            double[] elements = new double []
            {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, value,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a mirror operation to this transform.
        /// </summary>
        ///
        /// <param name="plane">the plane that defines the mirror operation</param>
        /// <returns>this transform</returns>
        /// 
        public Transform mirror(Plane plane)
        {

            Console.Error.WriteLine("WARNING: I'm too dumb to implement the mirror() operation correctly. Please fix me!");

            double nx = plane.getNormal().x();
            double ny = plane.getNormal().y();
            double nz = plane.getNormal().z();
            double w = plane.getDist();
            double[] elements = new double []
            {
                (1.0 - 2.0 * nx * nx), (-2.0 * ny * nx), (-2.0 * nz * nx), 0,
                (-2.0 * nx * ny), (1.0 - 2.0 * ny * ny), (-2.0 * nz * ny), 0,
                (-2.0 * nx * nz), (-2.0 * ny * nz), (1.0 - 2.0 * nz * nz), 0,
                (-2.0 * nx * w), (-2.0 * ny * w), (-2.0 * nz * w), 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation to this transform.
        /// </summary>
        ///
        /// <param name="vec">vector that specifies scale (x,y,z)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scale(IVector3d vec)
        {

            if (vec.x() == 0 || vec.y() == 0 || vec.z() == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                vec.x(), 0, 0, 0,
                0, vec.y(), 0, 0,
                0, 0, vec.z(), 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation to this transform.
        /// </summary>
        ///
        /// <param name="x">x scale value</param>
        /// <param name="y">y scale value</param>
        /// <param name="z">z scale value</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scale(double x, double y, double z)
        {

            if (x == 0 || y == 0 || z == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation to this transform.
        /// </summary>
        ///
        /// <param name="s">s scale value (x, y and z)</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scale(double s)
        {

            if (s == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                s, 0, 0, 0,
                0, s, 0, 0,
                0, 0, s, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation (x axis) to this transform.
        /// </summary>
        ///
        /// <param name="s">x scale value</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scaleX(double s)
        {

            if (s == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                s, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation (y axis) to this transform.
        /// </summary>
        ///
        /// <param name="s">y scale value</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scaleY(double s)
        {

            if (s == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                1, 0, 0, 0,
                0, s, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies a scale operation (z axis) to this transform.
        /// </summary>
        ///
        /// <param name="s">z scale value</param>
        /// <returns>this transform</returns>
        /// 
        public Transform scaleZ(double s)
        {

            if (s == 0)
            {
                throw new ArgumentException("scale by 0 not allowed!");
            }

            double[] elements = new double []
            {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, s, 0,
                0, 0, 0, 1
            };
            m.mul(new Matrix4d(elements));
            return this;
        }

        /// <summary>
        /// Applies this transform to the specified vector.
        /// </summary>
        ///
        /// <param name="vec">vector to transform</param>
        /// <returns>the specified vector</returns>
        /// 
        public IModifiableVector3d transform(IModifiableVector3d vec)
        {
            double x, y;
            x = m.m00 * vec.x() + m.m01 * vec.y() + m.m02 * vec.z() + m.m03;
            y = m.m10 * vec.x() + m.m11 * vec.y() + m.m12 * vec.z() + m.m13;
            vec.setZ(m.m20 * vec.x() + m.m21 * vec.y() + m.m22 * vec.z() + m.m23);
            vec.setX(x);
            vec.setY(y);

            return vec;
        }

        /// <summary>
        /// Applies this transform to the specified vector.
        /// </summary>
        ///
        /// <param name="vec">vector to transform</param>
        /// <returns>the specified vector</returns>
        /// 
        public IVector3d transform(IVector3d vec)
        {
            IModifiableVector3d result = vec.asModifiable();
            double x, y;
            x = m.m00 * vec.x() + m.m01 * vec.y() + m.m02 * vec.z() + m.m03;
            y = m.m10 * vec.x() + m.m11 * vec.y() + m.m12 * vec.z() + m.m13;
            result.setZ(m.m20 * vec.x() + m.m21 * vec.y() + m.m22 * vec.z() + m.m23);
            result.setX(x);
            result.setY(y);

            return result;
        }

        /// <summary>
        /// Applies this transform to the specified vector.
        /// </summary>
        ///
        /// <param name="vec">vector to transform</param>
        /// <param name="amount">transform amount (0 = 0 %, 1 = 100%)</param>
        /// <returns>the specified vector</returns>
        /// 
        public IModifiableVector3d transform(IModifiableVector3d vec, double amount)
        {

            double prevX = vec.x();
            double prevY = vec.y();
            double prevZ = vec.z();

            double x, y;
            x = m.m00 * vec.x() + m.m01 * vec.y() + m.m02 * vec.z() + m.m03;
            y = m.m10 * vec.x() + m.m11 * vec.y() + m.m12 * vec.z() + m.m13;
            vec.setZ(m.m20 * vec.x() + m.m21 * vec.y() + m.m22 * vec.z() + m.m23);
            vec.setX(x);
            vec.setY(y);

            double diffX = vec.x() - prevX;
            double diffY = vec.y() - prevY;
            double diffZ = vec.z() - prevZ;

            vec.setX(prevX + (diffX) * amount);
            vec.setY(prevY + (diffY) * amount);
            vec.setZ(prevZ + (diffZ) * amount);

            return vec;
        }

        //    /// <summary>
        //     /// Performs an SVD normalization of the underlying matrix to calculate and
        //     /// return the uniform scale factor. If the matrix has non-uniform scale
        //     /// factors, the largest of the x, y, and z scale factors distill be
        //     /// returned.
        //     ///
        //     /// <b>Note:</b> this transformation is not modified.
        //     ///
        //     /// <returns>the scale factor of this transformation</returns>
        //     /// </summary>
        //    public double getScale() {
        //        return m.getScale();
        //    }

        /// <summary>
        /// Indicates whether this transform performs a mirror operation, i.e., flips
        /// the orientation.
        /// </summary>
        ///
        /// <returns><c>true</c> if this transform performs a mirror operation;
        /// <c>false</c> otherwise.</returns>
        /// 
        public bool isMirror()
        {
            return m.determinant() < 0;
        }

        /// <summary>
        /// Applies the specified transform to this transform.
        /// </summary>
        ///
        /// <param name="t">transform to apply</param>
        /// <returns>this transform</returns>
        /// 
        public Transform apply(Transform t)
        {
            m.mul(t.m);
            return this;
        }

        public override string ToString()
        {
            return m.ToString();
        }
    }
}
