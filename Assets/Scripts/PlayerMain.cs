using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    private Vector2 mov = new Vector2(0, 0);

    [SerializeField] private float normalSpeed = 3;
    [SerializeField] private float fastSpeed= 6;
    private float speed;

    private Rigidbody2D rb;

    private int lifePlayer = 0;

    public int quantityOfPumpkins = 0;
    public int quantityOfCarrots = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");
        rb = GetComponent<Rigidbody2D>();
        ChangeLife(100);
        Debug.Log("Life player =" + lifePlayer);
        speed = normalSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {

        Sprint();
        // Movimiento vertical
        MovV();
        // Movimiento horizontal
        MovH();
        //Asignamos la variable que determina la dirección
        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        //Normalizamos el vector
        mov = mov.normalized;
        //Código para mover con transform
        transform.Translate(mov * speed * Time.deltaTime);
        //Código para movimiento con addforce
       // rb.AddForce(mov * speed * Time.fixedDeltaTime);

    }
    private void MovV()
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
    }
    private void MovH()
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

    /*Código para movimiento con velocity
    private void FixedUpdate()
    {
        rb.velocity = mov * speed * Time.fixedDeltaTime;
    }
    */

}
