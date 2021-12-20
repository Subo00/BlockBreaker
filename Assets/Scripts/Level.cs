using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int _breakableBlocks;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        _breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        _breakableBlocks--;
        if(_breakableBlocks == 0)
        {
            //load next level
            _sceneLoader.LoadNextScene();
        }
    }
}
