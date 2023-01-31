using System.Security.Cryptography.X509Certificates;

internal class Program
{   
    public static List<List<int>> CreateSprialMatrix(int n)
    {
        List<List<int>> matrix= new List<List<int>>();
        for(int i=0; i<n; i++)
        {
            matrix.Add(new List<int>(new int[n]));
        }

        int top_dir = 0;
        int down_dir = n - 1;
        int left_dir = 0;
        int right_dir = n-1;
        int dir = 0;
        int num = 1;

        while(top_dir<= down_dir && left_dir <= right_dir) {
        
            // first case 
            if(dir == 0)
            { 
                // pointer move to left to right
                for(int i = left_dir; i <= right_dir; i++)
                {
                    // row is static no change , only change col
                 (matrix[top_dir][i]) = num++;
                }
                
                top_dir++;
            }

            // second case 

            else if(dir == 1)
            {
                // pointer move to top to down 

                for (int i= top_dir; i<=down_dir; i++)
                {
                    // col is static , only change in row 
                    (matrix[i][right_dir]) = num++;
                }
                right_dir--;
            }
            // third case 

            else if(dir == 2)
            {
                // pointer move to right to left

                for (int i =right_dir; i >= left_dir; i--)
                {
                    // row is static, only change in col
                    (matrix[down_dir][i]) = num++;
                }
                down_dir--;
            }

            // fourth case 

            else if (dir == 3)
            {                 
                // pointer move to down to top

                for (int i=down_dir; i>=top_dir; i--)
                {
                    // col fix , row change
                    (matrix[i][left_dir]) = num++;
                }
                left_dir++;
            }

            dir = (dir + 1) % 4;

        }
        return matrix;

 
            }

    private static void Print_mt(List<List<int>> matrix)
    {
        foreach (List<int> row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Size of Matrix : ");
        int n = int.Parse(Console.ReadLine());
        List<List<int>> matrix = CreateSprialMatrix(n);
        Print_mt(matrix);
        Console.ReadLine();
    }

    
}