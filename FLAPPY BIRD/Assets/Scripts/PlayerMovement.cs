using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //get body
    public Rigidbody2D rb;
    //force of jump
    public float jumpForce = 2;
    // click trigger
    public bool isPressed = false;
    //pipes reference
    public PipeMovement pipeMovement;
    public PipeSpawner spawner;
    //GameMenager ref
    public GameMenager gameMenager;

    private void Start()
    {
        //get rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // get jump input
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        // jump when clicked
        if(isPressed)
        {
            Jump();
            isPressed = false;
        }
    }
    //jump function
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    //death on collison
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag =="Pipe")
        {
            Debug.Log("collision");
            Death();
        }
    }
    // turn off bird when die, stop pipes
    public void Death()
    {
        gameMenager.DeathEvents();
        gameObject.SetActive(false);
        Time.timeScale = 0;
        //calls Ui changes
        
    }
}
