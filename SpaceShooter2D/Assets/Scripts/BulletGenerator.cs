using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private Coroutine generateCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Generate()
    {
        if (this.generateCoroutine == null)
            this.generateCoroutine = StartCoroutine(CoGenerate());
    }

    private IEnumerator CoGenerate()
    {
        GameObject bulletGo = Instantiate(bulletPrefab);
        yield return new WaitForSeconds(0.1f);
        this.generateCoroutine = null;
    }
}
