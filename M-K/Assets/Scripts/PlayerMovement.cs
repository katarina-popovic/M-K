using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    private TrailRenderer tr;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasedPerPoint = 0.1f;
    //[SerializeField] float jumpForce = 0.001f;
    //[SerializeField] LayerMask groundMask;
    public int jumpHeight = 7;

    private void FixedUpdate(){
        
        if(!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime ;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (transform.position.y < -5)
        {
            Die();
        }

        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

        /*if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }*/
    }

    public void Die()
    {
        alive = false;

        Invoke("Restart", 2);
        
    }

    void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*void Jump ()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }*/
}
