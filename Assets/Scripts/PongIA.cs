using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongIA : MonoBehaviour
{
    public float velocidade = 8f;       // velocidade da IA
    public Transform bola;             // referência à bola
    public float limiteSuperior = 3.5f;
    public float limiteInferior = -3.5f;

    void Update()
    {
        if (bola == null) return;

        // IA segue a posição da bola no eixo Y
        if (bola.position.y > transform.position.y)
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }
        else if (bola.position.y < transform.position.y)
        {
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        }

        // Limitar movimento da raquete
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, limiteInferior, limiteSuperior);
        transform.position = pos;
    }
}
