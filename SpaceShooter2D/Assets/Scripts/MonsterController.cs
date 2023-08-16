using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public System.Action onDie;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        //onDie();
        Destroy(this.gameObject);
    }
}
