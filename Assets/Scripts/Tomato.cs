using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    [SerializeField] private float respawnTime = 5f;
    [SerializeField] private string itemName = "tomato";

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMain player = collision.GetComponent<PlayerMain>();
            if (player != null)
            {
                player.AddToInventory(itemName);
                player.StartVegetableRespawn(gameObject, respawnTime);
                gameObject.SetActive(false);
            }
        }
    }

}
