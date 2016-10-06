using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour {
    private int _livesValue;
    private int _scoreValue;
   //private AudioSource _endGameSound;


    // PUBLIC INSTANCE VARIABLES (TESTING) +++++++++

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject plane;
    public GameObject laser;
    public List<GameObject> asteroids;
    public List<GameObject> comets;

    // PUBLIC PROPERTIES +++++++++++++++++++++++++++
    public int LivesValue
    {
        get
        {
            return _livesValue;
        }

        set
        {
            _livesValue = value;
            if (_livesValue <= 0)
            {
                _endGame();
            }
            else
            {
                LivesLabel.text = "Lives: " + _livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return _scoreValue;
        }

        set
        {
            _scoreValue = value;
            ScoreLabel.text = "Score: " + _scoreValue;
        }
    }




    // Use this for initialization
    void Start()
    {
        LivesValue = 5;
        ScoreValue = 0;

        GameOverLabel.gameObject.SetActive(false);
        FinalScoreLabel.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        //laser.gameObject.SetActive(false);


        //_endGameSound = GetComponent<AudioSource>();

            foreach (GameObject asteroid in asteroids)
            {
                Instantiate(asteroid);
            }
           
            foreach (GameObject comet in comets)
            {
                Instantiate(comet);
            }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void _endGame()
    {
        GameOverLabel.gameObject.SetActive(true);
        FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        FinalScoreLabel.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        ScoreLabel.gameObject.SetActive(false);
        LivesLabel.gameObject.SetActive(false);
        plane.SetActive(false);
        setObject(false, asteroids);
        setObject(false, comets);

        //_endGameSound.Play();
    }

    private void setObject(bool set, List<GameObject> obj_list)
    {
        foreach (GameObject obj in obj_list)
        {
            obj.SetActive(set);

        }
    }

    // PUBLIC METHODS ++++++++++++++++++++++++++++++

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("MainScene");
    }
}
