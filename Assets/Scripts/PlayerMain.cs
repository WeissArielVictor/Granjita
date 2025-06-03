using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    private Vector2 mov = new Vector2(0, 0);

    [SerializeField] private float normalSpeed = 100;
    [SerializeField] private float fastSpeed= 200;
    private float speed;

    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private int lifePlayer = 0;

    public int quantityOfPumpkins = 0;
    public int quantityOfCarrots = 0;

    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowSpeed=10;
    [SerializeField] private Vector3 margin = new Vector3(1, 0, 1);
    [SerializeField]private float rotationSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game sputo");
        rb = GetComponent<Rigidbody2D>();
        ChangeLife(100);
        Debug.Log("Life playerssssss =" + lifePlayer);
        speed = normalSpeed;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckWalk();
        //Correr
        Sprint();
        //Disparar flecha
        shoot();
        //Rotación
        rotation();
        // Movimiento vertical
        MovV();
        // Movimiento horizontal
        MovH();
        //Asignamos la variable que determina la dirección
        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        //Normalizamos el vector
        mov = mov.normalized;
        //Código para mover con transform
        //transform.Translate(mov * speed * Time.deltaTime);
        //Código para movimiento con addforce
       // rb.AddForce(mov * speed * Time.fixedDeltaTime);

    }
    private void MovH()
    {
        if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = (-1);
        }
        else { movimientoHorizontal = 0; }
        FlipSprite();
    }
    private void MovV()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movimientoVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimientoVertical = (-1);
        }
        else { movimientoVertical = 0; }
    }
    private void ChangeLife(int a)
    {
        lifePlayer += a;
    }
    private void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = fastSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("PlayerAttack");
            Vector3 posV3 = transform.position;
            GameObject a= Instantiate(arrow, (posV3+margin), transform.rotation);

            Rigidbody2D rbArrow = a.GetComponent<Rigidbody2D>();

            rbArrow.velocity = transform.right * arrowSpeed;

            Destroy(a.gameObject, 2f);
        }
    }
    void rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime * (-1));
        }
    }
    void CheckWalk()
    {
        if (Mathf.Abs(rb.velocity.x)>0||Mathf.Abs(rb.velocity.y)>0)
        {
            animator.SetFloat("xVelocity", 1);
        }
        else
        {
            animator.SetFloat("xVelocity", 0);
        }
    }
    private void FlipSprite()
    {
        if(movimientoHorizontal!=0)
        {
            spriteRenderer.flipX = movimientoHorizontal < 0;
        }
    }
    //Código para movimiento con velocity
    private void FixedUpdate()
    {
        rb.velocity = mov * speed * Time.fixedDeltaTime;
    }

}
