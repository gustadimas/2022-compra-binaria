using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeradorDeLista : MonoBehaviour
{
    string[] listaDeItens = 
    {
        "abacaxi",
        "batataFrita",
        "donut",
        "hamburguer",
        "marmita",
        "maca",
        "melancia",
        "morango",
        "peraAmarela",
        "peraVerde",
        "uvaRoxa",
        "uvaVerde"
    };


    [HideInInspector] public int indice = 0;

    int totalItens = 9;

    static string[] listaDeCompras;

    Controlador controlador;

    void Awake() 
    {
        RandomizarLista();
    }

    void Start()
    {
        controlador = GameObject.FindObjectOfType<Controlador>();   
    }

    void RandomizarLista()
    {
        listaDeCompras = new string[totalItens];

        int[] indices_escolhidos = new int[totalItens];

        for (int i = 0; i < totalItens; i++)
        {
            int indice_aleatorio = Random.Range(0, listaDeItens.Length);

            while (VerificarSeIndiceJaFoiEscolhido(indice_aleatorio, indices_escolhidos))
            {
                indice_aleatorio = Random.Range(0, listaDeItens.Length);
            }

            indices_escolhidos[i] = indice_aleatorio;

            listaDeCompras[i] = listaDeItens[indice_aleatorio];
        } 

        System.Array.Sort(listaDeCompras); // Realiza a ordenação da lista.
    }

    bool VerificarSeIndiceJaFoiEscolhido(int indice_aleatorio, int[] indices_escolhidos)
    {
        for (int i = 0; i < indices_escolhidos.Length; i++)
        {
            if(indice_aleatorio == indices_escolhidos[i])
            {
                return true;
            }
        }

        return false;
    }

    public static string[] ListaDeCompras()
    {
        return listaDeCompras;
    }

    public int TamanhoListaDeCompras()
    {
        return totalItens;
    }

    
    public string ObterItemParaComprar()
    {
        if (indice < totalItens)
        {
            return listaDeCompras[indice];
        }
        
        else
        {
            return null;
        }       
    }

    public void PassarParaProximoItem()
    {
        if (indice < totalItens)
        {
            indice++;
        }

        controlador.SetarProximoItemNoCanvas();        
    }

    public void RemoverAlimento()
    {
        listaDeCompras[indice] = "ALIMENTO_REMOVIDO_DA_LISTA";
    }

}   
