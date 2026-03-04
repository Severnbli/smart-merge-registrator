# Smart Merge Registrator

This repository contains an Unity Editor script that automatically registers Unity's built-in SmartMerge tool (UnityYAMLMerge.exe) as the Git merge driver for .unity YAML files. 
On first load (or when Unity version changes), it silently configures git merge.unityyamlmerge settings via command-line calls and adds menu items under Tools → Git for manual registration/unregistration. This enables proper 3-way merging of scenes, prefabs and other YAML assets instead of plain-text conflicts.

## Installation
Install via git url or by adding new entry in your **`manifest.json`**.
```json
{
  "dependencies": {
    "severnbli.smart-merge-registrator": "https://github.com/Severnbli/smart-merge-registrator.git#upm",
    ...
  }
}
```
