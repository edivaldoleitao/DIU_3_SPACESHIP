using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool dead = false;
    [SerializeField]public int vida_boss = 100;
    public GameObject projectilePrefab; // Prefab do proj�til a ser disparado
    public float projectileSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            ChangeObjectLayer("explosion_fire", 3);
            ChangeObjectLayer("explosion2", 3);
            Destroy(gameObject, 2f);
        }
        else
        {
            ChangeObjectLayer("explosion_fire", 0);
            ChangeObjectLayer("explosion2", 0);
        }

        if (vida_boss < 0)
            dead = true;
    }
    void ChangeObjectLayer(string objName, int layer)
    {
        GameObject obj = GameObject.Find(objName);
        // Verifica se o objeto foi fornecido
        if (obj != null)
        {
            // Obt�m o componente SpriteRenderer do objeto
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            // Verifica se o objeto tem um componente SpriteRenderer
            if (spriteRenderer != null)
            {
                // Muda a camada do objeto para a camada padr�o (layer 1)
                spriteRenderer.sortingLayerName = "Default";
                spriteRenderer.sortingOrder = layer;
               
            }

        }
    }
    void Shoot()
    {
        // Cria 8 proj�teis e os dispara em 8 dire��es
        for (int i = 0; i < 8; i++)
        {
            // Calcula a dire��o do proj�til
            Vector2 direction = Quaternion.Euler(0, 0, i * 45) * Vector2.right;

            // Cria o proj�til
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Obt�m o componente Rigidbody2D do proj�til
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Define a velocidade do proj�til
            rb.velocity = direction * projectileSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            vida_boss -= 1;
        }
    }
}
