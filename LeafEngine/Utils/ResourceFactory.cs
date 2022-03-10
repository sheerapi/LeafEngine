using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace Leaf
{
    /// <summary>
    /// Used to load and save assets, useful when you don't want to copy everything to bin
    /// </summary>
    public class ResourceFactory
    {
        private static Asset[] Assets = Array.Empty<Asset>();

        /// <summary>
        /// Saves an asset to the assets.res file
        /// </summary>
        /// <param name="assetToSave">The asset to save</param>
        public static void SaveAsset(Asset assetToSave)
        {
            if (File.Exists("assets.res")) Assets = JsonConvert.DeserializeObject<Asset[]>(File.ReadAllText("assets.res"));

            foreach (Asset asset in Assets)
            {
                if (asset.name == assetToSave.name)
                {
                    Logger.Log("Tried to save an asset but an asset with that name already exists, skipping asset...", Logger.LogLevel.Warning);
                    return;
                }
            }

            Array.Resize(ref Assets, Assets.Length + 1);
            Assets[^1] = assetToSave;

            string json = JsonConvert.SerializeObject(Assets, Formatting.Indented);
            File.WriteAllText("assets.res", json);
        }

        /// <summary>
        /// Loads an asset from the asset.res file
        /// </summary>
        /// <param name="name">The name of the asset (Case sensitive)</param>
        /// <returns><see cref="byte"/>[]</returns>
        public static byte[] GetAsset(string name)
        {
            if (!File.Exists("assets.res"))
            {
                Logger.Log("Tried to load an asset, but the assets.res file doesn't exists.", Logger.LogLevel.Error);
                return null;
            }

            Asset[] assets = JsonConvert.DeserializeObject<Asset[]>(File.ReadAllText("assets.res"));
            Asset requiredAsset = null;

            foreach (Asset asset in assets)
            {
                if (asset.name == name)
                {
                    requiredAsset = asset;
                }
            }

            if (requiredAsset == null)
            {
                Logger.Log("Tried to load an asset that doesn't exists.", Logger.LogLevel.Error);
                return null;
            }

            return requiredAsset.value;
        }
    }

    /// <summary>
    /// Class used to manage every kind of file, i.e Fonts, sprites, etc
    /// </summary>
    public class Asset
    {
        public string name { get; set; }

        public byte[] value { get; set; }

        /// <summary>
        /// Creates a new asset with the given properties
        /// </summary>
        /// <param name="Name">The name of the asset</param>
        /// <param name="content">The content of the asset</param>
        public Asset(string Name, byte[] content)
        {
            name = Name;
            value = content;
        }
    }
}
