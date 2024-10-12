
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class LeaveButton : UdonSharpBehaviour
{
    [SerializeField, UdonSynced] int players;
    [SerializeField] TextMeshProUGUI text;

    void Update(){
        int test = players;
        text.text = test.ToString();
    }

    public void OnClicked(){
        RequestSerialization();
        Debug.Log(players);
    }
}
