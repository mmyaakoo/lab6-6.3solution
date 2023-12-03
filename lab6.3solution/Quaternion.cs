class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    // Constructors
    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public Quaternion() : this(0, 0, 0, 0) { }

    // Arithmetic operations using operator overloading
    public static Quaternion operator +(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Quaternion operator -(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        return new Quaternion(
            a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z,
            a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
            a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
            a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W
        );
    }

    // Norm calculation
    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    // Conjugate
    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }


    // Inverse
    public Quaternion Inverse()
    {
        double normSq = Norm() * Norm();
        return new Quaternion(W / normSq, -X / normSq, -Y / normSq, -Z / normSq);
    }


    // Comparison operators
    public static bool operator ==(Quaternion a, Quaternion b)
    {
        return a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(Quaternion a, Quaternion b)
    {
        return !(a == b);
    }

    // Conversion between Quaternion and Rotation Matrix
    public static explicit operator Matrix3x3(Quaternion q)
    {
        double w2 = q.W * q.W;
        double x2 = q.X * q.X;
        double y2 = q.Y * q.Y;
        double z2 = q.Z * q.Z;

        double wx = 2 * q.W * q.X;
        double wy = 2 * q.W * q.Y;
        double wz = 2 * q.W * q.Z;

        double xy = 2 * q.X * q.Y;
        double xz = 2 * q.X * q.Z;

        double yz = 2 * q.Y * q.Z;

        return new Matrix3x3(
            1 - 2 * (y2 + z2), 2 * (xy - wz), 2 * (xz + wy),
            2 * (xy + wz), 1 - 2 * (x2 + z2), 2 * (yz - wx),
            2 * (xz - wy), 2 * (yz + wx), 1 - 2 * (x2 + y2)
        );
    }

    public static explicit operator Quaternion(Matrix3x3 m)
    {
        double trace = m.M11 + m.M22 + m.M33;

        if (trace > 0)
        {
            double s = 0.5 / Math.Sqrt(trace + 1.0);
            return new Quaternion(
                0.25 / s,
                (m.M32 - m.M23) * s,
                (m.M13 - m.M31) * s,
                (m.M21 - m.M12) * s
            );
        }
        else if (m.M11 > m.M22 && m.M11 > m.M33)
        {
            double s = 2.0 * Math.Sqrt(1.0 + m.M11 - m.M22 - m.M33);
            return new Quaternion(
                (m.M32 - m.M23) / s,
                0.25 * s,
                (m.M12 + m.M21) / s,
                (m.M13 + m.M31) / s
            );
        }
        else if (m.M22 > m.M33)
        {
            double s = 2.0 * Math.Sqrt(1.0 + m.M22 - m.M11 - m.M33);
            return new Quaternion(
                (m.M13 - m.M31) / s,
                (m.M12 + m.M21) / s,
                0.25 * s,
                (m.M23 + m.M32) / s
            );
        }
        else
        {
            double s = 2.0 * Math.Sqrt(1.0 + m.M33 - m.M11 - m.M22);
            return new Quaternion(
                (m.M21 - m.M12) / s,
                (m.M13 + m.M31) / s,
                (m.M23 + m.M32) / s,
                0.25 * s
            );
        }
    }

    // Other methods can be added as needed
}