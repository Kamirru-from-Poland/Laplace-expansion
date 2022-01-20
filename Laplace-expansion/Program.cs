Console.WriteLine("Enter the dimensions of the square matrix");
int dimension = int.Parse(Console.ReadLine());
Console.WriteLine("Enter each matrix factor consecutively");
int[,] matrix = new int[dimension, dimension];
for (int m = 0; m < dimension; m++)//rows of the matrix
    for (int n = 0; n < dimension; n++){//columns of the matrix
        Console.WriteLine($"Enter the matrix factor ({m + 1};{n + 1}) value:");
        int value = int.Parse(Console.ReadLine());
        matrix[m, n] = value;
    }
static int LaplaceExpansion(int[,] matrix){
    if (matrix.Length == 1) return matrix[0, 0];
    if (matrix.Length == 4) return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
    int q = (int)Math.Sqrt(matrix.Length);
    int determinant = 0;
    int sign = 1;
    int[,] submatrix = new int[q - 1, q - 1];
    for (int e = 0; e < q; e++){//following the first row
        int m = 0;//rows of the submatrix
        int n = 0;//columns of the submatrix
        for (int i = 1; i < q; i++){//rows of the matrix
            for (int j = 0; j < q; j++){//columns of the matrix
                if (j == e)
                    continue;
                submatrix[m, n++] = matrix[i, j];
            }
            m++;
            n = 0;
        }
        determinant += matrix[0, e] * sign * (LaplaceExpansion(submatrix));
        sign = -sign;
    }
    return determinant;
}
Console.WriteLine($"The matrix ({dimension}×{dimension})");
for (int m = 0; m < dimension; m++){
    for (int n = 0; n < dimension; n++)
        Console.Write($"{matrix[m, n]} ");
    Console.WriteLine();
}
Console.WriteLine($"The determinant of the matrix is {LaplaceExpansion(matrix)}");