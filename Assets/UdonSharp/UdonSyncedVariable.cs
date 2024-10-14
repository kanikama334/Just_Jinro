
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class UdonSyncedVariable : UdonSharpBehaviour
{
    // オーナーにRequestSerializationを呼び出してもらうメソッド
    public void CallRequestSerialization(){
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, nameof(CallRequestSerializationMethod));
    }
    public void CallRequestSerializationMethod(){
        RequestSerialization();
    }
} 
