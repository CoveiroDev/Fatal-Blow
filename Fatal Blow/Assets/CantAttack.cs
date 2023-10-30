using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantAttack : MonoBehaviour
{
    EnemyManager enemyManager;
    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyManager.cantFight = true;
    }
}
