using EjemploTask_Autos.Logica;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EjemploTask_Autos
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        private void btn_PrenderAuto_Click(object sender, EventArgs e)
        {
            SistemaAuto.AutoEncendido = true;
            pb_nafta.Visible = true;
            pb_temperatura.Visible = true;
        }

        private void btn_Conducir_Click(object sender, EventArgs e)
        {
            try
            {
                if (SistemaAuto.AutoEncendido)
                {
                    pb_rpm.Visible = true;
                    pb_velocimetro.Visible = true;

                    SistemaAuto.CircularAuto(ActualizarKilometrosEnPantalla, MensajeEnTablero, cts.Token);


                    btn_Conducir.Text = "Auto en marcha";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ActualizarKilometrosEnPantalla(int km)
        {
            if (this.lb_kilometraje.InvokeRequired)
            {
                this.lb_kilometraje.BeginInvoke((MethodInvoker)delegate ()
                {
                    lb_kilometraje.Visible = true;

                    this.lb_kilometraje.Text = km.ToString();
                });

                Thread.Sleep(1000);
            }
            else
            {
                this.lb_kilometraje.Text = km.ToString();
            }
        }

        private void btn_ApagarAutomovil_Click(object sender, EventArgs e)
        {
            if (SistemaAuto.AutoCirculando)
            {
                cts.Cancel();
            }
        }

        private void MensajeEnTablero(string mensaje)
        {
            if (this.lb_informacionTablero.InvokeRequired)
            {
                this.lb_informacionTablero.BeginInvoke((MethodInvoker)delegate ()
                {
                    lb_informacionTablero.Visible = true;

                    lb_informacionTablero.Text = mensaje;
                });

            }
        }

        private void btn_kmIniciales_Click(object sender, EventArgs e)
        {
            ActualizarKilometrosEnPantalla(int.Parse(textBox1.Text));
        }

        private void btn_girarIzquierda_Click(object sender, EventArgs e)
        {
            if (SistemaAuto.AutoCirculando)
            {
                try
                {
                    SistemaAuto.GirarIzquierda(EncenderLuzGiroIzquierda);

                }
                catch (Exception)
                {

                }
            }
        }

        private void btn_GirarDerecha_Click(object sender, EventArgs e)
        {
            if (SistemaAuto.AutoCirculando)
            {
                try
                {
                    SistemaAuto.GirarDerecha(EncenderLuzGiroDerecha);
                }
                catch (Exception)
                {

                }
            }
        }

        private void EncenderLuzGiroDerecha()
        {
            if (this.pb_luzDer.InvokeRequired)
            {
                this.pb_luzDer.BeginInvoke((MethodInvoker)delegate ()
                {
                    pb_luzDer.Visible = true;
                    Thread.Sleep(5000);
                    pb_luzDer.Visible = false;
                });

            }
            else
            {
                pb_luzDer.Visible = true;
                Thread.Sleep(5000);
                pb_luzDer.Visible = false;
            }
        }

        private void EncenderLuzGiroIzquierda()
        {
            if (this.pb_luzIzquierda.InvokeRequired)
            {
                this.pb_luzIzquierda.BeginInvoke((MethodInvoker)delegate ()
                {
                    pb_luzIzquierda.Visible = true;
                    Thread.Sleep(5000);
                    pb_luzIzquierda.Visible = false;
                });

            }
            else
            {
                pb_luzIzquierda.Visible = true;
                Thread.Sleep(5000);
                pb_luzIzquierda.Visible = false;
            }
        }

        private void btn_PrenderLuces_Click(object sender, EventArgs e)
        {

            if (SistemaAuto.AutoCirculando)
            {
                try
                {
                    SistemaAuto.PrenderLuces(ToggleEncenderLuces);
                }
                catch (Exception)
                {

                }
            }
        }

        private void btn_llover_Click(object sender, EventArgs e)
        {

            if (SistemaAuto.AutoCirculando)
            {
                try
                {
                    SistemaAuto.PrenderLuces(ToggleLimpiaParabrisas);
                }
                catch (Exception)
                {

                }
            }
        }

        private void ToggleEncenderLuces()
        {
            if (this.pb_luces.InvokeRequired)
            {
                this.pb_luces.BeginInvoke((MethodInvoker)delegate ()
                {
                    if (pb_luces.Visible)
                    {
                        pb_luces.Visible = false;
                        btn_PrenderLuces.Text = "Prender luces";
                    }
                    else
                    {
                        pb_luces.Visible = true;
                        btn_PrenderLuces.Text = "Apagar luces";
                    }

                });

            }
            else
            {
                if (pb_luces.Visible)
                {
                    pb_luces.Visible = false;
                }
                else
                {
                    pb_luces.Visible = true;

                }
            }
        }

        private void ToggleLimpiaParabrisas()
        {
            if (this.pb_limpiaParabrisas.InvokeRequired)
            {
                this.pb_limpiaParabrisas.BeginInvoke((MethodInvoker)delegate ()
                {
                    if (pb_limpiaParabrisas.Visible)
                    {
                        pb_limpiaParabrisas.Visible = false;
                        btn_llover.Text = "Llueve";
                    }
                    else
                    {
                        pb_limpiaParabrisas.Visible = true;
                        btn_llover.Text = "Ya no llueve";
                    }

                });

            }
            else
            {
                if (pb_limpiaParabrisas.Visible)
                {
                    pb_limpiaParabrisas.Visible = false;
                }
                else
                {
                    pb_limpiaParabrisas.Visible = true;

                }

            }
        }
    }
}
