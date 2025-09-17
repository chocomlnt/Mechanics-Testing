using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, Interactable
{
    private Collider2D interactRange;

    public void Interact()
    {
  
    }

    void Start()
    {
        interactRange = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("in range");
        }
    }
  
}
