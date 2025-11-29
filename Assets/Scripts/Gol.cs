using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{
    public bool golJogador1;
    public Rigidbody2D RigidBola;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(golJogador1 == true)
        {
            FindObjectOfType<GameManager>().aumentarPontuacaoJogador2();
            other.GetComponent<Bola>().ResetarBola();
        }
        else
        {
            FindObjectOfType<GameManager>().aumentarPontuacaoJogador1();
            other.GetComponent<Bola>().ResetarBola();  
        }
    }

}
