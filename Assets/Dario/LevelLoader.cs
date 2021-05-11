using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public string scene = "DarioScene";
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel());

    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

}
