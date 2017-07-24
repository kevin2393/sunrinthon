using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float jumpSpeed = 4f;
    public int Jumpset = 0;
    public bool isGrounded = false;
    Rigidbody rb;
    public int Fire = 0, Light = 0, Newcle = 0, Water = 0, Wind = 0, Co2 = 0, Elec = 0;
    public bool fire = false;
    public bool liGht = false;
    public bool newcle = false;
    public bool water = false;
    public bool wind = false;
    public bool co2 = false;
    public bool elec = false;

    public int del;

    public int score;
    public float hp = 100.0f;

    private UICtrl gameUI;

    public Slider sr;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameUI = GameObject.Find("GameUI").GetComponent<UICtrl>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            rb.mass = 4;
            Jumpset = 0;
            if (Fire == 1 && Newcle == 1 && Wind == 1 && Light == 1 && Water == 1 && Elec == 1)
            {
                hp = 100;
                Fire = 0;
                Newcle = 0;
                Light = 0;
                Water = 0;
                Elec = 0;
            }
        }
        if(collision.gameObject.tag == "Death")
        {
            score = gameUI.totScore;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Fire"))
        {
            if (fire)
            {
                LEle();
                Destroy(other.gameObject);
                Fire = 1;
                gameUI.DipScore(1500);
                hp += 13;
            }
        }
        else if (other.gameObject.tag.Equals("Light"))
        {
            if (liGht)
            {
                LEle();
                Destroy(other.gameObject);
                Light = 1;
                gameUI.DipScore(1500);
                hp += 13;
            }
        }
        else if (other.gameObject.tag.Equals("Newcle"))
        {
            if (newcle)
            {
                LEle();
                Destroy(other.gameObject);
                Newcle = 1;
                gameUI.DipScore(1500);
                hp += 13;
            }
        }
        else if (other.gameObject.tag.Equals("Water"))
        {
            if (water)
            {
                LEle();
                Destroy(other.gameObject);
                Water = 1;
                gameUI.DipScore(1500);
                hp += 13;
            }
        }
        else if (other.gameObject.tag.Equals("Wind"))
        {
            if (wind)
            {
                LEle();
                Destroy(other.gameObject);
                Wind = 1;
                gameUI.DipScore(1500);
                hp += 13;
            }
        }
        else if (other.gameObject.tag.Equals("Co2"))
        {
            if (co2)
            {
                LEle();
                Destroy(other.gameObject);
                gameUI.DipScore(-3000);
                hp -= 30;
            }
        }
        else if (other.gameObject.tag.Equals("Elec"))
        {
            if (elec)
            {
                LEle();
                Destroy(other.gameObject);
                Elec = 1;
                gameUI.DipScore(1500);
                hp += 20;
            }
        }
    }
    public void getEle()
    {
        fire = true;
        liGht = true;
        newcle = true;
        wind = true;
        water = true;
        co2 = true;
        elec = true;
    }

    private void LEle()
    {
        fire = false;
        liGht = false;
        newcle = false;
        wind = false;
        water = false;
        co2 = false;
        elec = false;
    }
    public void Jump()
    {
        if (isGrounded)
        {
            if (Jumpset < 2)
            {
                rb.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
                Jumpset++;
            }
        }
        if (Jumpset == 2)
        {
            isGrounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Jumpset < 2)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    rb.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
                    Jumpset++;
                }
            }
        }
        if (Jumpset == 2)
        {
            isGrounded = false;
        }
        gameUI.DipScore(2);
        hp = hp -0.025f;
        sr.value = hp;

        if(hp < 0)
        {
            score = gameUI.totScore;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}