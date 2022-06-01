using System;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploTask_Autos.Logica
{
    public static class SistemaAuto
    {

        static int kilometrajeAuto;
        static bool autoEncendido;
        static bool autoCirculando;

        public static bool AutoEncendido { get => autoEncendido; set => autoEncendido = value; }
        public static int KilometrajeAuto { get => kilometrajeAuto; }
        public static bool AutoCirculando { get => autoCirculando; }

        public static void CircularAuto(Action<int> actualizarKilometraje, Action<string> informacionTablero, CancellationToken cancelToken)
        {
            Task.Run(() =>
            {
                autoCirculando = true;

                while (true)
                {
                    // agrego try catch
                    try
                    {
                        if (cancelToken.IsCancellationRequested)
                        {
                            autoCirculando = false;
                            informacionTablero.Invoke("Auto apagado correctamente");
                            cancelToken.ThrowIfCancellationRequested();
                            
                        }
                        Task.Delay(3000);
                        kilometrajeAuto++;
                        actualizarKilometraje.Invoke(KilometrajeAuto);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                    }

                }

            }

              );

        }

        internal static void GirarIzquierda(Action encenderLuzGiroIzquierda)
        {
          Task.Run( () => encenderLuzGiroIzquierda.Invoke())  ;
        }

        internal static void GirarDerecha(Action encenderLuzGiroDerecha)
        {
            Task.Run(() => encenderLuzGiroDerecha.Invoke());
        }

        internal static void PrenderLuces(Action encender)
        {
            Task.Run(() => encender.Invoke());
        }
    }
}
