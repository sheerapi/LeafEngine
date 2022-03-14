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
- Basic UI (Only text at the moment, working on more things dw)

## To-do
There's a "huge" list of things left yet, such as:
- Making the renderer so it can render more than 1 object at the same time / **Fixed**
- Stop the camera from flicking randomly / **Fixed, i think**
- Make the audio system more fluid / **Working on it**
- Physics system (Box2D for C#) / **Delayed**
- Resource loader and saver (Encrypting and Decrypting files) / **Finished (Removed encrypting)**

## FAQ
### When i try to play an .mp3 file it doesn't play
This is a extract from the [SFML](https://www.sfml-dev.org) docs.
> SFML supports the audio file formats WAV, OGG/Vorbis and FLAC. Due to licensing issues MP3 is **not supported**.
### Will this have an editor?
Yes, it's planned, but first, every bug needs to be solved, but dw, im working on it :)

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
