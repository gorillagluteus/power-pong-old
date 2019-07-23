using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkedPlayer : MonoBehaviour, IPunObservable {
	public GameObject avatar;
	public Transform playerGlobal;
	public Transform playerLocal;
    // Start is called before the first frame update
    void Start()
    {
		/*
        if (false)//photonView.isMine)
		{
			playerGlobal = GameObject.Find("OVRPlayerController").transform;
			playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
			
			this.transform.SetParent(playerLocal);
		}*/
    }
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
		/*
        if (stream.isWriting)
        {
           
            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
		*/
    }
}
