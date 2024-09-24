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
    public AudioClip[] musicas;  // Array com as músicas para diferentes cenas.

    private static ControladorDeMusicas instance;
    private int musicaAtualIndex = -1;  // Armazena o índice da música que está tocando.

    void Awake()
    {
        // Verifica se já existe uma instância deste controlador e a destrói se houver outra.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserva este GameObject entre as cenas.
        }
        else
        {
            Destroy(gameObject); // Se já existe, destrói o novo para não duplicar.
            return;
        }
    }

    void Start()
    {
        // Registrar o método para ser chamado sempre que uma cena for carregada.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Desregistrar o método ao destruir o objeto para evitar problemas de referência.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Método chamado sempre que uma nova cena é carregada.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TrocarMusica(scene.buildIndex); // Passa o índice da cena para o método que troca a música.
    }

    void TrocarMusica(int sceneIndex)
    {
        // Se a música atual já está tocando, não faça nada.
        if (musicaAtualIndex == sceneIndex)
        {
            return;  // A música é a mesma, então não trocamos.
        }

        switch (sceneIndex)
        {
            case 0: // Exemplo para a primeira cena.
                audioSource.clip = musicas[0]; // Seleciona a música para a cena 0.
                break;
            case 1: // Exemplo para a segunda cena.
                audioSource.clip = musicas[1]; // Seleciona a música para a cena 1.
                break;
            case 2: // Exemplo para a terceira cena.
                audioSource.clip = musicas[2]; // Seleciona a música para a cena 2.
                break;
            default:
                audioSource.clip = null; // Nenhuma música para cenas não especificadas.
                break;
        }

        // Toca a música apenas se for diferente da anterior e não for nula.
        if (audioSource.clip != null && audioSource.clip != audioSource.clip)
        {
            musicaAtualIndex = sceneIndex; // Atualiza o índice da música atual.
            audioSource.Play();
        }
    }
}
