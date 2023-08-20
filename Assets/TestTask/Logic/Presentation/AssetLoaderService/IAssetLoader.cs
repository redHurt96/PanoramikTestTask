using UnityEngine;
using Object = UnityEngine.Object;

namespace TestTask.Logic.Presentation.AssetLoaderService
{
    public interface IAssetLoader
    {
        Sprite LoadIconSprite(string spriteName);
        Sprite LoadBackground();
        T CreateWindow<T>() where T : Object;
        T LoadConfig<T>() where T : ScriptableObject;
    }
}