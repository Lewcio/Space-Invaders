using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform bullet;
    public float speed;
	// Use this for initialization
	void Start () {
        bullet = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        bullet.position += Vector3.up * speed;
        if (bullet.position.y >= 5)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // add points
        } else if (collision.tag == "Box") {
            GameObject gObject = collision.gameObject;
            Box box = gObject.GetComponent<Box>();
            box.health -= 0.3f;
            Destroy(gameObject);
        }
    }
}
