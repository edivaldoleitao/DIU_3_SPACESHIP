using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Score.scoreValue += 10;

            if (Score.scoreValue > 0 && Score.scoreValue % 100 == 0)
            {
                Vidas.vidas += 1;
            }

            if (spaceship.shieldValue < 3)
                spaceship.shieldValue += 1;

            Destroy(gameObject);
        }
    }
}
