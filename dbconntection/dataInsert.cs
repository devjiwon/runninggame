using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dbconntection
{
    public partial class dataInsert : Form
    {
        public static String url = "SERVER=127.0.0.1; " +
                                   "USER=root; " +
                                   "DATABASE=rank;" +
                                   "PORT=3306; " +
                                   "PASSWORD=4245; " +
                                   "SSLMODE=NONE";

        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문

        //private MySqlDataAdapter mySqlDataAdapter;

        //private DataTable data_table = null;

        //private string tempName;
        //private int count = 0;

        /*
        private void dbconnect()
        {
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
        }
        */

        public dataInsert()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

      
        private void button1_Click(object sender, EventArgs e) //data insert button
        {
            try
            {
                mConnection = new MySqlConnection(url); // DB접속
                mCommand = new MySqlCommand(); // 쿼리문 생성
                mCommand.Connection = mConnection; // DB에 연결

                mCommand.CommandText = "INSERT INTO ranking (name, score, grade) VALUES ('" + textBox1.Text + "', 1204,'12')"; // 쿼리문 작성

                //mCommand.CommandText = "INSERT INTO ranking VALUES ("+ count+", '" + textBox1.Text + "', 12,'12')"; // 쿼리문 작성
                mConnection.Open(); // DB 오픈
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

                mConnection.Close(); // 사용 후 객체 닫기
                
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }

            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void dataInsert_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
