using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldPortal : MonoBehaviour
{
    public string NextScene = "Level1";
    public Animator transition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("e"))
        {
            StartCoroutine(LoadLevel());
        }
    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(NextScene);
    }

}
