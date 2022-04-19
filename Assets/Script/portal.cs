using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform saida;
    public bool entrou;

    // Start is called before the first frame update
    void Start()
    {
        entrou = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!entrou)
        {
            if (other.tag == "Player")
            {
          
                other.transform.position = saida.position;
                entrou = true;

            }
        }
        else
        {
            entrou = false;
        }

     }
}
