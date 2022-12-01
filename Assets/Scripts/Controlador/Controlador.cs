using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controlador : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoItens;
    [SerializeField] TextMeshProUGUI textoMetaColetar;
    [SerializeField] TextMeshProUGUI textoItensNoCarrinho;
    [SerializeField] TextMeshProUGUI textoProximoItem;
    [SerializeField] TextMeshProUGUI textoTimer;
    [SerializeField] TextMeshProUGUI textoVitoriaOuDerrota;


    GeradorDeLista gerador;
    Carrinho carrinhoCompras;

    Coroutine corrotinaTimer;
    int quantidadeItensColetar = 0;


    void Start()
    {
        
        gerador = GameObject.FindObjectOfType<GeradorDeLista>();
        carrinhoCompras = GameObject.FindObjectOfType<Carrinho>();

        IniciarTimer();
        SetarListaDeComprasNoCanvas();
        SetarTextoMeta();
        SetarProximoItemNoCanvas();

    }

    void Update()
    {        
        if (carrinhoCompras.ObterQuantidadeDeItensNoCarrinho() >= quantidadeItensColetar)
        {
            
            textoProximoItem.text = "Fim da lista";
            textoVitoriaOuDerrota.text = "Parabéns, você ganhou!";
            textoVitoriaOuDerrota.color = Color.green;
            
            PararTimer();  
        }
    }

    public void SetarProximoItemNoCanvas()
    {
        textoProximoItem.text = "Próximo item para coletar: " + ObterAlimento(gerador.ObterItemParaComprar());
        textoItensNoCarrinho.text = "Total de itens no carrinho: " + carrinhoCompras.ObterQuantidadeDeItensNoCarrinho();
    }


    void IniciarTimer()
    {
        corrotinaTimer = StartCoroutine(Timer());
    }

    void SetarTextoMeta()
    {
        textoMetaColetar.text = "Total para coletar: "+ quantidadeItensColetar;
    }

    void SetarListaDeComprasNoCanvas()
    {
        
        string[] listaCompras = GeradorDeLista.ListaDeCompras();

        quantidadeItensColetar = listaCompras.Length;

        string textolista = "";
        string alimento = "";

        for (int i = 0; i < listaCompras.Length; i++)
        {           
            alimento = ObterAlimento(listaCompras[i]);

            textolista += alimento + "\n";
        }

        textoItens.text = textolista;
    }


    string ObterAlimento(string variavelAlimento)
    {
        string nomeAlimento = "";

        switch(variavelAlimento)
        {
            case "abacaxi":
                nomeAlimento = "Abacaxi";
                break;
            case "batataFrita":
                nomeAlimento = "Batata Frita";
                break;
            case "donut":
                nomeAlimento = "Donut";
                break;
            case "hamburguer":
                nomeAlimento = "Hamburguer";
                break;
            case "marmita":
                nomeAlimento = "Marmita";
                break;
            case "maca":
                nomeAlimento = "Maçã";
                break;
            case "melancia":
                nomeAlimento = "Melancia";
                break;
            case "morango":
                nomeAlimento = "Morango";
                break;
            case "peraAmarela":
                nomeAlimento = "Pêra Amarela";
                break;
            case "peraVerde":
                nomeAlimento = "Pêra Verde";
                break;
            case "uvaRoxa":
                nomeAlimento = "Uva Roxa";
                break;
            case "uvaVerde":
                nomeAlimento = "Uva Verde";
                break;                
        }   
        
        return nomeAlimento.ToUpper(); 
    }


    public void PararTimer()
    {
        if (corrotinaTimer != null)
        {
            StopCoroutine(corrotinaTimer);
        }
    }


    void ResetarTime()
    {
        if (corrotinaTimer != null)
        {
            StopCoroutine(corrotinaTimer);
        }

        IniciarTimer();
    }


    void VerificarDerrota()
    {
        if (carrinhoCompras.ObterQuantidadeDeItensNoCarrinho() < quantidadeItensColetar)
        {
            textoVitoriaOuDerrota.text = "Você perdeu!";
            textoVitoriaOuDerrota.color = Color.red;
        }
    }

    public void Derrota()
    {
        textoVitoriaOuDerrota.text = "Você perdeu!";
        
        textoVitoriaOuDerrota.color = Color.red;   
        
        PararTimer();     
        
        StartCoroutine(ReiniciarJogo());
    }

    IEnumerator Timer()
    {
        float tempo = 180f;
        
        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            
            textoTimer.text = Mathf.RoundToInt(tempo) + "s";
            
            yield return null;
        }
        
        textoTimer.text = "0s";
        
        Spawner.podeSpawnar = false;
        
        yield return new WaitForSeconds(2f);
        
        textoTimer.text = "Acabou";

        VerificarDerrota();
    }

    IEnumerator ReiniciarJogo()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
