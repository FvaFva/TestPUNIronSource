using UnityEngine;
using Photon.Pun;

public class PUNInstantiator : MonoBehaviourPunCallbacks
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _instantiatePosition;

    private void Awake()
    {
        Vector3 spawn = _instantiatePosition.position;
        spawn.x += Random.Range(-7, 8);
        GameObject newCharacter = PhotonNetwork.Instantiate(_prefab.gameObject.name, spawn, Quaternion.identity);
        CharacterSettings settings = (CharacterSettings)PhotonNetwork.LocalPlayer.CustomProperties["Settings"];
        newCharacter.GetComponent<Character>().ApplySettings(settings);
    }
}
