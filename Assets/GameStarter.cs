using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public static GameStarter instance;

    public int currentLevel = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
            Destroy(this);


        currentLevel = 0;

        if (PlayerPrefs.HasKey("LevelId"))
        {
            currentLevel = PlayerPrefs.GetInt("LevelId");
        }
        else
        {
            PlayerPrefs.SetInt("LevelId", currentLevel);
        }
        currentLevel = 3;
        if(currentLevel > 4)
        {
            Instantiate(Resources.Load("Level" + currentLevel), new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Resources.Load("Level" + currentLevel), new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void LoadNextLevel()
    {
        LevelPassed();
        SceneManager.LoadScene("GameScene");
    }

    public void LevelPassed()
    {
        if (++currentLevel > 2)
        {
            currentLevel = Random.Range(0, 2);
        }
        PlayerPrefs.SetInt("LevelId", currentLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Fail()
    {
        StartCoroutine(WaitAndActivate(GameManager.instance.RestartButton, 2f));
    }
    
    IEnumerator WaitAndActivate(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(true);
    }
}