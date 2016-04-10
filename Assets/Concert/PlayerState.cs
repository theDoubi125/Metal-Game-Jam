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
        print("Change room : " + currentRoom);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
