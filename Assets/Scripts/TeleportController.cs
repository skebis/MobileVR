using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
    public float SecondsToTeleport = 3f;
    private float timer = 0;
    Text txt;
    Canvas cnvs;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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

        if (timer >= SecondsToTeleport)
        {
            player.transform.position = new Vector3(gameObject.transform.position.x, 
                player.transform.position.y, gameObject.transform.position.z);
            timer = 0;
            txt.text = timer.ToString();
        }
    }

    public void LookAtTeleport(bool lookAt)
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
        }
    }

    private IEnumerator StartCountDown()
    {
        while (timer <= SecondsToTeleport)
        {
            Debug.Log("looked at teleport. Time: " + timer);

            yield return new WaitForSeconds(1.0f);
            timer++;
        }
    }
}
