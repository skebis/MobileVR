using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopHatController : MonoBehaviour
{
    public float SecondsToPickUp = 3f;
    private float timer = 0;
    Text txt;
    Canvas cnvs;

    GameObject player;
    GameObject pCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pCamera = GameObject.FindGameObjectWithTag("MainCamera");

        cnvs = GameObject.FindObjectOfType<Canvas>();
        txt = GameObject.FindObjectOfType<Text>();

        txt.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            txt.text = timer.ToString();
        }

        if (timer >= SecondsToPickUp && (pCamera.transform.Find("TopHat") == null))
        {
            gameObject.transform.parent = pCamera.transform;
            gameObject.transform.position = new Vector3(player.transform.position.x, 13f, player.transform.position.z);
            timer = 0;
            txt.text = timer.ToString();
        }
    }

    public void LookAtHat(bool lookAt)
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
        while (timer <= SecondsToPickUp)
        {
            Debug.Log("looked at hat. Time: " + timer);

            yield return new WaitForSeconds(1.0f);
            timer++;
        }
    }
}
