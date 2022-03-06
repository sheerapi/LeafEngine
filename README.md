# Leaf
A C# based game engine

## Introduction
Leaf is a 2D game engine, made with C# and the [Simple and Fast Multimedia Library](https://www.sfml-dev.org).

Leaf is just a "code shortener" so it might have some SFML references somewhere.

## What offers Leaf?
Leaf offers:
- A scene system
- Audio Players!
- Graphic Rendering
- Shape Rendering (Circles and Polygons)
- Input System
- Logger System (even with pretty colors)
- Time System
- PlayerPrefs System (so you can save and load player settings in runtime!)

## To-do
There's a huge "list" of things left yet, such as:
- Making the renderer so it can render more than 1 object at the same time
- Stop the camera from flicking randomly
- Make the audio system more fluid
- Physics system (Box2D for C#)
- Resource loader and saver (Encrypting and Decrypting files)

## FAQ
### When i try to play an .mp3 file it doesn't play
This is a extract from the [SFML](https://www.sfml-dev.org) docs.
> SFML supports the audio file formats WAV, OGG/Vorbis and FLAC. Due to licensing issues MP3 is **not supported**.
### When i try to render two or more sprites, it spams "Failed to activate the OpenGL context"
Due to limitations (Knowledge limitations), i couldn't get Leaf to render two or more sprites/shapes, but i'm working on it, it's first priority on the To-Do list.

## Building
Building Leaf is as simple as:
- Downloading the source code
- Opening it in Visual Studio
- Pressing "Build"

Simple, isn't it?

Now, how i clone the repo?

You have three ways to do it:
#### Browser Way:
Head to the repo site, then press "Code", then "Download ZIP"

#### GitHub CLI Way:
Open your terminal and type:
```
gh repo clone sheerapi/LeafEngine
```

#### Git Way:
Open your terminal (again) and type:
```
git clone https://github.com/sheerapi/LeafEngine
```

## License
This project is under the [MIT license](https://choosealicense.com/licenses/mit/).
