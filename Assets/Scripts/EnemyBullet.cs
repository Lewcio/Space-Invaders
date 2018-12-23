using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //Score score;
    private Transform bullet;
    public float speed;
    // Use this for initialization
    void Start() {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        bullet.position += Vector3.up * -speed;
        if (bullet.position.y <= -5)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.tag == "Box") {
            GameObject gObject = collision.gameObject;
            Box box = gObject.GetComponent<Box>();
            box.health -= 0.3f;
            //score.minus(100);
            Destroy(gameObject);
        }
    }
}
