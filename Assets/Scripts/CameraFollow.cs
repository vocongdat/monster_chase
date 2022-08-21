using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest getRequest = UnityWebRequest.Get("https://pokeapi.co/api/v2/pokemon?limit=2");
        yield return getRequest.SendWebRequest();
        if (getRequest.isNetworkError)
        {
            Debug.Log(getRequest.error);
        }
        else
        {
            Debug.Log(getRequest.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;

        tempPos = transform.position;
        tempPos.x = player.position.x;


        if(tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        transform.position = tempPos;
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }

    
}
