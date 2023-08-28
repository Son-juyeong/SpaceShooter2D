using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    private int bulletCount = 10;
    private List<GameObject> bulletList = new List<GameObject>();
    public static BulletPoolManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        for(int i=0;i<bulletCount;i++)
        {
            GameObject bulletGo = Instantiate(bulletPrefab, this.transform);
            bulletList.Add(bulletGo);
            bulletGo.SetActive(false);
        }
    }

    public GameObject GetBulletInPool()
    {
        foreach(GameObject bulletGo in bulletList)
        {
            if (bulletGo.activeSelf == false)
            {
                return bulletGo;
            }
        }
        GameObject bullet = Instantiate(bulletPrefab, this.transform);
        bulletList.Add(bullet);
        return bullet;
    }
}
