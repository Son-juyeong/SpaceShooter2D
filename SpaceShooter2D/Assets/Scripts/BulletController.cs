using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float moveSpeed = 7.5f;

    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (this.transform.position.y >= 5.2f)
            this.DestroyBullet();
    }
    private void DestroyBullet()
    {
        this.gameObject.SetActive(false);
        this.transform.SetParent(BulletPoolManager.instance.transform);
        this.transform.localPosition = Vector2.zero;
    }
}
