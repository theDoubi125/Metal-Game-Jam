using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {


    public enum EnumRooms :int { Parking, Concert, Reserve }

    public EnumRooms currentRoom = EnumRooms.Parking;

    public int bombeState = 0;


    bool isInConcert()
    {
        return currentRoom == EnumRooms.Concert;
    }


    public void setRoom(EnumRooms room)
    {
        if (currentRoom == room) return;
        currentRoom = room;
        changeRoomEvent();
    }

    void changeRoomEvent()
    {
        print("Change room : " + currentRoom+" "+ bombeState);
        bombeState++;

        SetTelephoneTextDependingOnBombeState();

        if (!TelephoneBehaviour.instance.isTelephoneVisible() && (currentRoom == EnumRooms.Parking || currentRoom == EnumRooms.Reserve))
            TelephoneBehaviour.instance.InitMovePhone();
    }


    void SetTelephoneTextDependingOnBombeState()
    {
        switch (bombeState)
        {
            case 1:
                TelephoneBehaviour.SetTelephoneText("Bonjour Agent 118 218, calmez vous, essayez de trouver la bombe", isInConcert());
                break;
            case 2:
                TelephoneBehaviour.SetTelephoneText("Omg !! Vs êtes tomB sur la nouveL génération du willi waller 2016. Vous devez absolument résoudre cette énigme et ne rien tenter d’autre.", isInConcert());
                break;
            case 3:
                TelephoneBehaviour.SetTelephoneText("", isInConcert());
                break;
        }

    }
            




    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
