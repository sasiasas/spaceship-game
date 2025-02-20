using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SkyBoxScript : MonoBehaviour
{
    [SerializeField] private List<Material> _skyboxMaterials;
    [SerializeField] private int _currSkyboxIndex = 0;

    private Skybox _skybox;

    private void Awake()
    {
        _skybox = GetComponent<Skybox>();
    }

    private void OnEnable()
    {
        ChangeSkybox(_currSkyboxIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_currSkyboxIndex < _skyboxMaterials.Count)
            {
                _currSkyboxIndex += 1;
                ChangeSkybox(_currSkyboxIndex);
            }
            else
            {
                _currSkyboxIndex = 0;
            }
        }
    }

    private void ChangeSkybox(int index)
    {
        if (_skybox != null && index >= 0 && index < _skyboxMaterials.Count)
        {
            _skybox.material = _skyboxMaterials[index];
        }
    }
}
