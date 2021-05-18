using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroller : MonoBehaviour
{
    public GameObject[] credits;

    public Animator transition;
    int currentScene;
    private static int swapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        credits = new GameObject[5];
        credits[0] = GameObject.Find("sophiescene");
        credits[1] = GameObject.Find("mimiscene");
        credits[2] = GameObject.Find("codyscene");
        credits[3] = GameObject.Find("konnerscene");
        credits[4] = GameObject.Find("darioscene");

        for (int i = 0; i < 5; i++)
        {
            credits[i].SetActive(false);
        }
        credits[0].SetActive(true);
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Scroll();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Back());
        }
    }

    void Scroll()
    {
        currentScene = swapCount % 5;
        credits[currentScene].SetActive(false);
        swapCount++;
        currentScene = swapCount % 5;
        credits[currentScene].SetActive(true);


    }

    IEnumerator Back()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("MainMenu");
    }
}
