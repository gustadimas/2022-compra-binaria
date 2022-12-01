using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuscaBinaria : MonoBehaviour
{
    public static int Buscar(string item)
    {
        string[] lista = GeradorDeLista.ListaDeCompras();
    
        int comeco = 0;
        int final = lista.Length - 1;
        int meio = 0;
        
        while (comeco <= final)
        {            
            if (lista[meio].ToLower().Equals(item.ToLower()))
            {
                return meio;
            }
            
            else if (lista[meio].ToLower().CompareTo(item.ToLower()) < 0)
            {
                comeco = meio + 1;
            }
            
            else
            
            {
                final = meio - 1;
            }
            
            meio = (comeco + final) / 2;                        
        }  
        
        return -1;
    }
}
