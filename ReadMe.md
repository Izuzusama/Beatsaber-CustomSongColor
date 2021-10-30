# Custom Song Color

This plugin allows you to set custom color for each beatmap without changing the info.dat and changing the hash.

The logic of changing color is based on [SongCore's plugin CustomSongColorsPatch](https://github.com/Kylemc1413/SongCore/blob/master/HarmonyPatches/CustomSongColorsPatch.cs)

## Configuration
To configure it, create a file named `customColor.json` in your custom song directory. Example of the 2 song with custom color config
```
Beat Saber_Data
│
└───CustomLevels
    │
    └───80b0 (Pink Cloud - Dandyfloss)
        │   customColor.json
    └───2120 (OKAY - hexagonial)
        │   customColor.json
```

Example of `customColor.json` the name and value is following [songcore's Explanation](https://github.com/Kylemc1413/SongCore#infodat-explanation)
```json
{
    "_colorLeft": {
        "r": 0.013660844415416155,
        "g": 0,
        "b": 0.07069587707519531
    },
    "_colorRight": {
        "r": 0.0014191981941151946,
        "g": 0.14107830811467803,
        "b": 0.07064014358987808
    },
    "_envColorLeft": {
        "r": 0.013660844415416155,
        "g": 0,
        "b": 0.07069587707519531
    },
    "_envColorRight": {
        "r": 0.0014191981941151946,
        "g": 0.14107830811467803,
        "b": 0.07064014358987808
    },
    "_envColorLeftBoost": {
        "r": 0.013660844415416155,
        "g": 0,
        "b": 0.07069587707519531
    },
    "_envColorRightBoost": {
        "r": 0.0014191981941151946,
        "g": 0.14107830811467803,
        "b": 0.07064014358987808
    },
    "_obstacleColor": {
        "r": 1,
        "g": 0,
        "b": 0
    }
}
```