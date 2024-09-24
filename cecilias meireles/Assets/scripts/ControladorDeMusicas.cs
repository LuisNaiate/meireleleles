using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ControladorDeMusicas : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicas;  // Array com as m�sicas para diferentes cenas.

    private static ControladorDeMusicas instance;
    private int musicaAtualIndex = -1;  // Armazena o �ndice da m�sica que est� tocando.

    void Awake()
    {
        // Verifica se j� existe uma inst�ncia deste controlador e a destr�i se houver outra.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserva este GameObject entre as cenas.
        }
        else
        {
            Destroy(gameObject); // Se j� existe, destr�i o novo para n�o duplicar.
            return;
        }
    }

    void Start()
    {
        // Registrar o m�todo para ser chamado sempre que uma cena for carregada.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Desregistrar o m�todo ao destruir o objeto para evitar problemas de refer�ncia.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // M�todo chamado sempre que uma nova cena � carregada.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TrocarMusica(scene.buildIndex); // Passa o �ndice da cena para o m�todo que troca a m�sica.
    }

    void TrocarMusica(int sceneIndex)
    {
        // Se a m�sica atual j� est� tocando, n�o fa�a nada.
        if (musicaAtualIndex == sceneIndex)
        {
            return;  // A m�sica � a mesma, ent�o n�o trocamos.
        }

        switch (sceneIndex)
        {
            case 0: // Exemplo para a primeira cena.
                audioSource.clip = musicas[0]; // Seleciona a m�sica para a cena 0.
                break;
            case 1: // Exemplo para a segunda cena.
                audioSource.clip = musicas[1]; // Seleciona a m�sica para a cena 1.
                break;
            case 2: // Exemplo para a terceira cena.
                audioSource.clip = musicas[2]; // Seleciona a m�sica para a cena 2.
                break;
            default:
                audioSource.clip = null; // Nenhuma m�sica para cenas n�o especificadas.
                break;
        }

        // Toca a m�sica apenas se for diferente da anterior e n�o for nula.
        if (audioSource.clip != null && audioSource.clip != audioSource.clip)
        {
            musicaAtualIndex = sceneIndex; // Atualiza o �ndice da m�sica atual.
            audioSource.Play();
        }
    }
}
