# Description

Add the level of the soul contained in <u>purchased or looted soul gems</u>. This will not work 
with empty soul gems which were filled by trapping souls. This is due to the fact that the localization key for these gems is identical whether it's filled or not.

## Install

- Manually download [MagicLoader](https://www.nexusmods.com/oblivionremastered/mods/1966?tab=description) **2.4+** and extract it to:
    - Steam: `~\Oblivion Remastered\MagicLoader\`
    - GamePass: `~\The Elder Scrolls IV- Oblivion Remastered\Content\MagicLoader\`
- Download and extract your flavour of the mod
- Run* MagicLoader.exe* (version 2 will now start the game unless you create a shortcut and add -c as a parameter).
- Launch the game, if necessary depending on the previous step.

## Uninstall

- Delete `SoulGemsContent.json` from `~\OblivionRemastered_*\Content\Dev\ObvData\Data\MagicLoader\`
- Delete contents of: `\OblivionRemastered_*\Content\Paks\~mods\MagicLoader\`
- Run `MagicLoader.exe` if you have other mods that depend on it, skip this step if not.
- Launch the game, if necessary.

## Update
- Overwrite *SoulGemsContent.json* in `\OblivionRemastered_*\Content\Dev\ObvData\Data\MagicLoader\`
- Run `MagicLoader.exe`.
- Launch the game, if necessary.

## Compatibility
- The sorted variant will conflict with [Tools First - Inventory Sorting](https://www.nexusmods.com/oblivionremastered/mods/964) 
(hopefully only until they update to MagicLoader 2). Use the individual files except `ToolsFirst_SoulGems.json`.

## Notes
- You must re-run [MagicLoader](https://www.nexusmods.com/oblivionremastered/mods/1966?tab=description) **2.4+** if I send out any updates to apply them!
- Safe mid-playthrough, but ALWAYS make backups when adding new mods!
- Vortex should be able to put my mod in the correct place for you with the `install` button, but you still need to manually install [MagicLoader](https://www.nexusmods.com/oblivionremastered/mods/1966?tab=description) and inject the files after installing it.

## Credits
- GRUmod for the list of locations found in his UE4SS version [Quest Dungeons Marked (.ESPless)](https://www.nexusmods.com/oblivionremastered/mods/3560).
- RareMojo for the mod description I shamelessly copied from [Tools First - Inventory Sorting](https://www.nexusmods.com/oblivionremastered/mods/964) .

# Changelog
## Version 1.0.0
- First stable release
## Version 1.0.1
- Update the MagicLoaderGenerator library to version 1.2.1 to fix problems with the generated Zip archives
## Version 2.0.0
- Update for MagicLoader version 2
