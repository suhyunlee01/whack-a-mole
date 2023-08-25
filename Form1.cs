using System;
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
        //Random구조체의 객체 생성
        Random random = new Random();


        //아래와 같은 방식이 오류가 나는 이유가 궁금함.
        //아직 진입점(클래스의 메서드)에 도달하지 않아서 아직 Application.Run()이 실행되지 않았음. 따라서 Form1의 객체가 생성되지 않아 오류 발생함.

        ////int XTop = this.Width - btnMole.Width;
        ////int YTop = this.Height - btnMole.Height;
        ////int XCenter = XTop / 2;
        ////int YCenter = YTop / 2;


        //일단 멤버 변수 만들고, 생성자에서 this를 통해 초기화하기
        private int XTop;
        private int YTop;
        private int XCenter;
        private int YCenter;


        public Form1()
        {
            InitializeComponent();

            //this는 앱이 실행되면서 생성된 Form1의 객체임
            XTop = this.Width - btnMole.Width;
            YTop = this.Height - btnMole.Height;
            XCenter = XTop / 2;
            YCenter = YTop / 2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //btnMole버튼의 초기 위치 설정 //Location 속성은 Point 객체를 받는다.
            //btnMole.Location = new Point(XCenter, YCenter);
            MoleReset(XCenter, YCenter);

            //타이머객체의 이벤트핸들러를 통해서 위치 이동시킴
            timer1.Start();
            timer1.Interval = 200;
        }

        private void btnMole_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            //맨 처음 설정한 btnMole버튼의 초기 위치에서 벗어났을 때만 클릭 이벤트 발생하기
            if (btnMole.Location != new Point(XCenter, YCenter))
            {
                MessageBox.Show("성공! 두더지를 잡았습니다!");
            }

            //btnMole.Location = new Point(XCenter, YCenter);
            MoleReset(XCenter, YCenter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //btnMole.Location = new Point(btnMole.Location.X + random.Next(1, 100), btnMole.Location.Y + random.Next(1, 100));


            //btnMole의 X/Y좌표를, 기존 X/Y좌표의 숫자 + 랜덤한 숫자로 이동하게 함.
            int X = btnMole.Location.X + random.Next(-400, 400);
            int Y = btnMole.Location.Y + random.Next(-400, 400);

            // 새로운 X/Y 좌표 위치를 Form1의 가로와 세로 경계 내로 조정함.
            //Max메서드를 통해 0, n 중 큰 수를 xy좌표로 정함.
            //n의 경우 XTop 혹은 X 좌표 중 작은 숫자를 n으로 정함.s
            //즉, 0이 최솟값 / Xtop 혹은 X중 작은 쪽을 선택해서 최댓값으로 함. -> 이렇게 하면 xtop보다는 작고, 0보다는 큰 수를 XY좌표로 정할 수 있다.
            X = Math.Max(0, Math.Min(XTop, X));
            Y = Math.Max(0, Math.Min(YTop, Y));

            //X랑 Y값으로 위치 조정
            MoleReset(X, Y);


            if (btnMole.Location.X == XTop && btnMole.Location.Y == YTop)
            {
                //센터 값으로 위치 초기화
                MoleReset(XCenter, YCenter);
            }
        }

        private void MoleReset(int X, int Y)
        {
            btnMole.Location = new Point(X, Y);
        }
    }
}
