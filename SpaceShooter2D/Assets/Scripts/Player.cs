using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private BulletPoolManager bulletGenerator;

    private Transform tr;
    private float moveSpeed = 4f;
    private Animator anim;
    private Coroutine shootCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        this.tr = this.gameObject.GetComponent<Transform>();
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void Move(float h, float v)
    {
        Vector2 pos = (Vector2.right * h) + (Vector2.up * v);
        this.tr.Translate(pos.normalized * moveSpeed * Time.deltaTime);

        this.tr.position = new Vector2(Mathf.Clamp(tr.position.x, -2.3f, 2.3f), Mathf.Clamp(tr.position.y, -4.5f, 4.5f));

        this.anim.SetFloat("Horizontal", h);
    }

    public void ShootBullet()
    {
        if (this.shootCoroutine == null)
            this.shootCoroutine = StartCoroutine(CoShootBullet());
    }

    private IEnumerator CoShootBullet()
    {
        //Debug.LogFormat("<color=blue>player position: {0}</color>", this.tr.position);
        GameObject bulletGo = BulletPoolManager.instance.GetBulletInPool();
        bulletGo.transform.SetParent(null);
        bulletGo.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        shootCoroutine = null;
    }
}
