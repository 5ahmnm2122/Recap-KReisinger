using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject target;
    public Camera cam;
    RaycastHit hit;
    private float canvWidth;
    private float canvHeight;
    public int score = 0;
    private GameObject targetObj = null;
    public float timer =0;
    public Text scoreTxt;

    void Start()
    {
        RecapEvents.current.onTargetHit += TargetHitFunc;
        RectTransform canvRect = canvas.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvWidth = canvRect.rect.width;
        canvHeight = canvRect.rect.height;
        Debug.Log(canvHeight + "   " + canvWidth);
        SpawnTarget();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2) {
            SpawnTarget();
        }
    }
 

    public void SpawnTarget() 
    {
        Destroy(targetObj);
        Debug.Log("Spawn");
        var screenPoint = new  Vector3 (Random.Range(0, canvWidth),Random.Range(0, canvHeight), 50);
        var worldPos = cam.ScreenToWorldPoint ( screenPoint );
        var obj = Instantiate( target, worldPos, Quaternion.identity );
        obj.transform.parent = canvas.transform;
        targetObj = obj;
        timer = 0;
    }

    public void TargetHitFunc() 
    {
        score++;
        scoreTxt.text = score.ToString(); 
        SpawnTarget();
    }


}
