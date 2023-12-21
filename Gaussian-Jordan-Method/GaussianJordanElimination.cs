using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApplication6
{
    class GaussianJordanElimination
    {
        double[,] a;
        int rows;
        public GaussianJordanElimination() { 
        }
       public void setArray(double [,]arr){
        this.a=arr;
        this.rows=arr.GetLength(0);
       }

        public void printMatrix(double[,]mat) {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j]+"\t");
                }
                Console.WriteLine();
            }
        }

        public string matToString(double[,] mat)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    sb.Append(mat[i, j] + "  ");
                }
                Console.WriteLine();
                sb.Append("\n");
            }
            sb.Append("\n");
            return sb.ToString();

        }

        public string solve()
        {
            rows = a.GetLength(0);
            int cols = a.GetLength(1);
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Displaying input Matrix");
            printMatrix(a);
            sb.Append("Displaying input Matrix \n");
            sb.Append(matToString(a));

            

            //=== START NEW COMITS FOR THE LEDAING != 0 ===//
            for (int inpt = 0; inpt < rows; inpt++)
            {
                
                double swp1, swp2, swp3, swp4;

                int test = inpt + 1;
                if (inpt == 0)
                {


                    if (a[inpt,inpt] == 0 && inpt == 0)
                    {
                        if (a[test, 0] != 0) 
                        {
                            swp1 = a[0,0];
                            swp2 = a[0, 1];
                            swp3 = a[0, 2];
                            swp4 = a[0, 3];

                            a[0, 0] = a[1, 0];
                            a[0, 1] = a[1, 1];
                            a[0, 2] = a[1, 2];
                            a[0, 3] = a[1, 3];

                            a[1, 0] = swp1;
                            a[1, 1] = swp2;
                            a[1, 2] = swp3;
                            a[1, 3] = swp4;

                        }
                        else if (a[2, 0] != 0)
                        {
                            swp1 = a[0, 0];
                            swp2 = a[0, 1];
                            swp3 = a[0, 2];

                            a[0, 0] = a[2, 0];
                            a[0, 1] = a[2, 1];
                            a[0, 2] = a[2, 2];

                            a[2, 0] = swp1;
                            a[2, 1] = swp2;
                            a[2,2] = swp3;
                        }
                        else  //-> Will implement if leading = 0 and all values below it = 0
                        {   
                            MessageBox.Show($"Infitely Solutions Because,The First Column In Array All Values = 0");
                            break;
                        } 


                    }

                    if (a[inpt , inpt] == 0 && inpt == 1 && a.GetLength(0) == 3 && a.GetLength(1) - 1 == 3)
                    {
                        if (a[test +1 , 1] != 0) 
                        {
                            swp1 = a[1, 0];
                            swp2 = a[1, 1];
                            swp3 = a[1, 2];

                            a[1, 0] = a[2, 0];
                            a[1, 1] = a[2, 1];
                            a[1, 2] = a[2, 2];

                            a[2, 0] = swp1;
                            a[2, 1] = swp1;
                            a[2, 2] = swp1;
                        }
                        else if (a[1, 2] == 0)
                        {
                            MessageBox.Show($"No Solutions Because,The Second Roq In Array All Values = 0");
                            break;
                        }


                    }


                    if (a[inpt, inpt] == 0 && inpt == 2)
                    {
                        if (a[1,inpt] != 0 && a[inpt,1] != 0) 
                        {
                            swp1 = a[2, 0];
                            swp2 = a[2, 1];
                            swp3 = a[2, 2];

                            a[2, 0] = a[1, 0];
                            a[2, 1] = a[1, 1];
                            a[2, 2] = a[1, 2];

                            a[2, 0] = swp1;
                            a[2, 1] = swp1;
                            a[2, 2] = swp1;
                        }

                    }

                }
                //=== END NEW COMITS FOR THE LEDAING != 0 ===//

            }


            /* i representing no of rows.
             * To obtain the main dianlog a00, a11, a22 to make them leading = (1).
             * Second for loop to make the first element equals 1 (obtain leading).
             * j representing no of columns.
             * a[i, j] = a[i, j] / temp ->To Store Multipliers.
             */

            for (int i = 0; i < rows; i++)       
            {
                double temp = a[i,i];           
                for (int j = 0; j < cols; j++)     
                {
                    a[i, j] = a[i, j] / temp;     
                }
                Console.WriteLine("Row operation is row" + i + " is divided by " + temp);
                printMatrix(a);
                sb.Append("Row operation is row" + i + " is divided by " + temp+" \n");
                sb.Append(matToString(a));

                /*
                 * k representing Rows on which operation is
                 * being performed. To create zeros below &////apply row operation for every row
                 * above the main diagonal.
                 * j represents no of colums on which operation is being performed
                 */

                for (int k = 0; k < rows; k++)  
                {                               
                    temp = a[k, i];           
                    if (i != k)
                    {
                        for (int j = 0; j < cols; j++) 
                        { 
                            a[k, j] = a[k, j] - (temp * a[i, j]);
                        }
                        Console.WriteLine("Row operation  is row" + i + " is multiplied by " + temp + " and then subtarcted from row" + k);
                        printMatrix(a);
                        sb.Append("Row operation  is row" + i + " is multiplied by " + temp + " and then subtarcted from row" + k+" \n");
                        sb.Append(matToString(a));
                    }
                }
            }

            Console.WriteLine("solved matrix");
            printMatrix(a);
            sb.Append("solved matrix \n");
            sb.Append(matToString(a));
            return sb.ToString();

        }

        // mat 2
        public static double DET(int n, double[,] Mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] SUBMat = new double[n, n];

            if (n == 2)
            {
                return ((Mat[0, 0] * Mat[1, 1]) - (Mat[1, 0] * Mat[0, 1]));
            }
            else
            {
                // n var represent no of rows in Mat

                for (k = 0; k < n; k++)     
                {
                    subi = 0;
                    for (i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            SUBMat[subi, subj] = Mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * Mat[0, k] * DET(n - 1, SUBMat));
                }
            }
            return d;
        }


    }

   
   
    
}