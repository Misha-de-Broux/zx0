using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDataUI : MonoBehaviour {
    [SerializeField]
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start() {
        Load();
    }

    public void Load() {
        PlayerData.Load();
        agent.transform.position = PlayerData.position;
        agent.SetDestination(PlayerData.destination);
    }

    public void Save() {
        PlayerData.position = agent.transform.position;
        PlayerData.destination = agent.destination;
        PlayerData.Save();
    }
}
