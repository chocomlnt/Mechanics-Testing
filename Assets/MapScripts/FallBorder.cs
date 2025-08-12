using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FallBorder : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPoint;

    // Update is called once per frame
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }
    private void OnTriggerExit2D(Collider2D other)
        {      
            
            if (other.gameObject.CompareTag("Player"))
        {
            // Reset player position to the start point
            player.transform.position = new Vector3(0, 10, 0); // Adjust the position as needed

        }
            }
        }
    

