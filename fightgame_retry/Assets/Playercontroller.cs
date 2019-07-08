using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D rb2d;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Vector3 velocity = Vector3.zero;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 targetVelocity = new Vector2(moveHorizontal * 10f, moveVertical * 10f);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.Play("WalkingLeft");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.Play("Crouch");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.Play("CrouchUp");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play("WalkingRight");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play("Jump");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.Play("Idle");
        }
        if (rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(6, 6, 1);
        }
        else if (rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(-6, 6, 1);
        }




    }
}
