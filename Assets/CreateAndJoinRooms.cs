using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerData
{
    public static int number = 0;
    public static bool Master {
        get {
            return number == 0;
        }
    }

    public static int Other {
        get {
            return (number + 1) % 2;
        }
    }
}

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public InputField numberInput;

    public void CreateRoom()
    {
        if (SetNumber())
        {
            PhotonNetwork.CreateRoom(createInput.text);
        }
    }

    public void JoinRoom()
    {
        if (SetNumber())
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("lab3scene");
    }

    private bool SetNumber()
    {
        var txt = numberInput.text;
        var ok = int.TryParse(txt, out int n);
        ok = ok && (n == 0 || n == 1);
        if (ok)
        {
            PlayerData.number = n;
        }
        else
        {
            numberInput.text = "incorrect number!";
        }
        return ok;
    }
}
