using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConstroller : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            player.GetComponent<PlayerController>().Teleport(transform.position, gameObject);
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
