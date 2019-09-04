using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp_Enemy : MonoBehaviour {
    public GameObject Enemy;
    public GameObject SwampEnemy;
    public float SwampTime;
    public float time;
    public float SwampStop;
	// Use this for initialization
	void Start () {
        SwampStop = 125f;
        SwampTime= 5.0f;
        time = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        SwampStop = SwampStop - time * Time.deltaTime;
        SwampTime=SwampTime-time * Time.deltaTime;
		if((SwampStop>=0)&&(SwampTime<=0))
        {
            Instantiate(Enemy, SwampEnemy.transform.position, Quaternion.identity);
            SwampTime = 30f;
        }
        if(SwampStop<=0)
        {
            time = 0;
        }
	}
}
