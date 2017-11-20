using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TapManagerEdit : MonoBehaviour,IInputClickHandler{

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    float offset = 0f;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var from = Camera.main.transform.position;
        var to = Camera.main.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(from, to, out hit, 10f))
        {
            if (hit.collider.gameObject.layer == 31)
            {
                var pos = hit.point + hit.normal * offset;
                var rot = Quaternion.LookRotation(hit.normal, Vector3.up);
                Instantiate(prefab, pos, rot, null);
            }
        }
    }
}
