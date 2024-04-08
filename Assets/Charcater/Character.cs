using Photon.Pun;
using UnityEngine;

[RequireComponent (typeof(PhotonView))]
public class Character : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    private Material _myMaterial;
    private PhotonView _view;

    private void Awake()
    {
        _myMaterial = _renderer.material;
        _view = GetComponent<PhotonView>();
    }

    public void ApplySettings(CharacterSettings settings)
    {
        if(_view.IsMine)
        {
            _view.RPC("SetPlayerSettingsRPC", RpcTarget.AllBuffered, settings);
        }

        SetMySettings(settings);
    }

    [PunRPC]
    public void SetPlayerSettingsRPC(CharacterSettings settings)
    {
        SetMySettings(settings);
    }

    private void SetMySettings(CharacterSettings settings)
    {
        _myMaterial.color = settings.Color;
        transform.localScale = settings.Scale;
    }
}
