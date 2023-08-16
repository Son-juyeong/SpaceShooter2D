using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private float moveSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 position = player.transform.position;
        position += Vector3.up*0.7f;
        this.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (this.transform.position.y >= 5.2f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterController monsterController = collision.GetComponent<MonsterController>();
        if (monsterController != null)
        {
            StartCoroutine(CoAttack(monsterController));
        }
    }

    private IEnumerator CoAttack(MonsterController target)
    {
        target.Die();
        yield return null;
        Destroy(this.gameObject);
    }
}
