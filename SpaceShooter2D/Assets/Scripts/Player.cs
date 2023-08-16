using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private BulletGenerator bulletGenerator;

    private Transform tr;
    private float moveSpeed = 4f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        this.tr = this.gameObject.GetComponent<Transform>();
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log(h);
        float v = Input.GetAxisRaw("Vertical");

        Vector2 pos = (Vector2.right * h) + (Vector2.up * v);
        this.tr.Translate(pos.normalized * moveSpeed * Time.deltaTime);

        this.tr.position = new Vector2(Mathf.Clamp(tr.position.x, -2.3f, 2.3f), Mathf.Clamp(tr.position.y, -4.5f, 4.5f));

        this.anim.SetFloat("Horizontal", h);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletGenerator.Generate();
        }
    }
}
