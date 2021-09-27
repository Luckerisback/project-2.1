using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl_v2 : MonoBehaviour 
{
    // Функция/метод, выполняемая при запуске игры 
    public Rigidbody2D rb;
    public Animator anim;
    public bool onGround;
    public bool onFloor;
    public LayerMask Ground;
    public LayerMask Floor;
    public Transform GroundCheck;
    public Transform FloorCheck;
    [SerializeField] private Collider2D collision;
    [SerializeField] private CircleCollider2D groundCheckCollision;
    [SerializeField] private CircleCollider2D floorCheckCollision;
    private float GroundCheckRadius;
    private float FloorCheckRadius;
    // Функция/метод для перемещения персонажа по горизонтали
    public Vector2 moveVector;
    public int speed = 1;
    // Функция/метод для отражения персонажа по горизонтали 
    public bool faceRight = true;
    // Функция/метод для прыжка 
    public int jumpForce = 10;
 
    private void Start()
    {
        //-v- Для автоматического присваивания в переменную, радиуса коллайдера объекта «GroundCheck»
        GroundCheckRadius = groundCheckCollision.radius;
        FloorCheckRadius = floorCheckCollision.radius;
    }
    // Функция/метод, выполняемая каждый кадр в игре 
    private void Update()
    {
        CheckingGround();
        CheckingFloor();
    }
    
    public void Walk(int direction)
    {
        rb.velocity = new Vector2( speed * direction, rb.velocity.y);
    }

    public void SetWalkAnim()
    {
        anim.SetBool("Move", true);
    }

    public void IdleState()
    {
        anim.SetBool("Move", false);
    }
   
    public void Reflect()
    {
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        faceRight = !faceRight;
    }
 
    public void Jump()
    {
        if ((onGround || onFloor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void DownJump()
    {
        if (onGround && !onFloor)
        {
            collision.enabled = false;
            Invoke("IgnoreCollisionOff", 0.25f);
        }
    }

    // Функция/метод для обнаружения земли 
    

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
      
    }

    private  void CheckingFloor()
    {
        onFloor = Physics2D.OverlapCircle(FloorCheck.position, FloorCheckRadius, Floor);
       
    }

    private void IgnoreCollisionOff()
    {
       collision.enabled = true;
    }

}