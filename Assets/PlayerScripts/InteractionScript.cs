using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionScript : MonoBehaviour, Interactable
{
    private Movement movement;
    LayerMask objectLayers;
    GameObject objectInRange;
    GameObject enemyInRange;


    private void Start()
    {
        movement = GetComponent<Movement>();
        objectLayers = LayerMask.GetMask("item", "enemy");
        objectInRange = GameObject.FindGameObjectWithTag("Item");
        enemyInRange = GameObject.FindGameObjectWithTag("Enemy");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }    
    }

    private void CastVisionLine(float viewDistance)
    {
        Vector2 endPos = transform.position + Vector3.right * viewDistance;
        RaycastHit2D viewLine = Physics2D.Raycast(transform.position, endPos, viewDistance, objectLayers);

        Debug.DrawLine(transform.position, endPos, Color.red);
        if (viewLine.collider != null)
        {
            if (viewLine.collider.CompareTag("Item"))
            {

                Debug.Log("item in range");
            }
            else if (viewLine.collider.CompareTag("Enemy"))
            {

                Debug.Log("enemy in range");
            }
        }
        else
        {
            objectInRange = null;
            enemyInRange = null;
        }
    }

    public void Interact()
    {
        int dir = movement.isFacingRight ? 2 : -2;
        CastVisionLine(dir);
    }
}
