using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int Damage;
    public Text HealthBar;
    public bool CurrentHeatlth=false;
    // Use this for initialization
    void Start()
    {
        Health = 100;
        Damage = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HealthBar.text = ("Health:" + Health);
        if (CurrentHeatlth==true)
        {
            Health=Health- Damage;
            CurrentHeatlth = false;
        }
        if(Health==-10)
        {
            GameObject.Destroy(gameObject);
            GameObject cam = GameObject.Find("Camera");
            cam.GetComponent<Camera>().enabled = true;
            GameObject LevelFailed = GameObject.Find("LevelFailed");
            LevelFailed.GetComponent<Canvas>().enabled = true;
            GameObject Controller = GameObject.Find("Mobile Controller");
            Controller.GetComponent<Canvas>().enabled = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject Ground = GameObject.Find("default");
        GameObject mesh = GameObject.Find("mesh");
        GameObject Building = GameObject.Find("bldgs2");
        if ((collision.collider.gameObject!=Ground)||(collision.collider.gameObject!=Building)||(collision.collider.gameObject!=mesh))
        {
            CurrentHeatlth = true;
        }
        if((collision.collider.gameObject == Ground) || (collision.collider.gameObject == Building) || (collision.collider.gameObject == mesh))
        {
            CurrentHeatlth = false;
        }
    }
}
