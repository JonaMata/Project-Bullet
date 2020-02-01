using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Transform shooter;
    public float bulletForce;
    bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        transform.right = mousePos - playerPos;

        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            isShooting = true;
            GameObject projectile = Instantiate(bullet);
            projectile.GetComponent<BulletConstroller>().SetPlayer(this.gameObject);
            projectile.transform.position = shooter.position;
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce((mousePos - playerPos).normalized * bulletForce);
        }


        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)/10*moveSpeed;
    }

    public void Teleport(Vector3 position, GameObject bullet)
    {
        transform.position = position;
        isShooting = false;
        Destroy(bullet);
    }
}
