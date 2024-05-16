using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;
    public GameObject boss;
    private int lastScoreValue = 0; // Guarda o valor da pontua��o da �ltima verifica��o
    private bool bossSpawned = false; // Indica se o chefe j� foi instanciado

    // Update is called once per frame
    void Update()
    {
        // Verifica se a pontua��o mudou e � um m�ltiplo de 100
        if (Score.scoreValue != lastScoreValue && Score.scoreValue % 100 == 0)
        {
            lastScoreValue = Score.scoreValue; // Atualiza o valor da �ltima pontua��o verificada

            // Se o chefe ainda n�o foi instanciado neste m�ltiplo de 100
            if (!bossSpawned)
            {
                // Instancia o chefe na posi��o calculada
                Instantiate(boss, firingPoint.position, firingPoint.rotation);
                bossSpawned = true; // Marca que o chefe foi instanciado
            }
        }
        // Reseta a marca��o do chefe se a pontua��o n�o for mais um m�ltiplo de 100
        else if (Score.scoreValue % 100 != 0)
        {
            bossSpawned = false;
        }
    }
}
