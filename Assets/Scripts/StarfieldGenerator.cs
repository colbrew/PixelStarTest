using UnityEngine;

public class StarfieldGenerator : MonoBehaviour
{
    [Tooltip("Set in Inspector")]
    [SerializeField] private GameObject star;
    [SerializeField] private int numberOfStars;
    [SerializeField] private float minStarDistance = 1;
    [SerializeField] private float maxStarDistance = 1000;
    [SerializeField] private bool rotateToFacePlayer = true;

    private GameObject player;
    private GameObject tempStar;

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        for (int i = 0; i < numberOfStars; i++)
        {
            InstantiateRandomLocationInSpace(star);
        }
    }

    void InstantiateRandomLocationInSpace(GameObject go)
    {
        Vector3 randomPos = player.transform.position + 
                            (Random.onUnitSphere * Random.Range(minStarDistance, maxStarDistance));
        tempStar = Instantiate(go, randomPos, Quaternion.identity, this.transform); 
        if(rotateToFacePlayer)
        {
            LookAtTarget(tempStar, player);
        }
    }

    // make an instantiated star rotate to face a target
    void LookAtTarget(GameObject star, GameObject target)
    {
        star.transform.LookAt(target.transform);
    }
}
