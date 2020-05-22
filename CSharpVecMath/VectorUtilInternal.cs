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
    ///<summary>
    /// Internal utility class.
    /// </summary>
    /// @author Michael Hoffer <info@michaelhoffer.de>
    public class VectorUtilInternal
    {

        public static string toString(IVector3d v)
        {
            return "[" + v.x() + ", " + v.y() + ", " + v.z() + "]";
        }

        public static bool equals(IVector3d thisV, object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (thisV.GetType() != obj.GetType())
            {
                return false;
            }
            IVector3d other = (IVector3d)obj;
            if (Math.Abs(thisV.x() - other.x()) > Plane.TOL)
            {
                return false;
            }
            if (Math.Abs(thisV.y() - other.y()) > Plane.TOL)
            {
                return false;
            }
            if (Math.Abs(thisV.z() - other.z()) > Plane.TOL)
            {
                return false;
            }
            return true;
        }

        public static int getHashCode(IVector3d v)
        {
            int hash = 7;
            hash = 67 * hash + (int)(BitConverter.DoubleToInt64Bits(v.x()) ^ (BitConverter.DoubleToInt64Bits(v.x()) >> 32));
            hash = 67 * hash + (int)(BitConverter.DoubleToInt64Bits(v.y()) ^ (BitConverter.DoubleToInt64Bits(v.y()) >> 32));
            hash = 67 * hash + (int)(BitConverter.DoubleToInt64Bits(v.z()) ^ (BitConverter.DoubleToInt64Bits(v.z()) >> 32));
            return hash;
        }
    }
}