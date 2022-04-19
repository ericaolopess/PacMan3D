using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAxis : MonoBehaviour
{
    float velocidade;
    float girar;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 20F;
        girar = 30F;
    }

    // Update is called once per frame
    void Update()
    {
        float translate = (Input.GetAxis("Vertical") * velocidade) * Time.deltaTime;
        float rotate = (Input.GetAxis("Horizontal") * girar) * Time.deltaTime;
        float jump = (Input.GetAxis("Jump") * velocidade) * Time.deltaTime;

        transform.Translate(0, 0, translate);
        transform.Rotate(0, rotate, 0);
        transform.Translate(0, jump, 0);
    }
}
