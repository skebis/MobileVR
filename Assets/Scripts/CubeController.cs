using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{

    public float SecondsToDestroy = 3f;
    private float timer = 0;
    Text txt;
    Canvas cnvs;

    // Start is called before the first frame update
    void Start()
    {
        cnvs = GameObject.FindObjectOfType<Canvas>();
        txt = GameObject.FindObjectOfType<Text>();

        txt.text = timer.ToString();
    }

    void Update()
    {
        if (timer > 0)
        {
            txt.text = timer.ToString();
        }

        if (timer >= SecondsToDestroy)
        {
            gameObject.SetActive(false);
            timer = 0;
            txt.text = timer.ToString();
        }
    }

    public void LookAtCube(bool lookAt)
    {
        if (lookAt)
        {
            StartCoroutine(StartCountDown());
        }
        else
        {
            Debug.Log("stopped looking");
            StopAllCoroutines();
            timer = 0;
            txt.text = timer.ToString();
        }
    }

    private IEnumerator StartCountDown()
    {
        while (timer <= SecondsToDestroy)
        {
            Debug.Log("looked at cube. Time: " + timer);

            yield return new WaitForSeconds(1.0f);
            timer++;
        }
    }
}
