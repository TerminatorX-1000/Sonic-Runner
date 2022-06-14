using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public void Attack(int damageAmount)
    {
        PlayerManager.CurrentHealth -= damageAmount;
    }
}