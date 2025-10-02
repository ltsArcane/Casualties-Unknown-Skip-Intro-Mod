# Forenote
I am, by no means, a professional game developer or modder, but even this mod was easy to make.  

This mod is made for the 4.0.1 version of Casualties: Unknown, which is currently the latest version on the game's [Itch page](https://orsonik.itch.io/scav-prototype). Make sure this is the version of the game you have before continuing.<br>
Downloadable [here](https://orsonik.itch.io/scav-prototype/download/eyJpZCI6MzIxNDQzOSwiZXhwaXJlcyI6MTc1ODgyMzQ4MX0%3d.bWj9Lv6KdmVaMJsIHZOA5Bqq0%2bg%3d) for free. Highly recommend you support the developer, or buy the game on Steam once it releases at the very least.

If you wish to see (what little) debugging happen, I recommend you set 2 of BepInEx's configs to be as such (both fall under the `[Logging.Console]`) section
```ini
Enabled = true
LogLevels = All
```
This is re-iterated with a picture in the installation guide file [here](INSTALLATION.md), so just double-check there if you aren't 100% sure.

# What This Mod Does
This mod forces *Casualties: Unknown* to skip the discretion warning, and to skip over the method that starts the intro scene for the game.

# How It Works (Technical Overview)
*This section is the optional "stats for nerds." Here for those curious about implementation details. Assumes you've already read "What This Mod Does".*

The mod starts off running a constant Update (similar to how Unity games work) that checks for the "Warning" GameObject, which is the discretion screen, and runs the onClick event on the button component of the object once found.
The mod also uses a [Harmony](https://github.com/pardeike/Harmony) patche to hook into *Casualties: Unknown*’s pre run script's methods and forces the "try lore" method to skip as soon as it is called.

### Why This Matters
This mod allows the user to skip through the 12 paragraph introduction.<br>
It's honestly not that bad, but when you're modding, you tend to see that scene multiple times during debugging sessions.

# Installation
For more in-depth installation instructions with images, see [INSTALLATION.md](INSTALLATION.md).
- Download [BepInEx](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.4), unpack in your game directory, remove non-core files if you wish.
- **Run the game once.** BepInEx needs to initialise some folders.
- Drag-and-drop the downloaded DLL file into `CasualtiesUnknown\BepInEx\plugins`.

# Footnote
This is probably the most I'm going to do, don't expect much else.
