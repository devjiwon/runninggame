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
    public partial class DB2 : Form
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

        public DB2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DB2_Load(object sender, EventArgs e)
        {
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
            mCommand.CommandText = "SELECT * FROM ranking"; // 쿼리문 작성
            mConnection.Open(); // DB 오픈
            mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

            while (mDataReader.Read()) // 전부 다 읽어 옴
            {
                // 여기서 부터 원하는 데이터를 받아와서 처리
                string tempName = mDataReader["name"].ToString();
                string tempScore = mDataReader["score"].ToString();
                string tempGrade = mDataReader["grade"].ToString();

                //string tempPhone = mDataReader["phone"].ToString();
                textBox1.AppendText("     " + tempName);
                textBox1.AppendText("     " + tempScore);
                //textBox1.AppendText("     " + tempName + "\t" + tempScore + "\t" + tempGrade );
                //textBox1.AppendText("전화번호 : " + tempPhone + "\n");
                textBox1.AppendText("\r\n\r\n");
            }

            mConnection.Close(); // 사용 후 객체 닫기
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
