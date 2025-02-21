# Pocket Editor Coroutines for Unity3D ![unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)

![stability-stable](https://img.shields.io/badge/stability-stable-green.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)

##

Simplified (50 lines of code) implementation of the [Editor Coroutines from Unity](https://docs.unity3d.com/Packages/com.unity.editorcoroutines@1.0/manual/index.html).
Use it if you need some compact solution and / or do not want to handle [this kind of issues](https://discussions.unity.com/t/cant-use-editor-coroutines-in-custom-pacakge/788791/4).

# Features

To skip a frame use standard:
```code
yield return 0;
yield return null;
```

To wait for seconds use:
```code
yield return 2f; // this will wait for 2 seconds
```

There is no support for WaitOperation etc.
There is no support for nested coroutines.

But it covers most cases of what is usually needed in Editor.

# How to use

Start Coroutine that way:
```code
PocketEditorCoroutine.Start(enumerator);
```
or that way
```code
PocketEditorCoroutine.Start(enumerator, this); // where 'this' might be EditorWindow which is used to detect when to stop the coroutine upon shutdown
```
you can also later stop coroutine by calling
```code
coroutine.Stop();
```

## Installation

You can just copy-paste [PocketEditorCoroutine.cs](./Editor/PocketEditorCoroutine.cs) to your project in any Editor folder.

## Contributions

Feel free to [report bugs, request new features](https://github.com/AlexeyPerov/Unity-Pocket-Editor-Coroutines/issues) 
or to [contribute](https://github.com/AlexeyPerov/Unity-Pocket-Editor-Coroutines/pulls) to this project! 

## Other tools

##### More extended version of Editor coroutines
See [Lite-Editor-Coroutines](https://github.com/AlexeyPerov/Unity-Lite-Editor-Coroutines).

##### Dependencies Hunter

To find unreferenced assets in Unity project see [Dependencies-Hunter](https://github.com/AlexeyPerov/Unity-Dependencies-Hunter).

##### Missing References Hunter

To find missing or empty references in your assets see [Missing-References-Hunter](https://github.com/AlexeyPerov/Unity-MissingReferences-Hunter).

##### Textures Hunter

To analyze your textures and atlases see [Textures-Hunter](https://github.com/AlexeyPerov/Unity-Textures-Hunter).
