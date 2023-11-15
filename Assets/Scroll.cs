using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;//öåëåâàÿ ïîçèöèÿ
    [SerializeField]
    int sensivity = 3;//÷óâñòâèòåëüíîñòü äëÿ âðàùåíèÿ è äâèæåíèÿ
    [SerializeField]
    float scrollSpeed = 10f;//ñêîðîñòü ïðîêðóòêè êîëåñà ìûøè äëÿ èçìåíåíèÿ ïðèáëèæåíèÿ.
    [SerializeField]
    int maxdistance = 20;// ìàêñèìàëüíîå ðàññòîÿíèå îò öåëè.
    [SerializeField]
    int mindistance = 1;// ìèíèàëüíîå ðàññòîÿíèå îò öåëè.


    void Update()
    {//ÂÐÀÙÅÍÈÅ ÂÎÊÐÓÃ ÖÅÍÒÐÀËÜÍÎÉ ÒÎ×ÊÈ ÓÑÒÀÍÎÂÊÈ Ñ ÇÀÆÀÒÎÉ ÏÐÀÂÎÉ ÊËÀÂÈØÈ ÌÛØÈ
        if (Input.GetMouseButton(1))
        {
            float yy = Input.GetAxis("Mouse X") * sensivity;
            Debug.Log(transform.rotation.y);
            if (yy != 0 )
            {
                transform.RotateAround(targetPos.position, Vector3.up, yy); //âðàùåíèå îáúåêòà
            }

        }
        //Ãîðèçîíòàëüíîå è âåðòèêàëüíîå äâèæåíèå êàìåðû
        float x = Input.GetAxis("Horizontal") / sensivity;
        float y = Input.GetAxis("Vertical") / sensivity;// êëàâèøè A, D
        if (x != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(new Vector3(x, 0, 0));

            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }

        if (y != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(new Vector3(0, y, 0));

            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }
        // ÏÐÈÁËÈÆÅÍÈÅ È ÓÄÀËÅÍÈÅ ÊÀÌÅÐÛ Ê ÓÑÒÀÍÎÂÊÅ ÍÀ ÑÖÅÍÅ ÏÐÎÊÐÓÒÊÎÉ ÊÎËÅÑÀ ÌÛØÈ
        float z = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        if(z != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(Vector3.forward * z);
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }


    }
    //   ÎÃÐÀÍÈ×ÅÍÈß ÏÐÅÄÅËÎÂ ÄÂÈÆÅÍÈß ÊÀÌÅÐÛ ÏÎ ÏÎÌÅÙÅÍÈÞ
    private bool ControlDistance(float distance)
    {
        if (distance > mindistance && distance < maxdistance) return true;
        return false;
    }


}
