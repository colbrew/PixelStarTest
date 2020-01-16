using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    GameObject target;
    bool rotateToFaceMovingTarget = false;

    public GameObject Target { get => target; set => target = value; }
    public bool RotateToFaceMovingTarget { get => rotateToFaceMovingTarget; set => rotateToFaceMovingTarget = value; }

    private void Awake()
    {
        //Sets rotation target initially to main camera
        Target = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform);
    }

    public void SetTarget(GameObject go)
    {
        Target = go;
    }
}
