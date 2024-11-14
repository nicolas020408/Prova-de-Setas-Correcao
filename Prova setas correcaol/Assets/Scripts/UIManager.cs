using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour //
{
    public static UIManager instance;

    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] imagens;
    [SerializeField] TextMeshProUGUI textoDePontuacao;
    [SerializeField] TextMeshProUGUI textoDoRelogio;

    private void Awake()
    {
        instance = this;
    }

    public void AtualizarSetas(KeyCode[] setas)
    {
        for (int i = 0; i < imagens.Length; i++)
        {
            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0];
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

    public void AtualizarTextos(int pontuacao, float relogio)
    {
        textoDePontuacao.text = pontuacao.ToString();
        textoDoRelogio.text = relogio.ToString();
    }
}
