using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public List<GameObject> playerList;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        if (playerList.Count > 1)
        {
            Destroy(playerList[1]);
        }
    }
}
