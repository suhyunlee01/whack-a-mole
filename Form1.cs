﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIc_Tac_Toe
{
    public partial class Form1 : Form
    {
        //Form클래스와 Random구조체의 객체 생성
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //btnMole이 위치할 form1의 가로와 세로 정 가운데를 구하기 위해서 두 가로 세로 길이를 뺌.
            //this = Form1안에서 form1 객체를 생성하지 않고 this 사용했음.
            int XCenter = (this.Width - btnMole.Width)/2;
            int YCenter = (this.Height - btnMole.Height)/2;


            //btnMole버튼의 초기 위치 설정 //Location 속성은 Point 객체를 받는다.
            btnMole.Location = new Point(XCenter, YCenter);

            //타이머객체의 이벤트핸들러를 통해서 위치 이동시킴
            timer1.Start();
            timer1.Interval = 500;
        }

        private void btnMole_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            int XCenter = (this.Width - btnMole.Width) / 2;
            int YCenter = (this.Height - btnMole.Height) / 2;

            //맨 처음 설정한 btnMole버튼의 초기 위치에서 벗어났을 때만 클릭 이벤트 발생하기
            if (btnMole.Location != new Point(XCenter, YCenter))
            {
                MessageBox.Show("성공! 두더쥐를 잡았습니다!");
            }
            btnMole.Location = new Point(XCenter, YCenter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int XTop = this.Width - btnMole.Width;
            int YTop = this.Height - btnMole.Height;
            int XCenter = XTop / 2;
            int YCenter = YTop / 2;
            //btnMole.Location = new Point(btnMole.Location.X + random.Next(1, 100), btnMole.Location.Y + random.Next(1, 100));


            //btnMole의 X/Y좌표를, 기존 X/Y좌표의 숫자 + 랜덤한 숫자로 이동하게 함.
            int newX = btnMole.Location.X + random.Next(1, 100);
            int newY = btnMole.Location.Y + random.Next(1, 100);

            // 새로운 X/Y 좌표 위치를 Form1의 가로와 세로 경계 내로 조정
            newX = Math.Max(0, Math.Min(XTop, newX)); //0~(X최대 길이~새로운 X좌표 위치)
            newY = Math.Max(0, Math.Min(YTop, newY));

            btnMole.Location = new Point(newX, newY);


            if (btnMole.Location.X == XTop && btnMole.Location.Y == YTop)
            {
                btnMole.Location = new Point(XCenter, YCenter);
            }
        }
    }
}