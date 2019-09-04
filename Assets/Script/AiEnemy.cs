using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AiEnemy : MonoBehaviour
{
    string state = "Patrol";
    public static int EnemyRemaining=-1;
    int CurrentWayPoint = 0;
    public float time;
    public float TurningSped;
    public float MovementSpeed;
    public float accuracyWayPoint;
    public float BulletSpeed;
    public GameObject[] WayPoints;
    public Transform Bullet;
    public Transform BulletSwamp;
    private Transform shoot;
    private Vector3 direction;
    public int Health;
    public int Damage;
    public bool CurrentHealth;
    public Swamp_Enemy Enemy;
    public Text EnemyRemain;
    // Use this for initialization
    void Start()
    {
        
        EnemyRemaining += 1;
        TurningSped = 4.0f;
        MovementSpeed = 10.0f;
        accuracyWayPoint = 1.0f;
        BulletSpeed = 50.0f;
        time = 1.0f;
        Health = 100;
        Damage = 50;
    }

    // Update is called once per frame
    void Update() {
        GameObject Player = GameObject.Find("vanquish");
        direction = Player.transform.position - this.transform.position;
        direction.y = 0;
        if ((state == "Patrol") && (WayPoints.Length > 0))
        {
            if (Vector3.Distance(WayPoints[CurrentWayPoint].transform.position, transform.position) < (accuracyWayPoint))
            {
                CurrentWayPoint++;
                if (CurrentWayPoint >= WayPoints.Length)
                {
                    CurrentWayPoint = 0;
                }
            }
            direction = WayPoints[CurrentWayPoint].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurningSped * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * MovementSpeed);
        }
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 100 || (state == "Pursuing"))
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), TurningSped * Time.deltaTime);
            if (direction.magnitude > 50)
            {
                this.transform.Translate(0, 0, Time.deltaTime * MovementSpeed);
            }
            else
            {
                time--;
                Attack();
            }
        }
        else
        {
            state = "Patrol";
        }
        EnemyRemain.text = ("EnemyRemaining: " + EnemyRemaining);
        if((EnemyRemaining<=0)&&(Enemy.SwampStop<=0))
        {
            GameObject Vanquish = GameObject.Find("vanquish");
            Vanquish.SetActive(false);
            GameObject MobileController = GameObject.Find("Mobile Controller");
            MobileController.GetComponent<Canvas>().enabled = false;
            GameObject Cam = GameObject.Find("Camera");
            Cam.GetComponent<Camera>().enabled = true;
            GameObject LevelWin = GameObject.Find("Level Win");
            LevelWin.GetComponent<Canvas>().enabled = true;
        }
    }
    public void Attack()
    {
        if ((time <= 0.0f)&&(direction.magnitude > 15))
        {
            shoot = Instantiate(Bullet, BulletSwamp.transform.position, Quaternion.identity);
            shoot.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
            time = 20.0f;
            time--;

        }
    }
    public void FixedUpdate()
    {
        if (CurrentHealth == true)
        {
            Health = Health - Damage;
            CurrentHealth = false;
        }
        if(Health==0)
        {
            GameObject.Destroy(gameObject);
            EnemyRemaining -= 1;
        }

    }
    public void OnCollisionEnter(Collision col)
    {
        GameObject Ground = GameObject.Find("default");
        GameObject mesh = GameObject.Find("mesh");
        GameObject Building = GameObject.Find("bldgs2");
        //GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if ((col.collider.gameObject!=Ground)||(col.collider.gameObject!=mesh)||(col.collider.gameObject!=Building)||(col.gameObject.tag=="enemy"))
        {
            CurrentHealth = true;
        }
        if ((col.collider.gameObject == Ground) || (col.collider.gameObject == Building) || (col.collider.gameObject == mesh))
        {
            CurrentHealth = false;
        }
    }
}
