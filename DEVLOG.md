# Devlog

## 11/15/2024 - Game Structure Planning
- `MovingEntity`
    - Attributes:
        - `Weapon currentWeapon`
        - `float currentHealth`
        - `float maxHealth`
        - `float movementSpeed`
        - `float resistance`
        - `float attackSpeed`
    - Methods:
        - `void Attack()`

- `Player` extends `MovingEntity`
    - Attributes:
        - `int coins`
        - `List<Upgrade> upgrades`
    - Methods:
        - `void TakeDamage(int damageTaken)`
        - `void Heal(int amountHealed)`

- `Zombie` extends `MovingEntity`
    - Static Attributes:
        - `int zombieCount`
    - Static Methods:
        - `static void IncreaseZombieCount(int increaseCount)`
        - `static void DecreaseZombieCount(int decreaseCount)`
    - Attributes:
        - `int coinValue`
    - Methods:
        - `void Die()`

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
- Create Game Sprites
    - Player Sprite
    - 3 Zombie Sprites
    - 5 Weapon Sprites
    - 4 Upgrade Sprites
    - 3 ObstacleSprites
- Setup Game Object hierarchies and initialize Components