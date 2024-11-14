using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    int pontos, teclaAtual;
    float relogio;
    KeyCode[] teclas;

    // Singleton
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        GerarSetas();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChecarTecla(KeyCode.DownArrow);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChecarTecla(KeyCode.LeftArrow);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChecarTecla(KeyCode.UpArrow);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChecarTecla(KeyCode.RightArrow);
        }

        ContagemRegressiva();
    }

    // Método com retorno para obter os pontos
    public int GetPontos()
    {
        return pontos;
    }

    // Método com retorno para obter o tempo restante
    public float GetRelogio()
    {
        return relogio;
    }

    void ContagemRegressiva()
    {
        relogio -= Time.deltaTime;

        // Atualiza os textos na UI através do Singleton da UIManager
        UIManager.Instance.AtualizarTextos(pontos, relogio);

        if (relogio <= 0)
        {
            pontos -= teclas.Length - teclaAtual;
            GerarSetas();
        }
    }

    void GerarSetas()
    {
        teclaAtual = 0;
        teclas = new KeyCode[Random.Range(5, 15)];

        for (int i = 0; i < teclas.Length; i++)
        {
            teclas[i] = (KeyCode)Random.Range(273, 276); // Gera teclas aleatórias de seta
        }

        relogio = teclas.Length / 2;
        UIManager.Instance.AtualizarSetas(teclas);
    }

    void ChecarTecla(KeyCode teclaPressionada)
    {
        if (teclaPressionada == teclas[teclaAtual])
        {
            pontos++;
            UIManager.Instance.AtualizarSeta(teclaAtual, true);
        }
        else
        {
            pontos--;
            relogio--;
            UIManager.Instance.AtualizarSeta(teclaAtual, false);
        }

        UIManager.Instance.AtualizarTextos(pontos, relogio);

        teclaAtual++;
        if (teclaAtual == teclas.Length)
        {
            GerarSetas();
        }
    }
}

