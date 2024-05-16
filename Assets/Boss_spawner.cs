using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;
    public GameObject boss;
    private int lastScoreValue = 0; // Guarda o valor da pontuação da última verificação
    private bool bossSpawned = false; // Indica se o chefe já foi instanciado

    // Update is called once per frame
    void Update()
    {
        // Verifica se a pontuação mudou e é um múltiplo de 100
        if (Score.scoreValue != lastScoreValue && Score.scoreValue % 100 == 0)
        {
            lastScoreValue = Score.scoreValue; // Atualiza o valor da última pontuação verificada

            // Se o chefe ainda não foi instanciado neste múltiplo de 100
            if (!bossSpawned)
            {
                // Instancia o chefe na posição calculada
                Instantiate(boss, firingPoint.position, firingPoint.rotation);
                bossSpawned = true; // Marca que o chefe foi instanciado
            }
        }
        // Reseta a marcação do chefe se a pontuação não for mais um múltiplo de 100
        else if (Score.scoreValue % 100 != 0)
        {
            bossSpawned = false;
        }
    }
}
