using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestTask.Logic.Presentation.AssetLoaderService
{
    public class AssetLoader : IAssetLoader
    {
        private const int _millisecondsDelay = 400;
        
        private static readonly string[] _atlases = new string[] { "icons_1", "icons_2" };

        private Dictionary<string, Sprite> _iconsSprites;
        
        private readonly Transform _windowsParent;

        public AssetLoader(Transform windowsParent)
        {
            _windowsParent = windowsParent;
            PreloadIcons();
        }

        public Sprite LoadIconSprite(string spriteName) => 
            _iconsSprites[spriteName];

        public Sprite LoadBackground() => 
            LoadLocalResource<Sprite>("background");

        public async Task<T> LoadResourceAsync<T>(string path) where T : Object
        {
            await Task.Delay(_millisecondsDelay);
            T resource = Resources.Load<T>(path);
            return resource;
        }

        public T CreateWindow<T>() where T : Object
        {
            string name = typeof(T).Name;
            T prefab = LoadLocalResource<T>(name);
            T window = Object.Instantiate(prefab, _windowsParent);
            window.name = name;

            return window;
        }

        public T LoadConfig<T>() where T : ScriptableObject => 
            Resources.Load<T>($"Configs/{typeof(T).Name}");

        private void PreloadIcons()
        {
            _iconsSprites = new();
            
            foreach (string atlas in _atlases)
            {
                Sprite[] sprites = Resources.LoadAll<Sprite>($"Images/{atlas}");
                
                foreach (Sprite sprite in sprites)
                    _iconsSprites.Add(sprite.name, sprite);
            }
        }

        private T LoadLocalResource<T>(string path) where T : Object
        {
            // if (path.Contains("background"))
            //     throw new Exception($"[{nameof(AssetLoader)}] Can't load asset with path name = {path}");
            
            var resource = Resources.Load<T>(path);
            return resource;
        }
    }
}