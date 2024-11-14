using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] imagens;
    [SerializeField] TextMeshProUGUI textoDePontuacao;
    [SerializeField] TextMeshProUGUI textoDoRelogio;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destr�i o novo objeto se j� existir uma inst�ncia
        }
    }

    // M�todo com retorno: retorna o texto da pontua��o
    public string GetTextoPontuacao()
    {
        return textoDePontuacao.text;
    }

    // M�todo com retorno: retorna o texto do rel�gio
    public string GetTextoRelogio()
    {
        return textoDoRelogio.text;
    }

    public void AtualizarSetas(KeyCode[] setas)
    {
        for (int i = 0; i < imagens.Length; i++)
        {
            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0]; // No seta
            }
            else if (setas[i] == KeyCode.DownArrow)
            {
                imagens[i].sprite = sprites[1];
            }
            else if (setas[i] == KeyCode.UpArrow)
            {
                imagens[i].sprite = sprites[2];
            }
            else if (setas[i] == KeyCode.LeftArrow)
            {
                imagens[i].sprite = sprites[3];
            }
            else if (setas[i] == KeyCode.RightArrow)
            {
                imagens[i].sprite = sprites[4];
            }

            imagens[i].color = Color.white;
        }
    }

    public void AtualizarSeta(int setaSelecionada, bool acertou)
    {
        if (acertou)
        {
            imagens[setaSelecionada].color = Color.green;
        }
        else
        {
            imagens[setaSelecionada].color = Color.red;
        }
    }

    // Atualiza a UI com a pontua��o e o tempo
    public void AtualizarTextos(int pontuacao, float relogio)
    {
        textoDePontuacao.text = pontuacao.ToString();
        textoDoRelogio.text = relogio.ToString();
    }

    // M�todo que retorna o n�mero de setas na tela
    public int GetQuantidadeSetas()
    {
        return imagens.Length;
    }
}

