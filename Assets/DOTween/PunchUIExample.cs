using UnityEngine;
using DG.Tweening;

public class PunchUIExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        transform.DOPunchScale(Vector3.one*0.2f,0.3f);
    }
}
