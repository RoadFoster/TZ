using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public GameObject Boll;
    public GameObject Panel;

    public GameObject StartGame;
    public GameObject Reset;
    public GameObject Exit;

    public Text Timer;
    public GameObject GameOver;

    public double milisec = 0;
    public int sec = 0;
    public int min = 0;
    public double miliscreen;

    private void Awake()
    {
        Time.timeScale = 0;
        milisec = 0;
    }
    private void Start()
    {
        Reset.SetActive(false);
        Exit.SetActive(false);
        GameOver.SetActive(false);
        
    }
    private void Update()
    {
        milisec = milisec + 1 * Time.deltaTime;
        milisec += Time.deltaTime;
        if (miliscreen >= 99)
        {
            miliscreen = 0;
            sec++;
            return;
        }
        if (sec >= 60)
        {
            min++;
            sec = 0;
            return;
        }

        if (milisec >= 0.01 && Time.timeScale == 1)
        {
                miliscreen++;
                milisec = 0;
                return;
        }

        Timer.text = min.ToString() + ":" + sec.ToString() + ":" + miliscreen.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boll")
        {
            Debug.Log("GameOver");
            Reset.SetActive(true);
            Exit.SetActive(true);
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Play()
    {
        StartGame.SetActive(false);
        Time.timeScale = 1;
        Reset.SetActive(false);
        Exit.SetActive(false);
        GameOver.SetActive(false);
    }
    public void reset()
    {
        Play();
        milisec = 0;
        sec = 0;
        min = 0;
        Boll.transform.position = new Vector3(0, 7, 12);
        Boll.transform.rotation = Quaternion.Euler(0, 0, 0);
        Panel.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
