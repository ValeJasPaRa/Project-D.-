using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
/*•	Registrar el medicamento considerando el código, nombre, cantidad y precio unitario. listo
•	Mostrar la lista de medicamentos considerando código, nombre, cantidad, precio unitario y monto invertido (se halla multiplicando cantidad por el precio unitario). listo
•	Buscar medicamentos por nombres y enviar un mensaje indicando si se encontró o no. LISTO 
•	Que permita eliminar un medicamento, ingresando el código. LISTO
•	Ordenar los medicamentos de forma alfabética por nombre de forma ascendente. listo */

//NOMBRE DE GRUPO : PROGRAMADOR SOLO//

namespace ciza_lenguaje_xd
{
    class Program
    {
        static void Main(string[] args)
        {
            int p_cont = 1;
            string p_rspt = "S";
            int p_anhadir = 0; //opcion si añadir o no
            int p_codigo=0;
            string p_nombre;
            int p_cantidad=0;
            float p_precio_unitario=0;
            float p_monto_invertido = 0;
            int p_buscar = 1;//opcion si buscar o no
            int p_eliminar = 1;//opcion si eliminar o no
            string p_nombre_med_buscar;//nombre de medicamento a buscar

            int p_ordenar=1;//opcion si ordenar o no

            ArrayList miArrayList = new ArrayList();

            Console.WriteLine("BIENVENIDO");
            do
            {
                Console.WriteLine();//SALTO DE LÍNEA
                do
                {   Console.WriteLine("¿Desea registrar medicamento?(S:si , N:no)";
                    p_rspt = Console.ReadLine();
                    p_rspt = p_rspt.ToUpper();
                    if (p_rspt == "N")
                    {
                        Console.WriteLine("Gracias por usar el programa");
                        break;
                    }
                    else if(p_rspt!="S")
                    {
                        Console.WriteLine("No es una opción válida, ingrese 'S'o 'N' ");
                    }
                } while (p_rspt != "S");

                  
                if (p_rspt == "S")
                {   
                    p_cont++;//el contador aumenta en 1 porque existe un nuervo medicamento//
                    do
                    {   Console.WriteLine(" * Inserte el código del medicamento (ingresar numeros>=0) >>");
                        p_codigo = int.Parse(Console.ReadLine());
                    } while (p_codigo < 0);
                        

                        Console.WriteLine(" * Inserte el nombre del medicamento >>");
                        p_nombre = Console.ReadLine();

                    do
                    {   Console.WriteLine(" * Inserte la cantidad de medicamento ha adquirir(>=0) >>");
                        p_cantidad = int.Parse(Console.ReadLine());                        
                    } while (p_cantidad < 0);

                    do
                    {   Console.WriteLine(" * Inserte el precio por unidad del medicamento (puede ingresar cifras decimales) >>");
                        p_precio_unitario = float.Parse(Console.ReadLine());
                    } while (p_precio_unitario < 0);

                    //CREANDO ARREGLOS
                    p_monto_invertido = p_precio_unitario * p_cantidad;//se define el monto
                    
                    // Agregamos elementos al ArrayList
                    miArrayList.Add(p_codigo); // Agregamos codigo
                    miArrayList.Add(p_nombre); // Agregamos nombre
                    miArrayList.Add(p_cantidad); //cantidad de medicamento
                    miArrayList.Add(p_precio_unitario);
                    miArrayList.Add(p_monto_invertido);

                    do
                    {
                        if (p_anhadir < 1 & p_anhadir > 2) { Console.WriteLine("Opción NO VÁLIDA"); Console.WriteLine("");}//SALTO DE LÍNEA; 
                        Console.WriteLine("¿Desea agregar medicamento? presione 1");
                        Console.WriteLine("¿Desea ver resumen de su compra? presione 2");
                        p_anhadir = int.Parse(Console.ReadLine());
                    } while (p_anhadir<1 & p_anhadir>2 );

                    if (p_anhadir == 2)
                    {
                        int i=0;
                        // MOSTRANDO ELEMENTOS DE LA LISTA
                        Console.WriteLine(" >>>LISTANDO MEDICAMENTOS>>>>");
                        for (int j = 1; j < p_cont; j++) { 
                            Console.WriteLine("MEDICAMENTO " + j);

                            i = (j - 1) * 5;
                            do
                            {
                                Console.WriteLine(miArrayList[i]);
                                i++;
                            } while (i < j * 5);
                        }

                        ///BUSCANDO MEDICAMENTO///
                        do
                        {
                          if (p_buscar < 0 & p_buscar > 1) { Console.WriteLine("Opción NO VÁLIDA"); Console.WriteLine(""); }//SALTO DE LÍNEA; 
                          Console.WriteLine("¿DESEA BUSCAR MEDICAMENTO? (1: SI, 0: NO)");
                          p_buscar = int.Parse(Console.ReadLine());
                        } while (p_buscar < 0 & p_buscar > 1);
                        if (p_buscar == 1)
                        {
                          Console.WriteLine("INSERTE EL NOMBRE DEL MEDICAMENTO A BUSCAR");
                          p_nombre_med_buscar = Console.ReadLine();
                          // Verificar si el ArrayList contiene el elemento buscado
                          bool contiene = miArrayList.Contains(p_nombre_med_buscar); //devuelve si 1 o no 0
                          if (contiene) { Console.WriteLine("   => SE ENCONTRÓ EL MEDICAMENTO"); }
                          else { Console.WriteLine("    => MEDICAMENTO NO ENCONTRADO"); }
                        
                        }

                        ///ELIMINAR MEDICAMENTO POR EL CÓDIGO//
                        do
                        {
                            if (p_eliminar < 0 & p_eliminar > 1) { Console.WriteLine("Opción NO VÁLIDA"); Console.WriteLine(""); }//SALTO DE LÍNEA; 
                            Console.WriteLine("¿DESEA ELIMINAR ALGÚN MEDICAMENTO? (1: SI, 0: NO)");
                            p_eliminar = int.Parse(Console.ReadLine());
                        } while (p_eliminar < 0 & p_eliminar > 1);
                        if (p_eliminar == 1){
                            //primero se busca el índice Del elemento para eliminar los 
                            // siguientes resultados que conforman al medicamento
                            Console.WriteLine("Inserte el código del medicamento a eliminar: ");
                            int cod_elim;//codigo a eliminar
                            cod_elim = int.Parse(Console.ReadLine()); // cod_elim sería un int por el dato guardado está en ese tipo.
                            bool conteniendo = miArrayList.Contains(cod_elim);
                            int index = 0;
                            if (conteniendo){ 
                               index = miArrayList.IndexOf(cod_elim);Console.WriteLine("UBICADO EN EL ÍNDICE:" + index);
                                // Eliminar un rango de elementos indice inicial
                                miArrayList.RemoveRange(index, 5);//el segundo cuenta como la cantidad de elementos q se vana a eliminar
                                                                  //El codigo del medicamento es el primero q ingresa para definir al medicamento
                                Console.WriteLine("  << MEDICAMENTO ELIMINADO SATISFACTORIAMENTE >>");
                                ///listando medicamentos para comprobar
                                
                            }
                            else { Console.WriteLine(" EL MEDICAMENTO NO ES POSIBLE ELIMINAR, NO SE ENCUENTRA"); }


                        }

                        // ORDENAR LOS MEDICAMENTO DE FORMA ASCENDENTE POR EL NOMBRE

                        do
                        {
                            if (p_ordenar < 0 & p_ordenar > 1) { Console.WriteLine("Opción NO VÁLIDA"); Console.WriteLine(""); }//SALTO DE LÍNEA; 
                            Console.WriteLine("¿DESEA ORDENAR ASCENDENTEMENTE LOS MEDICAMENTOS? (1: SI, 0: NO)");
                            p_ordenar = int.Parse(Console.ReadLine());
                        } while (p_ordenar < 0 & p_ordenar > 1);

                        if (p_ordenar == 1)
                        {
                            // Ordenar los elementos del ArrayList
                            ArrayList LETRAS = new ArrayList(); // para insertar los nombres
                            Console.WriteLine("MEDICAMENTO ");
                            int aux = 0;                            
                            int longitud = miArrayList.Count;
                            do
                            {
                                LETRAS.Add( miArrayList[aux + 1]);aux = aux +5;
                            } while (aux <longitud ) ;
                            
                            Console.WriteLine("ArrayList ordenado:");
                            //MOSTRAR ELEMENTOS ORDENADOS//
                            LETRAS.Sort();int x=0;
                            foreach (var elemento in LETRAS)
                            {
                                x= miArrayList.IndexOf(elemento);
                                Console.WriteLine("NOMBRE: "+elemento +"- CÓDIGO "+miArrayList[x-1]+"- CANTIDAD "+ miArrayList[x+1] + " -PRECIO UNITARIO "+ miArrayList[x+2]+" -MONTO A INVERTIR "+ miArrayList[x + 3]);
                            }

                        }
                    }

                }


            } while (p_anhadir == 1);//valida que el programa siga añadiendo listas
            
        }
    }
}

