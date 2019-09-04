using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {
    public static int playerTurnAxisTouch = 0;
    public static int playerMoveAxisTouch = 0;
    public static int playerJumpAxisTouch = 0;
    public static int playerFireButtonTouch= 0;
    public static int playerShiftAxisTouch = 0;
    public Player PlayerScript;
    private Transform shoot;
    // Use this for initialization
    void Start () {
        playerTurnAxisTouch = 0;
	}
	public void playerLeftUIPointerDown()
    {
        playerTurnAxisTouch = -1;
    }
    public void playerLeftUIPointerUP()
    {
        playerTurnAxisTouch = 0;
    }
    public void playerRightUIPointerDown()
    {
        playerTurnAxisTouch = 1;
    }
    public void playerRightUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }
    public void playerUpUIPointerDown()
    {
        playerMoveAxisTouch = 1;
    }
    public void playerUpUIPointerUp()
    {
        playerMoveAxisTouch = 0;
    }
    public void playerDownUIPointerDown()
    {
        playerMoveAxisTouch =-1;
    }
    public void playerDownUIPointerUp()
    {
        playerMoveAxisTouch = 0;
    }
    public void playerShiftLeftUIPointerDown()
    {
        playerShiftAxisTouch = -1;
    }
    public void playerShiftLeftUIPointerUp()
    {
        playerShiftAxisTouch = 0;
    }
    public void playerShiftRightUIPointerDown()
    {
        playerShiftAxisTouch = 1;
    }
    public void playerShiftRightUIPointerUp()
    {
        playerShiftAxisTouch = 0;
    }
    public void playerJumpUIPointerDown()
    {
        playerJumpAxisTouch = 1;
        if (PlayerScript.Jump == false)
        {
            transform.GetComponent<Rigidbody>().AddForce(transform.up * PlayerScript.JumpForce * Time.deltaTime);
            PlayerScript.Jump = true;
        }
    }
    public void playerJumpUIPointerUp()
    {
        playerJumpAxisTouch = 0;
    }
    public void playerFireUIPointerDown()
    {
        if ((PlayerScript.bulletCount > 0) && (PlayerScript.BulletFireGap <= 0))
        {
            shoot = Instantiate(PlayerScript.Bullet, PlayerScript.BulletSwamp.transform.position, Quaternion.identity);
            shoot.GetComponent<Rigidbody>().velocity = transform.forward * PlayerScript.BulletSpeed;
            PlayerScript.bulletCount -= 1;
            PlayerScript.BulletFireGap = 1.0f;
        }

    }
    public void Reload()
    {
        PlayerScript.bulletCount = 6;
    }
}
