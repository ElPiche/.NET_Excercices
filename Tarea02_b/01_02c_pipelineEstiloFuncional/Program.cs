// See https://aka.ms/new-console-template for more information
using _01_02c_pipelineEstiloFuncional;
using _01_02c_pipelineEstiloFuncional.pipeline;

//new EjemploEstiloFuncional().probar();


PipeLineEstiloFuncional pipeLine= new PipeLineEstiloFuncional();

/*
pipeLine.AgregarEndPoint(new Endpoint("/casoA", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoA trabajando con List");
    Console.WriteLine($"Parámetro recibido: {s}");
}));


pipeLine.AgregarEndPoint(new Endpoint("/casoB", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoB trabajando con List");
}));

pipeLine.AgregarEndPoint(new Endpoint("/casoC", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoC trabajando con List");
}));

// cada vez que recibo un request ejecuto el pipeLine pasando como parámetro
// la urlDestino
pipeLine.ProcesarRequestEntrante("/casoB");
*/

// Diseño utilizando map.

pipeLine.AgregarEndPointMap(new Endpoint("/casoA", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoA trabajando con MAP");
    Console.WriteLine($"Parámetro recibido: {s}");
}));

pipeLine.AgregarEndPointMap(new Endpoint("/casoB", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoB trabajando con MAP");
    Console.WriteLine($"Parámetro recibido: {s}");
}));

pipeLine.AgregarEndPointMap(new Endpoint("/casoC", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoC trabajando con MAP");
    Console.WriteLine($"Parámetro recibido: {s}");
}));

pipeLine.ProcesarRequestEntranteMap("/casoB");



