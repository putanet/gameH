using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviour {

    public int score;
    public float timeLeft = 60;
    public GameObject timeUI;
    public GameObject scoreUI;
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text=""+(int)timeLeft;
        scoreUI.gameObject.GetComponent<Text>().text= "" + score;
        if (timeLeft<0.1f)
        {
            //GameOver
            Application.LoadLevel("Home");
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Coin")
        {
            score += 10;
            Destroy(other.gameObject); //ลบเหรียญทิ้ง
        }
    }
}