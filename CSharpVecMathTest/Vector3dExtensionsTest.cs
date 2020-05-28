using System;
using CSharpVecMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CVecMathTest
{

    [TestClass]
    public class Vector3dExtensionsTest
    {
        private const double EPSILON = 1e-12;
        private static readonly Random random = new Random();

        private static Transform RandomRotation()
        {
            return Transform.unity().rot(
                360.0 * random.NextDouble(),
                360.0 * random.NextDouble(),
                360.0 * random.NextDouble());
        }

        private static IVector3d RandomVector()
        {
            return Vector3d.xyz(random.NextDouble(), random.NextDouble(), random.NextDouble());
        }

        [TestMethod]
        public void getterTest()
        {
            double x = 100.0 * random.NextDouble();
            double y = 100.0 * random.NextDouble();
            double z = 100.0 * random.NextDouble();

            IVector3d v = Vector3d.xyz(x, y, z);

            double[] buff = v.get();

            double delta = Math.Abs(x - buff[0]);
            Assert.AreEqual(x, buff[0], EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(y - buff[1]);
            Assert.AreEqual(y, buff[1], EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(z - buff[2]);
            Assert.AreEqual(z, buff[2], EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(x - v.get(0));
            Assert.AreEqual(x, v.get(0), EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(y - v.get(1));
            Assert.AreEqual(y, v.get(1), EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(z - v.get(2));
            Assert.AreEqual(z, v.get(2), EPSILON, $"getter value diverges from set value! Delta:{delta}");


            delta = Math.Abs(x - v.x());
            Assert.AreEqual(x, v.x(), EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(y - v.y());
            Assert.AreEqual(y, v.y(), EPSILON, $"getter value diverges from set value! Delta:{delta}");

            delta = Math.Abs(z - v.z());
            Assert.AreEqual(z, v.z(), EPSILON, $"getter value diverges from set value! Delta:{delta}");


        }

        [TestMethod]
        public void plusMinusAddedSubtractedTest()
        {
            Transform randRot = RandomRotation();
            Transform angleTrans = Transform.unity().rotZ(180.0 * random.NextDouble());

            IVector3d va = randRot.transform(Vector3d.X_ONE.times(100.0 * random.NextDouble()));
            IVector3d vc = randRot.transform(angleTrans.transform(Vector3d.X_ONE.times(100.0 * random.NextDouble())));
            IVector3d vb = Vector3d.xyz(vc.x() - va.x(), vc.y() - va.y(), vc.z() - va.z());


            IVector3d ac = va.added(vb);
            double delta = Math.Abs(ac.magnitude() - vc.magnitude());
            Assert.AreEqual(ac.magnitude(), ac.magnitude(), EPSILON, $"sum vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d pc = va.plus(vb);
            delta = Math.Abs(pc.magnitude() - vc.magnitude());
            Assert.AreEqual(pc.magnitude(), vc.magnitude(), EPSILON, $"sum vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d p2c = va.plus(vb.x(), vb.y(), vb.z());
            delta = Math.Abs(p2c.magnitude() - vc.magnitude());
            Assert.AreEqual(p2c.magnitude(), vc.magnitude(), EPSILON, $"sum vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d sb = vc.subtracted(va);
            delta = Math.Abs(sb.magnitude() - vb.magnitude());
            Assert.AreEqual(sb.magnitude(), vb.magnitude(), EPSILON, $"difference vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d mb = vc.minus(va);
            delta = Math.Abs(mb.magnitude() - vb.magnitude());
            Assert.AreEqual(mb.magnitude(), vb.magnitude(), EPSILON, $"difference vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d m2b = vc.minus(va.x(), va.y(), va.z());
            delta = Math.Abs(m2b.magnitude() - vb.magnitude());
            Assert.AreEqual(m2b.magnitude(), vb.magnitude(), EPSILON, $"difference vector magnitude diverges from generated value! Delta:{delta}");
        }

        [TestMethod]
        public void timesMultipliedDividedTest()
        {
            Transform randRot = RandomRotation();
            Transform angleTrans = Transform.unity().rotZ(180.0 * random.NextDouble());
            double alpha = 100.0 * random.NextDouble();

            IVector3d va = randRot.transform(Vector3d.X_ONE);
            IVector3d vb = randRot.transform(angleTrans.transform(Vector3d.X_ONE.times(100.0 * random.NextDouble())));

            // times
            IVector3d ta = va.times(alpha);
            double delta = Math.Abs(alpha - ta.magnitude());
            Assert.AreEqual(alpha, ta.magnitude(), EPSILON, $"scaled vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d t2a = va.times(vb);
            double dot = t2a.x() + t2a.y() + t2a.z();
            delta = Math.Abs(dot - va.dot(vb));
            Assert.AreEqual(va.dot(vb), dot, EPSILON, $"multiplied vector sum diverges from dot product value! Delta:{delta}");

            IVector3d t3a = va.times(vb.x(), vb.y(), vb.z());
            dot = t3a.x() + t3a.y() + t3a.z();
            delta = Math.Abs(dot - va.dot(vb));
            Assert.AreEqual(va.dot(vb), dot, EPSILON, $"multiplied vector sum diverges from dot product value! Delta:{delta}");

            // multiplied
            IVector3d t4a = va.multiplied(alpha);
            delta = Math.Abs(alpha - t4a.magnitude());
            Assert.AreEqual(alpha, t4a.magnitude(), EPSILON, $"scaled vector magnitude diverges from generated value! Delta:{delta}");

            IVector3d t5a = va.multiplied(vb);
            dot = t5a.x() + t5a.y() + t5a.z();
            delta = Math.Abs(dot - va.dot(vb));
            Assert.AreEqual(va.dot(vb), dot, EPSILON, $"multiplied vector sum diverges from dot product value! Delta:{delta}");

            // divided
            IVector3d t6a = va.divided(alpha);
            delta = Math.Abs(1/alpha - t6a.magnitude());
            Assert.AreEqual(1/alpha, t6a.magnitude(), EPSILON, $"divided vector magnitude diverges from generated value! Delta:{delta}");

        }

        [TestMethod]
        public void dotTest()
        {
            Transform randRot = RandomRotation();

            IVector3d va = randRot.transform(Vector3d.X_ONE.times(100.0 * random.NextDouble()));
            IVector3d vb = randRot.transform(Vector3d.Y_ONE.times(100.0 * random.NextDouble()));
            IVector3d vc = randRot.transform(Vector3d.Z_ONE.times(100.0 * random.NextDouble()));

            double delta = va.dot(vb);
            Assert.AreEqual(0, va.dot(vb), EPSILON, $"scalar product of perpendicular vectors diverges from zero! Delta:{delta}");

            delta = vb.dot(vc);
            Assert.AreEqual(0, vb.dot(vc), EPSILON, $"scalar product of perpendicular vectors diverges from zero! Delta:{delta}");

            delta = vc.dot(va);
            Assert.AreEqual(0, vc.dot(va), EPSILON, $"scalar product of perpendicular vectors diverges from zero! Delta:{delta}");

            IVector3d ca = Vector3d.xyz(1, 2, 3);
            IVector3d cb = Vector3d.xyz(3, 4, 5);

            delta = Math.Abs(ca.dot(cb) - 26.0);
            Assert.AreEqual(26.0, ca.dot(cb), EPSILON, $"scalar product of vectors diverges from generated value! Delta:{delta}");

        }

        [TestMethod]
        public void crossedTest()
        {

            Transform randRot = RandomRotation();


            double a = random.NextDouble();
            double b = random.NextDouble();
            double c = random.NextDouble();

            IVector3d va = randRot.transform(Vector3d.xyz(a, 0, 0));
            IVector3d vb = randRot.transform(Vector3d.xyz(0, b, 0));
            IVector3d vc = randRot.transform(Vector3d.xyz(0, 0, c));

            IVector3d w = va.crossed(vb);
            double delta = Math.Abs(a * b - w.magnitude());

            Assert.AreEqual(a * b, w.magnitude(), EPSILON, $"result vector magnitude not equal to magnitude-product of orthogonal precursor vectors. Delta: {delta}");
            Assert.AreEqual(w.dot(va), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(va)}");
            Assert.AreEqual(w.dot(vb), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(vb)}");

            w = vb.crossed(vc);
            delta = Math.Abs(b * c - w.magnitude());

            Assert.AreEqual(b * c, w.magnitude(), EPSILON, $"result vector magnitude not equal to magnitude-product of orthogonal precursor vectors. Delta: {delta}");
            Assert.AreEqual(w.dot(vb), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(vb)}");
            Assert.AreEqual(w.dot(vc), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(vc)}");

            w = vc.crossed(va);
            delta = Math.Abs(c * a - w.magnitude());

            Assert.AreEqual(c * a, w.magnitude(), EPSILON, $"result vector magnitude not equal to magnitude-product of orthogonal precursor vectors. Delta: {delta}");
            Assert.AreEqual(w.dot(vc), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(vc)}");
            Assert.AreEqual(w.dot(va), 0, EPSILON, $"result vector not perpendicular to precursor vectors. Delta: {w.dot(va)}");

        }

        [TestMethod]
        public void magnitudeTest()
        {
            Transform randRot = RandomRotation();

            double a = 100.0 * random.NextDouble();
            double aSqr = a * a;
            IVector3d va = randRot.transform(Vector3d.X_ONE.times(a));

            double delta = Math.Abs(a - va.magnitude());
            Assert.AreEqual(a, va.magnitude(), EPSILON, $"magnitude of vector diverges from generated value! Delta:{delta}");

            delta = Math.Abs(aSqr - va.magnitudeSq());
            Assert.AreEqual(aSqr, va.magnitudeSq(), EPSILON, $"squared magnitude of vector diverges from generated value! Delta:{delta}");

        }

        [TestMethod]
        public void normalizedTest()
        {
            Transform randRot = RandomRotation();

            double a = 100.0 * random.NextDouble();
            IVector3d va = randRot.transform(Vector3d.X_ONE.times(a));
            IVector3d na = va.normalized();

            double delta = Math.Abs(1.0 - na.magnitude());
            Assert.AreEqual(1.0, na.magnitude(), EPSILON, $"magnitude of normalized vector diverges from 1.0! Delta:{delta}");

            delta = Math.Abs(a - na.dot(va));
            Assert.AreEqual(a, na.dot(va), EPSILON, $"dotproduct of normalized vector diverges from generated value! Delta:{delta}");

        }

        [TestMethod]
        public void negatedTest()
        {
            IVector3d v = RandomVector().times(100.0);
            IVector3d n = v.negated();

            double delta = Math.Abs(v.magnitude() - n.magnitude());

            Assert.AreEqual(v.magnitude(), n.magnitude(), EPSILON, $"calculated magnitudes diverges for negated vector! Delta: {delta}");

            IVector3d z = v.plus(n);

            Assert.AreEqual(z.magnitude(), 0, EPSILON, $"sum of vector and its negation not equal to zero! Delta: {z.magnitude()}");

        }

        [TestMethod]
        public void orthogonalTest()
        {
            Transform randRot = RandomRotation();

            double a = 100.0 * random.NextDouble();
            IVector3d va = randRot.transform(Vector3d.X_ONE.times(a));
            IVector3d oa = va.orthogonal();

            double delta = Math.Abs(oa.dot(va));
            Assert.AreEqual(0, oa.dot(va), EPSILON, $"dotproduct of orthogonal vector diverges from zero! Delta:{delta}");

        }

        [TestMethod]
        public void angleTest()
        {
            double angle = 180.0 * random.NextDouble();
            Transform angleTrans = Transform.unity().rotZ(angle);
            Transform randRot = RandomRotation();
            double a = 100.0*random.NextDouble();
            double b = 100.0*random.NextDouble();

            IVector3d va = Vector3d.X_ONE.times(a);
            IVector3d vb = angleTrans.transform(Vector3d.X_ONE.times(b));

            va = randRot.transform(va);
            vb = randRot.transform(vb);

            double calcAngle = va.angle(vb);

            double delta = Math.Abs(calcAngle - angle);

            Assert.AreEqual(angle, calcAngle, EPSILON, $"calculated angle diverges from generated angle! Delta: {delta}");

        }

        [TestMethod]
        public void distanceTest()
        {
            Transform randTrans = RandomRotation();
            double distance = 100.0*random.NextDouble();
            IVector3d d = randTrans.transform(Vector3d.X_ONE.times(distance));
            IVector3d a = RandomVector().times(100.0);
            IVector3d b = a.plus(d);
            double calcDistance = a.distance(b);

            double delta = Math.Abs(calcDistance - distance);


            Assert.AreEqual(distance, calcDistance, EPSILON, $"calculated distance diverges from generated distance! Delta: {delta}");


        }

        [TestMethod]
        public void lerpTest()
        {
            double t = random.NextDouble();
            IVector3d va = RandomVector();
            IVector3d vb = RandomVector();

            IVector3d x = va.lerp(vb, t);
            IVector3d tx = va.times(1.0 - t).plus(vb.times(t));

            Assert.AreEqual(0, x.distance(tx), EPSILON, $"lerp vector diverges from alternatively generated vector! Delta: {x.distance(tx)}");
        }

        [TestMethod]
        public void projectTest()
        {
            Transform randRot = RandomRotation();

            double a = 100.0 * random.NextDouble();
            double b = 100.0 * random.NextDouble();

            IVector3d va = Vector3d.X_ONE.times(a);
            IVector3d vb = Vector3d.Y_ONE.times(b);
            IVector3d vc = va.plus(vb);
            va = va.normalized();

            va = randRot.transform(va);
            vb = randRot.transform(vb);
            vc = randRot.transform(vc);

            IVector3d p = va.project(vc);

            double delta = Math.Abs(a - p.magnitude());
            Assert.AreEqual(a, p.magnitude(), EPSILON, $"projected vector magnitude diverges from generated value! Delta: {delta}");
        }

        [TestMethod]
        public void collinearTest()
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
