using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class PowerPongNetworkDiscovery : NetworkDiscovery
{
	private float timeout = 5f;
	private Dictionary<LanConnectionInfo, float> lanAddresses = new Dictionary<LanConnectionInfo, float>(); 
    // Start is called before the first frame update
    private void Awake()
    {
        base.Initialize();
        base.StartAsClient();
        StartCoroutine(CleanupExpiredEntries());
    }
    public void StartBroadcast()
    {
    	StopBroadcast();
    	base.Initialize();
    	base.StartAsServer();
    }
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
    	base.OnReceivedBroadcast(fromAddress, data);
    	LanConnectionInfo info = new LanConnectionInfo(fromAddress, data);
    	if(lanAddresses.ContainsKey(info) == false)
    	{
    		lanAddresses.Add(info, Time.time + timeout);
    		UpdateMatchInfos();
    	}
    	else
    	{
    		lanAddresses[info] = Time.time + timeout;
    	}
    }
    private IEnumerator CleanupExpiredEntries()
    {
    	while(true)
    	{
    		bool changed = false;
    		var keys = lanAddresses.Keys.ToList();
    		foreach (var key in keys)
    		{
    			if(lanAddresses[key] < Time.time)
    			{
    				lanAddresses.Remove(key);
    				changed = true;
    			}
    		}
    		if(changed)
    		{
    			UpdateMatchInfos();
    		}
    		yield return new WaitForSeconds(timeout);
    	}
    }
    private void UpdateMatchInfos()
    {
    	//GameListController.AddLanMatches(lanAddresses.Keys.ToList());
    }
}
public struct LanConnectionInfo
{
	public string ipAddress;
	public int port;
	public string name;

	public LanConnectionInfo(string fromAddress, string data)
	{
		ipAddress = fromAddress.Substring(fromAddress.LastIndexOf(":") + 1, fromAddress.Length - (fromAddress.LastIndexOf(":") + 1));
		string portText = data.Substring(data.LastIndexOf(":")+1, data.Length - (data.LastIndexOf(":") + 1));
		port = 7777;
		int.TryParse(portText, out port);
		name = "local";
	}
}