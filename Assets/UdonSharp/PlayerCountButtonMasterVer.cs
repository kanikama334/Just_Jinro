using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerCountButtonMasterVer : UdonSharpBehaviour
{
    [SerializeField] TextMeshProUGUI playerText;

    [UdonSynced, FieldChangeCallback(nameof(Players))] private int _players;

    public int Players{
        get => _players;
        set{
            _players = value;
            // 以下、任意の処理
            playerText.text = "Players: " + _players;
        }
    }

    public void PlayerCountUp(){
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        Players++;
        RequestSerialization();
    }

    public void PlayerCountDown(){
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        Players--;
        RequestSerialization();
    }
}
