using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Components")]
    [SerializeField] public GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float movementSpeed = 2f;

    /*[Header("Enemy Layer Detection")]

    [SerializeField] public static LayerMask playerLayer;
    [SerializeField] public static Transform playerCheck;


    public static Transform PlayerCheck
    {
        get { return playerCheck; }
        set { playerCheck = value; }
    }

    public static LayerMask PlayerLayer
    {
        get { return playerLayer; }
        set { playerLayer = value; }
    }*/

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int[] attackTypes = { 1, 2, 3 };
        int randomAttack = attackTypes[UnityEngine.Random.Range(0, attackTypes.Length)];
        if (collision.gameObject.CompareTag("Player"))
        {
            if (randomAttack == 1)
            {
                EnemyType enemyType = new CommonAttack();
                enemyType.Attack();
            }
            if (randomAttack == 2)
            {
                EnemyType enemyType = new MultipleAttacks();
                enemyType.Attack();
            }
        }
    }

    
}


public abstract class EnemyType
{
    public abstract void Attack();
    
}

class CommonAttack : EnemyType
{
    public override void Attack()
    {
        Debug.Log("normie attack!");
    }
}

class MultipleAttacks : EnemyType
{   

    private GameObject player = GameObject.FindGameObjectWithTag("Player");

    //THIS IS SO STUPID ITS ALREADY REFFERENCING THE PLAYER LAYER AND CHECK FROM THE ENEMY SCRIPT BUT UNITY CANT FIND IT WHAAAAT AHAHAHDJDJJS
    //gonna fix next update I swear LOOLOLOL


    /*private LayerMask playerLayer = EnemyScript.PlayerLayer;
    private Transform playerCheck = EnemyScript.PlayerCheck;*/

    /*private bool inRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, 0.6f, playerLayer);
    }*/

    public override void Attack()
    {
        //while (inRange())
        //{
        Debug.Log("multiple attacks!");
        //}

    }
}


   
