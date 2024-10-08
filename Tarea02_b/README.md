Código Tarea02_b Consigna 3 Refactorizar código

Tema: Functional Style

Consigna 3: Refactoring del ejemplo planteado en clases

Objetivos:

	-Interiorizar el uso del estilo funcional en C#
	-Familiarizarse con librerías de C# para el manejo de estructuras de memoria
	-Familiarizarse con la estructura Map

Se pide:

	El código de ejemplo planteado en clases implementa un pipeline que simula el procesamiento de requests: dado una request entrante se decide que endpoint la va a procesar.
Para lograr este comportamiento, cada endpoint se implementa como un paso concreto que se agrega al pipeline de ejecución. 
Este diseño tiene una desventaja: hay que recorrer el pipeline cada vez que llega una request, orden de ejecución: O(n)
Utilizando un Map, donde la clave sea la url y el valor sea una función, se puede optimizar el diseño realizado, ya que se accede a la función a ejecutar con un orden de ejecución de  O(1)

Link código ejemplo: https://github.com/gabrielaramburu/TallerNET/tree/main/01_02b_pipelinePattern/01_02c_pipelineEstiloFuncional