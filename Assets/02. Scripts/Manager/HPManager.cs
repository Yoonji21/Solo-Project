using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    private float enemyHp;
    public float EnemyHp
    {
        get
        {
            return enemyHp;
        }
        set
        {
            enemyHp = value;
        }
    }
    [SerializeField] private GameObject enemyPrefab;

    //public static HPManager instance = null;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public void Damage(float damage)
    {
        enemyHp -= damage;
        print($"АјАн {enemyHp}");
    }

    private void Update()
    {
        if (enemyHp < 1)
        {
            enemyPrefab.SetActive(false);
        }
    }
}
