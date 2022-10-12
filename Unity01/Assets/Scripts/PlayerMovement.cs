using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float speed;

    private float direction;
    private bool isGrounded;
    private bool facingRight = true;


    //int nummer;
    //float kommatal;
    // Denne metode kaldes netop en gang .. ved opstart
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        direction = Input.GetAxis("Horizontal"); //Left = -1 .. Right = +1

        rb.velocity = new Vector2(direction *speed, rb.velocity.y);

        // Hvis Jump (space) er installeret så ændre ridgidBody y-velocity..

        if (Input.GetButtonDown("Jump") && isGrounded == true )
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            anim.SetBool("IsJumping", true);
        }

        //Går mod højre
        if (direction > 0 && facingRight == false)
            Flip();
        {
            //Flip sprite 
        }
        //Går mod venstre?
        if (direction < 0 && facingRight == true)
            Flip();

        if (direction < 0) 
        {
            //Flip Sprite
            anim.SetBool("IsRunning", true);
        }
       
         else if (direction > 0) 
        { 
          anim.SetBool("IsRunning", true);
        }
         else if (direction == 0) 
        {
          anim.SetBool("IsRunning", false);
        }
        
    }

    private void Flip()
    {
        Vector3 current = gameObject.transform.localScale;
        current.x = current.x * -1;
        
        gameObject.transform.localScale = current;
        facingRight = !facingRight;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            anim.SetBool("IsJumping", false);

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;

        }
    }
    
}