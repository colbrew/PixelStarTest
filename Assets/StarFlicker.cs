using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StarFlicker : MonoBehaviour
{
    [Tooltip("Set in Inspector")]
    [SerializeField]
    [Range(0, 1)]
    float flickerChance = .4f;

    float randomOffset; //use this so stars don't all flicker in unison

    SpriteRenderer sr;
    Vector4 tempColor;
    
    bool flicker = false;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        randomOffset = Random.value;
        if(Random.value < flickerChance)
        {
            flicker = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flicker)
        {
            FlickerAlpha();
        }
    }

    void FlickerAlpha()
    {
        tempColor = sr.color;
        float x = Mathf.Clamp(Mathf.Cos(Time.timeSinceLevelLoad + randomOffset), 0, 1);
        float y = Mathf.Clamp(Mathf.Sin(Time.timeSinceLevelLoad + randomOffset), 0, 1);
        tempColor.w = Mathf.PerlinNoise(x, y);

        sr.color = tempColor;
    }
}
