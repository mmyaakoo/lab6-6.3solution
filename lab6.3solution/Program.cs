using System;



class Program
{
    static void Main()
    {
        // Example usage of the Quaternion class
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        Console.WriteLine($"Quaternion 1: {q1.W} + {q1.X}i + {q1.Y}j + {q1.Z}k");
        Console.WriteLine($"Quaternion 2: {q2.W} + {q2.X}i + {q2.Y}j + {q2.Z}k");

        Quaternion sum = q1 + q2;
        Console.WriteLine($"Sum: {sum.W} + {sum.X}i + {sum.Y}j + {sum.Z}k");

        Quaternion difference = q1 - q2;
        Console.WriteLine($"Difference: {difference.W} + {difference.X}i + {difference.Y}j + {difference.Z}k");

        Quaternion product = q1 * q2;
        Console.WriteLine($"Product: {product.W} + {product.X}i + {product.Y}j + {product.Z}k");

        Console.WriteLine($"Norm of Quaternion 1: {q1.Norm()}");
        Console.WriteLine($"Conjugate of Quaternion 1: {q1.Conjugate().W} + {q1.Conjugate().X}i + {q1.Conjugate().Y}j + {q1.Conjugate().Z}k");
        Console.WriteLine($"Inverse of Quaternion 1: {q1.Inverse().W} + {q1.Inverse().X}i + {q1.Inverse().Y}j + {q1.Inverse().Z}k");

        Console.WriteLine($"Quaternion 1 == Quaternion 2: {q1 == q2}");
        Console.WriteLine($"Quaternion 1 != Quaternion 2: {q1 != q2}");

        // Conversion to Rotation Matrix
        Matrix3x3 rotationMatrix = (Matrix3x3)q1;
        Console.WriteLine("Rotation Matrix from Quaternion 1:");
        Console.WriteLine($"| {rotationMatrix.M11}, {rotationMatrix.M12}, {rotationMatrix.M13} |");
        Console.WriteLine($"| {rotationMatrix.M21}, {rotationMatrix.M22}, {rotationMatrix.M23} |");
        Console.WriteLine($"| {rotationMatrix.M31}, {rotationMatrix.M32}, {rotationMatrix.M33} |");

        // Conversion from Rotation Matrix
        Quaternion fromRotationMatrix = (Quaternion)rotationMatrix;
        Console.WriteLine($"Quaternion from Rotation Matrix:");
        Console.WriteLine($"{fromRotationMatrix.W} + {fromRotationMatrix.X}i + {fromRotationMatrix.Y}j + {fromRotationMatrix.Z}k");
    }
}
