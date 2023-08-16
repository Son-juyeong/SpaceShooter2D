using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject monsterGo = Instantiate(monsterPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
