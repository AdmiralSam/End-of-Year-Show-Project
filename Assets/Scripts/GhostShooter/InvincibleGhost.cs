using UnityEngine;

public class InvincibleGhost : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        this.GetComponent<Renderer>().material.color = new Color(102 / 255F, 51 / 255F, 153 / 255F, 1F);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}