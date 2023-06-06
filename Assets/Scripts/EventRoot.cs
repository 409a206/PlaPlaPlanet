using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {        //이벤트의 종류
    public enum TYPE {
        NONE = -1,          //없음
        ROCKET = 0,         //우주선 수리
        NUM,                //이벤트가 몇 종류 있는지 나타낸다(=1)
    }
}

public class EventRoot : MonoBehaviour
{
    //지정된 게임 오브젝트의 이벤트 타입을 반환한다
    public Event.TYPE getEventType(GameObject event_go) {
        Event.TYPE type = Event.TYPE.NONE;

        if(event_go != null) {      //인수의 게임 오브젝트가 비어 있지 않으면
           if(event_go.tag == "Rocket") {
               type = Event.TYPE.ROCKET;
           }
        }

        return type;
    }

    //이벤트를 실행할 수 있는지 반환
    public bool isEventIgnitable(Item.TYPE carried_item, GameObject event_go) {
        bool ret = false;
        Event.TYPE type = Event.TYPE.NONE;

        if(event_go != null) {
            type = this.getEventType(event_go);         //이벤트 타입을 가져온다
        }

        switch(type) {
            case Event.TYPE.ROCKET : 
                if(carried_item == Item.TYPE.IRON) {    //가지고 있는 것이 철광석이라면
                    ret = true;                         //'이벤트할 수 있어요! ' 라고 응답한다
                }
                if(carried_item == Item.TYPE.PLANT) {   //가지고 있는것이 식물이라면
                    ret = true;                         //'이벤트할 수 있어요! ' 라고 응답한다
                }
                break;
        }
        return ret;
    }

    //이벤트를 실행할 수 있을 때의 메시지를 반환한다
    public string getIgnitableMessage(GameObject event_go) {
        string message = "";
        Event.TYPE type = Event.TYPE.NONE;
        if(event_go != null) {
            type = this.getEventType(event_go);
        } 
        switch(type) {
            case Event.TYPE.ROCKET :
                message = "수리한다";
                break;
        }
        return message;
    }


}
