using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform enemies;
    public GameObject bullet;
    private float speed;
    private int hardness;
	// Use this for initialization
	void Start () {
        speed = 0.5f;
        hardness = 95;
        InvokeRepeating("Run", 0.1f, 0.8f);
        InvokeRepeating("Shot", 2f, Random.Range(0.1f, 2f));
        enemies = GetComponent<Transform>();
	}

    void Run() {
        enemies.position += Vector3.right * speed;
        foreach (Transform enemy in enemies)
        {
            if (enemy.position.x > 7.5 || enemy.position.x < -7.5)
            {
                speed = -speed;
                if (enemies.position.y > -2.5)
                    enemies.position += Vector3.down * 0.3f;
            }
        }
        // boss
        if (enemies.childCount <= 1)
        {
            CancelInvoke("Run");
            InvokeRepeating("Run", 0.1f, 0.1f);
            enemies.GetChild(0).GetComponent<Renderer>().material.color = Color.cyan;
            print(enemies.GetChild(0).childCount);
            hardness = 1;
        }
    }

    void Shot() {
        foreach (Transform enemy in enemies) {
            if (Random.Range(1, 100) > hardness) {
                Instantiate(bullet, enemy.position, enemy.rotation);
                CancelInvoke("Shot");
                InvokeRepeating("Shot", 0.1f, Random.Range(0.1f, 2f));
            }
        }

    }
}
