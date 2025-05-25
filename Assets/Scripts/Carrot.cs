using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name==("PlayeObject"))
        {
            PlayerMain p = collision.GetComponent<PlayerMain>();
            p.quantityOfCarrots += 1;
            Debug.Log("Has " + p.quantityOfCarrots + " carrots");
        }
    }
}
