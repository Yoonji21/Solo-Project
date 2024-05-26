using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSOEnenmy", menuName = "SO/Enemy/A/B/C")]
public class SOTest : ScriptableObject
{
    public int damage;
    public int hp;
    new public string name;
}
