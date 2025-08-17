using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // Update is called once per frame
    void Update()
    {
       /* //Player.playerHealth = Player.GetComponent<Movement>().playerHealth;
        while (Player.damageContact())
        {
            StartCoroutine(TakeDamage());
        }*/
    }

    private IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(1f);
        //Player.playerHealth--;
    }
}