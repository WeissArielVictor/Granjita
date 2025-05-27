using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    public int carneObtenida;
    [SerializeField]
    private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector3 margin = new Vector3(1,0,1);
    [SerializeField] private float rotationSpeed = 1f;

    [SerializeField] public float vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        rotation();
    }

   public void Damaged(int a)
    {
        vida -= a;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 posV3 = transform.position;
           
            GameObject b2 = Instantiate(bullet, (posV3 +margin),
           transform.rotation);//transform.poso
            //o Quaternion.identity
           // Rigidbody2D rbBullet = b2.GetComponent<Rigidbody2D>();
            //rbBullet.velocity = Vector3.right * bulletSpeed;
           // rbBullet.AddForce(transform.right * bulletSpeed);
            // o Vecto2.Right
            //b2.transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
          //  Destroy(b2.gameObject, 2f);
        }
    }

    void rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
       else  if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime * (-1));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("Chocando Pared");
        }
           
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Agarre objeto");
    }

}
