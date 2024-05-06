using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool transparente =  true; // Indica se est� transparente ou n�o
    public float transparenciaMinima = 0.0f; // Transpar�ncia m�nima
    public float transparenciaMaxima = 1.0f; // Transpar�ncia m�xima

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("O objeto n�o possui um SpriteRenderer!");
            enabled = false; // Desativa este script para evitar erros
        }

        // Define a transpar�ncia inicial minima
        AtualizarTransparencia(transparenciaMinima);
    }

    void Update()
    {
        // Verifica se o jogador pressionou o bot�o Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alterna entre transpar�ncia m�xima e m�nima
            if (transparente)
                AtualizarTransparencia(transparenciaMaxima); // M�xima
            else
                AtualizarTransparencia(transparenciaMinima); // M�nima

            transparente = !transparente; // Inverte o estado de transpar�ncia
        }
    }

    void AtualizarTransparencia(float alpha)
    {
        Color cor = spriteRenderer.color;
        cor.a = Mathf.Clamp01(alpha); // Garante que o valor da transpar�ncia esteja entre 0 e 1
        spriteRenderer.color = cor;
    }
}
