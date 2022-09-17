using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateOrJoinSever : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField joinInput;
    
    public void CreateServer()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinServer()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SpaceDrift");
        DontDestroyOnLoad(this);
    }

    
}


