using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class PUNConnector : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "1";

    [SerializeField] private PlayerSettings _settings;
    [SerializeField] private EnterMenu _enterMenu;
    [SerializeField] private Button _connectBut;
    [SerializeField] private Button _enterGameBut;

    public bool IsConnected {  get; private set; }

    private void Awake()
    {
        PUNSerializationService.Register();
        _connectBut.onClick.AddListener(OnButConnectClick);
        _enterGameBut.onClick.AddListener(EnterRoom);
    }

    private void OnButConnectClick()
    {
        PhotonNetwork.NickName = _settings.Name;
        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.ConnectUsingSettings();
        _enterMenu.ShowNextGUI();
        _enterMenu.ShowLoading();
    }

    public override void OnConnectedToMaster()
    {
        IsConnected = true;
        _enterMenu.HideLoading();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private void EnterRoom()
    {
        _enterMenu.ShowLoading();
        SaveProperties();
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    private void SaveProperties()
    {
        Hashtable myProperties = PhotonNetwork.LocalPlayer.CustomProperties;
        myProperties.Add("Settings", _settings.CharacterSettings);
        PhotonNetwork.LocalPlayer.SetCustomProperties(myProperties);
    }
}
