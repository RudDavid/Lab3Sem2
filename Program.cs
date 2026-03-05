/*****************************
*  Создал Руднев Д.А.        *
*  Вариант: универсальный    *
*  Язык программирования: C# *
*****************************/

using System;

namespace Programming2._3 {
  internal class Program {

    public class MatrixException : Exception {
      public MatrixException(string message) : base(message) { }
      public MatrixException(string message, Exception inner) : base(message, inner) { }
    }

    class SquareMatrix {
      public int[,] userMatrix { get; set; }

      public SquareMatrix(int sizeOfMatrix) {
        userMatrix = new int[sizeOfMatrix, sizeOfMatrix];
        int indexI;
        int indexJ;

        Console.WriteLine("Enter the matrix elements: ");
        for (indexI = 0; indexI < sizeOfMatrix; ++indexI) {
          for (indexJ = 0; indexJ < sizeOfMatrix; ++indexJ) {
            if (int.TryParse(Console.ReadLine(), out int value)) {
              userMatrix[indexI, indexJ] = value;
            }
          }
        }
      }
      public int Size {
        get { return userMatrix.GetLength(0); }
      }
      public int this[int indexI, int indexJ] {
        get { return userMatrix[indexI, indexJ]; }
        set { userMatrix[indexI, indexJ] = value; }
      }
      public static SquareMatrix operator +(SquareMatrix left, SquareMatrix right) {
        int indexI;
        int indexJ;

        if (left.Size != right.Size) {
          throw new MatrixException("Matrices of different sizes");
        }

        SquareMatrix resultOfSum = new SquareMatrix(left.Size);
        for (indexI = 0; indexI < left.Size; ++indexI) {
          for (indexJ = 0; indexJ < left.Size; ++indexJ) {
            resultOfSum[indexI, indexJ] = left[indexI, indexJ] + right[indexI, indexJ];

          }
        }
        return resultOfSum;
      }

      public static SquareMatrix operator -(SquareMatrix left, SquareMatrix right) {
        int indexI;
        int indexJ;


        if (left.Size != right.Size) {
          throw new MatrixException("Matrices of different sizes");
        }

        SquareMatrix resultOfTheQuotient = new SquareMatrix(left.Size);
        for (indexI = 0; indexI < left.Size; ++indexI) {
          for (indexJ = 0; indexJ < left.Size; ++indexJ) {
            resultOfTheQuotient[indexI, indexJ] = left[indexI, indexJ] - right[indexI, indexJ];

          }
        }
        return resultOfTheQuotient;
      }

      public static SquareMatrix operator *(SquareMatrix left, SquareMatrix right) {

        int sum;
        int indexI;
        int indexJ;
        int indexK;

        if (left.Size != right.Size) {
          throw new MatrixException("Matrices of different sizes");
        }

        SquareMatrix resultOfTheMultiplication = new SquareMatrix(left.Size);
        for (indexI = 0; indexI < left.Size; ++indexI) {
          for (indexJ = 0; indexJ < left.Size; ++indexJ) {
            sum = 0;
            for (indexK = 0; indexK < left.Size; ++indexK) {
              sum += left[indexI, indexK] * right[indexK, indexJ];
              resultOfTheMultiplication[indexI, indexJ] = sum;
            }
          }
        }
        return resultOfTheMultiplication;
      }

      public static bool operator ==(SquareMatrix left, SquareMatrix right) {
        return ((left.Size == right.Size));
      }
      public static bool operator !=(SquareMatrix left, SquareMatrix right) {
        return (left.Size != right.Size);
      }

      public int CompareTo(SquareMatrix other) {
        if (other is SquareMatrix) {
          var param = other as SquareMatrix;
          if (param.Size > this.Size) {
            return -1;
          }
          if (param.Size == this.Size) {
            return 0;
          }
          if (param.Size < this.Size) {
            return 1;
          }
        }
        return -1;
      }

      public override bool Equals(object other) {
        int indexI;
        int indexJ;
        SquareMatrix matrix = other as SquareMatrix;
        if (this.Size == matrix.Size) {
          for (indexI = 0; indexI < this.Size; ++indexI) {
            for (indexJ = 0; indexJ < this.Size; ++indexJ) {
              if (this[indexI, indexJ] != matrix[indexI, indexJ]) {
                return false;
              }

            }
          }
          return true;
        }
        return false;

      }

      public override int GetHashCode() {
        int hash;
        hash = 17;
        return (int)hash * this.Size;
      }

      public override string ToString() {
        string stringResult = "";
        int indexI;
        int indexJ;

        for (indexI = 0; indexI < this.Size; ++indexI) {
          for (indexJ = 0; indexJ < this.Size; ++indexJ) {
            stringResult += this[indexI, indexJ] + ", ";
          }
          stringResult += "\n";
        }
        return strResult;

      }

      public object CloneMatrix() {
        int indexI;
        int indexJ;
        SquareMatrix cloneMatrix = new SquareMatrix(Size);
        for (indexI = 0; indexI < Size; ++indexI) {
          for (indexJ = 0; indexJ < Size; ++indexJ) {
            cloneMatrix[indexI, indexJ] = this[indexI, indexJ];
          }
        }

        return cloneMatrix;
      }

    }

    static void Main(string[] args) {
      bool isRun = true;

      while (isRun) {
        try {
          Console.Write("Enter the size for two square matrices");
          int size2, button0, button3;

          button0 = 0;
          button3 = 3;
          size2 = int.Parse(Console.ReadLine());

          SquareMatrix matrix1 = new SquareMatrix(size2);
          SquareMatrix matrix2 = new SquareMatrix(size2);

          Console.Write("Matrix A: ");
          Console.Write(matrix1 + "\t");
          Console.Write("Matrix B: ");
          Console.WriteLine(matrix2);

          Console.WriteLine("\n=== OPERATIONS MENU ===\n" +
            "0 - Exit program\n" +
            "1 - Addition (A + B)\n" +
            "2 - Subtraction(A - B)\n" +
            "3 - Multiplication (A * B)\n");

          int userNum;
          userNum = int.Parse(Console.ReadLine());
          while (userNum > button3 || userNum < button0) {
            userNum = int.Parse(Console.ReadLine());
          }

          switch (userNum) {
            case 0:
              isRun = false;
              break;
            case 1:
              Console.WriteLine("\nA + B:");
              SquareMatrix sum = matrix1 + matrix2;
              Console.WriteLine(sum);
              break;

            case 2:
              Console.WriteLine("\nA - B:");
              SquareMatrix diff = matrix1 - matrix2;
              Console.WriteLine(diff);
              break;

            case 3:
              Console.WriteLine("\nA * B:");
              SquareMatrix mult = matrix1 * matrix2;
              Console.WriteLine(mult);
              break;
          }
        } catch (FormatException) {
          Console.WriteLine("Error: Please enter a valid number!");
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
        } catch (MatrixException ex) {
          Console.WriteLine("Matrix Error: " + ex.Message);
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
        } catch (Exception ex) {
          Console.WriteLine("Unexpected Error: " + ex.Message);
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
        }
      }
    }

  }

}