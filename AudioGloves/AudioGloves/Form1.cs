using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Midi;


namespace AudioGloves
{
    public partial class Form1 : Form
    {
        private Hand Left, LeftTrans, Right, RightTrans;
        OutputDevice outputDevice;

        public Form1()
        {
            InitializeComponent();
            Left = new Hand();
            LeftTrans = new Hand();
            Right = new Hand();
            RightTrans = new Hand();
            outputDevice = OutputDevice.InstalledDevices[0];
            outputDevice.Open();

        }

        public void PlayNote(int key, double duration)
        {
            // Used a thread in order for the application
            // to play multiple notes at the same time

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Pitch Note = ((Pitch[])Enum.GetValues(typeof(Pitch)))[key];
                outputDevice.SendNoteOn(Channel.Channel1, Note, 80);
            }).Start();

        }

        public void StopNote(int key)
        {
            Pitch Note = ((Pitch[])Enum.GetValues(typeof(Pitch)))[key];
            outputDevice.SendNoteOff(Channel.Channel1, Note, 80);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if ((char)e.KeyValue == 'R')
            {
                if (Left.FirstF == true)
                {
                    Left.FirstF = false;
                    LeftTrans.FirstF = true;
                    LF_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'E')
            {
                if (Left.SecondF == true)
                {
                    Left.SecondF = false;
                    LeftTrans.SecondF = true;
                    LS_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'W')
            {
                if (Left.ThirdF == true)
                {
                    Left.ThirdF = false;
                    LeftTrans.ThirdF = true;
                    LT_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'Q')
            {
                if (Left.LittleF == true)
                {
                    Left.LittleF = false;
                    LeftTrans.LittleF = true;
                    LL_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'C')
            {
                if (Left.Thumb == true)
                {
                    Left.Thumb = false;
                    LeftTrans.Thumb = true;
                    LTH_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'X')
            {
                if (Left.ThumbK == true)
                {
                    Left.ThumbK = false;
                    LeftTrans.ThumbK = true;
                    LK_label.Visible = false;

                }
            }
            if ((char)e.KeyValue == 'Z')
            {
                if (Left.Palm == true)
                {
                    Left.Palm = false;
                    LeftTrans.Palm = true;
                    LP_label.Visible = false;

                }
            }

            //Right Hand

            if ((char)e.KeyValue == 'U')
            {
                if (Right.FirstF == true)
                {
                    Right.FirstF = false;
                    RightTrans.FirstF = true;
                    RF_label.Visible = false;
                }
            }
            if ((char)e.KeyValue == 'I')
            {
                if (Right.SecondF == true)
                {
                    Right.SecondF = false;
                    RightTrans.SecondF = true;
                    RS_label.Visible = false;
                }
            }
            if ((char)e.KeyValue == 'O')
            {
                if (Right.ThirdF == true)
                {
                    Right.ThirdF = false;
                    RightTrans.ThirdF = true;
                    RT_label.Visible = false;
                }
            }

            if ((char)e.KeyValue == 'P')
            {
                if (Right.LittleF == true)
                {
                    Right.LittleF = false;
                    RightTrans.LittleF = true;
                    RL_label.Visible = false;
                }
            }

            if ((char)e.KeyValue == 'N')
            {
                if (Right.Thumb == true)
                {
                    Right.Thumb = false;
                    RightTrans.Thumb = true;
                    RTH_label.Visible = false;
                }
            }
            if ((char)e.KeyValue == 'M')
            {
                if (Right.Palm == true)
                {
                    Right.Palm = false;
                    RightTrans.Palm = true;
                    RP_label.Visible = false;
                }
            }
            CalculateNote(false);

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 'r')
            {
                if (Left.FirstF == false)
                {
                    Left.FirstF = true;
                    LeftTrans.FirstF = true;
                    LF_label.Visible = true;
                }
            }
            if (e.KeyChar == 'e')
            {
                if (Left.SecondF == false)
                {
                    Left.SecondF = true;
                    LeftTrans.SecondF = true;
                    LS_label.Visible = true;
                }
            }
            if (e.KeyChar == 'w')
            {
                if (Left.ThirdF == false)
                {
                    Left.ThirdF = true;
                    LeftTrans.ThirdF = true;
                    LT_label.Visible = true;
                }
            }
            if (e.KeyChar == 'q')
            {
                if (Left.LittleF == false)
                {
                    Left.LittleF = true;
                    LeftTrans.LittleF = true;
                    LL_label.Visible = true;
                }
            }
            if (e.KeyChar == 'c')
            {
                if (Left.Thumb == false)
                {
                    Left.Thumb = true;
                    LeftTrans.Thumb = true;
                    LTH_label.Visible = true;
                }
            }
            if (e.KeyChar == 'x')
            {
                if (Left.ThumbK == false)
                {
                    Left.ThumbK = true;
                    LeftTrans.ThumbK = true;
                    LK_label.Visible = true;
                }
            }
            if (e.KeyChar == 'z')
            {
                if (Left.Palm == false)
                {
                    Left.Palm = true;
                    LeftTrans.Palm = true;
                    LP_label.Visible = true;
                }
            }

            // Right Hand


            if (e.KeyChar == 'u')
            {
                if (Right.FirstF == false)
                {
                    Right.FirstF = true;
                    RightTrans.FirstF = true;
                    RF_label.Visible = true;
                }
            }
            if (e.KeyChar == 'i')
            {
                if (Right.SecondF == false)
                {
                    Right.SecondF = true;
                    RightTrans.SecondF = true;
                    RS_label.Visible = true;
                }
            }
            if (e.KeyChar == 'o')
            {
                if (Right.ThirdF == false)
                {
                    Right.ThirdF = true;
                    RightTrans.ThirdF = true;
                    RT_label.Visible = true;
                }
            }
            if (e.KeyChar == 'p')
            {
                if (Right.LittleF == false)
                {
                    Right.LittleF = true;
                    RightTrans.LittleF = true;
                    RL_label.Visible = true;
                }
            }
            if (e.KeyChar == 'n')
            {
                if (Right.Thumb == false)
                {
                    Right.Thumb = true;
                    RightTrans.Thumb = true;
                    RTH_label.Visible = true;

                }
            }
            if (e.KeyChar == 'm')
            {
                if (Right.Palm == false)
                {
                    Right.Palm = true;
                    RightTrans.Palm = true;
                    RP_label.Visible = true;
                }
            }
            CalculateNote(true);
        }

        private void CalculateNote(bool PlayStop)
        {
            int Note = 0;
            if (Left.FirstF)
            {
                if (RightTrans.Thumb) Note = 33;      // A First Octave
                if (RightTrans.FirstF) Note = 37;     // C#
                if (RightTrans.SecondF) Note = 40;    // E
                if (RightTrans.ThirdF) Note = 43;     // G
                if (RightTrans.LittleF) Note = 47;    // B

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 36; // A minor
                }

                if(Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 44; // G#
                }
            }

            if (Left.FirstF && Left.Palm)
            {
                if (RightTrans.Thumb) Note = 34;      // A# First Octave
                if (RightTrans.FirstF) Note = 38;     // D
                if (RightTrans.SecondF) Note = 41;    // F
                if (RightTrans.ThirdF) Note = 44;     // G#
                if (RightTrans.LittleF) Note = 48;    // C

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 37; // C#
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 45; // A Second Octave
                }
            }

            if (Left.FirstF && Left.SecondF)
            {
                if (RightTrans.Thumb) Note = 35;      // B First Octave
                if (RightTrans.FirstF) Note = 39;     // D#
                if (RightTrans.SecondF) Note = 42;    // F#
                if (RightTrans.ThirdF) Note = 45;     // A Second Octave
                if (RightTrans.LittleF) Note = 49;    // C#

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 38; // D
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 46; // A#
                }
            }

            if (Left.FirstF && Left.SecondF && Left.ThirdF)
            {
                if (RightTrans.Thumb) Note = 36;      // C First Octave
                if (RightTrans.FirstF) Note = 40;     // E
                if (RightTrans.SecondF) Note = 43;    // G
                if (RightTrans.ThirdF) Note = 46;     // A#
                if (RightTrans.LittleF) Note = 50;    // D

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 39; // D#
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 47; // B
                }
            }

            if (Left.FirstF && Left.SecondF && Left.ThirdF && Left.Palm)
            { 
                if (RightTrans.Thumb) Note = 37;      // C#
                if (RightTrans.FirstF) Note = 41;     // F
                if (RightTrans.SecondF) Note = 44;    // G#
                if (RightTrans.ThirdF) Note = 47;     // B
                if (RightTrans.LittleF) Note = 51;    // D#

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 40; // E
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 48; // C
                }
            }

            if (Left.FirstF && Left.SecondF && Left.ThirdF && Left.LittleF)
            {
                if (RightTrans.Thumb) Note = 38;      // D
                if (RightTrans.FirstF) Note = 42;     // F#
                if (RightTrans.SecondF) Note = 45;    // A
                if (RightTrans.ThirdF) Note = 48;     // C
                if (RightTrans.LittleF) Note = 52;    // E

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 41; // F
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 49; // C#
                }
            }

            if (Left.FirstF && Left.SecondF && Left.ThirdF && Left.LittleF && Left.Palm)
            {
                if (RightTrans.Thumb) Note = 39;      // D#
                if (RightTrans.FirstF) Note = 43;     // G
                if (RightTrans.SecondF) Note = 46;    // A#
                if (RightTrans.ThirdF) Note = 49;     // C#
                if (RightTrans.LittleF) Note = 53;    // F

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 42; // F#
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 50; // D
                }
            }

            if (Left.SecondF && Left.ThirdF && Left.LittleF)
            {
                if (RightTrans.Thumb) Note = 40;      // E
                if (RightTrans.FirstF) Note = 44;     // G#
                if (RightTrans.SecondF) Note = 47;    // B
                if (RightTrans.ThirdF) Note = 50;     // D
                if (RightTrans.LittleF) Note = 54;    // F#

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 43; // G
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 51; // D#
                }
            }


            if (Left.ThirdF && Left.LittleF)
            {
                if (RightTrans.Thumb) Note = 41;      // F
                if (RightTrans.FirstF) Note = 45;     // A
                if (RightTrans.SecondF) Note = 48;    // C
                if (RightTrans.ThirdF) Note = 51;     // D#
                if (RightTrans.LittleF) Note = 55;    // G

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 44; // G#
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 52; // E
                }
            }

            if (Left.ThirdF && Left.LittleF && Left.Palm)
            {
                if (RightTrans.Thumb) Note = 42;      // F#
                if (RightTrans.FirstF) Note = 46;     // A#
                if (RightTrans.SecondF) Note = 49;    // C#
                if (RightTrans.ThirdF) Note = 52;     // E
                if (RightTrans.LittleF) Note = 56;    // G#

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 45; // A
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 53; // F
                }
            }

            if (Left.LittleF)
            {
                if (RightTrans.Thumb) Note = 43;      // G
                if (RightTrans.FirstF) Note = 47;     // B
                if (RightTrans.SecondF) Note = 50;    // D
                if (RightTrans.ThirdF) Note = 53;     // F
                if (RightTrans.LittleF) Note = 57;    // A

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 46; // A#
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 54; // F#
                }
            }

            if (Left.LittleF&&Left.Palm)
            {
                if (RightTrans.Thumb) Note = 44;      // G#
                if (RightTrans.FirstF) Note = 48;     // C
                if (RightTrans.SecondF) Note = 51;    // D#
                if (RightTrans.ThirdF) Note = 54;     // F#
                if (RightTrans.LittleF) Note = 58;    // A#

                if (Left.Thumb)
                {
                    if (RightTrans.FirstF) Note = 47; // B
                }

                if (Left.ThumbK)
                {
                    if (RightTrans.ThirdF) Note = 55; // G
                }
            }

            ClearTrans();

            if (Note > 0)
            {
                if (PlayStop)
                    PlayNote(Note, 70);
                else
                    StopNote(Note);
            }

        }


        private void ClearTrans()
        {
            RightTrans.FirstF = false;
            RightTrans.SecondF = false;
            RightTrans.ThirdF = false;
            RightTrans.LittleF = false;
            RightTrans.Thumb = false;
            RightTrans.ThumbK = false;
            RightTrans.Palm = false;
        }
    }

    public class Hand
    {
        public bool FirstF, SecondF, ThirdF, LittleF, Thumb,ThumbK, Palm;
        public Hand()
        {
            FirstF = false;
            SecondF = false;
            ThirdF = false;
            LittleF = false;
            Thumb = false;
            ThumbK = false;
            Palm = false;
        }
    }

}