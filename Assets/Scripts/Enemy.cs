using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public Transform enemies;
    public GameObject bullet;
    public Text winText;
    private float speed;
    private int hardness;
	// Use this for initialization
	void Start ()
    {
        winText.text = "";
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
                    enemies.position += Vector3.down * 0.2f;
            }
        }
        // boss
        if (enemies.childCount == 1)
        {
            CancelInvoke("Run");
            InvokeRepeating("Run", 0.1f, 0.1f);

            foreach (Transform enemy in enemies)
            {
                Renderer[] rrr = enemy.GetComponents<Renderer>();
                foreach (Renderer toChange in rrr)
                {
                    toChange.material.color = Color.red;

                }
            }
            //GameObject enemy = GameObject.FindWithTag("Enemy") as GameObject;
            //foreach(GameObject e in enemy) { }
            //enemy.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            hardness = 30;
        }
        if (enemies.childCount == 0)
        {
            winText.text = "FUCK YOUR LIFE\nYOU WIN";
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
