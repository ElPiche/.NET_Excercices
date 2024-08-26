using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_pipelineEstiloFuncional.pipeline
{

    internal class PipeLineEstiloFuncional
    {
        //notese que por simplicidad aqui no estoy utilizando una interface
        //private IList<Endpoint> _endpoints; //lista de endpoints orden O(n)

        private Dictionary<string, Endpoint> _endpointsMap; //map (dictionary) de endpoints con orden de ejecución de O(1), en teoria mas rapido a la hora de buscar.

        public PipeLineEstiloFuncional()
        {
            //_endpoints = new List<Endpoint>();
            _endpointsMap = new Dictionary<string , Endpoint>();
        }
        /*
        public void AgregarEndPoint(Endpoint nuevoEndpoint)
        {
            _endpoints.Add(nuevoEndpoint);
        }
        */
        public void AgregarEndPointMap(Endpoint nuevoEndpoint)
        {

            string url = nuevoEndpoint.GetUrl(); //será la clave de mi objeto endpoint

            if (!_endpointsMap.ContainsKey(url))
            {
                _endpointsMap.Add(url, nuevoEndpoint);
            }
            else
            {
                Console.WriteLine("El endpoint ya se encuentra registrado");
            }
        }

        /*
        public void ProcesarRequestEntrante(string urlRequestEntrate)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foreach (Endpoint nuevoEndpoint in _endpoints)
            {
                nuevoEndpoint.Evaluar(urlRequestEntrate);
            }

            stopwatch.Stop();

            Console.WriteLine("Tiempo medido en milisegundos: " + stopwatch.ElapsedMilliseconds.ToString());
            Console.WriteLine("Tiempo medido en ticks: " + stopwatch.ElapsedTicks.ToString());
        }
        */
        public void ProcesarRequestEntranteMap(string urlRequestEntrate)
        {
            Stopwatch stopwatch = new Stopwatch(); 
            stopwatch.Start();

            if (_endpointsMap.TryGetValue(urlRequestEntrate, out Endpoint endPoint))
            {
                endPoint.Evaluar(urlRequestEntrate);

                stopwatch.Stop();

                Console.WriteLine("Tiempo medido en milisegundos: " + stopwatch.ElapsedMilliseconds.ToString()); //imprimo tiempo de demora de la busqueda.
                Console.WriteLine("Tiempo medido en ticks: " + stopwatch.ElapsedTicks.ToString());
            }
            else
            {
                Console.WriteLine("No existe endpoint.");
            }

        }
    }
}
