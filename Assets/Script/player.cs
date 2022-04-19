using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Rigidbody rb;
    float speed;
 
    public Text pontos;
    public Text cherry;
    public Text life;

    public Transform inicialPonto;

    private bool powerUp;

	private AudioSource pegarProp;

    int score;
    int countFruit;
    int vida;

    //lerp
    public Color startEnemy;
    public Color endEnemy;
   



    // Start is called before the first frame update
    void Start()
    {
		pegarProp = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        speed = 5;

        score = 0;
        countFruit = 0;
        vida = 3;
        powerUp = false;

        pontos.text = "" + score;
        cherry.text = "x " + countFruit;
        life.text = "Life x " + vida;
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        rb.velocity = move * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "prop")
        {
            score += 1;
            pontos.text = "" + score;
            Destroy(other.gameObject);
			pegarProp.Play();
        }

        if (other.tag == "cherry")
        {
            countFruit += 1;
            cherry.text = "x " + countFruit;
            Destroy(other.gameObject);
        }

        //recebe dano
        if (other.tag == "Enemy"  && powerUp == false)
        {
            vida -= 1;
            life.text = "Life x " + vida;
        }
        
        //para de receber dano
        if (other.tag == "Enemy" && powerUp == true)
        {
            other.transform.position = inicialPonto.position;
            //Destroy(other.gameObject);
        }

        if (other.tag == "powerUp")
        {
            powerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void UpPlayer()
    {
        startEnemy = Color.red;
        endEnemy = Color.white;

        GetComponent<Renderer>().material.color = 
                        Color.Lerp(endEnemy, startEnemy, Mathf.PingPong(Time.time, 1));

    }
}
