using System;
using CSharpVecMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CVecMathTest
{
    

    [TestClass]
    public class Vector3dTest
    {

        [TestMethod]
        public void collinearityTest()
        {
            {
                IVector3d p1 = Vector3d.xyz(1, 1, 1);
                IVector3d p2 = p1.times(5);
                IVector3d p3 = p1.times(10);

                Assert.IsTrue(p1.collinear(p2, p3), "p1, p2, p3 must be collinear");
            }
            {
                IVector3d p1 = Vector3d.xyz(1, 1, 1);
                IVector3d p2 = p1.times(5, 5, 4);
                IVector3d p3 = p1.times(10);

                Assert.IsTrue(!p1.collinear(p2, p3), "p1, p2, p3 must not be collinear");
            }
            {
                IVector3d p1 = Vector3d.xyz(10, 10, 10);
                IVector3d p2 = Vector3d.xyz(-1, -1, -1);
                IVector3d p3 = p1.times(5);

                Assert.IsTrue(p1.collinear(p2, p3), "p1, p2, p3 must be collinear");
            }
            {
                IVector3d p1 = Vector3d.xyz(10, 20, 10);
                IVector3d p2 = p1.clone();
                IVector3d p3 = p2.clone();

                Assert.IsTrue(p1.collinear(p2, p3), "p1, p2, p3 must be collinear");
            }
        }
    }

}
