using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerCountButton : UdonSharpBehaviour
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
    public void CallPlayerCountUp(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, nameof(PlayerCountUp));
    }

    public void PlayerCountUp(){
        Players++;
        RequestSerialization();
    }

    public void CallPlayerCountDown(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, nameof(PlayerCountDown));
    }

    public void PlayerCountDown(){
        Players--;
        RequestSerialization();
    }

}
