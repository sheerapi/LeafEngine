using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using System.IO;

namespace Leaf
{
    public static class ShaderManager
    {
        public static bool ShadersAvailable { get => Shader.IsAvailable; }

        public static bool GeometryShadersAvailable { get => Shader.IsGeometryAvailable; }

        public enum ShaderType
        {
            Vertex,
            Geometry,
            Fragment
        }

        /// <summary>
        /// Loads a fragment, geometry, or vertex shader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns><see cref="Shader"/></returns>
        /// <exception cref="ShaderException"></exception>
        public static Shader LoadShader(string filename, ShaderType shaderType)
        {
            if (!ShadersAvailable)
            {
                ShaderException exception = new ShaderException("The Shader Manager tried to load a shader, sadly, shaders are NOT available on this machine. Expect ugly game");
                Logger.Log(exception, Logger.LogLevel.Error);
                return null;
            }

            if (!GeometryShadersAvailable && shaderType == ShaderType.Geometry)
            {
                ShaderException exception = new ShaderException("The Shader Manager tried to load a geometry shader, sadly, geometry shaders are NOT available on this machine. Expect ugly game");
                Logger.Log(exception, Logger.LogLevel.Error);
                return null;
            }

            if (!File.Exists(filename))
            {
                ShaderException exception = new ShaderException("The Shader Manager didn't found your shader file in the bin/ folder, are you sure you copied it?");
                Logger.Log(exception, Logger.LogLevel.Error);
                return null;
            }

            switch (shaderType)
            {
                case ShaderType.Vertex:
                    return new Shader(filename, null, null);
                    break;
                case ShaderType.Geometry:
                    return new Shader(null, filename, null);
                    break;
                case ShaderType.Fragment:
                    return new Shader(null, null, filename);
                    break;
            }

            return null;
        }
    }
}
