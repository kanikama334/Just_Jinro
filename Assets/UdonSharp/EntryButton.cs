
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class EntryButton : OriginalUdonSharpBehaviour
{   
    [SerializeField] TextMeshProUGUI text;
    [SerializeField, UdonSynced] int players; 

    public void OnClicked(){
        udonSyncedVariable.players++;
        SerializeRequest();
    }

    void Update(){
        text.text = "players: " + players.ToString();
    }
}
