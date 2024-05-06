using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool transparente =  true; // Indica se está transparente ou não
    public float transparenciaMinima = 0.0f; // Transparência mínima
    public float transparenciaMaxima = 1.0f; // Transparência máxima

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("O objeto não possui um SpriteRenderer!");
            enabled = false; // Desativa este script para evitar erros
        }

        // Define a transparência inicial minima
        AtualizarTransparencia(transparenciaMinima);
    }

    void Update()
    {
        // Verifica se o jogador pressionou o botão Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alterna entre transparência máxima e mínima
            if (transparente)
                AtualizarTransparencia(transparenciaMaxima); // Máxima
            else
                AtualizarTransparencia(transparenciaMinima); // Mínima

            transparente = !transparente; // Inverte o estado de transparência
        }
    }

    void AtualizarTransparencia(float alpha)
    {
        Color cor = spriteRenderer.color;
        cor.a = Mathf.Clamp01(alpha); // Garante que o valor da transparência esteja entre 0 e 1
        spriteRenderer.color = cor;
    }
}
