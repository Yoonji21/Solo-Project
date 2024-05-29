using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    private float enemyHp = 100f;
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

    private Enemy enemy;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

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

    private void Update()
    {
        
    }
}
