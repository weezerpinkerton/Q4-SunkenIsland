using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel("DarioScene"));

    }
    public void LoadCredit()
    {

        StartCoroutine(LoadLevel("CreditScene"));

    }
    public void LoadTutorial()
    {

        StartCoroutine(LoadLevel("TutorialScene"));

    }
    public void LoadMenu()
    {
        StartCoroutine(LoadLevel("MainMenu"));
    }

    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }


}
