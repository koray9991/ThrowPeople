using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   public int maxCount;
    public int insideCount;
    public GameObject[] students;
    public bool winBool;
    float timer;
    float finishTimer;
    public GameObject winPanel,failPanel;
    public TextMeshProUGUI stateText;
    public GameObject confetti1, confetti2;
    public float maxTime;
    public float gameTime;
    public Image timeBar;
    public bool fail;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    void Start()
    {
        Time.timeScale = 1;
        gameTime = maxTime;
        timeBar.fillAmount = gameTime / maxTime;
        students = GameObject.FindGameObjectsWithTag("Student");
        maxCount = students.Length;
        stateText.text = insideCount + " / " + maxCount;
    }

   
    void Update()
    {
        gameTime -= Time.deltaTime;
        timeBar.fillAmount = gameTime / maxTime;
        if (gameTime <= 0)
        {
            fail = true;
            failPanel.SetActive(true);
            Time.timeScale = 0;
        }

        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0;
            if(insideCount != maxCount) { finishTimer = 0; }
            insideCount = 0;
            
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].GetComponent<Hip>().inside)
                {
                    insideCount++;
                }

            }
            stateText.text = insideCount + " / " + maxCount;
        }
        if (insideCount == maxCount)
        {
            finishTimer += Time.deltaTime;
            if (finishTimer > 2 && !winBool)
            {
                winBool = true;
                for (int i = 0; i < students.Length; i++)
                {
                    students[i].GetComponent<Hip>().Parent.SetActive(false);
                }
                confetti1.SetActive(true);
                confetti2.SetActive(true);
            }
            if (finishTimer > 4)
            {
                Time.timeScale = 0;
                winPanel.SetActive(true);
            }
        }
       
    }
    public void Buttons(int ButtonNo)
    {
        if (ButtonNo == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (ButtonNo == 2)
        {
           

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
