
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OriginalUdonSharpBehaviour : UdonSharpBehaviour
{
    [SerializeField] public UdonSyncedVariable udonSyncedVariable;

    public void SerializeRequest(){
        udonSyncedVariable.CallRequestSerialization();
    }
}
