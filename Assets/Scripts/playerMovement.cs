using UnityEngine;

public class playerMovement : MonoBehaviour
{

    Rigidbody2D rb2d;

    float horizontal;
    float vertical;
    float speed = 20f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 1)
        {
            transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal == -1)
        {
            transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(horizontal, vertical);
        movementVector = Vector2.ClampMagnitude(movementVector, 1f);
        rb2d.linearVelocity = movementVector * speed;
        if (rb2d.linearVelocity != Vector2.zero)
        {
            if (Time.frameCount % 10 == 0)
            {
                audioSource.pitch = Random.Range(0.9f, 1.11f);
                audioSource.Play();
            }
            animator.SetBool("movement", true);
        }
        else
        {
            animator.SetBool("movement", false);
        }
    }
}
