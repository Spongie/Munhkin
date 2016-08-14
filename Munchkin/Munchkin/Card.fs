namespace Munchkin

type Card(name: string) =
    member this.Name = name

type TreasureCard(name: string) =
    inherit Card(name)

type DoorCard(name: string) =
    inherit Card(name)

type CurseCard(name: string) =
    inherit DoorCard(name)
        
type MonsterCard(name: string, level: int, minimumPlayerLevel: int, levelReward: int, treasureCount: int) =
    inherit DoorCard(name)  
        member this.Level = level
        member this.MinimumPlayerLevel = minimumPlayerLevel 
        member this.LevelReward = levelReward
        member this.TreasureCount = treasureCount
    