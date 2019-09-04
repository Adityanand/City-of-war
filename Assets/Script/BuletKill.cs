using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletKill : MonoBehaviour {
    public float Timer;
    public bool BulletCollider;
	// Use this for initialization
	public void Start () {
        Timer = 2.0f;
	}
	
	// Update is called once per frame
	public void Update () {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else if (BulletCollider == true)
        {
            GameObject.Destroy(gameObject);
        }
	}
    public void OnCollisionEnter(Collision col)
    {
       BulletCollider = true;
    }
}
