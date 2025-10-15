using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetup;


    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorSetup.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }

    public void RandomizeColorsFromSetup(ArtManager.ArtType artType)
    {
        var setup = colorSetup.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++)
        {
            Color randomColor = setup.colors[Random.Range(0, setup.colors.Count)];
            materials[i].SetColor("_Color", randomColor);
        }
    }

}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
