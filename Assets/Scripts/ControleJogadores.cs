using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogadores : MonoBehaviour
{
    public float velocidadeJogador;
    public bool jogador1;

    private float yMinima = -4;
    private float yMaxima = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jogador1 == true)
        {
            MoverJogador1();
        }
        else
        {
            MoverJogador2();
        }
    }
    private void MoverJogador1()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, yMinima, yMaxima));

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * velocidadeJogador * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * velocidadeJogador * Time.deltaTime);
        }
    }
    private void MoverJogador2()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, yMinima, yMaxima));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * velocidadeJogador * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * velocidadeJogador * Time.deltaTime);
        }
    }
}
