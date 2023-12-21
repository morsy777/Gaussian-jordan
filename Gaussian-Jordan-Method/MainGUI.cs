using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ConsoleApplication6
{
    public partial class MainGUI : Form
    {
        GaussianJordanElimination gaus = new GaussianJordanElimination();
        public MainGUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataTable createTable(int rows, int cols) {
            DataTable table = new DataTable();
            // Loop for determine no of cols in head 
            for (int x = 0; x < cols; x++)
            {
                table.Columns.Add("X" + x, typeof(double));
                
            }
            // Loop for creating values and assign values for it 
            for (int y = 0; y < rows; y++)
            {
                int[,] array = new int[1, cols];

                table.Rows.Add(array.Cast<object>().ToArray());
            }

            return table;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int rows = 0;
            int cols = 0;

            /*
             * If user enter string data type or bool,
             * program will making exception,
             * so we determine try and catch to handling exception.
             */

            try
            {
                 cols = int.Parse(textBox1.Text);
                 rows = int.Parse(textBox2.Text);

                 if (cols <= 0 & rows <= 0) {
                     MessageBox.Show("Rows and Columns must be a poistive integer");
                 }else if (cols - rows != 1)
                 {
                     MessageBox.Show("Columns must be greater than Rows by 1");
                 }

                 DataTable table=createTable(rows, cols);
                 dataGridView1.Visible=true;
                 dataGridView1.DataSource = table;
                 dataGridView1.Size = new Size((cols*41)+30,(rows*25)+15);
                 Console.WriteLine(rows + " " + cols);

            }
            catch (FormatException)
            {
                MessageBox.Show("Rows and Columns must be an integer");
            }

        }

        /*
         * Button 2 for solve array by determine 2D array (data) and its size = no of rows * no of cols.
         * 2 Nested loop for access each element in the array after that solve it.
         */
        private void button2_Click(object sender, EventArgs e)
        {
           DataTable table=(DataTable)dataGridView1.DataSource;
           int rows= table.Rows.Count;
           int cols = table.Columns.Count;
           double [,]data=new double[rows,cols];
          
               for (int y = 0; y < rows; y++)
               {
                   for (int x = 0; x < cols; x++)
                   {
                       data[y,x] = double.Parse(table.Rows[y][x].ToString());
                   }
               }

            // remove the last column from the augmrnted matrix, by creating new arr and add al columns except the last column
            double [,] data_no_augment= new double[rows,cols-1];
            for(int i=0;i<data.GetLength(0);i++){

                 for(int j=0;j<data.GetLength(1)-1;j++){
                     data_no_augment[i,j] = data[i,j];
                 }
            }
            double det=GaussianJordanElimination.DET(rows,data_no_augment);

            ////======================>

            //float[,] data_no_augment2 = new float[rows, cols];
            //for (int i = 0; i < data.GetLength(0); i++)
            //{

            //    for (int j = 0; j < data.GetLength(1) - 1; j++)
            //    {
            //        data_no_augment2[i, j] = data[i, j];
            //    }
            //}

            //double det = GaussianJordanElimination.DET(rows, data_no_augment);

            ////=======================>

            //gaus.printMatrix(data);

            // Comment 
            if (det == 0)
            {

                richTextBox1.Text = "Can not be solved as determinant=0\ndeterminate=0, if there is no solution or infietly solution";
            }


            //================================
            //else if (det == 1)
            //{
            //    richTextBox1.Text = "Has infinite multiple solution";
            //}
            //================================

            //coment
            else
            {
                gaus.setArray(data);

                richTextBox1.Text = gaus.solve();
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
