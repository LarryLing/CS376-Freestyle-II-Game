# Devlog

## 11/15/2024 - Game Structure Planning
- `IMovingEntity`
    - Attributes:
        - `Weapon currentWeapon`
        - `float currentHealth`
        - `float maxHealth`
        - `float movementSpeed`
        - `float resistance`
        - `float attackSpeed`
    - Methods:
        - `void Attack()`

- `Player` extends `IMovingEntity`
    - Attributes:
        - `int coins`
        - `List<Upgrade> upgrades`
    - Methods:
        - `void TakeDamage(int damageTaken)`
        - `void Heal(int amountHealed)`

- `IZombie` extends `IMovingEntity`
    - Static Attributes:
        - `int zombieCount`
    - Static Methods:
        - `static void IncreaseZombieCount(int increaseCount)`
        - `static void DecreaseZombieCount(int decreaseCount)`
    - Attributes:
        - `int coinValue`
    - Methods:
        - `void Die()`

- `NormalZombie` extends `IZombie`
- `SpeedZombie` extends `IZombie`
- `TankZombie` extends `IZombie`

- `IUpgrade`
    - Attributes:
        - `int cost`
        - `float traitMultiplierValue`
    - Methods:
        - `bool AddToUpgradesList`
        - `void IncreasePlayerTraitValue()`
        - `void ResetPlayerTraitValue()`

- `SpeedBoost` extends `IUpgrade`
- `ExtraResistance` extends `IUpgrade`
- `ExtraHealth` extends `IUpgrade`
- `QuickAttack` extends `IUpgrade`

- `IWeapon`
    - Attributes:
        - `float baseAttackSpeed`
        - `float damage`
    - Methods:
        - `void EquipWeapon()`
        - `void DequipWeapon()`

- `IMeleeWeapon` extends `IWeapon`
    - Attributes:
        - `float range`
    - Methods:

- `IRangedWeapon` extends `IWeapon`
    - Attributes:
        - `bool infiniteMagazine`
        - `int magazineSize`
        - `float reloadTime`
    - Methods:
        - `void ReloadWeapon()`

- `Pistol` extends `IRangedWeapon`
- `Rifle` extends `IRangedWeapon`
- `LongSword` extends `IMeleeWeapon`
- `Mace` extends `IMeleeWeapon`
- `Elder Gun` extends `IRangedWeapon`

## 11/16/2024 - Game Setup
- Created Game Sprites
    - Player Sprite
    - 3 Zombie Sprites
    - 5 Weapon Sprites
    - 4 Upgrade Sprites
    - 2 ObstacleSprites

- Setup Game Object hierarchies and initialize Components

- The interface `IZombie` has been removed in favor of the `Zombie` class. Each zombie type
will have use the `Zombie` class to initialize its traits.

- The interfaces `IRangedWeapon` and `IMeleeWeapon` will be removed in favor of `RangedWeapon` and `MeleeWeapon` classes.
Each ranged and melee weapon will use their respective classes to initialize their traits.

- Implemented player and camera movement.

- Implemented RangedWeapon firing, equipping, and dropping.

- Implemented GUI to show total number of coins, current health, current amount of ammo, zombies remaining, and upgrade points available.

- Replaced the `Quick Attack` upgrade to `Damage Boost` upgrade.

- Implemented `Speed Boost`, `Extra Resistance`, `Extra Health`, and `Damage Boost` upgrades to change `Player` traits.

## 11/17/2024 - UI and Gunplay
- When the player wants to purchase an upgrade, they can click on the sprite and a popup will appear.
On the popup, they can choose to either purchase an upgrade (which will expend an `Upgrade Point` and `Coins`) or
downgrade (which will only give them an `Upgrade Point` in return).
    - The downgrade system aims to push players towards making smarter purchase decisions throughout the game.
    - As of now, player can only max out on two of the four upgrades, given the number of upgrade points they are given 
    at the start of the game.
    - If an upgrade or downgrade actions cannot be completed, a warning text will show up on the bottom right of the screen.

- Upon opening of the UI, other game objects will no longer respond to clicks and user movement input will not be read. Once the user closes the UI, game object and movement input will return to normal function.

- Implemented sound effects for shooting, bullets hitting zombies, reloading, upgrading stats, and downgrading stats.

- Melee weapons will no longer be implemented in the game. Instead, there will be more variations of guns such as burst weapons and shotguns, each with their own firing sounds.

## 11/18/2024 - Enemy AI, Map Creation, and Zombie Waves
- The map will consist of a large rectangular boundary so that stray bullets will always be destroyed upon a collision. Throughout the map, there will be 6 different zombie
spawner points. The upgrades will also be spread out throughout the map. Crates of different sizes will also be placed throughout the map to serve as places for the player to take cover.

- The game will consist of 5 waves. The first wave will only consist of normal zombies. As the waves progress, the probability of speed and tank zombies will increase and the total number of zombies that will spawned in the wave
will increase. The percentages below will list out the probability of spawning each type of zombie during each wave (Normal/Speed/Tank).
    - Wave 1: 100%/0%/0%
    - Wave 2: 80%/10%/10%
    - Wave 3: 60%/20%/20%
    - Wave 4: 40%/30%/30%
    - Wave 5: 20%/40%/40%

- The end of each wave will grant the player a 30 second grace period where they can choose to buy new weapons or perform upgrades/downgrades. In addition, the player will be allowed to buy weapons and perform upgrades and downgrades during the wave. 
Although healing will not be provided during the wave, the end of each wave will bring the player back to full health.

- The player wins by surviving each wave.

- Zombies have a radius in which they can detect a player. One a player has been detected, the enemy will move towards that player until the player moves out of the detection radius.

- Implemented player damage system. The player will take damage as long as they are in contact with a zombie, however they have an invincibility period of 1.5 seconds so that their health does not drain 
too quickly.

- Zombies will now take a small amount of knockback upon taking damage.

- Implemented a game over screen that will display the number of zombies killed, the number of waves survived, and the an option to try again.

- Fixed a bug where the health bar was not scaling correctly when the player upgraded/downgraded their max health.

- Created map consisting of crates and scattered collectibles around the map.

- Tweaked player, collectibles, and zombie stats for balancing.

- Fixed a bug where diagonal player movement causes player to move faster. To compensate, the player's speed will be faster than that of a normal zombie.

- Instead of dedicated spawn points throughout the map for zombies, they will now spawn randomly throughout the map.

- Added win screen and warning text if playing tries to buy weapon without having enough money.