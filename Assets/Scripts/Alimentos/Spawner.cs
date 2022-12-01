using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] alimentos;

    public static bool podeSpawnar = true;

    private int ultimaEscolha = 0;

    void Start()
    {
        InvokeRepeating("SpawnarAlimentos", 0f, Random.Range(1.5f, 3.2f));
    }

    void SpawnarAlimentos()
    {

        if (podeSpawnar == false)
        {
            CancelInvoke();
        }

        int indice = Random.Range (0, alimentos.Length);

        while (indice == ultimaEscolha)
        {
            indice = Random.Range(0, alimentos.Length);
        }

        Instantiate (alimentos[indice], transform.position, Quaternion.identity);        
    }

}
