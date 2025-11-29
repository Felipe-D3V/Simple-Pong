using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJogador2 : MonoBehaviour
{
    public float velocidadeJogador;

    private float yMinima = -4;
    private float yMaxima = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverJogador1();
    }
    private void MoverJogador1()
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
