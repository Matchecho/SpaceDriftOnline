using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector2 SpawnPosition;
    private void Start()
    {                       
        SpawnPosition = new Vector2(SpawnPosition.x, SpawnPosition.y * 1.0f);        
        PhotonNetwork.Instantiate(playerPrefab.name, SpawnPosition, Quaternion.identity);
    }
}
