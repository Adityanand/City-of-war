using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float MoveSpeed;
    public float ShiftMove;
    public float TurnSpeed;
    public float JumpForce;
    public bool Jump;
    public Transform Bullet;
    public Transform BulletSwamp;
    private Transform shoot;
    public float BulletSpeed;
    public int bulletCount;
    public float BulletFireGap;
    public Text BulletCount;
	// Use this for initialization
	void Start ()
    {
        MoveSpeed = 20.0f;
        ShiftMove = 5.0f;
        TurnSpeed = 15.0f;
        JumpForce = 800.0f;
        BulletSpeed = 100.0f;
        bulletCount = 6;
        BulletFireGap = 0.0f;
        gameObject.GetComponent<Rigidbody>().mass = .025f;
        Jump = false;
   
	}
	
	// Update is called once per frame
	void Update () {
        BulletCount.text = ("BulletRemain:" + bulletCount);
        BulletFireGap -= 1 * Time.deltaTime;
        transform.Rotate(0, TouchControl.playerTurnAxisTouch*TurnSpeed*Time.deltaTime, 0);
        transform.Translate(0, 0, TouchControl.playerMoveAxisTouch * MoveSpeed*Time.deltaTime);
        transform.Translate(TouchControl.playerShiftAxisTouch * ShiftMove*Time.deltaTime,0,0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * ShiftMove * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * ShiftMove * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * TurnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime);
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Rotate(Vector3.left * TurnSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Rotate(-Vector3.left * TurnSpeed * Time.deltaTime);
        //}
        if ((Input.GetKeyDown(KeyCode.Space))&&(Jump==false))
        {
            transform.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce*Time.deltaTime);
            Jump = true;
        }
        if(Input.GetKey(KeyCode.LeftControl)&&(bulletCount>0)&&(BulletFireGap<=0))
        {
            shoot =Instantiate(Bullet,BulletSwamp.transform.position, Quaternion.identity);
            shoot.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
            bulletCount-=1;
            BulletFireGap = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 6;
        }
	}
    void OnCollisionEnter(Collision col)
    {
        GameObject Ground = GameObject.Find("default");
        GameObject mesh = GameObject.Find("mesh");
        GameObject Building = GameObject.Find("bldgs2");
       if((col.collider.gameObject==Ground)||(col.collider.gameObject==Building)||(col.collider.gameObject==mesh))
        {
            Jump = false;
        }
    }
}
