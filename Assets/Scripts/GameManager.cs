using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontuacaoJogador1;

    public int pontuacaoJogador2;


    public GameObject Placar;
    public Text pontuacao;

    public GameObject quitMenu;
    public GameObject vencedorJogador1;
    public GameObject vencedorJogador2;
    public GameObject mensagemReiniciar;
    public GameObject TelaInicial;

    public GameObject player2; // arraste o jogador 2 aqui pelo Inspector

    public AudioSource SomDeGol;
    public AudioSource VictorySound;
    public AudioSource ButtonSound;
    public AudioSource RestartAudio;

    public static bool Comecar = true;


    void Start()
    {
        /*Estava tendo um problema que ao reiniciar com 'R' a tela inicial estava abrindo novamente, como não é o
          que estava querendo que acontecesse, coloquei uma condicional para que o Menu Inicial só apareça na primeira entrada do usuário*/
        if (Comecar == true)
        {
            Placar.SetActive(false);
            TelaInicial.SetActive(true);
            Time.timeScale = 0f;
            Comecar = false;

        }
        else
        {
            Placar.SetActive(true);
            TelaInicial.SetActive(false);
            Time.timeScale = 1f;
        }

        pontuacaoJogador1 = 0;
        pontuacaoJogador2 = 0;
        pontuacao.text = pontuacaoJogador1 + " - " + pontuacaoJogador2;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarPartida();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;

            MusicManager.Instance.TryReconnectSlider();
        }
            if (pontuacaoJogador1 >= 7)
            {
                Time.timeScale = 0f;
                vencedorJogador1.SetActive(true);
                mensagemReiniciar.SetActive(true);
                VictorySound.PlayOneShot(VictorySound.clip);

            //'R' dentro da partida
            if (Input.GetKeyDown(KeyCode.R))
                {
                    
                    ReiniciarPartida();
                    RestartAudio.Play();
                    vencedorJogador1.SetActive(false);
                    mensagemReiniciar.SetActive(false);
                }

            }
            if (pontuacaoJogador2 == 7)
            {
                Time.timeScale = 0f;
                vencedorJogador2.SetActive(true);
                mensagemReiniciar.SetActive(true);
                VictorySound.PlayOneShot(VictorySound.clip);

            //'R' Ao finalizar a partida
            if (Input.GetKeyDown(KeyCode.R))
                {
                    
                    ReiniciarPartida();
                    RestartAudio.Play();
                    vencedorJogador1.SetActive(false);
                    vencedorJogador2.SetActive(false);
                    mensagemReiniciar.SetActive(false);

            }
            
        }
    }



    //Botões Menu ESC
    public void ConfirmarSaida()
    {
        ButtonSound.Play();
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }

    public void CancelarSaida()
    {
        quitMenu.SetActive(false);
        Time.timeScale = 1f;
        if (MusicManager.Instance != null)
            MusicManager.Instance.UnPauseMusic();
        ButtonSound.Play();
        Cursor.visible = false;
    }




    //Botões do Menu Inicial

    public void IniciarPartida()
    {
        ButtonSound.Play();
        Time.timeScale = 1f;
        Cursor.visible = false;
        TelaInicial.SetActive(false);
        Placar.SetActive(true);

    }

    public void JogarContraIA()
    {
        
        ButtonSound.Play();
        Time.timeScale = 1f;
        Cursor.visible = false;
        TelaInicial.SetActive(false);
        Placar.SetActive(true);
        SceneManager.LoadScene("PongIA");
    }

    public void SairDoJogo()
    {
        ButtonSound.Play();
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }




    //Pontuação de Partida
    public void aumentarPontuacaoJogador1()
    {
        pontuacaoJogador1 += 1;
        AtualizarTextoPontuacao();
    }

    public void aumentarPontuacaoJogador2()
    {
        pontuacaoJogador2 += 1;
        AtualizarTextoPontuacao();
    }

    public void AtualizarTextoPontuacao()
    {
        pontuacao.text = pontuacaoJogador1 + " - " + pontuacaoJogador2;
        SomDeGol.Play();
    }





    //Reiniciar Cena
    private void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


}
