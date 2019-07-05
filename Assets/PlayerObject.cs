using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject PlayerUnitPrefab;

    void Start()
    {
		if(isLocalPlayer == false)
		{
			return;
		}
		else
		{
			CmdSpawnMyUnit();
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    void CmdSpawnMyUnit()
    {
    	GameObject p = Instantiate(PlayerUnitPrefab);
    	NetworkServer.Spawn(p);
    }
}
