using UnityEngine;

public class EndLineColorizer : MonoBehaviour
{
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null && renderer.materials.Length > 0)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            renderer.material = new Material(renderer.material); // força instância
            renderer.material.SetColor("_Color", randomColor);

        }
    }
}
