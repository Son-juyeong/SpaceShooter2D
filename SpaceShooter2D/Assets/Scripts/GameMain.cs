using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGo = Instantiate(playerPrefab);
        this.player=playerGo.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        this.player.Move(h, v);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.player.ShootBullet();
        }
    }
}
