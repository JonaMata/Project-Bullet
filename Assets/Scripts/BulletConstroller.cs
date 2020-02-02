using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConstroller : MonoBehaviour
{
    public float bulletSpeed;
    public float steerForce;
    GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            player.GetComponent<PlayerController>().Teleport(transform.position, gameObject);
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletPos = new Vector2(transform.position.x, transform.position.y);
        rb.AddForce((mousePos - bulletPos).normalized*steerForce);
        rb.velocity = rb.velocity.normalized * bulletSpeed;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
