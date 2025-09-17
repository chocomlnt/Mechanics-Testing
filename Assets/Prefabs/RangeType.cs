using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class RangeType : MonoBehaviour
{
    [Header("Range Attack Variables")]
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private int attackLimit = 3;
    int attackCount;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        while (attackCount < attackLimit)
        {
            attackCount++;
            int[] attackTypes = { 1, 2, 3, 4, 5 };
            int randomAttack = attackTypes[UnityEngine.Random.Range(0, attackTypes.Length)];
            yield return new WaitForSeconds(0.8f);
            
                if (randomAttack == 1 || randomAttack == 3 || randomAttack == 4 || randomAttack == 5)
                {
                    RangeAttack rangeAttack = new NormalRangedAttack();
                    rangeAttack.Attack();
                }
                if (randomAttack == 2)
                {
                    RangeAttack specialRangeAttack = new SpecialRangedAttack();
                    specialRangeAttack.Attack();
                }
            
            attackCount = 0;
        }
    }
}

public abstract class RangeAttack
{
    public abstract void Attack();
}

public class NormalRangedAttack : RangeAttack
{
    public override void Attack()
    {
        Debug.Log("Normal ranged attack!");
    }
}

public class SpecialRangedAttack : RangeAttack
{
    public override void Attack()
    {
        Debug.Log("Speciakl ranged attack!");
    }
}
