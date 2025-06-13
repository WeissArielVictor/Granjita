using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomberito : MonoBehaviour
{
    [SerializeField] private int life = 100;
    [SerializeField] private GlobalTimer tm;
    private bool enragePomberito;

    public Transform target; //El objetivo al cual se moverá
    public float speed = 2f; //Velocidad de npc
    public float detectionRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance<detectionRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        /*if(!enragePomberito && tm.timeToFinish<=5)
        {
            enragePomberito = true;
            Debug.Log("Pomberito is enrage");
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            gameObject.SetActive(false);
        }
    }

}
