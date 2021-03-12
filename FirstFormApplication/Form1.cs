using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstFormApplication
{
    public partial class Form1 : Form
    {
        int n = 0; // 동적생성을 위한 전역변수1 n
        int r = 0; // 동적생성을 위한 전역변수2 r
        int time = 0; // 시간을 카운트하기 위한 전역변수 time

        public Form1()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, EventArgs e)
        { // 누르면 한번에 버튼이 생기도록 하는 이벤트 함수
            for (int i = 1; i < 5; i++) // 1부터 4까지 반복
            {
                Button bt = new Button(); // 버튼 생성 후
                Controls.Add(bt);
                bt.Location = new Point(12, 12 + (23 + 3) * i); // 위치 지정
                bt.Text = "동적 생성 " + i + "번째"; // 버튼의 텍스트 수정
                bt.Width = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { // 누르면 하나씩 아래에 버튼이 생기도록 하는 이벤트 함수
            n++; // 전역변수 n의 값을 변경
            Button bt = new Button();
            Controls.Add(bt);
            bt.Location = new Point(139, 12 + (23 + 3) * n); // n의 값에따라 y축을 변화시켜줌
            bt.Text = "동적 생성 " + n + "번째";
            bt.Width = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        { // 누르면 하나씩 아래에 버튼이 생기고 그 버튼에도 이벤트를 등록하는 함수
            r++;
            Button bt = new Button();
            Controls.Add(bt);
            bt.Location = new Point(261, 12 + (23 + 3) * r);
            bt.Text = "동적 생성 " + r + "번째";
            bt.Width = 100;
            bt.Click += new System.EventHandler(button2_Click); // 새로만든 버튼에도 생성 이벤트를 추가
        }

        private void timer1_Tick(object sender, EventArgs e)
        { // 시간이 1초 단위로 지날 때 마다 실행되는 이벤트
            time++; // 전역변수 time의 값을 1추가
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result; // 누른 버튼을 받아오기 위한 DialogResult 변수 result
            result = MessageBox.Show("버튼들을 지울까요?", "확인", MessageBoxButtons.YesNo);

            
            if (result == DialogResult.No) // 취소 클릭 시
                e.Cancel = true; // 종료를 취소
            else // 확인 클릭 시 소요 시간을 보여주며 종료
                MessageBox.Show(time + "초 경과", "소요 시간", MessageBoxButtons.YesNo);
        }
    }
}
