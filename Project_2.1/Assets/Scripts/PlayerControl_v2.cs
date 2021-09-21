using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl_v2 : MonoBehaviour 
{
    // Функция/метод, выполняемая при запуске игры 
    public Rigidbody2D rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //-v- Для автоматического присваивания в переменную, радиуса коллайдера объекта «GroundCheck»
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        FloorCheckRadius = FloorCheck.GetComponent<CircleCollider2D>().radius;
    }
    // Функция/метод, выполняемая каждый кадр в игре 
    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
        CheckingFloor();
    }
    // Функция/метод для перемещения персонажа по горизонтали
    public Vector2 moveVector;
    public int speed = 1;
    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        if(moveVector.x != 0 && moveVector.y == 0)
            anim.SetBool("Move", true);
        else anim.SetBool("Move", false);
    }
    // Функция/метод для отражения персонажа по горизонтали 
    public bool faceRight = true;
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.Rotate(0f, 180, 0f);
            //transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
    // Функция/метод для прыжка 
    public int jumpForce = 10;
    void Jump()
    {
        if (onGround && !onFloor && Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("IgnoreCollisionOff", 0.25f);
        }

        if ((onGround || onFloor) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Функция/метод для обнаружения земли 
    public bool onGround;
    public bool onFloor;
    public LayerMask Ground;
    public LayerMask Floor;
    public Transform GroundCheck;
    public Transform FloorCheck;
    private float GroundCheckRadius;
    private float FloorCheckRadius;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    void CheckingFloor()
    {
        onFloor = Physics2D.OverlapCircle(FloorCheck.position, FloorCheckRadius, Floor);
        anim.SetBool("onFloor", onFloor);
    }

    private void IgnoreCollisionOff()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

}