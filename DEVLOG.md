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