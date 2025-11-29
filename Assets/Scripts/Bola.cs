using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public float velocidadeBola;

    public float direcaoAleatoriaX;
    public float direcaoAleatoriaY;

    public Rigidbody2D RigidBola;
    public AudioSource somDaBola;

    // Start is called before the first frame update
    void Start()
    {
        MoverBola();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoverBola()
    {
        float dirX = Random.Range(0, 2) == 0 ? -1 : 1;
        float dirY = Random.Range(0, 2) == 0 ? -1 : 1;
        RigidBola.velocity = new Vector2(dirX * velocidadeBola, dirY * velocidadeBola);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        somDaBola.Play();
        RigidBola.velocity += new Vector2(direcaoAleatoriaX, direcaoAleatoriaY);
    }

    public void ResetarBola()
    {
        RigidBola.velocity = Vector2.zero;
        RigidBola.position = Vector2.zero;
        MoverBola();
    }
}
