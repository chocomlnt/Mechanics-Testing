using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Components")]

    [SerializeField] private GameObject enemy;
    [SerializeField] private float movementSpeed = 2f;
     
    public void OnCollisionEnter2D(Collision2D collision)
    {
        int[] attackTypes = { 1, 2, 3, 4, 5 };
        int randomAttack = attackTypes[UnityEngine.Random.Range(0, attackTypes.Length)];
        if (collision.gameObject.CompareTag("Player"))
        {
            if (randomAttack == 1 || randomAttack == 3 || randomAttack == 4 || randomAttack == 5)
            {
                EnemyType enemyType = new CommonAttack();
                enemyType.Attack();
            }
            if (randomAttack == 2)
            {
                EnemyType enemyType = new SpecialAttack();
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

class SpecialAttack : EnemyType
{
    
    private GameObject player = GameObject.FindGameObjectWithTag("Player");
    private bool OnCollisionEnter2D(Collision2D collision)
    {
        return true;
    }

    public override void Attack()
    {   
        int attackCount = 0;
        while (OnCollisionEnter2D(new Collision2D()) && attackCount < 3)
        {
            attackCount++;
            Debug.Log("multiple attacks!");
            
        }
    }
}


   
