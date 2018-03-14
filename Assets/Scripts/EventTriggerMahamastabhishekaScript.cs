using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerMahamastabhishekaScript : EventTrigger {
    

    public override void OnPointerEnter(PointerEventData data)
    {
        MahamastabhishekaScript.SetGazedAtMahamastabhisheka(true);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        MahamastabhishekaScript.SetGazedAtMahamastabhisheka(false);
    }
}
