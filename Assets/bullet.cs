using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] public float speed = 10f;

    [Range(1, 10)]
    [SerializeField] public float lifetime = 3f;

    [SerializeField] private Rigidbody2D rb;

    GameManager gm;

    // Recarrega a cena atual usando o seu índice
 
    void Start()
    {
        rb.MoveRotation(rb.rotation + 180f);
        Destroy(gameObject, lifetime);
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Score.scoreValue += 1;
            gm.boss = true;
            if (Score.scoreValue > 0 && Score.scoreValue%100 == 0 && Vidas.vidas < 3)
            {
                Vidas.vidas += 1;
                
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
