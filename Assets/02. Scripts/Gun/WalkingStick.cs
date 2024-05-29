using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingStick : MonoBehaviour
{
    public Stack<GameObject> FireSkillPool = new Stack<GameObject>();
    private GameObject fireObj;
    [SerializeField] private GameObject fireSkillPrefab;
    [SerializeField] private Transform player;

    private void Awake()
    {
        CreatFire();
    }

    private void Update()
    {
        if (UIManager.instance.isActivation == true)
        {
            transform.position = new Vector3(player.position.x + 0.5f, player.position.y, player.position.z);
        }

        if (Input.GetKeyDown(KeyCode.F) && UIManager.instance.isActivation == true)
        {
            fireObj = FireSkillPool.Pop();
            fireObj.SetActive(true);
            fireObj.transform.position = gameObject.transform.position;
        }
    }

    private void CreatFire()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject fire = Instantiate(fireSkillPrefab);
            FireSkillPool.Push(fire);
            fire.SetActive(false);
        }
    }
}
