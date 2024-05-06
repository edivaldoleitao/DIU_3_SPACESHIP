using UnityEngine;
using UnityEngine.SceneManagement;

public class spaceship : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Animator animator;

    private Vector2 posicaoInicial;
    private bool estado = false;
    public static bool shield = false;
    public static int shieldValue = 3;
    void Start()
    {
        posicaoInicial = transform.position;
        shieldValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Define a animação com base no movimento
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            movement = new Vector2(horizontalInput, verticalInput).normalized;
        }
        else
        {
            movement = Vector2.zero;
         
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            Shoot();
        }
        firingPoint.localRotation = Quaternion.Euler(0, 0, 180f);

        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if (shieldValue > 0)
            {
                shieldValue -= 1;
                LevantarEscudo();
                Invoke("LevantarEscudo", 1f);
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 11f),
            Mathf.Clamp(transform.position.y, -6f, 6f), transform.position.z);
    }

    private void Shoot()
    {
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
    }

    private void LevantarEscudo()
    {
            estado = !estado;
            shield = estado;
            animator.SetBool("Shield", estado);
            animator.SetBool("noShield", !estado);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && shield == false)
        {
            if (Vidas.vidas > 0)
            {
                Respawn();
                LevantarEscudo();
                Invoke("LevantarEscudo", 1f);

            }
            else
            {
                PlayerDied();
            }
        }
    }
    public void PlayerDied()
    {
        // Reinicia a cena
        Score.scoreValue = 0;
        SceneManager.LoadScene("Game_over");
    }

    public void Respawn()
    {
        Vidas.vidas -= 1;
        transform.position = posicaoInicial;
    }
}
