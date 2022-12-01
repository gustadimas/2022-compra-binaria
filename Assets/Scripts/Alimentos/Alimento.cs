using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alimento : MonoBehaviour
{
    Rigidbody2D rb;

    float offset_x;
    float offset_y;

    Vector2 posicaoDoMouse;

    public string nomeDoAlimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (0, Random.Range(-2f, -5f));
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown() 
    {
        offset_x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offset_y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;        
    }

    void OnMouseDrag()
    {
        posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(posicaoDoMouse.x - offset_x, posicaoDoMouse.y - offset_y);
    }

    void OnMouseUp()
    {
        GameObject carrinho = GameObject.FindObjectOfType<Carrinho>().gameObject;

        if (Vector2.Distance(transform.position, carrinho.transform.position) < 1.5f)
        {            
            carrinho.GetComponent<Carrinho>().AdicionarItem(nomeDoAlimento);
            Destroy(gameObject);            
        }
    }
}
