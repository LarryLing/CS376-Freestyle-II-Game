# Game Objects
1. Player (Purple Circle)
    - The player can move around, shoot zombies, interact with guns and upgrades, and take damage from zombies
    - The player can only take damage once every 1.5 seconds in order to prevent them from dying to quickly when in contact with the zombies.
2. Zombie (Green Circles)
    - There are three different zombie types: Normal, Speed, and Tank
    - All zombies will chase the player once they are within a certain range of the zombie. 
    - The three zombie types have varying stats in terms of movement speed, health, resistance, and damage.
3. Guns (Pistol, Automatic Rifle, Burst Rifle, Shotgun, Rail Gun)
    - The guns can be fired when the user holds down right click. Each gun has a certain amount of bullets that can be fire before they need to be reloaded. 
    - The guns are scattered throughout the map for the player to find.
    - The player must be close enough to the sprite to purchase the gun.
    - The Pistol, Automatic Rifle, and Rail Gun will fire single rounds once every given interval.
    - The Burst Rifle will fire three bullets in quick succession once every given interval.
    - The Shotgun will fire three bullets at once in a spread fashion once every given interval.
4. Large and Small Crates
    - Crates are scattered across the map.
    - They cannot be moved by the player and the zombie as they serve as a means for the player to make space between themselves and the zombies.
5. Upgrades (Speed Boost, Damage Boost, Health Boost, Resistance Boost)
    - An interaction with a upgrade will bring up a UI prompt. Choosing the upgrade a stat will cost the player money and an upgrade point. Choosing to downgrade a stat will only give the player back an upgrade point. 
    - The player must be close enough to the sprite to interact.
    - There are restrictions to the amount of upgrades and downgrades the player can perform. The minimum level for a stat is 0 while the maximum level for a stat is 3.

# Player Controls
1. Left Click (Fire1) on guns and upgrades to purchase/interact with them.
2. Right Click (Fire2) with a gun in hand to fire bullets.
3. WASD to move the player around.
4. Move the mouse around the screen to aim.

# Scoring
1. Every bullet that connects with a zombie will give the player 15 coins. The player can then use those coins to purchase guns and upgrades.
2. The number of waves, zombies killed, and coins collected will be tracked in the background and revealed to the player once the game terminates.

# Game Termination
1. The game will end when the player either dies before finishing all of the waves or when the player manages to survive all of the waves. 