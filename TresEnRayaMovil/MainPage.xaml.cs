namespace TresEnRayaMovil
{
    public partial class MainPage : ContentPage
    {
        private bool cambiarTurno = true;

        int ganadosX = 0;
        int ganadosO = 0;


        public MainPage()
        {
            InitializeComponent();

            Application.Current.UserAppTheme = AppTheme.Light;

            turno.Text = "Jugador X";
        }

        private void NuevoJuego_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
        }

        private void RestablecerResultados_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
            ganadosX = 0;
            ganadosO = 0;
            resultadoX.Text = Convert.ToString(ganadosX);
            resultadoO.Text = Convert.ToString(ganadosO);
        }


        private async void Button_Click(object sender, EventArgs e)
        {
            ImageButton boton = (ImageButton)sender;

            if (boton.ClassId != null)
            {
                await MensajeCasillaVacia();

            }
            else
            {
                if (cambiarTurno)
                {
                    boton.Source = "xficha.gif";
                    boton.ClassId = "x";
                    await Ganador();
                    turno.Text = "Jugador O";
                }
                else
                {
                    boton.Source = "oficha.gif";
                    boton.ClassId = "o";
                    await Ganador();
                    turno.Text = "Jugador X";
                }

                cambiarTurno = !cambiarTurno;
            }
        }


        private async Task Ganador()
        {
            if (btn1.ClassId != null && btn2.ClassId != null && btn3.ClassId != null && btn1.ClassId == btn2.ClassId && btn2.ClassId == btn3.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn4.ClassId != null && btn5.ClassId != null && btn6.ClassId != null && btn4.ClassId == btn5.ClassId && btn5.ClassId == btn6.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn7.ClassId != null && btn8.ClassId != null && btn9.ClassId != null && btn7.ClassId == btn8.ClassId && btn8.ClassId == btn9.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn1.ClassId != null && btn4.ClassId != null && btn7.ClassId != null && btn1.ClassId == btn4.ClassId && btn4.ClassId == btn7.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn2.ClassId != null && btn5.ClassId != null && btn8.ClassId != null && btn2.ClassId == btn5.ClassId && btn5.ClassId == btn8.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn3.ClassId != null && btn6.ClassId != null && btn9.ClassId != null && btn3.ClassId == btn6.ClassId && btn6.ClassId == btn9.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn1.ClassId != null && btn5.ClassId != null && btn9.ClassId != null && btn1.ClassId == btn5.ClassId && btn5.ClassId == btn9.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn3.ClassId != null && btn5.ClassId != null && btn7.ClassId != null && btn3.ClassId == btn5.ClassId && btn5.ClassId == btn7.ClassId)
            {
                await MensajeGanador();
                Resultado();
                ReiniciarJuego();
            }
            else if (btn1.ClassId != null && btn2.ClassId != null && btn3.ClassId != null && btn4.ClassId != null && btn5.ClassId != null &&
                btn6.ClassId != null && btn7.ClassId != null && btn8.ClassId != null && btn9.ClassId != null)
            {
                await MensajeEmpate();
                ReiniciarJuego();
            }
        }

        private async Task MensajeGanador()
        {
            winner.Text = turno.Text.ToUpper();
            winnerFrame.IsVisible = true;

            await Task.Delay(3000);

            winnerFrame.IsVisible = false;
        }

        private async Task MensajeEmpate()
        {
            winner.Text = "EMPATE!!";
            ganador.IsVisible = false;
            winnerFrame.IsVisible = true;

            await Task.Delay(3000);

            winnerFrame.IsVisible = false;
            ganador.IsVisible = true;
        }

        private async Task MensajeCasillaVacia()
        {
            winner.Text = "Debes pulsar en una casilla vacía";
            ganador.IsVisible = false;
            winnerFrame.IsVisible = true;

            await Task.Delay(3000);

            winnerFrame.IsVisible = false;
            ganador.IsVisible = true;
        }

        private void ReiniciarJuego()
        {
            ImageButton[] botonesArray = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

            for (int i = 0; i < 9; i++)
            {
                botonesArray[i].Source = null;
                botonesArray[i].ClassId = null;
            }
        }

        private void Resultado()
        {
            if (turno.Text == "Jugador X")
            {
                ganadosX++;
                resultadoX.Text = Convert.ToString(ganadosX);
            }
            else
            {
                ganadosO++;
                resultadoO.Text = Convert.ToString(ganadosO);
            }
        }

    }
}