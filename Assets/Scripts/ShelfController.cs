using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfController : MonoBehaviour
{
    public float SecondsToPutDown = 3f;
    private float timer = 0;
    Text txt;
    Canvas cnvs;

    GameObject pCamera;
    GameObject topHatSpawn1;
    GameObject topHatSpawn2;

    // Start is called before the first frame update
    void Start()
    {
        pCamera = GameObject.FindGameObjectWithTag("MainCamera");
        topHatSpawn1 = GameObject.FindGameObjectWithTag("TopHatSpawn1");
        topHatSpawn2 = GameObject.FindGameObjectWithTag("TopHatSpawn2");

        cnvs = GameObject.FindObjectOfType<Canvas>();
        txt = GameObject.FindObjectOfType<Text>();

        txt.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Transform topHat = pCamera.transform.Find("TopHat");
        if (timer > 0)
        {
            txt.text = timer.ToString();
        }

        if (timer >= SecondsToPutDown && (topHat != null))
        {
            if (topHatSpawn1.transform.Find("TopHat") == null)
            {
                topHat.position = topHatSpawn1.transform.position;
                topHat.rotation = Quaternion.identity;
                topHat.parent = topHatSpawn1.transform;
            }
            else
            {
                topHat.position = topHatSpawn2.transform.position;
                topHat.rotation = Quaternion.identity;
                topHat.parent = topHatSpawn2.transform;
            }
            timer = 0;
            txt.text = timer.ToString();
        }
    }

    public void LookAtShelf(bool lookAt)
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
        while (timer <= SecondsToPutDown)
        {
            Debug.Log("looked at shelf. Time: " + timer);

            yield return new WaitForSeconds(1.0f);
            timer++;
        }
    }
}
