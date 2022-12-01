using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carrinho : MonoBehaviour
{
    GeradorDeLista gerador;
    Controlador controlador;

    static string[] listaItensCarrinho;
    int indiceCarrinho = 0;

    [SerializeField] TextMeshProUGUI textoStatusBusca;

    void Start()
    {
        controlador = GameObject.FindObjectOfType<Controlador>();
        gerador = GameObject.FindObjectOfType<GeradorDeLista>();

        listaItensCarrinho = new string[gerador.TamanhoListaDeCompras()];
    }

    public void AdicionarItem(string item)
    {
        int resultadoBusca = BuscaBinaria.Buscar(item);
        
        if (resultadoBusca != -1)
        {
            if (resultadoBusca == gerador.indice)
            {
                textoStatusBusca.text = "Item adicionado no carrinho";
                listaItensCarrinho[indiceCarrinho] = item;
                
                if (indiceCarrinho < listaItensCarrinho.Length)
                {
                    indiceCarrinho++;
                }

                gerador.RemoverAlimento();
                gerador.PassarParaProximoItem();                
            } 
            
            else
            {
                textoStatusBusca.text = "Você não pode pegar esse item agora";
                controlador.Derrota();
            }
        } 
        
        else
        {
            textoStatusBusca.text = "Item não encontrado";
        }

        StartCoroutine(LimparTextoStatusBusca());
    }

    public int ObterQuantidadeDeItensNoCarrinho()
    {
        return indiceCarrinho;
    }

    IEnumerator LimparTextoStatusBusca()
    {
        yield return new WaitForSeconds(0.7f);
        textoStatusBusca.text = "";
    }

}
