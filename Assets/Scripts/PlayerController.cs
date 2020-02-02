using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    public SpriteAtlas CharacterAtlas;   
    public float moveSpeed;
    public GameObject bullet;
    public Transform shooter;
    public float bulletForce;
    SpriteRenderer sr;
    bool isShooting = false;
    Sprite[] sprites;
    int spriteIndex = 0;
    int counter = 0;
    int maxCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sprites = new Sprite[CharacterAtlas.spriteCount];
        CharacterAtlas.GetSprites(sprites);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        
        float angle = Vector2.Angle(Vector2.up, (mousePos - playerPos));
        if (mousePos.x < playerPos.x) angle = 360-angle;
        float angleStep = (360 / 8);
        int anglePos = (int) ((angle - angleStep / 2) / angleStep);
        Debug.Log(anglePos);
        switch(anglePos)
        {
            case 0:
                sr.sprite = sprites[2];
                sr.flipX = false;
                break;
            case 1:
                sr.sprite = sprites[3];
                sr.flipX = false;
                break;
            case 2:
                sr.sprite = sprites[0];
                sr.flipX = false;
                break;
            case 3:
                sr.sprite = sprites[1];
                sr.flipX = false;
                break;
            case 4:
                sr.sprite = sprites[0];
                sr.flipX = true;
                break;
            case 5:
                sr.sprite = sprites[3];
                sr.flipX = true;
                break;
            case 6:
                sr.sprite = sprites[2];
                sr.flipX = true;
                break;
            case 7:
                sr.sprite = sprites[4];
                sr.flipX = false;
                break;
        }

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
