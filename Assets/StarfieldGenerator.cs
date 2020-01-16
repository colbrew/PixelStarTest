using UnityEngine;

public class StarfieldGenerator : MonoBehaviour
{
    [Tooltip("Set in Inspector")]
    [SerializeField] private GameObject star;
    [SerializeField] private int numberOfStars;
    [SerializeField] private float minDistance = 1;
    [SerializeField] private float maxDistance = 1000;
    [SerializeField] private bool rotateToFacePlayer = true;

    private GameObject player;
    GameObject tempInstantiatedObject;

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        for (int i = 0; i < numberOfStars; i++)
        {
            InstantiateRandomObject(star);
        }

    }

    void InstantiateRandomObject(GameObject go)
    {
        Vector3 randomPos = player.transform.position + 
                            (Random.onUnitSphere * Random.Range(minDistance, maxDistance));
        tempInstantiatedObject = Instantiate(go, randomPos, Quaternion.identity); 
        if(rotateToFacePlayer)
        {
            LookAtTarget(tempInstantiatedObject, player);
        }
    }

    // make a looker rotate to face a target
    void LookAtTarget(GameObject looker, GameObject target)
    {
        looker.transform.LookAt(target.transform);
    }
}
