using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private Camera cam;

    private float canvWidth;
    private float canvHeight;
    private float timer = 0;
    private int score = 0;
    private GameObject targetObj = null;

    private float margin = 100f;

    void Start()
    {
        // Triggered by Target
        RecapEvents.current.onTargetHit += TargetHitFunc;
        RectTransform canvRect = canvas.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvWidth = canvRect.rect.width;
        canvHeight = canvRect.rect.height;
        SpawnTarget();
    }


    void Update()
    {
        if(score < 10)  
        {
            timer += Time.deltaTime;
            if(timer > 2) 
            {
                SpawnTarget();
            }
        }
    }
 
    public void SpawnTarget() 
    {
        Destroy(targetObj);
        var screenPoint = new  Vector3 (Random.Range(margin, canvWidth - margin),Random.Range(margin, canvHeight - margin), 50);
        var worldPos = cam.ScreenToWorldPoint ( screenPoint );
        var obj = Instantiate( target, worldPos, Quaternion.identity );
        obj.transform.SetParent(canvas.transform);

        targetObj = obj;
        timer = 0;
    }

    public void TargetHitFunc() 
    {
        score++;
        scoreTxt.text = score.ToString();
        if(score < 10) { 
            SpawnTarget();
        } else {
            winText.gameObject.active = true;
        }
    }
}
